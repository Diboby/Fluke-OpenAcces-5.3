using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Fluke.Thermography.IRAccess;
using Fluke.Thermography.LibSupport;

namespace SampleApp
{
    public partial class OpenAccess_SampleApplicationForm : Form
    {        
        bool updatingImage = false;
        Cursor cursor = new Cursor(Cursor.Current.Handle);
        private IRImg image = null;
        Fluke.Thermography.IRAccess.IRMovie movieObject;
        Fluke.Thermography.IRAccess.FrameMapEntry[] frameMap;


        public OpenAccess_SampleApplicationForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            DialogResult dr = fd.ShowDialog();
            switch (dr)
            {
                case DialogResult.OK:
                    LoadFile(fd.FileName);
                    break;
            }
        }

        private void LoadFile(string filename)
        {
            ClearState();
            IRFileExObject fo = new IRFileExObject();
            try
            {
                DateTime startPt = DateTime.Now;
                IRLoadable lo = fo.Load(filename, null, false);
                if (null != lo.MovieObject)
                {
                    // whoops, got a movie object and this application doesn't deal with them yet!
                    movieObject = lo.MovieObject as Fluke.Thermography.IRAccess.IRMovie;
                    frameMap = movieObject.GetFrameMap();
                    Size sz = new System.Drawing.Size(0, 0);
                    byte[] aviBytes = movieObject.GetMovieBlob(ref sz);
                    System.Diagnostics.Debug.WriteLine("Movie size is " + sz.Width + "x" + sz.Height);
                }
                else //if (null != lo.StillImage)
                {
                    var PictureTaken = (DateTime)lo.GetType().GetProperty("Timestamp").GetValue(lo, null);
                    image = lo as IRImg;
                    var emissivity = image.GetEmissivity();
                    
                }
                DateTime finishPt = DateTime.Now;
                TimeSpan ts = finishPt.Subtract(startPt);
                System.Diagnostics.Debug.WriteLine(ts.TotalMilliseconds.ToString("f1") + "ms to load file");
            }
            catch (Exception e)
            {
                image = null;
            }
            if (null == image)
            { 
                MessageBox.Show("Couldn't open file '" + filename + "'");
            }
            LoadSettingsForDisplay();
            DumpImageInformation();
            UpdateForm();
        }


        private void UpdateForm()
        {
            if (null != image)
            {
                if (!pictureBoxViewedImage.Visible)
                {
                    pictureBoxViewedImage.Visible = true;
                }
                UpdateFormStillFrame();
            }
            else if (null != movieObject)
            {
                if (pictureBoxViewedImage.Visible)
                {
                    pictureBoxViewedImage.Visible = false;
                }
            }
        }
        
        private void UpdateFormStillFrame()
        {
            updatingImage = true;
            if (null != image)
            {
                int width = 0;
                int height = 0;
                double newScale = 1.0;

                if (image.HasEmbeddedControlImage && image.PIPMode == true)
                {
                    width = image.CameraInfo.VLSensorSize.Width;
                    height = image.CameraInfo.VLSensorSize.Height;
                }
                else
                {
                    width = image.CameraInfo.IRSensorSize.Width;
                    height = image.CameraInfo.IRSensorSize.Height;
                }
               
                //if (cbVariableSizeScaling.Checked)
                //{
                //double widthScale = (double)this.pictureBoxViewedImage.Width / (double)width;
                //double heightScale = (double)this.pictureBoxViewedImage.Height / (double)height;
                //newScale = Math.Min(widthScale, heightScale);
                //}
                //else
                //{
                // find the biggest image size as a multiple of 160x120 we can accommodate in the picture box
                //while ((width * newScale * 2 < this.pictureBoxViewedImage.Width) &&
                //       (height * newScale * 2 < this.pictureBoxViewedImage.Height))
                //{
                //    newScale *= 2;
                //}
                //}
                width = -1; // (int)((double)width * newScale);
                height = -1; // (int)((double)height * newScale);

                Bitmap bmp;
                Rectangle irRectangleOnBitmap;
                if (image.HasEmbeddedControlImage)
                {
                    DateTime startPt = DateTime.Now;
                    //bmp = image.GetFusedBitmap(BITMAP_OBJECT_TYPE.NET_BITMAP, width, height, image.BlendingLevel) as Bitmap;
                    bmp = image.GetFusedBitmap(width, height, image.BlendingLevel, cbPIP.Checked,
                                                System.Drawing.Imaging.PixelFormat.Format32bppArgb,
                                                System.Drawing.Drawing2D.InterpolationMode.Default,
                                                System.Drawing.Drawing2D.InterpolationMode.Default) as Bitmap;

                    irRectangleOnBitmap = this.image.IRAreaLocationOnIRBitmap;
                    DateTime finishPt = DateTime.Now;
                    TimeSpan ts = finishPt.Subtract(startPt);
                    System.Diagnostics.Debug.WriteLine(ts.TotalMilliseconds.ToString("f1") + "ms to GetFusedBitmap()");

                }
                else
                {
                    bmp = image.GetIRBitmap(BITMAP_OBJECT_TYPE.NET_BITMAP, width, height) as Bitmap;
                    irRectangleOnBitmap = new Rectangle(0,0, width, height);
                }

                DrawMarkersOnBitmap(bmp, irRectangleOnBitmap);

                this.pictureBoxViewedImage.Image = bmp;
                this.pictureBoxViewedImage.SizeMode = PictureBoxSizeMode.Zoom;
                width = bmp.Width;
                height = bmp.Height;

                //if (null == pictureBoxPaletteScale.Image)
                {
                    bmp = image.Palette.GetPaletteBarBitmap(BITMAP_OBJECT_TYPE.NET_BITMAP, true,
                            Color.White, Color.White,
                            this.pictureBoxPaletteScale.Width,
                            this.pictureBoxPaletteScale.Height) as Bitmap;
                    pictureBoxPaletteScale.Image = bmp;
                }

                groupBoxTemp.Enabled = true;
            }
            updatingImage = false;
        }

        private RectangleF ConvertToImageSpace(RectangleF originalCoordinates, Size originalImageSize, Size newImageSize)
        {
            float l, t, w, h;
            l = originalCoordinates.Left;
            t = originalCoordinates.Top;
            w = originalCoordinates.Width;
            h = originalCoordinates.Height;
            l *= (float)newImageSize.Width / (float)originalImageSize.Width;
            t *= (float)newImageSize.Width / (float)originalImageSize.Width;
            w *= (float)newImageSize.Height / (float)originalImageSize.Height;
            h *= (float)newImageSize.Height / (float)originalImageSize.Height;

            return new RectangleF((float)Math.Round(l), (float)Math.Round(t), (float)Math.Round(w), (float)Math.Round(h));
        }

        private void DrawMarkersOnBitmap(Bitmap bmp, Rectangle irRectangleOnBitmap)
        {
            if (null != image)
            {
                if (!image.PIPMode || !image.HasEmbeddedControlImage)
                {
                    // 2010/6/14: For images having a control image, there is an error in 
                    // the library that returns an unhelpful result to the request
                    // for GetLocationOnIRImageBitmap() for each marker. 
                    // Fix should be forthcoming soon.
                    using (Graphics gr = Graphics.FromImage(bmp))
                    {
                        int i;
                        RectangleF r, newR;
                        r = Rectangle.Empty;
                        string s = string.Empty;
                        Size irBitmapSize = image.IRBitmapSize;
                        if (image.GetStdMarker(IR_MARKER_TYPE.STD_CENTER_POINT).Visible)
                        {
                            //s += "\nCenterpoint temperature: " +
                            //     image.GetStdMarker(IR_MARKER_TYPE.STD_CENTER_POINT).GetAvgTemp(TemperatureUnit.CELSIUS).ToString("f1");
                            r = image.GetStdMarker(IR_MARKER_TYPE.STD_CENTER_POINT).GetLocationOnIRImageBitmap();
                            newR = ConvertToImageSpace(r, irBitmapSize, irRectangleOnBitmap.Size);
                            gr.DrawRectangle(Pens.White, newR.Left, newR.Top, newR.Width, newR.Height);
                        }
                        try
                        {
                            IRMarker marker = image.GetStdMarker(IR_MARKER_TYPE.STD_CENTER_BOX);
                            if ((null != marker) &&
                                marker.Visible)
                            {
                                //double t = image.GetStdMarker(IR_MARKER_TYPE.STD_CENTER_BOX).GetAvgTemp(TemperatureUnit.CELSIUS);
                                r = image.GetStdMarker(IR_MARKER_TYPE.STD_CENTER_BOX).GetLocationOnIRImageBitmap();
                                newR = ConvertToImageSpace(r, irBitmapSize, irRectangleOnBitmap.Size);
                                gr.DrawRectangle(Pens.White, (int)newR.Left, (int)newR.Top, (int)newR.Width, (int)newR.Height);
                                //s += "\nCenterbox temperature: " +
                                //     image.GetStdMarker(IR_MARKER_TYPE.STD_CENTER_BOX).GetAvgTemp(TemperatureUnit.CELSIUS).ToString("f1");
                                r = image.GetStdMarker(IR_MARKER_TYPE.STD_CENTER_BOX).GetLocationOnIRImageBitmap();
                            }
                        }
                        catch { }

                        try
                        {
                            IRMarker marker = image.GetStdMarker(IR_MARKER_TYPE.STD_HOTTEST_POINT);
                            if ((null != marker) &&
                                marker.Visible)
                            {
                                //s += "\nHotpoint temperature: " +
                                //     image.GetStdMarker(IR_MARKER_TYPE.STD_HOTTEST_POINT).GetAvgTemp(TemperatureUnit.CELSIUS).ToString(
                                //         "f1");
                                r = image.GetStdMarker(IR_MARKER_TYPE.STD_HOTTEST_POINT).GetLocationOnIRImageBitmap();
                                newR = ConvertToImageSpace(r, irBitmapSize, irRectangleOnBitmap.Size);
                                gr.DrawRectangle(Pens.Red, newR.Left, newR.Top, newR.Width, newR.Height);
                            }
                        }
                        catch { }

                        try
                        {
                            IRMarker marker = image.GetStdMarker(IR_MARKER_TYPE.STD_COLDEST_POINT);
                            if ((null != marker) &&
                                marker.Visible)
                            {
                                //s += "\nColdpoint temperature: " +
                                //     image.GetStdMarker(IR_MARKER_TYPE.STD_COLDEST_POINT).GetAvgTemp(TemperatureUnit.CELSIUS).ToString(
                                //         "f1");
                                r = image.GetStdMarker(IR_MARKER_TYPE.STD_COLDEST_POINT).GetLocationOnIRImageBitmap();
                                newR = ConvertToImageSpace(r, irBitmapSize, irRectangleOnBitmap.Size);
                                gr.DrawRectangle(Pens.Blue, newR.Left, newR.Top, newR.Width, newR.Height);
                            }
                        }
                        catch { }

                        int markerCount;
                        markerCount = image.GetUserDefinedMarkerCount();
                        s += "\nAll user-defined marker count: " + markerCount;
                        for (i = 0; i < markerCount; i++)
                        {
                            IRMarker marker = image.GetUserDefinedMarkerByIndex(i);
                            if (marker.Visible)
                            {
                                string locationStr = string.Empty;
                                bool drawMarkerRectangle = false;
                                switch (marker.Type)
                                {
                                    case IR_MARKER_TYPE.LINE:
                                        {
                                            locationStr = "line under construction";
                                        }
                                        break;
                                    case IR_MARKER_TYPE.POINT:
                                    case IR_MARKER_TYPE.RECTANGLE:
                                    case IR_MARKER_TYPE.ELLIPSE:
                                        locationStr = marker.SensorLocation.ToString();
                                        r = marker.GetLocationOnIRImageBitmap();
                                        drawMarkerRectangle = true;
                                        break;
                                    case IR_MARKER_TYPE.POLYGON:
                                        locationStr = "polygon under construction";
                                        break;
                                }
                                if (drawMarkerRectangle)
                                {
                                    newR = ConvertToImageSpace(r, irBitmapSize, irRectangleOnBitmap.Size);
                                    gr.DrawRectangle(Pens.Gray, (int)newR.Left - 1, (int)newR.Top - 1, (int)newR.Width + 1, (int)newR.Height + 1);
                                    gr.DrawRectangle(Pens.White, (int)newR.Left, (int)newR.Top, (int)newR.Width, (int)newR.Height);
                                    gr.DrawRectangle(Pens.Gray, (int)newR.Left + 1, (int)newR.Top + 1, (int)newR.Width - 1, (int)newR.Height - 1);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void OpenAccess_SampleApplicationForm_Load(object sender, EventArgs e)
        {
            ClearState();
        }
        private void ClearState()
        {
            nudAlphaBlendingLevel.Enabled = false;

            cbPaletteScheme.Items.Clear();
            cbPaletteScheme.Enabled = false;
            cbUltraContrast.Enabled = false;
            cbPIP.Enabled = false;
            cbVariableSizeScaling.Enabled = false;

            nudPaletteMin.Enabled = false;
            nudPaletteMax.Enabled = false;
            nudPaletteLevel.Enabled = false;
            nudColorAlarmMin.Enabled = false;
            nudColorAlarmMax.Enabled = false;
            btnAutoscalePalette.Enabled = false;

            comboColorAlarmType.Items.Clear();
            comboColorAlarmType.Enabled = false;
            comboColorAlarmMode.Items.Clear();
            comboColorAlarmMode.Enabled = false;

            groupBoxTemp.Enabled = false;
        }

        private void DumpImageInformation()
        {
            if (null != image)
            {
                IRImageCommonAttributes ca = image as IRImageCommonAttributes;

                int i;
                rtbImageCharacteristics.Text = "";
                string s = string.Empty;
                
                IRMarker marker = null;


                s += "\nImage capture time: " + image.Timestamp.ToString();
                s += "\nCamera manufacturer: " + image.CameraInfo.CompanyName;
                s += "\nIR camera family: " + image.CameraInfo.IRCameraFamily.ToString();
                s += "\nIR camera model name: " + image.CameraInfo.ModelName.ToString();
                string tmpS = image.CameraInfo.SerialNumber.ToString();
                char[] trimChars = new char[] { '\0', '\r', '\n' };
                s += "\nCamera serial number: " + tmpS.Trim(trimChars);

                s += "\nCamera screen size: " + image.CameraInfo.IRCameraScreenSize.ToString();
                s += "\nIR sensor size: " + image.CameraInfo.IRSensorSize.ToString();
                s += "\nVL sensor size: " + image.CameraInfo.VLSensorSize.ToString();
                if (null != image.CameraInfo.IRImage)
                {
                    s += "\nCalibration range: " + image.CameraInfo.IRImage.GetCalibrationRangeMinTemp(TemperatureUnit.CELSIUS).ToString();
                    s += " to " + image.CameraInfo.IRImage.GetCalibrationRangeMaxTemp(TemperatureUnit.CELSIUS).ToString();
                    s += "\nDisplayable temperature range: " + image.CameraInfo.IRImage.GetDisplayRangeMinTemp(TemperatureUnit.CELSIUS).ToString();
                    s += " to " + image.CameraInfo.IRImage.GetDisplayRangeMaxTemp(TemperatureUnit.CELSIUS).ToString();
                }

                s += "\nIR lens description: " + image.CameraInfo.IRLensDescription.Trim(trimChars).ToString();
                s += "\nIR lens serial number: " + image.CameraInfo.IRLensSerialNumber.Trim(trimChars).ToString();
                s += "\nIR lens type: " + image.CameraInfo.IRLensType.ToString();

                s += "\nCamera GUI version: " + image.CameraInfo.OCASoftwareVersion.ToString();
                s += "\nCamera DSP version: " + image.CameraInfo.DSPSoftwareVersion.ToString();

                s += "\nEmissivity: " + image.GetEmissivity().ToString("f2");
                s += "\nBackground temperature: " + image.GetBackgroundTemp(TemperatureUnit.CELSIUS).ToString("f1");

                s += "\nPalette rendering: " + image.Palette.Settings.PaletteScheme.ToString();
                image.Palette.Settings.TempRange.TempUnits = TemperatureUnit.CELSIUS;
                s += "\nPalette range: " + image.Palette.Settings.TempRange.GetLowBoundaryTemp().ToString("f1");
                s += " to " + image.Palette.Settings.TempRange.GetHighBoundaryTemp().ToString("f1");

                s += "\nColor alarms enabled: " + image.Palette.IsColorAlarmsEnabled;
                if (null != image.Palette.ColorAlarmSettings)
                {
                    image.Palette.ColorAlarmSettings.TempRange.TempUnits = TemperatureUnit.CELSIUS;
                    s += "\nColor alarm range: " + image.Palette.ColorAlarmSettings.TempRange.GetLowBoundaryTemp().ToString("f1");
                    s += " to " + image.Palette.ColorAlarmSettings.TempRange.GetHighBoundaryTemp().ToString("f1");
                }

                s += "\nImage comments: " + ca.Comments;
                if (string.IsNullOrEmpty(ca.Comments))
                {
                    s += "<none>";
                }

                s += "\nCenterpoint temperature: " + image.GetStdMarker(IR_MARKER_TYPE.STD_CENTER_POINT).GetAvgTemp(TemperatureUnit.CELSIUS).ToString("f1");
                marker = image.GetStdMarker(IR_MARKER_TYPE.STD_CENTER_BOX);
                if (null != marker)
                {
                    double t = marker.GetAvgTemp(TemperatureUnit.CELSIUS);
                    s += "\nCenterbox location: " + marker.SensorLocation.ToString();
                    s += ", MinTemp=" + marker.GetMinTemp(TemperatureUnit.CELSIUS).ToString("f1");
                    s += ", AvgTemp=" + marker.GetAvgTemp(TemperatureUnit.CELSIUS).ToString("f1");
                    s += ", MaxTemp=" + marker.GetMaxTemp(TemperatureUnit.CELSIUS).ToString("f1");
                }
                marker = image.GetStdMarker(IR_MARKER_TYPE.STD_HOTTEST_POINT);
                if (null != marker)
                {
                    s += "\nHotpoint temperature: " + marker.GetAvgTemp(TemperatureUnit.CELSIUS).ToString("f1");
                }
                marker = image.GetStdMarker(IR_MARKER_TYPE.STD_COLDEST_POINT);
                if (null != marker)
                {
                    s += "\nColdpoint temperature: " + marker.GetAvgTemp(TemperatureUnit.CELSIUS).ToString("f1");
                }

                int markerCount;
                markerCount = image.GetUserDefinedMarkerCount();
                s += "\nAll user-defined marker count: " + markerCount;
                for (i = 0; i < markerCount; i++)
                {
                    marker = image.GetUserDefinedMarkerByIndex(i);
                    string locationStr = string.Empty;
                    switch (marker.Type)
                    {
                        case IR_MARKER_TYPE.LINE:
                            {
                                locationStr = "line under construction";
                            }
                            break;
                        case IR_MARKER_TYPE.POINT:
                        case IR_MARKER_TYPE.RECTANGLE:
                        case IR_MARKER_TYPE.ELLIPSE:
                            locationStr = marker.SensorLocation.ToString();
                            break;
                        case IR_MARKER_TYPE.POLYGON:
                            locationStr = "polygon under construction";
                            break;
                    }
                    s += "\n\tMarker " + i + ", type=" + marker.Type.ToString() + " (" + marker.Name + "): Location=" + locationStr;
                    s += ", MinTemp=" + marker.GetMinTemp(TemperatureUnit.CELSIUS).ToString("f1");
                    s += ", AvgTemp=" + marker.GetAvgTemp(TemperatureUnit.CELSIUS).ToString("f1");
                    s += ", MaxTemp=" + marker.GetMaxTemp(TemperatureUnit.CELSIUS).ToString("f1");

                    s += "\n\t\tAnnotations:";
                    
                    //for (int annIdx = 0; annIdx < marker.AnnotationsCount; annIdx++)
                    {
                        
                        //IRAnnotation annotation = marker.Annotations.GetAnnotationByIndex(annIdx);
                        //s += annotation
                    }
                }
                s += "\n\n";
                markerCount = image.GetMarkerCount(IR_MARKER_TYPE.POINT);
                s += "\nPoint marker count: " + markerCount;
                markerCount = image.GetMarkerCount(IR_MARKER_TYPE.LINE);
                s += "\nLine marker count: " + markerCount;
                markerCount = image.GetMarkerCount(IR_MARKER_TYPE.RECTANGLE);
                s += "\nRectangle marker count: " + markerCount;
                markerCount = image.GetMarkerCount(IR_MARKER_TYPE.ELLIPSE);
                s += "\nEllipse marker count: " + markerCount;
                markerCount = image.GetMarkerCount(IR_MARKER_TYPE.POLYGON);
                s += "\nPolygon marker count: " + markerCount;


                int aCount = ca.Annotations.AnnotationsCount;
                s += "\nAnnotations count: " + aCount;
                for (i = 0; i < aCount; i++)
                {
                    IRAnnotation ann = ca.Annotations.GetAnnotationByIndex(i);
                    s += "\n\tNote " + i + " name=" + ann.Name;
                    if (ann.AnnotationType == IR_ANNOTATION_TYPE.SINGLE_VALUE)
                    {
                        s += ", value='" + ann.GetFirstSelectedValue().Value + "'";
                    }
                    else
                    {
                        for (int j = 0; j < ann.ValuesCount; j++)
                        {
                            s += "\n\t\tvalue='" + ann.GetAnnotationValueByIndex(j).Value + "'";
                            if (ann.GetAnnotationValueByIndex(j).IsSelected)
                            {
                                s += " <selected>";
                            }
                        }
                    }
                }
                //LoadPaletteSchemeList();
                //nudAlphaBlendingLevel.Value = (decimal)image.BlendingLevel;
                //nudAlphaBlendingLevel.Enabled = true;

                //cbPIP.Checked = image.PIPMode;
                //cbPIP.Enabled = true;
                //cbVariableSizeScaling.Checked = true;
                //cbVariableSizeScaling.Enabled = true;

                //nudColorAlarmMax.Minimum = nudColorAlarmMin.Minimum = nudPaletteMin.Minimum = nudPaletteMax.Minimum = nudPaletteLevel.Minimum =
                //    (decimal)image.GetDisplayRangeMinTemp(TemperatureUnit.CELSIUS);
                //nudColorAlarmMax.Maximum = nudColorAlarmMin.Maximum = nudPaletteMin.Maximum = nudPaletteMax.Maximum = nudPaletteLevel.Maximum =
                //    (decimal)image.GetDisplayRangeMaxTemp(TemperatureUnit.CELSIUS);


                //UpdatePaletteRangeSettingsControls(true, true, true);
                //UpdateColorAlarmRangeSettingsControls(true, true);

                s += "\n";

                rtbImageCharacteristics.Text = s;
            }
        }

        private void LoadSettingsForDisplay()
        {
            if (null != image)
            {
                updatingControlValuesWithinHandler = true;
                LoadPaletteSchemeList();


                nudAlphaBlendingLevel.Value = (decimal)image.BlendingLevel;
                cbPIP.Checked = image.PIPMode;
                if (image.HasEmbeddedControlImage)
                {
                    nudAlphaBlendingLevel.Enabled = true;
                    cbPIP.Enabled = true;
                }
                cbVariableSizeScaling.Checked = true;
                cbVariableSizeScaling.Enabled = true;

                nudColorAlarmMax.Minimum = nudColorAlarmMin.Minimum = nudPaletteMin.Minimum = nudPaletteMax.Minimum = nudPaletteLevel.Minimum =
                    (decimal)image.GetDisplayRangeMinTemp(TemperatureUnit.CELSIUS);
                nudColorAlarmMax.Maximum = nudColorAlarmMin.Maximum = nudPaletteMin.Maximum = nudPaletteMax.Maximum = nudPaletteLevel.Maximum =
                    (decimal)image.GetDisplayRangeMaxTemp(TemperatureUnit.CELSIUS);


                //2012/12/8: exclude this for now
                UpdatePaletteRangeSettingsControls(true, true, true);
                //UpdateColorAlarmRangeSettingsControls(true, true);
                //updatingControlValuesWithinHandler = false;

                try
                {
                    IRMarker marker = image.GetStdMarker(IR_MARKER_TYPE.STD_CENTER_POINT);
                    if (null != marker)
                    {
                        cbCenterPoint.Checked = marker.Visible;
                    }
                }
                catch
                {
                    cbCenterPoint.Checked = false;
                    cbCenterPoint.Enabled = false;
                }
                try
                {
                    IRMarker marker = image.GetStdMarker(IR_MARKER_TYPE.STD_CENTER_BOX);
                    if (null != marker)
                    {
                        cbCenterBox.Checked = marker.Visible;
                    }
                }
                catch
                {
                    cbCenterBox.Checked = false;
                    cbCenterBox.Enabled = false;
                }
                try
                {
                    IRMarker marker = image.GetStdMarker(IR_MARKER_TYPE.STD_HOTTEST_POINT);
                    if (null != marker)
                    {
                        cbHotPoint.Checked = marker.Visible;
                    }
                }
                catch
                {
                    cbHotPoint.Checked = false;
                    cbHotPoint.Enabled = false;
                }
                try
                {
                    IRMarker marker = image.GetStdMarker(IR_MARKER_TYPE.STD_COLDEST_POINT);
                    if (null != marker)
                    {
                        cbColdPoint.Checked = marker.Visible;
                    }
                }
                catch
                {
                    cbColdPoint.Checked = false;
                    cbColdPoint.Enabled = false;
                }
            }
        }

        private void LoadPaletteSchemeList()
        {
            if (null != image)
            {
                cbPaletteScheme.Items.Clear();
                cbPaletteScheme.Enabled = true;
                for (int i = (int)IR_PALETTE.GRAYSCALE; i <= (int)IR_PALETTE.AMBER_INVERTED; i++)
                {
                    IR_PALETTE pal = (IR_PALETTE)i;
                    int index = cbPaletteScheme.Items.Add(pal.ToString());
                }
                for (int i = (int)IR_PALETTE.HIGH_CONTRAST_VT; i <= (int)IR_PALETTE.PALSCHEME_PHANTOM_SWVARIO; i++)
                {
                    IR_PALETTE pal = (IR_PALETTE)i;
                    int index = cbPaletteScheme.Items.Add(pal.ToString());
                }
                cbPaletteScheme.SelectedItem = (int)(image.Palette.Settings.PaletteScheme);

                comboColorAlarmType.Items.Clear();
                comboColorAlarmType.Items.Add("Off");
                comboColorAlarmType.Items.Add("Isotherm");
                comboColorAlarmType.Items.Add("Color Alarm");
                comboColorAlarmMode.Items.Clear();
                comboColorAlarmMode.Items.Add("Inside Range");
                comboColorAlarmMode.Items.Add("Outside Range");
                comboColorAlarmMode.Items.Add("Above Threshold");
                comboColorAlarmMode.Items.Add("Below Threshold");
                comboColorAlarmMode.Items.Add("Dewpoint");

                IRPaletteSettings2 pal2 = image.Palette.Settings as IRPaletteSettings2;
                if (null == pal2)
                {
                    cbUltraContrast.Enabled = false;
                }
                else
                {
                    cbUltraContrast.Enabled = pal2.IsUltraContrastModeSupported;
                    cbUltraContrast.Checked = pal2.UltraContrastMode;
                }


            }
        }

        private double GetCalibrationLimitedValue(double value)
        {
            double result = value;
            double dispMin, dispMax;
            dispMin = image.GetDisplayRangeMinTemp(TemperatureUnit.CELSIUS);
            dispMax = image.GetDisplayRangeMaxTemp(TemperatureUnit.CELSIUS);
            if (result < dispMin)
            {
                result = dispMin;
            }
            if (result > dispMax)
            {
                result = dispMax;
            }
            return result;
        }


        bool updatingControlValuesWithinHandler = false;
        private void UpdatePaletteRangeSettingsControls(bool updateMin, bool updateLevel, bool updateMax)
        {
            if (null != image)
            {
                DateTime startPt = DateTime.Now;

                updatingControlValuesWithinHandler = true;
                image.Palette.Settings.TempRange.TempUnits = TemperatureUnit.CELSIUS;
                double min = image.Palette.Settings.TempRange.GetLowBoundaryTemp();
                double max = image.Palette.Settings.TempRange.GetHighBoundaryTemp();

                min = GetCalibrationLimitedValue(min);
                max = GetCalibrationLimitedValue(max);
                if (updateMin)
                {
                    nudPaletteMin.Value = (decimal)min;
                }
                if (updateLevel)
                {
                    nudPaletteLevel.Value = (decimal)((min + max) / 2.0);
                }
                if (updateMax)
                {
                    nudPaletteMax.Value = (decimal)max;
                }

                nudPaletteMin.Enabled = true;
                nudPaletteMax.Enabled = true;
                nudPaletteLevel.Enabled = true;
                btnAutoscalePalette.Enabled = true;
                updatingControlValuesWithinHandler = false;
                DateTime finishPt = DateTime.Now;
                TimeSpan ts = finishPt.Subtract(startPt);
                System.Diagnostics.Debug.WriteLine(ts.TotalMilliseconds.ToString("f1") + "ms to UpdatePaletteRangeSettingsControls()");
            }
        }

        private void UpdateColorAlarmRangeSettingsControls(bool updateMin, bool updateMax)
        {
            if (null != image)
            {
                updatingControlValuesWithinHandler = true;
                if (image.HasEmbeddedControlImage)
                {
                    comboColorAlarmType.Enabled = true;
                }
                if (image.HasEmbeddedControlImage &&
                    (image.Palette.IsColorAlarmsEnabled ||
                    image.Palette.IsIsothermsEnabled))
                {
                    if (image.Palette.IsColorAlarmsEnabled)
                    {
                        comboColorAlarmType.SelectedIndex = 2;
                        comboColorAlarmMode.Enabled = true;
                        ColorAlarmRangeSelection alarmSelection = image.Palette.ColorAlarmSettings.TempRange.GetAlarmMode();
                        int selection = 0;
                        bool lowEnabled = false;
                        bool highEnabled = false;
                        switch (alarmSelection)
                        {
                            case ColorAlarmRangeSelection.AlarmAboveThreshold:
                                lowEnabled = true;
                                selection = 0;
                                break;
                            case ColorAlarmRangeSelection.AlarmBelowThreshold:
                                selection = 1;
                                highEnabled = true;
                                break;
                            case ColorAlarmRangeSelection.AlarmInsideRange:
                                selection = 2;
                                lowEnabled = highEnabled = true;
                                break;
                            case ColorAlarmRangeSelection.AlarmOutsideRange:
                                selection = 3;
                                lowEnabled = highEnabled = true;
                                break;
                            case ColorAlarmRangeSelection.AlarmDewPoint:
                                selection = 4;
                                highEnabled = true;
                                break;
                            default:
                                lowEnabled = highEnabled = false;
                                break;
                        }
                        comboColorAlarmMode.SelectedIndex = selection;
                        nudColorAlarmMin.Enabled = lowEnabled;
                        nudColorAlarmMax.Enabled = highEnabled;
                    }
                    else
                    {
                        if (image.Palette.IsIsothermsEnabled)
                        {
                            comboColorAlarmType.SelectedIndex = 1;
                            comboColorAlarmMode.SelectedIndex = 0;
                            comboColorAlarmMode.Enabled = true;
                            nudColorAlarmMin.Enabled = true;
                            nudColorAlarmMax.Enabled = true;
                        }
                    }

                    image.Palette.ColorAlarmSettings.TempRange.TempUnits = TemperatureUnit.CELSIUS;

                    double min = image.Palette.ColorAlarmSettings.TempRange.GetLowBoundaryTemp();
                    min = GetCalibrationLimitedValue(min);
                    double max = image.Palette.ColorAlarmSettings.TempRange.GetHighBoundaryTemp();
                    max = GetCalibrationLimitedValue(max);
                    if (updateMin)
                    {
                        nudColorAlarmMin.Value = (decimal)min;
                    }
                    if (updateMax)
                    {
                        nudColorAlarmMax.Value = (decimal)max;
                    }
                }
                else
                {
                    comboColorAlarmType.SelectedIndex = 0;
                    comboColorAlarmMode.Enabled = false;
                    comboColorAlarmMode.SelectedIndex = 0;
                    nudColorAlarmMin.Enabled = false;
                    nudColorAlarmMax.Enabled = false;
                    comboColorAlarmMode.Enabled = false;
                }
                updatingControlValuesWithinHandler = false;
            }
        }

        private void cbPaletteScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingControlValuesWithinHandler && (null != image))
            {
                IR_PALETTE newScheme = (IR_PALETTE)(cbPaletteScheme.SelectedIndex);
                if (image.Palette.Settings.PaletteScheme != newScheme)
                {
                    if (newScheme != IR_PALETTE.CUSTOM)
                    {
                        image.Palette.Settings.PaletteScheme = newScheme;
                        //pictureBoxPaletteScale.Image = null;
                        UpdateForm();
                    }
                }
            }
        }

        private void cbPIP_CheckedChanged(object sender, EventArgs e)
        {
            if (!updatingControlValuesWithinHandler && (null != image))
            {
                bool newSetting = cbPIP.Checked;
                if (image.PIPMode != newSetting)
                {
                    image.PIPMode = newSetting;
                    UpdateForm();
                }
            }
        }
        private void nudAlphaBlendingLevel_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingControlValuesWithinHandler && (null != image))
            {
                int newSetting = (int)nudAlphaBlendingLevel.Value;
                if (image.BlendingLevel != newSetting)
                {
                    image.BlendingLevel = newSetting;
                    UpdateForm();
                }
            }
        }

        private void cbVariableSizeScaling_CheckedChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void btnAutoscalePalette_Click(object sender, EventArgs e)
        {
            if (!updatingControlValuesWithinHandler && (null != image))
            {
                double newMin, newMax;
                newMin = image.GetStdMarker(IR_MARKER_TYPE.STD_COLDEST_POINT).GetAvgTemp(TemperatureUnit.CELSIUS);
                newMax = image.GetStdMarker(IR_MARKER_TYPE.STD_HOTTEST_POINT).GetAvgTemp(TemperatureUnit.CELSIUS);
                newMin = GetCalibrationLimitedValue(newMin);
                newMax = GetCalibrationLimitedValue(newMax);

                image.Palette.Settings.TempRange.SetLowBoundaryTemp(newMin);
                image.Palette.Settings.TempRange.SetHighBoundaryTemp(newMax);
                UpdatePaletteRangeSettingsControls(true, true, true);
                UpdateForm();
            }
        }

        private void nudPaletteLevel_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingControlValuesWithinHandler && (null != image))
            {
                image.Palette.Settings.AutoscaleMode = false;
                double newSetting = (double)nudPaletteLevel.Value;
                double oldSetting = (image.Palette.Settings.TempRange.GetLowBoundaryTemp() +
                                     image.Palette.Settings.TempRange.GetHighBoundaryTemp()) / 2.0;
                double delta = oldSetting - newSetting;
                if (delta != 0.0)
                {
                    double newMin, newMax;
                    newMin = GetCalibrationLimitedValue(image.Palette.Settings.TempRange.GetLowBoundaryTemp() + delta);
                    newMax = GetCalibrationLimitedValue(image.Palette.Settings.TempRange.GetHighBoundaryTemp() + delta);

                    image.Palette.Settings.TempRange.SetLowBoundaryTemp(newMin);
                    image.Palette.Settings.TempRange.SetHighBoundaryTemp(newMax);
                    UpdatePaletteRangeSettingsControls(true, true, true);
                    UpdateForm();
                }
            }
        }

        private void nudPaletteMin_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingControlValuesWithinHandler && (null != image))
            {
                image.Palette.Settings.AutoscaleMode = false;
                double newSetting = (double)nudPaletteMin.Value;
                newSetting = GetCalibrationLimitedValue(newSetting);
                if (image.Palette.Settings.TempRange.GetLowBoundaryTemp() != newSetting)
                {
                    image.Palette.Settings.TempRange.SetLowBoundaryTemp(newSetting);
                    UpdatePaletteRangeSettingsControls(true, true, false);
                    UpdateForm();
                }
            }
        }

        private void nudPaletteMax_ValueChanged(object sender, EventArgs e)
        {
            if (!updatingControlValuesWithinHandler && (null != image))
            {
                image.Palette.Settings.AutoscaleMode = false;
                double newSetting = (double)nudPaletteMax.Value;
                newSetting = GetCalibrationLimitedValue(newSetting);
                if (image.Palette.Settings.TempRange.GetHighBoundaryTemp() != newSetting)
                {
                    image.Palette.Settings.TempRange.SetHighBoundaryTemp(newSetting);
                    DateTime startPt = DateTime.Now;
                    UpdatePaletteRangeSettingsControls(false, true, true);
                    DateTime finishPt = DateTime.Now;
                    TimeSpan ts = finishPt.Subtract(startPt);
                    System.Diagnostics.Debug.WriteLine(ts.TotalMilliseconds.ToString("f1") + "ms to change palette setting");

                    UpdateForm();
                }
            }
        }

        private void nudColorAlarmMin_ValueChanged_1(object sender, EventArgs e)
        {
            if (!updatingControlValuesWithinHandler && (null != image))
            {
                double newSetting = (double)nudColorAlarmMin.Value;
                newSetting = GetCalibrationLimitedValue(newSetting);
                if (image.Palette.ColorAlarmSettings.TempRange.GetLowBoundaryTemp() != newSetting)
                {
                    image.Palette.ColorAlarmSettings.TempRange.SetLowBoundaryTemp(newSetting);
                    UpdateColorAlarmRangeSettingsControls(true, true);
                    UpdateForm();
                }
            }
        }

        private void nudColorAlarmMax_ValueChanged_1(object sender, EventArgs e)
        {
            if (!updatingControlValuesWithinHandler && (null != image))
            {
                double newSetting = (double)nudColorAlarmMax.Value;
                newSetting = GetCalibrationLimitedValue(newSetting);
                if (image.Palette.ColorAlarmSettings.TempRange.GetHighBoundaryTemp() != newSetting)
                {
                    DateTime startPt = DateTime.Now;
                    image.Palette.ColorAlarmSettings.TempRange.SetHighBoundaryTemp(newSetting);
                    DateTime finishPt = DateTime.Now;
                    TimeSpan ts = finishPt.Subtract(startPt);
                    System.Diagnostics.Debug.WriteLine(ts.TotalMilliseconds.ToString("f1") + "ms to change color alarm setting");
                    UpdateColorAlarmRangeSettingsControls(true, true);
                    UpdateForm();
                }
            }
        }

        private void comboColorAlarmType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingControlValuesWithinHandler && (null != image))
            {
                int selection = comboColorAlarmType.SelectedIndex;
                switch (selection)
                {
                    default:
                    case 0:
                        image.Palette.EnableColorAlarms(false);
                        image.Palette.EnableIsotherms(false);
                        break;
                    case 1:
                        image.Palette.EnableColorAlarms(false);
                        image.Palette.EnableIsotherms(true);
                        break;
                    case 2:
                        image.Palette.EnableColorAlarms(true);
                        image.Palette.EnableIsotherms(false);
                        break;
                }
                UpdateColorAlarmRangeSettingsControls(true, true);
                UpdateForm();
            }
        }

        private void comboColorAlarmMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingControlValuesWithinHandler && (null != image))
            {
                int selection = comboColorAlarmMode.SelectedIndex;
                switch (selection)
                {
                    case 0:
                        image.Palette.ColorAlarmSettings.TempRange.SetAlarmMode(ColorAlarmRangeSelection.AlarmAboveThreshold);
                        break;
                    case 1:
                        image.Palette.ColorAlarmSettings.TempRange.SetAlarmMode(ColorAlarmRangeSelection.AlarmBelowThreshold);
                        break;
                    case 2:
                        image.Palette.ColorAlarmSettings.TempRange.SetAlarmMode(ColorAlarmRangeSelection.AlarmInsideRange);
                        break;
                    case 3:
                        image.Palette.ColorAlarmSettings.TempRange.SetAlarmMode(ColorAlarmRangeSelection.AlarmOutsideRange);
                        break;
                    case 4:
                        image.Palette.ColorAlarmSettings.TempRange.SetAlarmMode(ColorAlarmRangeSelection.AlarmDewPoint);
                        break;
                }
                UpdateColorAlarmRangeSettingsControls(true, true);
                UpdateForm();
            }
        }

        private void cbUltraContrast_CheckedChanged(object sender, EventArgs e)
        {
            if (!updatingControlValuesWithinHandler && (null != image))
            {
                IRPaletteSettings2 pal2 = image.Palette.Settings as IRPaletteSettings2;
                if (null != pal2)
                {
                    pal2.UltraContrastMode = cbUltraContrast.Checked;
                    UpdateForm();
                }
            }
        }

        private void pictureBoxViewedImage_MouseMove(object sender, MouseEventArgs e)
        {
            if ((null != this.image) && 
                (this.updatingImage == false) &&
                (null != this.pictureBoxViewedImage.Image))
            {
                PictureBoxSizeMode sm = this.pictureBoxViewedImage.SizeMode;
                Size zoomedBmpSize = this.pictureBoxViewedImage.Size;
                Size srcBmpSize = this.pictureBoxViewedImage.Image.Size;
                float xfl, yfl;
                xfl = yfl = 0;
                int x = 0;
                int y = 0;
                switch (sm)
                {
                    case PictureBoxSizeMode.CenterImage:
                        xfl = (float)e.X / (float)this.pictureBoxViewedImage.Width;
                        yfl = (float)e.Y / (float)this.pictureBoxViewedImage.Height;
                        break;
                    case PictureBoxSizeMode.Zoom:
                        xfl = (float)e.X / (float)this.pictureBoxViewedImage.Width;
                        yfl = (float)e.Y / (float)this.pictureBoxViewedImage.Height;
                        break;
                    default:
                        break;
                }
                x = (int)(xfl * (float)this.pictureBoxViewedImage.Image.Size.Width);
                y = (int)(yfl * (float)this.pictureBoxViewedImage.Image.Size.Height);

                //Point bitmapPoint = TranslateMousePosition(new Point((int)(e.X), (int)(e.Y)), this.image.IRBitmapSize, this.pictureBoxViewedImage.Size);
                Rectangle irSectionOfBitmap = this.image.IRAreaLocationOnIRBitmap;

                Point bitmapPoint = TranslateMousePositionToBitmapPosition(new Point(e.X, e.Y), zoomedBmpSize, srcBmpSize);
                Size sensorSize = this.image.IRBitmapSize;
                string valueText = @"---";
                if (irSectionOfBitmap.Contains(bitmapPoint))
                {
                    Point[] pointsOnIRBitmap = new Point[1];
                    pointsOnIRBitmap[0] = bitmapPoint;
                    ulong convertedCount = image.MapIRBitmapPoints2IRSensorPoints(ref pointsOnIRBitmap, 1.0f /*(float)srcBmpSize.Width / (float)zoomedBmpSize.Width*/, cbPIP.Checked);
                    Point sensorPoint = pointsOnIRBitmap[0];
                    try
                    {
                        //valueText = image.GetIRImageBitmapTemp(sensorPoint.X, sensorPoint.Y, TemperatureUnit.CELSIUS).ToString();
                        valueText = image.GetIRSensorTemp(sensorPoint.X, sensorPoint.Y, TemperatureUnit.CELSIUS).ToString();

                    }
                    catch
                    {
                    }
                }
                this.labelTemp.Text = valueText;

                this.toolStripStatusLabelInfo.Text = String.Format(
                    "picbox({0},{1}) img({2},{3},{4},{5}) point({6},{7})",
                    this.pictureBoxViewedImage.Width,
                    this.pictureBoxViewedImage.Height,
                    irSectionOfBitmap.X,
                    irSectionOfBitmap.Y,
                    irSectionOfBitmap.Width,
                    irSectionOfBitmap.Height,
                    bitmapPoint.X,
                    bitmapPoint.Y);
            }
        }

        /// <summary>
        /// This method will translate the location of a mouse over a bitmap image inside a picture 
        /// box that is zoomed (and therefore also centered), clipping to the bounds of the image size.
        /// </summary>
        /// <param name="zoomedCoordinates">the cordinates on the container to map to the image</param>
        /// <param name="zoomedBitmapSize">the original container size to map from.</param>
        /// <param name="imageRect">within the overall image size, the IR image area to map to</param>
        /// <param name="origBitmapSize">the original image size to map to.</param>
        /// <returns>(-1,-1) if the mouse coordinate doesn't translate to a valid sensor position, a valid (x,y) sensor position otherwise</returns>
        private Point TranslateMousePositionToBitmapPosition(Point zoomedCoordinates, Size zoomedBitmapSize, Size origBitmapSize)
        {
            float newX = -1;
            float newY = -1;

            // compute the subregion of the zoomed bitmap that is part of the original bitmap region
            float activeLeft_f, activeTop_f, activeRight_f, activeBottom_f;
            float srcAspectRatio = (float)origBitmapSize.Width / (float)origBitmapSize.Height;
            float zoomedAspectRatio = (float)zoomedBitmapSize.Width / (float)zoomedBitmapSize.Height;

            if (srcAspectRatio < zoomedAspectRatio)
            {
                activeTop_f = 0;
                activeBottom_f = zoomedBitmapSize.Height;
                // the height is the limiting factor, so compute the left and right sides
                float activeWidth = zoomedBitmapSize.Height * srcAspectRatio;
                activeLeft_f = (zoomedBitmapSize.Width - activeWidth) / 2;
                activeRight_f = activeLeft_f + activeWidth;
            }
            else
            {
                activeLeft_f = 0;
                activeRight_f = zoomedBitmapSize.Width;
                // the height is the limiting factor, so compute the left and right sides
                float activeHeight = zoomedBitmapSize.Width / srcAspectRatio;
                activeTop_f = (zoomedBitmapSize.Height - activeHeight) / 2;
                activeBottom_f = activeTop_f + activeHeight;
            }

            Rectangle scaledImageRect = new Rectangle((int)activeLeft_f, (int)activeTop_f,
                                                        (int)(activeRight_f - activeLeft_f), (int)(activeBottom_f - activeTop_f));

            if (scaledImageRect.Contains(zoomedCoordinates))
            {

                // make sure that our width and height are not 0
                if (origBitmapSize.Width != 0 && origBitmapSize.Height != 0)
                {
                    float xfl, yfl;

                    xfl = (float)(zoomedCoordinates.X - scaledImageRect.Left) / (float)scaledImageRect.Width;
                    yfl = (float)(zoomedCoordinates.Y - scaledImageRect.Top) / (float)scaledImageRect.Height;

                    newX = (int)(xfl * origBitmapSize.Width);
                    newY = (int)(yfl * origBitmapSize.Height);
                }
            }
            
            return new Point((int)newX, (int)newY);
        }

        private void pictureBoxViewedImage_MouseLeave(object sender, EventArgs e)
        {
            this.labelTemp.Text = "---";

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.CheckFileExists = false;
            fd.CreatePrompt = true;
            fd.ValidateNames = true;
            DialogResult dr = fd.ShowDialog();
            switch (dr)
            {
                case DialogResult.OK:
                    SaveFile(fd.FileName);
                    break;
            }
        }

        private void SaveFile(string filename)
        {
            if (null != image)
            {
                try
                {
                    image.File.SaveAs(filename, null, false);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Unable to save file");
                }
            }

        }

        private void cbCenterPoint_CheckedChanged(object sender, EventArgs e)
        {
            IRMarker marker = image.GetStdMarker(IR_MARKER_TYPE.STD_CENTER_POINT);
            marker.Visible = cbCenterPoint.Checked;
            UpdateForm();
        }

        private void cbCenterBox_CheckedChanged(object sender, EventArgs e)
        {
            IRMarker marker = image.GetStdMarker(IR_MARKER_TYPE.STD_CENTER_BOX);
            marker.Visible = cbCenterBox.Checked;
            UpdateForm();
        }

        private void cbHotPoint_CheckedChanged(object sender, EventArgs e)
        {
            IRMarker marker = image.GetStdMarker(IR_MARKER_TYPE.STD_HOTTEST_POINT);
            marker.Visible = cbHotPoint.Checked;
            UpdateForm();
        }

        private void cbColdPoint_CheckedChanged(object sender, EventArgs e)
        {
            IRMarker marker = image.GetStdMarker(IR_MARKER_TYPE.STD_COLDEST_POINT);
            marker.Visible = cbColdPoint.Checked;
            UpdateForm();
        }

        private void exportIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double averageValue, stdDevValue;
            int minTempArrayIndex, maxTempArrayIndex;
            IDisposableDataBlock dataBlock = image.GetTempMapOfIRSensor3Ex(true, false, 
                new Rectangle(0, 0, image.IRBitmapSize.Width, image.IRBitmapSize.Height),
                image.GetEmissivity(), image.GetBackgroundTemp(TemperatureUnit.CELSIUS), TemperatureUnit.CELSIUS, 
                out averageValue, out stdDevValue, out minTempArrayIndex, out maxTempArrayIndex);

            double[,] result2D = ConvertTo2DArray_double(dataBlock);
            ((IDisposable)dataBlock).Dispose();

            const string separator = ",";

            StringBuilder sb = new StringBuilder();
            sb.Append(" " + separator);
            for (int i = 0; i < result2D.GetLength(0); i++)
            {
                sb.Append((i + 1) + " " + separator);
            }
            sb.AppendLine();


            for (int y=0; y < result2D.GetLength(1); y++)
            {
                sb.Append((y + 1) + separator);
                for (int x=0; x < result2D.GetLength(0); x++)
                {
                    sb.Append(Math.Round(result2D[x, y], 2) + " " + separator);
                }
                sb.AppendLine();
            }

            string tmpFilename = NewFileWithExtension(".txt");
            File.WriteAllText(tmpFilename, sb.ToString());

            System.Diagnostics.Process proc = new System.Diagnostics.Process();

            proc.StartInfo.FileName = "notepad.exe";
            proc.StartInfo.Arguments = tmpFilename;
            proc.EnableRaisingEvents = false;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.Start();

        }

        public static string NewFileWithExtension(string preferredFileExtension)
        {
            string tmpFilename = Path.GetTempFileName();
            string baseFilename = Path.GetDirectoryName(tmpFilename);
            string basePath = Path.GetFileNameWithoutExtension(tmpFilename);
            string newFilename = basePath + "." + preferredFileExtension;
            newFilename = Path.Combine(baseFilename, newFilename);
            return newFilename;
        }


        static public double[,] ConvertTo2DArray_double(IDisposableDataBlock db)
        {
            double[,] result = null;

            unsafe
            {
                int blockSizeBytes = db.GetBlockSizeBytes();
                Size dbBlockSize = db.GetAssociatedRectangle().Size;
                int w = dbBlockSize.Width;
                int h = dbBlockSize.Height;
                int index = 0;

                IntPtr ptr = db.GetDataPtrDirectCLI();
                int elemSizeBytes = db.GetElementSizeBytes();
                int elemCount = db.GetNumElements();
                if (elemCount > 0)
                {
                    result = new double[w, h];
                    switch (elemSizeBytes)
                    {
                        case 4:
                            {
                                float* elemPtr = (float*)ptr;
                                for (int r = 0; r < h; r++)
                                {
                                    for (int c = 0; c < w; c++)
                                    {
                                        result[c, r] = (double)elemPtr[index++];
                                    }
                                }
                            }
                            break;
                        case 8:
                            {
                                double* elemPtr = (double*)ptr;
                                for (int r = 0; r < h; r++)
                                {
                                    for (int c = 0; c < w; c++)
                                    {
                                        result[c, r] = elemPtr[index++];
                                    }
                                }
                            }
                            break;
                    }

                }
            }
            return result;
        }
    }
}