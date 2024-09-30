using Merlino.AddressParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Excel = Microsoft.Office.Interop.Excel;

namespace Merlino
{
    public partial class MainTaskPane : UserControl
    {

        Preferences preferences;
        private OllamaClient ollama;
      

        private ComuniCap comuniCap;
        private AddressParser.AddressParser addressParser;



        public MainTaskPane()
        {
            InitializeComponent();
            preferences = Preferences.LoadPreferences();

            ollama = new OllamaClient(preferences.OllamaUrl, "gemma2");

        

            addressParser = new AddressParser.AddressParser();
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "comuni_cap.xlsx");
            comuniCap = new ComuniCap(filePath);


        }



        public static string CorreggiNumeroTelefono(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                return "Errore";

            // Verifica se il numero contiene caratteri non numerici
            if (Regex.IsMatch(numero, @"[^\d\s]")) // Verifica che ci siano solo numeri e spazi
            {
                return "Errore"; // Se trova un carattere non numerico, restituisci "Errore"
            }

            // Rimuovi eventuali spazi o caratteri non numerici
            numero = Regex.Replace(numero, @"\D", "");

            // Verifica se il numero inizia con "3"
            if (numero.StartsWith("3"))
            {
                // Verifica le eccezioni per i prefissi 335, 330, 306 e 368
                if (numero.StartsWith("335") || numero.StartsWith("330") || numero.StartsWith("306") || numero.StartsWith("368"))
                {
                    if (numero.Length == 9 || numero.Length == 10)
                    {
                        return numero; // Numero valido con 6 o 7 cifre dopo il prefisso
                    }
                    else
                    {
                        return "Errore";
                    }
                }
                // Verifica il caso generale per i numeri che iniziano con "3" (7 cifre dopo)
                else if (numero.Length == 10)
                {
                    return numero; // Numero valido con 7 cifre dopo il prefisso
                }
                else
                {
                    return "Errore"; // Numero con lunghezza non valida
                }
            }
            if (numero.StartsWith("0"))
            {
                return numero;
            }
            // Se non inizia con "3", consideralo un numero fisso e aggiungi lo "0"
            else
            {
                return "0" + numero; // Aggiungi lo "0" iniziale
            }

        }




        private async void btnPulisci_Click(object sender, EventArgs e)
        {
            Excel.Worksheet ws = ExcelUtils.getActiveSheet();

            // Prendiamo la prima e l'ultima cella per determinare l'area di lavoro
            string[] firstCellArr = txtPrimaCella.Text.Split('$');
            string[] lastCellArr = txtUltimaCella.Text.Split('$');

            // Calcoliamo gli indici di riga corretti
            int firstRowIndex = Convert.ToInt32(firstCellArr[2]);
            int lastRowIndex = Convert.ToInt32(lastCellArr[2]);

            // Calcoliamo gli indici di colonna dinamicamente dai textbox
            int nomeCognomeColIndex = !string.IsNullOrEmpty(txtNomeCognome.Text) ? ExcelUtils.ColumnLetterToIndex(txtNomeCognome.Text) : -1;
            int nomeColIndex = !string.IsNullOrEmpty(txtNome.Text) ? ExcelUtils.ColumnLetterToIndex(txtNome.Text) : -1;
            int cognomeColIndex = !string.IsNullOrEmpty(txtCognome.Text) ? ExcelUtils.ColumnLetterToIndex(txtCognome.Text) : -1;
            int numeroColIndex = !string.IsNullOrEmpty(txtNumero.Text) ? ExcelUtils.ColumnLetterToIndex(txtNumero.Text) : -1;
            int indirizzoColIndex = !string.IsNullOrEmpty(txtIndirizzo.Text) ? ExcelUtils.ColumnLetterToIndex(txtIndirizzo.Text) : -1;
            int comuneColIndex = !string.IsNullOrEmpty(txtComune.Text) ? ExcelUtils.ColumnLetterToIndex(txtComune.Text) : -1;
            int capColIndex = !string.IsNullOrEmpty(txtCap.Text) ? ExcelUtils.ColumnLetterToIndex(txtCap.Text) : -1;

            // Nuova colonna di scrittura
            string firstNewCol = ExcelUtils.GetColumNamePlusDelta(lastCellArr[1], 2);
            int firstNewColIndex = ExcelUtils.ColumnLetterToIndex(firstNewCol);

            Cursor.Current = Cursors.WaitCursor;

            int batchSize = 30; // Scriviamo ogni 30 righe
            List<Task> tasks = new List<Task>();

            // Matrice temporanea per i dati elaborati
            object[,] processedData = new object[batchSize, 3]; // Tre colonne per NomeCognome, Numero, Comune

            int batchRowStart = firstRowIndex;

            // Iniziamo il cronometro
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int r = firstRowIndex; r <= lastRowIndex; r++)
            {
                int currentBatchIndex = (r - firstRowIndex) % batchSize; // Indicizza all'interno del batch

                string nomeCognome = "", nome = "", cognome = "", numero = "", indirizzo = "", comune = "";

                // Verifica condizionale basata sugli indici di colonna
                if (nomeCognomeColIndex != -1)
                {
                    nomeCognome = ws.Cells[r, nomeCognomeColIndex]?.Value2?.ToString().ToUpper();
                }

                if (nomeColIndex != -1 && cognomeColIndex != -1)
                {
                    nome = ws.Cells[r, nomeColIndex]?.Value2?.ToString();
                    cognome = ws.Cells[r, cognomeColIndex]?.Value2?.ToString();
                }

                if (numeroColIndex != -1)
                {
                    numero = ws.Cells[r, numeroColIndex]?.Value2?.ToString();
                    numero = CorreggiNumeroTelefono(numero);
                }

                if (indirizzoColIndex != -1)
                {
                    indirizzo = ws.Cells[r, indirizzoColIndex]?.Value2?.ToString();
                    // Elaborazione asincrona del comune
                    if (!string.IsNullOrEmpty(indirizzo))
                    {
                        comune = addressParser.getComuneFromIndirizzo(indirizzo);

                        if (chkIA.Checked &&  comune == "")
                        {
                            comune = await indovinaComuneDaIndirizzo(indirizzo);
                        }
                    }
                }

                if (comuneColIndex != -1) { 
                    comune = ws.Cells[r, comuneColIndex]?.Value2?.ToString().ToUpper();

                    if (comune == null) comune = "";
                }


                if ((capColIndex!=-1))
                {
                    var cap  = ws.Cells[r, capColIndex]?.Value2?.ToString();

                    List<string> comuni =  comuniCap.GetComuniByCap(cap);

                    if (comuni != null && comuni.Count > 0) {
                        comune = comuni[0];
                    }
                }



                // Scrittura nei dati processati per il batch
                processedData[currentBatchIndex, 0] = !string.IsNullOrEmpty(nomeCognome) ? nomeCognome : (nome + " " + cognome)?.ToUpper();
                processedData[currentBatchIndex, 1] = numero;
                processedData[currentBatchIndex, 2] = comune.ToUpper();

                // Quando raggiungiamo il batch size o l'ultima riga, scriviamo il batch
                if (currentBatchIndex == batchSize - 1 || r == lastRowIndex)
                {
                    int rowsInBatch = currentBatchIndex + 1; // Quante righe ci sono nel batch attuale

                    // Scriviamo il batch di righe su Excel
                    Excel.Range destinationRange = ws.Range[ws.Cells[batchRowStart, firstNewColIndex], ws.Cells[batchRowStart + rowsInBatch - 1, firstNewColIndex + 2]];
                    object[,] batchData = new object[rowsInBatch, 3];

                    // Copiamo i dati nel batch corrente
                    Array.Copy(processedData, batchData, rowsInBatch * 3);

                    destinationRange.Value2 = batchData;

                    // Aggiorniamo il batchRowStart per il prossimo batch
                    batchRowStart = r + 1;

                    // Reset della matrice temporanea
                    processedData = new object[batchSize, 3];

                    ws.ScrollToRowCentered(r);
                }
            }

            // Fermiamo il cronometro
            stopwatch.Stop();

            // Calcoliamo il tempo totale e medio
            TimeSpan elapsedTime = stopwatch.Elapsed;
            double averageTimePerRow = elapsedTime.TotalSeconds / (lastRowIndex - firstRowIndex + 1);

            // Formattiamo il tempo in ore:minuti:secondi
            string formattedElapsedTime = string.Format("{0:D2}:{1:D2}:{2:D2}",
                elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds);

            // Mostra un messaggio con il tempo totale e medio per riga
            MessageBox.Show($"Elaborazione completata.\nDurata totale: {formattedElapsedTime}\nTempo medio per riga: {averageTimePerRow:F2} secondi", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Cursor.Current = Cursors.Default;
        }







        private async Task<string> indovinaComuneDaIndirizzo(string indirizzo)
        {
            string msg = "A partire da questo indirizzo riesci a capire di quale comune si tratta? Rispondi con il solo comune, senza aggiungere altro.\n" + indirizzo;
            ApiResponse result = await ollama.SendMessages(msg);
            return result.message.Content.Trim();
        }



        private async void btnIndovinaCelle_Click(object sender, EventArgs e)
        {
            Excel.Worksheet ws = ExcelUtils.getActiveSheet();
            var cells = ExcelUtils.GuessFirstAndLastUsedCell();

            txtPrimaCella.Text = cells.firstCell.Address;
            txtUltimaCella.Text = cells.lastCell.Address;


          /*  if (chkUseAi.Checked)
            {
                string data = ExcelUtils.GetRowDataInFormat(ws, 2);

                string msg = @"Ho una riga di dati in formato Colonna:Valore, Le coppie sono separate da un ';'. Voglio identificare in quale colonna si trovano nome, cognome, il nome cognome insieme, indirizzo, telefono e comune.Di solito il nome e il cognome o sono nella stessa cella o sono separati. Non puoi duplicare la rispota nel senso che in una colonna ci può essere solo un informazione.
Se un'informazione non è presente, restituisci "" per quella categoria.
Ecco i dati:" + data + @"
Restituisci solo le informazioni nel seguente formato senza aggiungere altro: Nome:<colonna>;Cognome:<colonna>;NomeCognome:<colonna>;Indirizzo:<colonna>;Telefono:<colonna>;Comune:<colonna>
            ";





                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents(); // Forza l'aggiornamento dell'interfaccia
                ApiResponse result = await ollama.SendMessages(msg);
                Cursor.Current = Cursors.Default;
                Application.DoEvents(); // Forza l'aggiornamento dell'interfaccia

                string[] response = result.message.Content.Split(';');

                UpdateControlSafely(txtNome, response[0].Split(':')[1]);
                UpdateControlSafely(txtCognome, response[1].Split(':')[1]);
                UpdateControlSafely(txtNomeCognome, response[2].Split(':')[1]);
                UpdateControlSafely(txtIndirizzo, response[3].Split(':')[1]);
                UpdateControlSafely(txtNumero, response[4].Split(':')[1]);
                UpdateControlSafely(txtComune, response[5].Split(':')[1]);
                // MessageBox.Show(result.message.Content);
            }/*/

        }


        void UpdateControlSafely(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(delegate
                {
                    control.Text = text;
                }));
            }
            else
            {
                control.Text = text;
            }
        }

    }
}
