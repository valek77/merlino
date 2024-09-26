using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Merlino
{
    public class FubRemover
    {
        private BPGClient bpg;


        public FubRemover()
        {
            bpg = new BPGClient();

        }


        public async void CleanSheet()
        {
            Excel.Worksheet ws = ExcelUtils.getActiveSheet();
            ws.WriteToCell("D1", "In connessione a BlackPhoneGuard");
            var token = await bpg.Login();
            ws.WriteToCell("D1", "Connesso. Attendere prego");
            //ws.DeleteRow(2);
            var cells = ExcelUtils.GuessFirstAndLastUsedCell();
            string[] lastCellArr = cells.lastCell.Address.Split('$');
            int lastRowIndex = Convert.ToInt32(lastCellArr[2]);

            List<string> toBeDeleted = new List<string>();


            FilterInput filterInput = new FilterInput();
            for (int row = 2; row <= lastRowIndex; row++)
            {
                NumberRow numberRow = new NumberRow();
                numberRow.row = "" + row;
                numberRow.number = ws.ReadFromCell("B" + row).ToString();
                filterInput.number_list.Add(numberRow);

                if (row % 1000 == 0)
                {
                    List<string> resp = await bpg.FilterNumbers(filterInput);
                    toBeDeleted.AddRange(resp);
                    filterInput = new FilterInput();
                    ws.WriteToCell("D1", "Trovate " + toBeDeleted.Count + " righe da cancellare");
                }

            }

            if (filterInput.number_list.Count > 0) {
                List<string> resp = await bpg.FilterNumbers(filterInput);
                toBeDeleted.AddRange(resp);
                ws.WriteToCell("D1", "Trovate " + toBeDeleted.Count + " righe da cancellare");
            }

            var toBeDeletedInt = toBeDeleted.Select(x=>Convert.ToInt32(x)).OrderByDescending(x=>x).ToList();


            foreach (var rowNumber in toBeDeletedInt) { 
                ws.DeleteRow(rowNumber);
            }

            bpg.Logout();

            MessageBox.Show("Cancellate " + toBeDeleted.Count() + " righe");

        }

    }
}
