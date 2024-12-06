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
            try
            {
                ws.WriteToCell("D1", "In connessione a BlackPhoneGuard");
                var token = await bpg.Login();
                ws.WriteToCell("D1", "Connesso. Attendere prego");
            }
            catch (Exception ex) {
                ws.WriteToCell("D1", ex.Message);
                return;
            }
            
            var cells = ExcelUtils.GuessFirstAndLastUsedCell();
            string[] lastCellArr = cells.lastCell.Address.Split('$');
            int lastRowIndex = Convert.ToInt32(lastCellArr[2]);

            List<string> toBeDeleted = new List<string>();


            FilterInput filterInput = new FilterInput();
            int row = 0;
            for ( row = 2; row <= lastRowIndex; row++)
            {
                NumberRow numberRow = new NumberRow();
                numberRow.row = "" + row;

                if (row % 100 == 0)
                    ws.WriteToCell("E1", "Lette " + row + " righe");


              var cell = ws.ReadFromCell("B" + row);
                if (cell == null) {
                    List<string> resp = await bpg.FilterNumbers(filterInput);
                    toBeDeleted.AddRange(resp);
                    filterInput = new FilterInput();
                    ws.WriteToCell("D1", "Trovate " + toBeDeleted.Count + " righe da cancellare su " + row + " righe eleborate");
                    break;
                }

                numberRow.number = ws.ReadFromCell("B" + row).ToString();
                filterInput.number_list.Add(numberRow);

                if (row % 5000 == 0)
                {
                    List<string> resp = await bpg.FilterNumbers(filterInput);
                    toBeDeleted.AddRange(resp);
                    filterInput = new FilterInput();
                    ws.WriteToCell("D1", "Trovate " + toBeDeleted.Count + " righe da cancellare su "+row+" righe eleborate");
                }

            }

            if (filterInput.number_list.Count > 0) {
                List<string> resp = await bpg.FilterNumbers(filterInput);
                toBeDeleted.AddRange(resp);
                ws.WriteToCell("D1", "Trovate " + toBeDeleted.Count + " righe da cancellare su " + row + " righe eleborate");
            }

            var toBeDeletedInt = toBeDeleted.Select(x=>Convert.ToInt32(x)).OrderByDescending(x=>x).ToList();


            //foreach (var rowNumber in toBeDeletedInt) {
            int totRows = toBeDeletedInt.Count;
           for (int i = 0; i<totRows;i++)
            {
                int rowNumber = toBeDeletedInt.ElementAt(i);
                ws.DeleteRow(rowNumber);

                if (i % 10 == 0) {
                    ws.WriteToCell("D1", "Cancellate " + i + " righe  su " + totRows + " righe");
                }
            }
            MessageBox.Show("Cancellate " + toBeDeleted.Count() + " righe");

           // bpg.Logout();

            

        }

    }
}
