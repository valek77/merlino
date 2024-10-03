using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Merlino
{
    public partial class RibbonMenu
    {
        private Microsoft.Office.Tools.CustomTaskPane myTaskPane;

        
        private void RibbonMenu_Load(object sender, RibbonUIEventArgs e)
        {
         
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            MainForm mf = new MainForm();

            mf.ShowDialog();
        }

        private void brtnOpzioni_Click(object sender, RibbonControlEventArgs e)
        {
            FormSettings form = new FormSettings();

            form.ShowDialog();
        }

        private void btnFilter_Click(object sender, RibbonControlEventArgs e)
        {

            DialogResult result = MessageBox.Show("I numeri di telefono devono trovarsi nella colonna <<B>> ! Vuoi procedere ?",
                 "Conferma eliminazione",  // Titolo della finestra
                 MessageBoxButtons.YesNo,  // Tipo di pulsanti (Yes e No)
                 MessageBoxIcon.Warning    // Icona di avviso
             );

            // Se l'utente conferma, procedi con l'eliminazione
            if (result == DialogResult.Yes)
            {
                FubRemover fubRemover = new FubRemover();

                fubRemover.CleanSheet(); 
            }
        }
    }
}
