namespace pt_legitymacjestudenckie
{
    partial class Registration
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
            this.ImieLabel = new System.Windows.Forms.Label();
            this.ImieTextBox = new System.Windows.Forms.TextBox();
            this.NazwiskoTextBox = new System.Windows.Forms.TextBox();
            this.NazwiskoLabel = new System.Windows.Forms.Label();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.HasloTextBox = new System.Windows.Forms.TextBox();
            this.HasloLabel = new System.Windows.Forms.Label();
            this.Haslo2TextBox = new System.Windows.Forms.TextBox();
            this.Haslo2Label = new System.Windows.Forms.Label();
            this.Zarejestrujbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ImieLabel
            // 
            this.ImieLabel.AutoSize = true;
            this.ImieLabel.Location = new System.Drawing.Point(73, 23);
            this.ImieLabel.Name = "ImieLabel";
            this.ImieLabel.Size = new System.Drawing.Size(26, 13);
            this.ImieLabel.TabIndex = 0;
            this.ImieLabel.Text = "Imie";
            // 
            // ImieTextBox
            // 
            this.ImieTextBox.Location = new System.Drawing.Point(167, 20);
            this.ImieTextBox.Name = "ImieTextBox";
            this.ImieTextBox.Size = new System.Drawing.Size(141, 20);
            this.ImieTextBox.TabIndex = 1;
            // 
            // NazwiskoTextBox
            // 
            this.NazwiskoTextBox.Location = new System.Drawing.Point(167, 61);
            this.NazwiskoTextBox.Name = "NazwiskoTextBox";
            this.NazwiskoTextBox.Size = new System.Drawing.Size(141, 20);
            this.NazwiskoTextBox.TabIndex = 3;
            // 
            // NazwiskoLabel
            // 
            this.NazwiskoLabel.AutoSize = true;
            this.NazwiskoLabel.Location = new System.Drawing.Point(73, 64);
            this.NazwiskoLabel.Name = "NazwiskoLabel";
            this.NazwiskoLabel.Size = new System.Drawing.Size(53, 13);
            this.NazwiskoLabel.TabIndex = 2;
            this.NazwiskoLabel.Text = "Nazwisko";
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(167, 103);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(141, 20);
            this.LoginTextBox.TabIndex = 5;
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Location = new System.Drawing.Point(73, 106);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(33, 13);
            this.LoginLabel.TabIndex = 4;
            this.LoginLabel.Text = "Login";
            // 
            // HasloTextBox
            // 
            this.HasloTextBox.Location = new System.Drawing.Point(167, 144);
            this.HasloTextBox.Name = "HasloTextBox";
            this.HasloTextBox.PasswordChar = '*';
            this.HasloTextBox.Size = new System.Drawing.Size(141, 20);
            this.HasloTextBox.TabIndex = 7;
            // 
            // HasloLabel
            // 
            this.HasloLabel.AutoSize = true;
            this.HasloLabel.Location = new System.Drawing.Point(73, 147);
            this.HasloLabel.Name = "HasloLabel";
            this.HasloLabel.Size = new System.Drawing.Size(36, 13);
            this.HasloLabel.TabIndex = 6;
            this.HasloLabel.Text = "Hasło";
            // 
            // Haslo2TextBox
            // 
            this.Haslo2TextBox.Location = new System.Drawing.Point(167, 186);
            this.Haslo2TextBox.Name = "Haslo2TextBox";
            this.Haslo2TextBox.PasswordChar = '*';
            this.Haslo2TextBox.Size = new System.Drawing.Size(141, 20);
            this.Haslo2TextBox.TabIndex = 9;
            // 
            // Haslo2Label
            // 
            this.Haslo2Label.AutoSize = true;
            this.Haslo2Label.Location = new System.Drawing.Point(73, 189);
            this.Haslo2Label.Name = "Haslo2Label";
            this.Haslo2Label.Size = new System.Drawing.Size(84, 13);
            this.Haslo2Label.TabIndex = 8;
            this.Haslo2Label.Text = "Ponownie hasło";
            // 
            // Zarejestrujbutton
            // 
            this.Zarejestrujbutton.Location = new System.Drawing.Point(167, 215);
            this.Zarejestrujbutton.Name = "Zarejestrujbutton";
            this.Zarejestrujbutton.Size = new System.Drawing.Size(140, 21);
            this.Zarejestrujbutton.TabIndex = 10;
            this.Zarejestrujbutton.Text = "Zarejestruj";
            this.Zarejestrujbutton.UseVisualStyleBackColor = true;
            this.Zarejestrujbutton.Click += new System.EventHandler(this.Zarejestrujbutton_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 266);
            this.Controls.Add(this.Zarejestrujbutton);
            this.Controls.Add(this.Haslo2TextBox);
            this.Controls.Add(this.Haslo2Label);
            this.Controls.Add(this.HasloTextBox);
            this.Controls.Add(this.HasloLabel);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.NazwiskoTextBox);
            this.Controls.Add(this.NazwiskoLabel);
            this.Controls.Add(this.ImieTextBox);
            this.Controls.Add(this.ImieLabel);
            this.MaximizeBox = false;
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Registration_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ImieLabel;
        private System.Windows.Forms.TextBox ImieTextBox;
        private System.Windows.Forms.TextBox NazwiskoTextBox;
        private System.Windows.Forms.Label NazwiskoLabel;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.TextBox HasloTextBox;
        private System.Windows.Forms.Label HasloLabel;
        private System.Windows.Forms.TextBox Haslo2TextBox;
        private System.Windows.Forms.Label Haslo2Label;
        private System.Windows.Forms.Button Zarejestrujbutton;
    }
}