namespace Merlino
{
    partial class MainTaskPane
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTaskPane));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPulisci = new System.Windows.Forms.Button();
            this.txtPrimaCella = new System.Windows.Forms.TextBox();
            this.txtUltimaCella = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIndovinaCelle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUseAi = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIndirizzo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtComune = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNomeCognome = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCognome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Luckiest Guy", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Merlino";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 193);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnPulisci
            // 
            this.btnPulisci.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPulisci.Location = new System.Drawing.Point(72, 820);
            this.btnPulisci.Name = "btnPulisci";
            this.btnPulisci.Size = new System.Drawing.Size(75, 34);
            this.btnPulisci.TabIndex = 2;
            this.btnPulisci.Text = "Pulisci";
            this.btnPulisci.UseVisualStyleBackColor = true;
            this.btnPulisci.Click += new System.EventHandler(this.btnPulisci_Click);
            // 
            // txtPrimaCella
            // 
            this.txtPrimaCella.Location = new System.Drawing.Point(19, 42);
            this.txtPrimaCella.Name = "txtPrimaCella";
            this.txtPrimaCella.Size = new System.Drawing.Size(100, 20);
            this.txtPrimaCella.TabIndex = 3;
            // 
            // txtUltimaCella
            // 
            this.txtUltimaCella.Location = new System.Drawing.Point(19, 81);
            this.txtUltimaCella.Name = "txtUltimaCella";
            this.txtUltimaCella.Size = new System.Drawing.Size(100, 20);
            this.txtUltimaCella.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Prima Cella";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ultima Cella";
            // 
            // btnIndovinaCelle
            // 
            this.btnIndovinaCelle.Location = new System.Drawing.Point(22, 510);
            this.btnIndovinaCelle.Name = "btnIndovinaCelle";
            this.btnIndovinaCelle.Size = new System.Drawing.Size(100, 23);
            this.btnIndovinaCelle.TabIndex = 7;
            this.btnIndovinaCelle.Text = "Indovina Celle";
            this.btnIndovinaCelle.UseVisualStyleBackColor = true;
            this.btnIndovinaCelle.Click += new System.EventHandler(this.btnIndovinaCelle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUseAi);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtIndirizzo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtComune);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNomeCognome);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCognome);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.txtPrimaCella);
            this.groupBox1.Controls.Add(this.btnIndovinaCelle);
            this.groupBox1.Controls.Add(this.txtUltimaCella);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(28, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 555);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametri";
            // 
            // chkUseAi
            // 
            this.chkUseAi.AutoSize = true;
            this.chkUseAi.Location = new System.Drawing.Point(6, 465);
            this.chkUseAi.Name = "chkUseAi";
            this.chkUseAi.Size = new System.Drawing.Size(159, 17);
            this.chkUseAi.TabIndex = 20;
            this.chkUseAi.Text = "Usa AI per capire contenuto";
            this.chkUseAi.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 405);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Colonna Indirizzo";
            // 
            // txtIndirizzo
            // 
            this.txtIndirizzo.Location = new System.Drawing.Point(22, 424);
            this.txtIndirizzo.MaxLength = 1;
            this.txtIndirizzo.Name = "txtIndirizzo";
            this.txtIndirizzo.Size = new System.Drawing.Size(53, 20);
            this.txtIndirizzo.TabIndex = 18;
            this.txtIndirizzo.Text = "c";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 356);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Colonna Comune";
            // 
            // txtComune
            // 
            this.txtComune.Location = new System.Drawing.Point(22, 375);
            this.txtComune.MaxLength = 1;
            this.txtComune.Name = "txtComune";
            this.txtComune.Size = new System.Drawing.Size(53, 20);
            this.txtComune.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Colonna Numero Tel";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(22, 322);
            this.txtNumero.MaxLength = 1;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(53, 20);
            this.txtNumero.TabIndex = 14;
            this.txtNumero.Text = "b";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Colonna Nome - Cognome";
            // 
            // txtNomeCognome
            // 
            this.txtNomeCognome.Location = new System.Drawing.Point(22, 265);
            this.txtNomeCognome.MaxLength = 1;
            this.txtNomeCognome.Name = "txtNomeCognome";
            this.txtNomeCognome.Size = new System.Drawing.Size(53, 20);
            this.txtNomeCognome.TabIndex = 12;
            this.txtNomeCognome.Text = "a";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Colonna Cognome";
            // 
            // txtCognome
            // 
            this.txtCognome.Location = new System.Drawing.Point(22, 210);
            this.txtCognome.MaxLength = 1;
            this.txtCognome.Name = "txtCognome";
            this.txtCognome.Size = new System.Drawing.Size(53, 20);
            this.txtCognome.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Colonna Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(22, 162);
            this.txtNome.MaxLength = 1;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(53, 20);
            this.txtNome.TabIndex = 8;
            // 
            // MainTaskPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPulisci);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "MainTaskPane";
            this.Size = new System.Drawing.Size(223, 882);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPulisci;
        private System.Windows.Forms.TextBox txtPrimaCella;
        private System.Windows.Forms.TextBox txtUltimaCella;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIndovinaCelle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNomeCognome;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCognome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIndirizzo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtComune;
        private System.Windows.Forms.CheckBox chkUseAi;
    }
}
