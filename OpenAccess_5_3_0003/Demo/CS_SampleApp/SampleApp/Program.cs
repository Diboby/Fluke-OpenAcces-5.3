using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace SampleApp {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
            try
            {
                //Handle unhandled exceptions here so that we get an email instead of them 
                //trying to send one to Microsoft.
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new OpenAccess_SampleApplicationForm());
            }
            catch (Exception e)
            {
                //System.ExecutionEngineException
                System.Diagnostics.Debug.WriteLine("Exception caught in application");
            }
		}



        /// <summary>
        /// Replaces the standard handling of unhandled exceptions in the application to gather information and 
        /// allow them to send a message to us.
        /// </summary>
        /// <param name="sender">Object that triggered the event</param>
        /// <param name="e">Event arguments from the sender</param>		
        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs tex)
        {
            System.Diagnostics.Debug.WriteLine("Exception caught in application");
        }
    }
}