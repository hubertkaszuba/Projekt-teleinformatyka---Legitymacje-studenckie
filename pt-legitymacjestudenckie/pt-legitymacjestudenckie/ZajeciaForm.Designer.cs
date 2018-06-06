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
            this.dgv_lista_obecnosci = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_szukaj_obecnosci = new System.Windows.Forms.Button();
            this.cb_przedmiot_przegladanie = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_data_od = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_data_do = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.data_zajec = new System.Windows.Forms.DateTimePicker();
            this.godzina_zajec = new System.Windows.Forms.DateTimePicker();
            this.btn_usun = new System.Windows.Forms.Button();
            this.btn_aktualizuj = new System.Windows.Forms.Button();
            this.Edytuj = new System.Windows.Forms.GroupBox();
            this.cb_sala = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lista_obecnosci)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.Edytuj.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_lista_obecnosci
            // 
            this.dgv_lista_obecnosci.AllowUserToAddRows = false;
            this.dgv_lista_obecnosci.AllowUserToDeleteRows = false;
            this.dgv_lista_obecnosci.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_lista_obecnosci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_lista_obecnosci.Location = new System.Drawing.Point(336, 12);
            this.dgv_lista_obecnosci.Name = "dgv_lista_obecnosci";
            this.dgv_lista_obecnosci.ReadOnly = true;
            this.dgv_lista_obecnosci.Size = new System.Drawing.Size(497, 426);
            this.dgv_lista_obecnosci.TabIndex = 0;
            this.dgv_lista_obecnosci.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_lista_obecnosci_CellClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.btn_szukaj_obecnosci);
            this.groupBox5.Controls.Add(this.cb_przedmiot_przegladanie);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.cb_data_do);
            this.groupBox5.Controls.Add(this.cb_data_od);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBox5.Location = new System.Drawing.Point(23, 30);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(295, 238);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Zajęcia do edycji";
            // 
            // btn_szukaj_obecnosci
            // 
            this.btn_szukaj_obecnosci.Location = new System.Drawing.Point(26, 143);
            this.btn_szukaj_obecnosci.Name = "btn_szukaj_obecnosci";
            this.btn_szukaj_obecnosci.Size = new System.Drawing.Size(244, 68);
            this.btn_szukaj_obecnosci.TabIndex = 6;
            this.btn_szukaj_obecnosci.Text = "Szukaj";
            this.btn_szukaj_obecnosci.UseVisualStyleBackColor = true;
            this.btn_szukaj_obecnosci.Click += new System.EventHandler(this.btn_szukaj_obecnosci_Click);
            // 
            // cb_przedmiot_przegladanie
            // 
            this.cb_przedmiot_przegladanie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_przedmiot_przegladanie.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cb_przedmiot_przegladanie.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_przedmiot_przegladanie.FormattingEnabled = true;
            this.cb_przedmiot_przegladanie.Location = new System.Drawing.Point(79, 24);
            this.cb_przedmiot_przegladanie.Name = "cb_przedmiot_przegladanie";
            this.cb_przedmiot_przegladanie.Size = new System.Drawing.Size(200, 23);
            this.cb_przedmiot_przegladanie.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Przedmiot";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_data_od
            // 
            this.cb_data_od.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_data_od.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cb_data_od.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cb_data_od.Location = new System.Drawing.Point(77, 76);
            this.cb_data_od.Name = "cb_data_od";
            this.cb_data_od.Size = new System.Drawing.Size(202, 20);
            this.cb_data_od.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "Data:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_data_do
            // 
            this.cb_data_do.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_data_do.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cb_data_do.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cb_data_do.Location = new System.Drawing.Point(77, 102);
            this.cb_data_do.Name = "cb_data_do";
            this.cb_data_do.Size = new System.Drawing.Size(202, 20);
            this.cb_data_do.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "od";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "do";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Godzina";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Sala";
            // 
            // data_zajec
            // 
            this.data_zajec.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.data_zajec.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.data_zajec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.data_zajec.Location = new System.Drawing.Point(62, 32);
            this.data_zajec.Name = "data_zajec";
            this.data_zajec.Size = new System.Drawing.Size(215, 20);
            this.data_zajec.TabIndex = 3;
            // 
            // godzina_zajec
            // 
            this.godzina_zajec.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.godzina_zajec.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.godzina_zajec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.godzina_zajec.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.godzina_zajec.Location = new System.Drawing.Point(62, 61);
            this.godzina_zajec.Name = "godzina_zajec";
            this.godzina_zajec.Size = new System.Drawing.Size(66, 20);
            this.godzina_zajec.TabIndex = 3;
            // 
            // btn_usun
            // 
            this.btn_usun.Enabled = false;
            this.btn_usun.Location = new System.Drawing.Point(66, 129);
            this.btn_usun.Name = "btn_usun";
            this.btn_usun.Size = new System.Drawing.Size(75, 23);
            this.btn_usun.TabIndex = 14;
            this.btn_usun.Text = "Usuń";
            this.btn_usun.UseVisualStyleBackColor = true;
            this.btn_usun.Click += new System.EventHandler(this.btn_usun_Click);
            // 
            // btn_aktualizuj
            // 
            this.btn_aktualizuj.Enabled = false;
            this.btn_aktualizuj.Location = new System.Drawing.Point(147, 129);
            this.btn_aktualizuj.Name = "btn_aktualizuj";
            this.btn_aktualizuj.Size = new System.Drawing.Size(75, 23);
            this.btn_aktualizuj.TabIndex = 14;
            this.btn_aktualizuj.Text = "Aktualizuj";
            this.btn_aktualizuj.UseVisualStyleBackColor = true;
            this.btn_aktualizuj.Click += new System.EventHandler(this.btn_aktualizuj_Click);
            // 
            // Edytuj
            // 
            this.Edytuj.Controls.Add(this.cb_sala);
            this.Edytuj.Controls.Add(this.label3);
            this.Edytuj.Controls.Add(this.btn_aktualizuj);
            this.Edytuj.Controls.Add(this.data_zajec);
            this.Edytuj.Controls.Add(this.btn_usun);
            this.Edytuj.Controls.Add(this.godzina_zajec);
            this.Edytuj.Controls.Add(this.label5);
            this.Edytuj.Controls.Add(this.label4);
            this.Edytuj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Edytuj.Location = new System.Drawing.Point(23, 274);
            this.Edytuj.Name = "Edytuj";
            this.Edytuj.Size = new System.Drawing.Size(295, 164);
            this.Edytuj.TabIndex = 15;
            this.Edytuj.TabStop = false;
            this.Edytuj.Text = "Edytuj";
            // 
            // cb_sala
            // 
            this.cb_sala.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cb_sala.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_sala.FormattingEnabled = true;
            this.cb_sala.Location = new System.Drawing.Point(62, 88);
            this.cb_sala.Name = "cb_sala";
            this.cb_sala.Size = new System.Drawing.Size(183, 23);
            this.cb_sala.TabIndex = 25;
            // 
            // ZajeciaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 455);
            this.Controls.Add(this.Edytuj);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.dgv_lista_obecnosci);
            this.Name = "ZajeciaForm";
            this.Text = "Edytor zajęć";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lista_obecnosci)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.Edytuj.ResumeLayout(false);
            this.Edytuj.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_lista_obecnosci;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_szukaj_obecnosci;
        private System.Windows.Forms.ComboBox cb_przedmiot_przegladanie;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker cb_data_od;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker cb_data_do;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker data_zajec;
        private System.Windows.Forms.DateTimePicker godzina_zajec;
        private System.Windows.Forms.Button btn_usun;
        private System.Windows.Forms.Button btn_aktualizuj;
        private System.Windows.Forms.GroupBox Edytuj;
        private System.Windows.Forms.ComboBox cb_sala;
    }
}