using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Excel = Microsoft.Office.Interop.Excel; 

namespace Merlino
{
    public partial class MainTaskPane : UserControl
    {
        public MainTaskPane()
        {
            InitializeComponent();
        }

        private void btnPulisci_Click(object sender, EventArgs e)
        {
            Excel.Worksheet ws = ExcelUtils.getActiveSheet();

            string[] firstCellArr = txtPrimaCella.Text.Split('$');
            string[] lastCellArr = txtUltimaCella.Text.Split('$');

            int firstColIndex = ExcelUtils.ColumnLetterToIndex(firstCellArr[1]);
            int lastColIndex = ExcelUtils.ColumnLetterToIndex(lastCellArr[1]);
            int numColUsed = lastColIndex - firstColIndex+1;


            int firstRowIndex = Convert.ToInt32(firstCellArr[2]);
            int lastRowIndex = Convert.ToInt32(lastCellArr[2]);


            string firstNewCol = ExcelUtils.GetColumNamePlusDelta(lastCellArr[1] ,numColUsed);


            ws.WriteToCell( firstNewCol+"1", "Ciao");

        }

        private void btnIndovinaCelle_Click(object sender, EventArgs e)
        {
            var cells = ExcelUtils.GuessFirstAndLastUsedCell();

            txtPrimaCella.Text = cells.firstCell.Address;
            txtUltimaCella.Text = cells.lastCell.Address;
        }
    }
}
