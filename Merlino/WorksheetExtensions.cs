using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;

namespace Merlino
{
    public static class WorksheetExtensions
    {
   
        public static void WriteToCell(this Excel.Worksheet ws, string cellName, object value)
        {
            // Accedi alla cella specificata dal nome
            Excel.Range cell = ws.Range[cellName.ToUpper()];

            
            cell.NumberFormat = "@"; // Imposta il formato della cella su "Testo"

            // Scrivi il valore nella cella
            cell.Value2 = value;
        }




        public static object ReadFromCell(this Excel.Worksheet ws, string cellName)
        {
            // Accedi alla cella specificata dal nome (es. "A1")
            Excel.Range cell = ws.Range[cellName.ToUpper()];

            // Restituisci il valore della cella
            return cell.Value2;
        }




        public static void WriteToCell(this Excel.Worksheet ws, int rowIndex, int columnIndex, object value)
        {
            // Accedi alla cella specificata dagli indici di riga e colonna
            try
            {
                Excel.Range cell = (Excel.Range)ws.Cells[rowIndex, columnIndex];

                
                cell.NumberFormat = "@"; // Imposta il formato della cella su "Testo"

                // Scrivi il valore nella cella
                cell.Value2 = value;
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
        }

        // Extension method per leggere il valore di una cella utilizzando indici di riga e colonna
        public static object ReadFromCell(this Excel.Worksheet ws, int rowIndex, int columnIndex)
        {
            // Accedi alla cella specificata dagli indici di riga e colonna
            Excel.Range cell = (Excel.Range)ws.Cells[rowIndex, columnIndex];

            // Restituisci il valore della cella
            return cell.Value2;
        }





        public static void DeleteRow(this Excel.Worksheet ws, int rowNum)
        {
            // Accedi alla cella specificata dal nome (es. "A1")
            Excel.Range row = ws.Rows[rowNum];

            row.Delete();
        }






        public static void ScrollToRow(this Excel.Worksheet worksheet, int rowIndex)
        {
            // Imposta la riga corrente come la prima riga visibile
            worksheet.Application.ActiveWindow.ScrollRow = rowIndex;
        }



        public static void ScrollToRowCentered(this Excel.Worksheet worksheet, int rowIndex)
        {
            // Ottieni l'oggetto ActiveWindow che rappresenta la finestra attiva di Excel
            Excel.Window activeWindow = worksheet.Application.ActiveWindow;

            // Ottieni il numero di righe visibili nella finestra corrente
            int visibleRows = activeWindow.VisibleRange.Rows.Count;

            // Calcola la riga da scorrere per centrare la riga desiderata
            int scrollRow = rowIndex - (visibleRows / 2);

            // Assicurati che la riga di scorrimento non sia inferiore a 1 (inizio del foglio)
            if (scrollRow < 1)
            {
                scrollRow = 1;
            }

            // Imposta la riga calcolata come la riga di scorrimento
            activeWindow.ScrollRow = scrollRow;
        }
    }
}

