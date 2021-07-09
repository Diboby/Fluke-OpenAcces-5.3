namespace SampleApp {
	partial class OpenAccess_SampleApplicationForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxViewedImage = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxTemp = new System.Windows.Forms.GroupBox();
            this.labelTemp = new System.Windows.Forms.Label();
            this.groupBoxPaletteMode = new System.Windows.Forms.GroupBox();
            this.cbUltraContrast = new System.Windows.Forms.CheckBox();
            this.cbPaletteScheme = new System.Windows.Forms.ComboBox();
            this.cbPIP = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAutoscalePalette = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboColorAlarmMode = new System.Windows.Forms.ComboBox();
            this.comboColorAlarmType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudColorAlarmMax = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudColorAlarmMin = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudPaletteMax = new System.Windows.Forms.NumericUpDown();
            this.nudPaletteLevel = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudPaletteMin = new System.Windows.Forms.NumericUpDown();
            this.nudAlphaBlendingLevel = new System.Windows.Forms.NumericUpDown();
            this.cbVariableSizeScaling = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxPaletteScale = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cbColdPoint = new System.Windows.Forms.CheckBox();
            this.cbHotPoint = new System.Windows.Forms.CheckBox();
            this.cbCenterBox = new System.Windows.Forms.CheckBox();
            this.cbCenterPoint = new System.Windows.Forms.CheckBox();
            this.rtbImageCharacteristics = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.exportIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxTemp.SuspendLayout();
            this.groupBoxPaletteMode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudColorAlarmMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColorAlarmMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaletteMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaletteLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaletteMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlphaBlendingLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaletteScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1640, 46);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportIRToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(72, 38);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.exitToolStripMenuItem.Text = "Quit";
            // 
            // pictureBoxViewedImage
            // 
            this.pictureBoxViewedImage.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxViewedImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxViewedImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxViewedImage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBoxViewedImage.Name = "pictureBoxViewedImage";
            this.pictureBoxViewedImage.Size = new System.Drawing.Size(1160, 721);
            this.pictureBoxViewedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxViewedImage.TabIndex = 1;
            this.pictureBoxViewedImage.TabStop = false;
            this.pictureBoxViewedImage.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            this.pictureBoxViewedImage.MouseLeave += new System.EventHandler(this.pictureBoxViewedImage_MouseLeave);
            this.pictureBoxViewedImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxViewedImage_MouseMove);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 46);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxTemp);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxPaletteMode);
            this.splitContainer1.Panel1.Controls.Add(this.cbPIP);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.nudAlphaBlendingLevel);
            this.splitContainer1.Panel1.Controls.Add(this.cbVariableSizeScaling);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBoxPaletteScale);
            this.splitContainer1.Panel1MinSize = 236;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1640, 1083);
            this.splitContainer1.SplitterDistance = 472;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBoxTemp
            // 
            this.groupBoxTemp.Controls.Add(this.labelTemp);
            this.groupBoxTemp.Location = new System.Drawing.Point(26, 994);
            this.groupBoxTemp.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBoxTemp.Name = "groupBoxTemp";
            this.groupBoxTemp.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBoxTemp.Size = new System.Drawing.Size(342, 81);
            this.groupBoxTemp.TabIndex = 24;
            this.groupBoxTemp.TabStop = false;
            this.groupBoxTemp.Text = "Temp (C)";
            // 
            // labelTemp
            // 
            this.labelTemp.AutoSize = true;
            this.labelTemp.Location = new System.Drawing.Point(24, 38);
            this.labelTemp.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTemp.Name = "labelTemp";
            this.labelTemp.Size = new System.Drawing.Size(33, 25);
            this.labelTemp.TabIndex = 0;
            this.labelTemp.Text = "---";
            // 
            // groupBoxPaletteMode
            // 
            this.groupBoxPaletteMode.Controls.Add(this.cbUltraContrast);
            this.groupBoxPaletteMode.Controls.Add(this.cbPaletteScheme);
            this.groupBoxPaletteMode.Location = new System.Drawing.Point(32, 187);
            this.groupBoxPaletteMode.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBoxPaletteMode.Name = "groupBoxPaletteMode";
            this.groupBoxPaletteMode.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBoxPaletteMode.Size = new System.Drawing.Size(386, 146);
            this.groupBoxPaletteMode.TabIndex = 23;
            this.groupBoxPaletteMode.TabStop = false;
            this.groupBoxPaletteMode.Text = "Palette Mode";
            // 
            // cbUltraContrast
            // 
            this.cbUltraContrast.AutoSize = true;
            this.cbUltraContrast.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbUltraContrast.Location = new System.Drawing.Point(100, 96);
            this.cbUltraContrast.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbUltraContrast.Name = "cbUltraContrast";
            this.cbUltraContrast.Size = new System.Drawing.Size(170, 29);
            this.cbUltraContrast.TabIndex = 23;
            this.cbUltraContrast.Text = "UltraContrast";
            this.cbUltraContrast.UseVisualStyleBackColor = true;
            this.cbUltraContrast.CheckedChanged += new System.EventHandler(this.cbUltraContrast_CheckedChanged);
            // 
            // cbPaletteScheme
            // 
            this.cbPaletteScheme.FormattingEnabled = true;
            this.cbPaletteScheme.Location = new System.Drawing.Point(24, 37);
            this.cbPaletteScheme.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbPaletteScheme.Name = "cbPaletteScheme";
            this.cbPaletteScheme.Size = new System.Drawing.Size(334, 33);
            this.cbPaletteScheme.TabIndex = 18;
            this.cbPaletteScheme.SelectedIndexChanged += new System.EventHandler(this.cbPaletteScheme_SelectedIndexChanged);
            // 
            // cbPIP
            // 
            this.cbPIP.AutoSize = true;
            this.cbPIP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbPIP.Location = new System.Drawing.Point(220, 94);
            this.cbPIP.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbPIP.Name = "cbPIP";
            this.cbPIP.Size = new System.Drawing.Size(77, 29);
            this.cbPIP.TabIndex = 22;
            this.cbPIP.Text = "PIP";
            this.cbPIP.UseVisualStyleBackColor = true;
            this.cbPIP.CheckedChanged += new System.EventHandler(this.cbPIP_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAutoscalePalette);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nudPaletteMax);
            this.groupBox1.Controls.Add(this.nudPaletteLevel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudPaletteMin);
            this.groupBox1.Location = new System.Drawing.Point(32, 371);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(336, 610);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Palette Range";
            // 
            // btnAutoscalePalette
            // 
            this.btnAutoscalePalette.Location = new System.Drawing.Point(160, 204);
            this.btnAutoscalePalette.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAutoscalePalette.Name = "btnAutoscalePalette";
            this.btnAutoscalePalette.Size = new System.Drawing.Size(150, 44);
            this.btnAutoscalePalette.TabIndex = 19;
            this.btnAutoscalePalette.Text = "Autoscale";
            this.btnAutoscalePalette.UseVisualStyleBackColor = true;
            this.btnAutoscalePalette.Click += new System.EventHandler(this.btnAutoscalePalette_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboColorAlarmMode);
            this.groupBox2.Controls.Add(this.comboColorAlarmType);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nudColorAlarmMax);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.nudColorAlarmMin);
            this.groupBox2.Location = new System.Drawing.Point(38, 265);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Size = new System.Drawing.Size(286, 340);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Color Alarm";
            // 
            // comboColorAlarmMode
            // 
            this.comboColorAlarmMode.FormattingEnabled = true;
            this.comboColorAlarmMode.Location = new System.Drawing.Point(52, 110);
            this.comboColorAlarmMode.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboColorAlarmMode.Name = "comboColorAlarmMode";
            this.comboColorAlarmMode.Size = new System.Drawing.Size(216, 33);
            this.comboColorAlarmMode.TabIndex = 22;
            this.comboColorAlarmMode.SelectedIndexChanged += new System.EventHandler(this.comboColorAlarmMode_SelectedIndexChanged);
            // 
            // comboColorAlarmType
            // 
            this.comboColorAlarmType.FormattingEnabled = true;
            this.comboColorAlarmType.Location = new System.Drawing.Point(52, 37);
            this.comboColorAlarmType.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboColorAlarmType.Name = "comboColorAlarmType";
            this.comboColorAlarmType.Size = new System.Drawing.Size(216, 33);
            this.comboColorAlarmType.TabIndex = 21;
            this.comboColorAlarmType.SelectedIndexChanged += new System.EventHandler(this.comboColorAlarmType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(46, 219);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 44);
            this.label6.TabIndex = 19;
            this.label6.Text = "Max";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudColorAlarmMax
            // 
            this.nudColorAlarmMax.DecimalPlaces = 1;
            this.nudColorAlarmMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudColorAlarmMax.Location = new System.Drawing.Point(146, 225);
            this.nudColorAlarmMax.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nudColorAlarmMax.Name = "nudColorAlarmMax";
            this.nudColorAlarmMax.Size = new System.Drawing.Size(126, 31);
            this.nudColorAlarmMax.TabIndex = 14;
            this.nudColorAlarmMax.ValueChanged += new System.EventHandler(this.nudColorAlarmMax_ValueChanged_1);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(46, 269);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 44);
            this.label7.TabIndex = 20;
            this.label7.Text = "Min";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudColorAlarmMin
            // 
            this.nudColorAlarmMin.DecimalPlaces = 1;
            this.nudColorAlarmMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudColorAlarmMin.Location = new System.Drawing.Point(146, 275);
            this.nudColorAlarmMin.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nudColorAlarmMin.Name = "nudColorAlarmMin";
            this.nudColorAlarmMin.Size = new System.Drawing.Size(126, 31);
            this.nudColorAlarmMin.TabIndex = 16;
            this.nudColorAlarmMin.ValueChanged += new System.EventHandler(this.nudColorAlarmMin_ValueChanged_1);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(88, 94);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 44);
            this.label5.TabIndex = 13;
            this.label5.Text = "Level";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudPaletteMax
            // 
            this.nudPaletteMax.DecimalPlaces = 1;
            this.nudPaletteMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudPaletteMax.Location = new System.Drawing.Point(188, 46);
            this.nudPaletteMax.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nudPaletteMax.Name = "nudPaletteMax";
            this.nudPaletteMax.Size = new System.Drawing.Size(126, 31);
            this.nudPaletteMax.TabIndex = 8;
            this.nudPaletteMax.ValueChanged += new System.EventHandler(this.nudPaletteMax_ValueChanged);
            // 
            // nudPaletteLevel
            // 
            this.nudPaletteLevel.DecimalPlaces = 1;
            this.nudPaletteLevel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudPaletteLevel.Location = new System.Drawing.Point(188, 100);
            this.nudPaletteLevel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nudPaletteLevel.Name = "nudPaletteLevel";
            this.nudPaletteLevel.Size = new System.Drawing.Size(126, 31);
            this.nudPaletteLevel.TabIndex = 12;
            this.nudPaletteLevel.ValueChanged += new System.EventHandler(this.nudPaletteLevel_ValueChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(88, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 44);
            this.label3.TabIndex = 9;
            this.label3.Text = "Max";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(88, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 44);
            this.label4.TabIndex = 11;
            this.label4.Text = "Min";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudPaletteMin
            // 
            this.nudPaletteMin.DecimalPlaces = 1;
            this.nudPaletteMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudPaletteMin.Location = new System.Drawing.Point(188, 154);
            this.nudPaletteMin.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nudPaletteMin.Name = "nudPaletteMin";
            this.nudPaletteMin.Size = new System.Drawing.Size(126, 31);
            this.nudPaletteMin.TabIndex = 10;
            this.nudPaletteMin.ValueChanged += new System.EventHandler(this.nudPaletteMin_ValueChanged);
            // 
            // nudAlphaBlendingLevel
            // 
            this.nudAlphaBlendingLevel.Location = new System.Drawing.Point(208, 15);
            this.nudAlphaBlendingLevel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nudAlphaBlendingLevel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudAlphaBlendingLevel.Name = "nudAlphaBlendingLevel";
            this.nudAlphaBlendingLevel.Size = new System.Drawing.Size(126, 31);
            this.nudAlphaBlendingLevel.TabIndex = 16;
            this.nudAlphaBlendingLevel.ValueChanged += new System.EventHandler(this.nudAlphaBlendingLevel_ValueChanged);
            // 
            // cbVariableSizeScaling
            // 
            this.cbVariableSizeScaling.AutoSize = true;
            this.cbVariableSizeScaling.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbVariableSizeScaling.Location = new System.Drawing.Point(56, 138);
            this.cbVariableSizeScaling.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbVariableSizeScaling.Name = "cbVariableSizeScaling";
            this.cbVariableSizeScaling.Size = new System.Drawing.Size(248, 29);
            this.cbVariableSizeScaling.TabIndex = 20;
            this.cbVariableSizeScaling.Text = "Variable Size Scaling";
            this.cbVariableSizeScaling.UseVisualStyleBackColor = true;
            this.cbVariableSizeScaling.CheckedChanged += new System.EventHandler(this.cbVariableSizeScaling_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 37);
            this.label1.TabIndex = 17;
            this.label1.Text = "IR-Fusion® Level";
            // 
            // pictureBoxPaletteScale
            // 
            this.pictureBoxPaletteScale.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxPaletteScale.Location = new System.Drawing.Point(430, 15);
            this.pictureBoxPaletteScale.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBoxPaletteScale.Name = "pictureBoxPaletteScale";
            this.pictureBoxPaletteScale.Size = new System.Drawing.Size(36, 1040);
            this.pictureBoxPaletteScale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxPaletteScale.TabIndex = 15;
            this.pictureBoxPaletteScale.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureBoxViewedImage);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1160, 1083);
            this.splitContainer2.SplitterDistance = 721;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 2;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.cbColdPoint);
            this.splitContainer3.Panel1.Controls.Add(this.cbHotPoint);
            this.splitContainer3.Panel1.Controls.Add(this.cbCenterBox);
            this.splitContainer3.Panel1.Controls.Add(this.cbCenterPoint);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.rtbImageCharacteristics);
            this.splitContainer3.Size = new System.Drawing.Size(1160, 354);
            this.splitContainer3.SplitterDistance = 55;
            this.splitContainer3.SplitterWidth = 8;
            this.splitContainer3.TabIndex = 1;
            // 
            // cbColdPoint
            // 
            this.cbColdPoint.AutoSize = true;
            this.cbColdPoint.Location = new System.Drawing.Point(472, 17);
            this.cbColdPoint.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbColdPoint.Name = "cbColdPoint";
            this.cbColdPoint.Size = new System.Drawing.Size(88, 29);
            this.cbColdPoint.TabIndex = 3;
            this.cbColdPoint.Text = "Cold";
            this.cbColdPoint.UseVisualStyleBackColor = true;
            this.cbColdPoint.CheckedChanged += new System.EventHandler(this.cbColdPoint_CheckedChanged);
            // 
            // cbHotPoint
            // 
            this.cbHotPoint.AutoSize = true;
            this.cbHotPoint.Location = new System.Drawing.Point(336, 17);
            this.cbHotPoint.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbHotPoint.Name = "cbHotPoint";
            this.cbHotPoint.Size = new System.Drawing.Size(77, 29);
            this.cbHotPoint.TabIndex = 2;
            this.cbHotPoint.Text = "Hot";
            this.cbHotPoint.UseVisualStyleBackColor = true;
            this.cbHotPoint.CheckedChanged += new System.EventHandler(this.cbHotPoint_CheckedChanged);
            // 
            // cbCenterBox
            // 
            this.cbCenterBox.AutoSize = true;
            this.cbCenterBox.Location = new System.Drawing.Point(198, 17);
            this.cbCenterBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbCenterBox.Name = "cbCenterBox";
            this.cbCenterBox.Size = new System.Drawing.Size(73, 29);
            this.cbCenterBox.TabIndex = 1;
            this.cbCenterBox.Text = "CB";
            this.cbCenterBox.UseVisualStyleBackColor = true;
            this.cbCenterBox.CheckedChanged += new System.EventHandler(this.cbCenterBox_CheckedChanged);
            // 
            // cbCenterPoint
            // 
            this.cbCenterPoint.AutoSize = true;
            this.cbCenterPoint.Location = new System.Drawing.Point(54, 17);
            this.cbCenterPoint.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbCenterPoint.Name = "cbCenterPoint";
            this.cbCenterPoint.Size = new System.Drawing.Size(73, 29);
            this.cbCenterPoint.TabIndex = 0;
            this.cbCenterPoint.Text = "CP";
            this.cbCenterPoint.UseVisualStyleBackColor = true;
            this.cbCenterPoint.CheckedChanged += new System.EventHandler(this.cbCenterPoint_CheckedChanged);
            // 
            // rtbImageCharacteristics
            // 
            this.rtbImageCharacteristics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbImageCharacteristics.Location = new System.Drawing.Point(0, 0);
            this.rtbImageCharacteristics.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rtbImageCharacteristics.Name = "rtbImageCharacteristics";
            this.rtbImageCharacteristics.Size = new System.Drawing.Size(1160, 291);
            this.rtbImageCharacteristics.TabIndex = 0;
            this.rtbImageCharacteristics.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1129);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1640, 42);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelInfo
            // 
            this.toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            this.toolStripStatusLabelInfo.Size = new System.Drawing.Size(238, 32);
            this.toolStripStatusLabelInfo.Text = "toolStripStatusLabel1";
            // 
            // exportIRToolStripMenuItem
            // 
            this.exportIRToolStripMenuItem.Name = "exportIRToolStripMenuItem";
            this.exportIRToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.exportIRToolStripMenuItem.Text = "Export IR...";
            this.exportIRToolStripMenuItem.Click += new System.EventHandler(this.exportIRToolStripMenuItem_Click);
            // 
            // OpenAccess_SampleApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1640, 1171);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "OpenAccess_SampleApplicationForm";
            this.Text = "OpenAccess Sample Application";
            this.Load += new System.EventHandler(this.OpenAccess_SampleApplicationForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewedImage)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxTemp.ResumeLayout(false);
            this.groupBoxTemp.PerformLayout();
            this.groupBoxPaletteMode.ResumeLayout(false);
            this.groupBoxPaletteMode.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudColorAlarmMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColorAlarmMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaletteMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaletteLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaletteMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlphaBlendingLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaletteScale)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.PictureBox pictureBoxViewedImage;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboColorAlarmMode;
        private System.Windows.Forms.ComboBox comboColorAlarmType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudColorAlarmMax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudColorAlarmMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudPaletteMax;
        private System.Windows.Forms.NumericUpDown nudPaletteLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudPaletteMin;
        private System.Windows.Forms.NumericUpDown nudAlphaBlendingLevel;
        private System.Windows.Forms.CheckBox cbVariableSizeScaling;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPaletteScheme;
        private System.Windows.Forms.PictureBox pictureBoxPaletteScale;
        private System.Windows.Forms.CheckBox cbPIP;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox rtbImageCharacteristics;
        private System.Windows.Forms.Button btnAutoscalePalette;
        private System.Windows.Forms.GroupBox groupBoxPaletteMode;
        private System.Windows.Forms.CheckBox cbUltraContrast;
        private System.Windows.Forms.GroupBox groupBoxTemp;
        private System.Windows.Forms.Label labelTemp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfo;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.CheckBox cbCenterPoint;
        private System.Windows.Forms.CheckBox cbCenterBox;
        private System.Windows.Forms.CheckBox cbHotPoint;
        private System.Windows.Forms.CheckBox cbColdPoint;
        private System.Windows.Forms.ToolStripMenuItem exportIRToolStripMenuItem;
    }
}

