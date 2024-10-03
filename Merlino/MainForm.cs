using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Merlino
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            MainTaskPane mainTaskPane = new MainTaskPane();
            this.Controls.Add(mainTaskPane);
            mainTaskPane.Dock = DockStyle.Fill;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
