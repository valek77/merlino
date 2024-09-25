namespace Merlino
{
    partial class FormSettings
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNome = new System.Windows.Forms.Button();
            this.txtOllamaUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBPGUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBPGUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBPGPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(461, 243);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Salva";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNome
            // 
            this.btnNome.Location = new System.Drawing.Point(25, 243);
            this.btnNome.Name = "btnNome";
            this.btnNome.Size = new System.Drawing.Size(75, 23);
            this.btnNome.TabIndex = 1;
            this.btnNome.Text = "Annulla";
            this.btnNome.UseVisualStyleBackColor = true;
            this.btnNome.Click += new System.EventHandler(this.btnNome_Click);
            // 
            // txtOllamaUrl
            // 
            this.txtOllamaUrl.Location = new System.Drawing.Point(22, 29);
            this.txtOllamaUrl.Name = "txtOllamaUrl";
            this.txtOllamaUrl.Size = new System.Drawing.Size(511, 20);
            this.txtOllamaUrl.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ollama url";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "BlackPhoneGuard url";
            // 
            // txtBPGUrl
            // 
            this.txtBPGUrl.Location = new System.Drawing.Point(22, 101);
            this.txtBPGUrl.Name = "txtBPGUrl";
            this.txtBPGUrl.Size = new System.Drawing.Size(511, 20);
            this.txtBPGUrl.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "BlackPhoneGuard UserName";
            // 
            // txtBPGUsername
            // 
            this.txtBPGUsername.Location = new System.Drawing.Point(24, 145);
            this.txtBPGUsername.Name = "txtBPGUsername";
            this.txtBPGUsername.Size = new System.Drawing.Size(511, 20);
            this.txtBPGUsername.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "BlackPhoneGuard Password";
            // 
            // txtBPGPassword
            // 
            this.txtBPGPassword.Location = new System.Drawing.Point(22, 194);
            this.txtBPGPassword.Name = "txtBPGPassword";
            this.txtBPGPassword.PasswordChar = '*';
            this.txtBPGPassword.Size = new System.Drawing.Size(511, 20);
            this.txtBPGPassword.TabIndex = 8;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 294);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBPGPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBPGUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBPGUrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOllamaUrl);
            this.Controls.Add(this.btnNome);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Merlino - Opzioni";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNome;
        private System.Windows.Forms.TextBox txtOllamaUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBPGUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBPGUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBPGPassword;
    }
}