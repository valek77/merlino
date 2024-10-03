using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Merlino
{
    public partial class ThisAddIn
    {
        private MainForm mainForm; // Istanza del form

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
       
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
         
        }

        #region VSTO generated code

        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
