namespace pt_legitymacjestudenckie
{
    partial class LoginForm
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
            this.Loginlabel = new System.Windows.Forms.Label();
            this.LogintextBox = new System.Windows.Forms.TextBox();
            this.HasłotextBox = new System.Windows.Forms.TextBox();
            this.Hasłolabel = new System.Windows.Forms.Label();
            this.Zalogujbutton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Loginlabel
            // 
            this.Loginlabel.AutoSize = true;
            this.Loginlabel.Location = new System.Drawing.Point(43, 33);
            this.Loginlabel.Name = "Loginlabel";
            this.Loginlabel.Size = new System.Drawing.Size(33, 13);
            this.Loginlabel.TabIndex = 0;
            this.Loginlabel.Text = "Login";
            // 
            // LogintextBox
            // 
            this.LogintextBox.Location = new System.Drawing.Point(94, 30);
            this.LogintextBox.Name = "LogintextBox";
            this.LogintextBox.Size = new System.Drawing.Size(160, 20);
            this.LogintextBox.TabIndex = 1;
            // 
            // HasłotextBox
            // 
            this.HasłotextBox.Location = new System.Drawing.Point(94, 75);
            this.HasłotextBox.Name = "HasłotextBox";
            this.HasłotextBox.PasswordChar = '*';
            this.HasłotextBox.Size = new System.Drawing.Size(160, 20);
            this.HasłotextBox.TabIndex = 2;
            // 
            // Hasłolabel
            // 
            this.Hasłolabel.AutoSize = true;
            this.Hasłolabel.Location = new System.Drawing.Point(43, 78);
            this.Hasłolabel.Name = "Hasłolabel";
            this.Hasłolabel.Size = new System.Drawing.Size(36, 13);
            this.Hasłolabel.TabIndex = 3;
            this.Hasłolabel.Text = "Hasło";
            // 
            // Zalogujbutton
            // 
            this.Zalogujbutton.Location = new System.Drawing.Point(46, 114);
            this.Zalogujbutton.Name = "Zalogujbutton";
            this.Zalogujbutton.Size = new System.Drawing.Size(94, 23);
            this.Zalogujbutton.TabIndex = 4;
            this.Zalogujbutton.Text = "Zaloguj";
            this.Zalogujbutton.UseVisualStyleBackColor = true;
            this.Zalogujbutton.Click += new System.EventHandler(this.Zalogujbutton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(160, 114);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Rejestracja";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 158);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Zalogujbutton);
            this.Controls.Add(this.Hasłolabel);
            this.Controls.Add(this.HasłotextBox);
            this.Controls.Add(this.LogintextBox);
            this.Controls.Add(this.Loginlabel);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Loginlabel;
        private System.Windows.Forms.TextBox LogintextBox;
        private System.Windows.Forms.TextBox HasłotextBox;
        private System.Windows.Forms.Label Hasłolabel;
        private System.Windows.Forms.Button Zalogujbutton;
        private System.Windows.Forms.Button button2;
    }
}