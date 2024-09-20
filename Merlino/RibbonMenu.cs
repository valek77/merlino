using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merlino
{
    public partial class RibbonMenu
    {
        private Microsoft.Office.Tools.CustomTaskPane myTaskPane;
        private void RibbonMenu_Load(object sender, RibbonUIEventArgs e)
        {
            myTaskPane = Globals.ThisAddIn.CustomTaskPanes[0];
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            if (myTaskPane != null)
            {
                // Controlla se il Task Pane è chiuso
                if (!myTaskPane.Visible)
                {
                    // Riapri il Task Pane
                    myTaskPane.Visible = true;
                }
            }
        }
    }
}
