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

        private string OllamaUrl = "http://localhost:11434/api/chat";
        private OllamaClient ollama ;

        public MainTaskPane()
        {
            InitializeComponent();

            ollama = new OllamaClient(OllamaUrl, "gemma2");
        }

        private async void btnPulisci_Click(object sender, EventArgs e)
        {
            Excel.Worksheet ws = ExcelUtils.getActiveSheet();

            string[] firstCellArr = txtPrimaCella.Text.Split('$');
            string[] lastCellArr = txtUltimaCella.Text.Split('$');

            int firstColIndex = ExcelUtils.ColumnLetterToIndex(firstCellArr[1]);
            int lastColIndex = ExcelUtils.ColumnLetterToIndex(lastCellArr[1]);
            int numColUsed = lastColIndex - firstColIndex + 1;


            int firstRowIndex = Convert.ToInt32(firstCellArr[2]);
            int lastRowIndex = Convert.ToInt32(lastCellArr[2]);


            string firstNewCol = ExcelUtils.GetColumNamePlusDelta(lastCellArr[1], 2);
            int firstNewColIndex = ExcelUtils.ColumnLetterToIndex(firstNewCol);
            //int lastNexColIndex = firstNewColIndex + numColUsed;

            int delta = firstNewColIndex - firstColIndex;

            Cursor.Current = Cursors.WaitCursor;


            for (int r = firstRowIndex; r <= 100; r++)
         
                {

                ws.ScrollToRowCentered(r);

                if (txtNomeCognome.Text != "") { 
                    var nomeCognome = ws.ReadFromCell(txtNomeCognome.Text+r);
                    ws.WriteToCell(r,lastColIndex+delta, nomeCognome.ToString().ToUpper());
                }


                if (txtNome.Text != "" && txtCognome.Text!="")
                {
                    var nome = ws.ReadFromCell(txtNome.Text + r);
                    var cognome = ws.ReadFromCell(txtCognome.Text + r);
                    var nomeCognome = nome + " " + cognome;
                    ws.WriteToCell(r, lastColIndex + delta, nomeCognome.ToString().ToUpper());
                }

                if (txtNumero.Text != "") {
                    var numero = ws.ReadFromCell(txtNumero.Text + r);
                    ws.WriteToCell(r, lastColIndex + delta+1, numero.ToString().ToUpper());
                }

                if (txtIndirizzo.Text != "" ) {
                    var ind = ws.ReadFromCell(txtIndirizzo.Text + r);

                    var comune = await indovinaComuneDaIndirizzo(ind.ToString());

                    ws.WriteToCell(r, lastColIndex + delta + 2, comune.ToString().ToUpper());
                }

                if (txtCognome.Text != "")
                {
                    var comune = ws.ReadFromCell(txtCognome.Text + r);

                    ws.WriteToCell(r, lastColIndex + delta + 2, comune.ToString().ToUpper());
                }



                /*for (int c = firstColIndex; c <= lastColIndex; c++)
                {
                    var tmp = ws.ReadFromCell(r, c);

                    if(txtNomeCognome.Text!="")


                    ws.WriteToCell(r, c + delta, tmp.ToString().ToLowerInvariant());
                }*/





            }

                Cursor.Current = Cursors.Default;

            ws.WriteToCell(firstNewCol + "1", "Ciao");

        }




        private  async Task<string> indovinaComuneDaIndirizzo(string indirizzo) {
            string msg = "A partire da qust'indirizzo riesci cappire di quale comune si tratta ?Rispondi con il solo comune non aggiungere nient'altro\n " + indirizzo;
            ApiResponse result = await ollama.SendMessages(msg);

            return result.message.Content.Trim();
        }



        private async void btnIndovinaCelle_Click(object sender, EventArgs e)
        {
            Excel.Worksheet ws = ExcelUtils.getActiveSheet();
            var cells = ExcelUtils.GuessFirstAndLastUsedCell();

            txtPrimaCella.Text = cells.firstCell.Address;
            txtUltimaCella.Text = cells.lastCell.Address;


            if (chkUseAi.Checked)
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
            }

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
