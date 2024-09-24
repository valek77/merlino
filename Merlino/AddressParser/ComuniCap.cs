using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace Merlino.AddressParser
{
    public class ComuniCap
    {
        // Dizionario che mappa CAP a lista di comuni
        private Dictionary<string, List<string>> capToComune = new Dictionary<string, List<string>>();

        // Dizionario che mappa Comune a CAP
        private Dictionary<string, string> comuneToCap = new Dictionary<string, string>();

        public ComuniCap(string filePath)
        {
            LoadData(filePath);
        }

        private void LoadData(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File non trovato: {filePath}");
            }

            // Impostiamo l'EPPlus per non utilizzare la licenza commerciale
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int lastRow = worksheet.Dimension.End.Row;

                for (int row = 2; row <= lastRow; row++)
                {
                    string comune = worksheet.Cells[row, 1].Text.Trim();
                    string cap = worksheet.Cells[row, 2].Text.Trim();

                    if (!string.IsNullOrEmpty(comune) && !string.IsNullOrEmpty(cap))
                    {
                        // Aggiungi al dizionario CAP -> Comuni
                        if (!capToComune.ContainsKey(cap))
                        {
                            capToComune[cap] = new List<string>();
                        }
                        capToComune[cap].Add(comune);

                        // Aggiungi al dizionario Comune -> CAP
                        if (!comuneToCap.ContainsKey(comune))
                        {
                            comuneToCap[comune] = cap;
                        }
                    }
                }

                Console.WriteLine("Dati comuni e CAP caricati con successo.");
            }
        }

        // Metodo per ottenere comuni per un dato CAP
        public List<string> GetComuniByCap(string cap)
        {
            if (capToComune.ContainsKey(cap))
            {
                return capToComune[cap];
            }
            return new List<string>();
        }

        // Metodo per ottenere CAP per un dato comune
        public string GetCapByComune(string comune)
        {
            if (comuneToCap.ContainsKey(comune))
            {
                return comuneToCap[comune];
            }
            return string.Empty;
        }

        // Metodo per ottenere tutti i comuni
        public List<string> GetAllComuni()
        {
            return new List<string>(comuneToCap.Keys);
        }
    }
}
