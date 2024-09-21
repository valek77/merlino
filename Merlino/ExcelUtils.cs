using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows.Forms; // Per utilizzare MessageBox
using Excel = Microsoft.Office.Interop.Excel; // Per accedere alle API di Excel
using Microsoft.Office.Tools.Excel; // Per i tipi di dati specifici di Excel in VSTO
namespace Merlino
{
    internal class ExcelUtils
    {
        public static Excel.Worksheet getActiveSheet()
        {
            return (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
        }



        public static string ColumnIndexToLetter(int columnIndex)
        {
            string columnLetter = string.Empty;
            while (columnIndex > 0)
            {
                int mod = (columnIndex - 1) % 26;
                columnLetter = (char)(65 + mod) + columnLetter;
                columnIndex = (columnIndex - mod) / 26;
            }
            return columnLetter;
        }

        public static int ColumnLetterToIndex(string columnLetter)
        {
            int columnIndex = 0;
            int multiplier = 1;

            // Inizia dalla fine della stringa e scansiona ogni lettera
            for (int i = columnLetter.Length - 1; i >= 0; i--)
            {
                // Calcola l'indice della lettera attuale ('A' -> 1, 'B' -> 2, ..., 'Z' -> 26)
                int letterValue = columnLetter[i] - 'A' + 1;

                // Aggiorna l'indice della colonna considerando le lettere successive
                columnIndex += letterValue * multiplier;

                // Ogni nuova lettera ha un valore 26 volte maggiore (come nelle basi numeriche)
                multiplier *= 26;
            }

            return columnIndex;
        }



        public static string GetRowDataInFormat(Excel.Worksheet worksheet, int rowIndex)
        {
            StringBuilder result = new StringBuilder();

            // Ottieni l'intervallo di celle usate nel foglio
            Excel.Range usedRange = worksheet.UsedRange;

            // Scorri tutte le colonne usate
            for (int colIndex = 1; colIndex <= usedRange.Columns.Count; colIndex++)
            {
                // Ottieni il nome della colonna
                string columnName = ColumnIndexToLetter(colIndex);

                // Ottieni il valore della cella nella riga specificata
                Excel.Range cell = worksheet.Cells[rowIndex, colIndex];
                object cellValue = cell.Value2 ?? ""; // Usa una stringa vuota se la cella è vuota

                // Costruisci la stringa nel formato NomeColonna:ValoreColonna
                result.AppendFormat("{0}:{1};", columnName, cellValue);
            }

            // Rimuovi l'ultimo "; " e restituisci la stringa finale
            if (result.Length > 0)
            {
                result.Length -= 2; // Rimuove gli ultimi due caratteri "; "
            }

            return result.ToString();
        }

        public static string GetColumNamePlusDelta(string columnName,int delta=2)
        {
            // Ottieni il foglio attivo
            Excel.Worksheet activeWorksheet = (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet;

            int columnIndex = ColumnLetterToIndex(columnName.ToUpper());

            // Aggiungi 2 all'indice della colonna
            int newColumnIndex = columnIndex + delta;

            // Converti l'indice numerico di colonna in una lettera (esempio: 3 -> "C", 5 -> "E")
            string newColumnLetter = ColumnIndexToLetter(newColumnIndex);

            return newColumnLetter;
        }


        public static (Excel.Range firstCell, Excel.Range lastCell) GuessFirstAndLastUsedCell()
        {
            // Ottieni il foglio attivo
            Excel.Worksheet activeWorksheet = (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet;

            // Trova l'ultima cella usata usando SpecialCells
            Excel.Range lastUsedCell = activeWorksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);

            // Trova il range usato nel foglio, che include la prima e ultima cella usata
            Excel.Range usedRange = activeWorksheet.UsedRange;

            // La prima cella usata nel range (angolo in alto a sinistra)
            Excel.Range firstUsedCell = usedRange.Cells[2, 1];

            // L'ultima cella usata nel range (angolo in basso a destra)
            Excel.Range lastCellInUsedRange = usedRange.Cells[usedRange.Rows.Count, usedRange.Columns.Count];

            // Restituisci la prima e l'ultima cella usata
            return (firstUsedCell, lastUsedCell);
        }

    }
}
