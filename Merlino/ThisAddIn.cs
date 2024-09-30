using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.IO;

namespace Merlino
{
    public partial class ThisAddIn
    {

        public static void WriteLog(string message)
        {
            string logFilePath = @"C:\tmp\MerlinoLog.txt";
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        private Microsoft.Office.Tools.CustomTaskPane taskPane;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            try
            {
           //     WriteLog("Init");
                MainTaskPane main = new MainTaskPane();

                taskPane = this.CustomTaskPanes.Add(main, "Merlino");
                taskPane.Visible = false;
          //      WriteLog("Plugin inzializzato");
            }
            catch (Exception ex) {
          //      WriteLog("Eccezione"+ ex.Message);
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
