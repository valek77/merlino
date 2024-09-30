using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Merlino
{
    public partial class FormSettings : Form
    {
      

        public FormSettings()
        {
            InitializeComponent();

           
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            Preferences preferences = Preferences.LoadPreferences();
            txtOllamaUrl.Text = preferences.OllamaUrl;
            txtBPGUrl.Text = preferences.BpgUrl;
            txtBPGUsername.Text = preferences.BpgUsername;
            txtBPGPassword.Text = preferences.BpgPassword;
        }

      


        private void btnNome_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show(txtOllamaUrl.Text);

            this.Close();
        }





        private void btnSave_Click(object sender, EventArgs e)
        {
            Preferences preferences = new Preferences();
            preferences.OllamaUrl = txtOllamaUrl.Text;
            preferences.BpgUrl = txtBPGUrl.Text;
            preferences.BpgUsername = txtBPGUsername.Text;
            preferences.BpgPassword = txtBPGPassword.Text;

            Preferences.SavePreferences(preferences);

            this.Close();

        }

      
    }
}
