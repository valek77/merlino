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
            this.btnPulisci.Location = new System.Drawing.Point(63, 493);
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
            this.txtUltimaCella.Location = new System.Drawing.Point(19, 100);
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
            this.label3.Location = new System.Drawing.Point(19, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ultima Cella";
            // 
            // btnIndovinaCelle
            // 
            this.btnIndovinaCelle.Location = new System.Drawing.Point(19, 152);
            this.btnIndovinaCelle.Name = "btnIndovinaCelle";
            this.btnIndovinaCelle.Size = new System.Drawing.Size(75, 23);
            this.btnIndovinaCelle.TabIndex = 7;
            this.btnIndovinaCelle.Text = "Indovina";
            this.btnIndovinaCelle.UseVisualStyleBackColor = true;
            this.btnIndovinaCelle.Click += new System.EventHandler(this.btnIndovinaCelle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPrimaCella);
            this.groupBox1.Controls.Add(this.btnIndovinaCelle);
            this.groupBox1.Controls.Add(this.txtUltimaCella);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(39, 255);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 191);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parametri";
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
            this.Size = new System.Drawing.Size(222, 548);
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
    }
}
