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
            Excel.Range cell = ws.Range[cellName];

            // Scrivi il valore nella cella
            cell.Value2 = value;
        }




        public static object ReadFromCell(this Excel.Worksheet ws, string cellName)
        {
            // Accedi alla cella specificata dal nome (es. "A1")
            Excel.Range cell = ws.Range[cellName];

            // Restituisci il valore della cella
            return cell.Value2;
        }




        public static void WriteToCell(this Excel.Worksheet ws, int rowIndex, int columnIndex, object value)
        {
            // Accedi alla cella specificata dagli indici di riga e colonna
            Excel.Range cell = (Excel.Range)ws.Cells[rowIndex, columnIndex];

            // Scrivi il valore nella cella
            cell.Value2 = value;
        }

        // Extension method per leggere il valore di una cella utilizzando indici di riga e colonna
        public static object ReadFromCell(this Excel.Worksheet ws, int rowIndex, int columnIndex)
        {
            // Accedi alla cella specificata dagli indici di riga e colonna
            Excel.Range cell = (Excel.Range)ws.Cells[rowIndex, columnIndex];

            // Restituisci il valore della cella
            return cell.Value2;
        }
    }
}
