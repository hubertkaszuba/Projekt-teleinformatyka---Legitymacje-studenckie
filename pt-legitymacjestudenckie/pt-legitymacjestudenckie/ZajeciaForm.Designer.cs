namespace pt_legitymacjestudenckie
{
    partial class ZajeciaForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cb_student_przegladanie = new System.Windows.Forms.ComboBox();
            this.cb_uwzglednij_date = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_szukaj_obecnosci = new System.Windows.Forms.Button();
            this.cb_przedmiot_przegladanie = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_data_przegladanie = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(338, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(450, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cb_student_przegladanie);
            this.groupBox5.Controls.Add(this.cb_uwzglednij_date);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.btn_szukaj_obecnosci);
            this.groupBox5.Controls.Add(this.cb_przedmiot_przegladanie);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.cb_data_przegladanie);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBox5.Location = new System.Drawing.Point(28, 87);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(295, 249);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Przeglądanie obecności";
            // 
            // cb_student_przegladanie
            // 
            this.cb_student_przegladanie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_student_przegladanie.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cb_student_przegladanie.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_student_przegladanie.FormattingEnabled = true;
            this.cb_student_przegladanie.Location = new System.Drawing.Point(79, 110);
            this.cb_student_przegladanie.Name = "cb_student_przegladanie";
            this.cb_student_przegladanie.Size = new System.Drawing.Size(200, 23);
            this.cb_student_przegladanie.TabIndex = 9;
            // 
            // cb_uwzglednij_date
            // 
            this.cb_uwzglednij_date.AutoSize = true;
            this.cb_uwzglednij_date.Location = new System.Drawing.Point(132, 85);
            this.cb_uwzglednij_date.Name = "cb_uwzglednij_date";
            this.cb_uwzglednij_date.Size = new System.Drawing.Size(144, 20);
            this.cb_uwzglednij_date.TabIndex = 8;
            this.cb_uwzglednij_date.Text = "Uwzględnianie daty";
            this.cb_uwzglednij_date.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label14.Location = new System.Drawing.Point(125, 140);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(135, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "wypełnić co najmniej jedno";
            // 
            // btn_szukaj_obecnosci
            // 
            this.btn_szukaj_obecnosci.Location = new System.Drawing.Point(20, 165);
            this.btn_szukaj_obecnosci.Name = "btn_szukaj_obecnosci";
            this.btn_szukaj_obecnosci.Size = new System.Drawing.Size(244, 68);
            this.btn_szukaj_obecnosci.TabIndex = 6;
            this.btn_szukaj_obecnosci.Text = "Szukaj";
            this.btn_szukaj_obecnosci.UseVisualStyleBackColor = true;
            // 
            // cb_przedmiot_przegladanie
            // 
            this.cb_przedmiot_przegladanie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_przedmiot_przegladanie.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cb_przedmiot_przegladanie.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_przedmiot_przegladanie.FormattingEnabled = true;
            this.cb_przedmiot_przegladanie.Location = new System.Drawing.Point(79, 29);
            this.cb_przedmiot_przegladanie.Name = "cb_przedmiot_przegladanie";
            this.cb_przedmiot_przegladanie.Size = new System.Drawing.Size(200, 23);
            this.cb_przedmiot_przegladanie.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Przedmiot";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_data_przegladanie
            // 
            this.cb_data_przegladanie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_data_przegladanie.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cb_data_przegladanie.Enabled = false;
            this.cb_data_przegladanie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cb_data_przegladanie.Location = new System.Drawing.Point(77, 62);
            this.cb_data_przegladanie.Name = "cb_data_przegladanie";
            this.cb_data_przegladanie.Size = new System.Drawing.Size(202, 20);
            this.cb_data_przegladanie.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(38, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "Data";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 114);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 16);
            this.label13.TabIndex = 5;
            this.label13.Text = "Student";
            // 
            // ZajeciaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ZajeciaForm";
            this.Text = "ZajeciaForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cb_student_przegladanie;
        private System.Windows.Forms.CheckBox cb_uwzglednij_date;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_szukaj_obecnosci;
        private System.Windows.Forms.ComboBox cb_przedmiot_przegladanie;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker cb_data_przegladanie;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}