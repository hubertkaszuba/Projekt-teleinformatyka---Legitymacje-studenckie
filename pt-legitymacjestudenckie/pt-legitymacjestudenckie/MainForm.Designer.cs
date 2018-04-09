namespace pt_legitymacjestudenckie
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("<nazwa zajęć>");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("<sala>");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("<godzina od do>");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("<nazwa zajęć>");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("<sala>");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("<godzina od do>");
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabObecnosc = new System.Windows.Forms.TabPage();
            this.dgv_lista_studentow = new System.Windows.Forms.DataGridView();
            this.lv_nastepne_zajecia = new System.Windows.Forms.ListView();
            this.lv_aktualne_zajecia = new System.Windows.Forms.ListView();
            this.btn_usun_zaznaczone = new System.Windows.Forms.Button();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lb_sekundy = new System.Windows.Forms.Label();
            this.lb_minuty = new System.Windows.Forms.Label();
            this.lb_dwukropek = new System.Windows.Forms.Label();
            this.lb_stoper_min = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_pozostaly_czas = new System.Windows.Forms.Label();
            this.btn_zapisz = new System.Windows.Forms.Button();
            this.btn_zakoncz = new System.Windows.Forms.Button();
            this.btn_rozpocznij = new System.Windows.Forms.Button();
            this.lb_imie_nazwisko_zalogowanego = new System.Windows.Forms.Label();
            this.kalendarz = new System.Windows.Forms.Label();
            this.zegar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_budynek = new System.Windows.Forms.TextBox();
            this.tb_numer_sali = new System.Windows.Forms.TextBox();
            this.btn_dodaj_sale = new System.Windows.Forms.Button();
            this.label_budynek = new System.Windows.Forms.Label();
            this.label_numer_sali = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_nazwa_przedmiotu = new System.Windows.Forms.Label();
            this.tb_nazwa_przedmiotu = new System.Windows.Forms.TextBox();
            this.btn_dodaj_przedmiot = new System.Windows.Forms.Button();
            this.dgv_zajęcia = new System.Windows.Forms.DataGridView();
            this.Nazwa_zajęć = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Czas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DzienTygodnia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tydzień = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_dodawanieZajęć = new System.Windows.Forms.GroupBox();
            this.cb_sala = new System.Windows.Forms.ComboBox();
            this.cb_zajecia = new System.Windows.Forms.ComboBox();
            this.dateTime_pierwsze_zajecia = new System.Windows.Forms.DateTimePicker();
            this.btn_dodaj_zajęcia = new System.Windows.Forms.Button();
            this.label_zajecia = new System.Windows.Forms.Label();
            this.label_czestosc = new System.Windows.Forms.Label();
            this.label_data_pierwszych_zajec = new System.Windows.Forms.Label();
            this.cb_czestosc = new System.Windows.Forms.ComboBox();
            this.label_sala = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.stoper = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabObecnosc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lista_studentow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_zajęcia)).BeginInit();
            this.gb_dodawanieZajęć.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tabControl1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabObecnosc);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(781, 436);
            this.tabControl1.TabIndex = 1;
            // 
            // tabObecnosc
            // 
            this.tabObecnosc.BackColor = System.Drawing.Color.Transparent;
            this.tabObecnosc.Controls.Add(this.dgv_lista_studentow);
            this.tabObecnosc.Controls.Add(this.lv_nastepne_zajecia);
            this.tabObecnosc.Controls.Add(this.lv_aktualne_zajecia);
            this.tabObecnosc.Controls.Add(this.btn_usun_zaznaczone);
            this.tabObecnosc.Controls.Add(this.numericUpDown);
            this.tabObecnosc.Controls.Add(this.lb_sekundy);
            this.tabObecnosc.Controls.Add(this.lb_minuty);
            this.tabObecnosc.Controls.Add(this.lb_dwukropek);
            this.tabObecnosc.Controls.Add(this.lb_stoper_min);
            this.tabObecnosc.Controls.Add(this.label4);
            this.tabObecnosc.Controls.Add(this.label3);
            this.tabObecnosc.Controls.Add(this.lb_pozostaly_czas);
            this.tabObecnosc.Controls.Add(this.btn_zapisz);
            this.tabObecnosc.Controls.Add(this.btn_zakoncz);
            this.tabObecnosc.Controls.Add(this.btn_rozpocznij);
            this.tabObecnosc.Controls.Add(this.lb_imie_nazwisko_zalogowanego);
            this.tabObecnosc.Controls.Add(this.kalendarz);
            this.tabObecnosc.Controls.Add(this.zegar);
            this.tabObecnosc.Controls.Add(this.label1);
            this.tabObecnosc.Location = new System.Drawing.Point(4, 22);
            this.tabObecnosc.Name = "tabObecnosc";
            this.tabObecnosc.Padding = new System.Windows.Forms.Padding(3);
            this.tabObecnosc.Size = new System.Drawing.Size(773, 410);
            this.tabObecnosc.TabIndex = 0;
            this.tabObecnosc.Text = "Sprawdzanie obecności";
            // 
            // dgv_lista_studentow
            // 
            this.dgv_lista_studentow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_lista_studentow.Location = new System.Drawing.Point(194, 130);
            this.dgv_lista_studentow.Name = "dgv_lista_studentow";
            this.dgv_lista_studentow.RowHeadersVisible = false;
            this.dgv_lista_studentow.Size = new System.Drawing.Size(430, 266);
            this.dgv_lista_studentow.TabIndex = 20;
            // 
            // lv_nastepne_zajecia
            // 
            this.lv_nastepne_zajecia.Enabled = false;
            listViewItem8.IndentCount = 1;
            listViewItem9.IndentCount = 2;
            listViewItem9.UseItemStyleForSubItems = false;
            this.lv_nastepne_zajecia.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem7,
            listViewItem8,
            listViewItem9});
            this.lv_nastepne_zajecia.Location = new System.Drawing.Point(155, 25);
            this.lv_nastepne_zajecia.Name = "lv_nastepne_zajecia";
            this.lv_nastepne_zajecia.Size = new System.Drawing.Size(132, 70);
            this.lv_nastepne_zajecia.TabIndex = 19;
            this.lv_nastepne_zajecia.UseCompatibleStateImageBehavior = false;
            this.lv_nastepne_zajecia.View = System.Windows.Forms.View.List;
            // 
            // lv_aktualne_zajecia
            // 
            this.lv_aktualne_zajecia.Enabled = false;
            listViewItem11.IndentCount = 1;
            listViewItem12.IndentCount = 2;
            listViewItem12.UseItemStyleForSubItems = false;
            this.lv_aktualne_zajecia.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem10,
            listViewItem11,
            listViewItem12});
            this.lv_aktualne_zajecia.Location = new System.Drawing.Point(6, 25);
            this.lv_aktualne_zajecia.Name = "lv_aktualne_zajecia";
            this.lv_aktualne_zajecia.Size = new System.Drawing.Size(132, 70);
            this.lv_aktualne_zajecia.TabIndex = 19;
            this.lv_aktualne_zajecia.UseCompatibleStateImageBehavior = false;
            this.lv_aktualne_zajecia.View = System.Windows.Forms.View.List;
            // 
            // btn_usun_zaznaczone
            // 
            this.btn_usun_zaznaczone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_usun_zaznaczone.Location = new System.Drawing.Point(627, 130);
            this.btn_usun_zaznaczone.Name = "btn_usun_zaznaczone";
            this.btn_usun_zaznaczone.Size = new System.Drawing.Size(140, 44);
            this.btn_usun_zaznaczone.TabIndex = 18;
            this.btn_usun_zaznaczone.Text = "Usuń zaznaczone";
            this.btn_usun_zaznaczone.UseVisualStyleBackColor = true;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(94, 209);
            this.numericUpDown.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown.TabIndex = 17;
            this.numericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // lb_sekundy
            // 
            this.lb_sekundy.AutoSize = true;
            this.lb_sekundy.Location = new System.Drawing.Point(114, 211);
            this.lb_sekundy.Name = "lb_sekundy";
            this.lb_sekundy.Size = new System.Drawing.Size(17, 13);
            this.lb_sekundy.TabIndex = 14;
            this.lb_sekundy.Text = "ss";
            // 
            // lb_minuty
            // 
            this.lb_minuty.AutoSize = true;
            this.lb_minuty.Location = new System.Drawing.Point(93, 211);
            this.lb_minuty.Name = "lb_minuty";
            this.lb_minuty.Size = new System.Drawing.Size(23, 13);
            this.lb_minuty.TabIndex = 14;
            this.lb_minuty.Text = "mm";
            // 
            // lb_dwukropek
            // 
            this.lb_dwukropek.AutoSize = true;
            this.lb_dwukropek.Location = new System.Drawing.Point(108, 211);
            this.lb_dwukropek.Name = "lb_dwukropek";
            this.lb_dwukropek.Size = new System.Drawing.Size(10, 13);
            this.lb_dwukropek.TabIndex = 13;
            this.lb_dwukropek.Text = ":";
            // 
            // lb_stoper_min
            // 
            this.lb_stoper_min.AutoSize = true;
            this.lb_stoper_min.Location = new System.Drawing.Point(134, 212);
            this.lb_stoper_min.Name = "lb_stoper_min";
            this.lb_stoper_min.Size = new System.Drawing.Size(23, 13);
            this.lb_stoper_min.TabIndex = 13;
            this.lb_stoper_min.Text = "min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Obecni studenci:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(150, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Następne zajęcia:";
            // 
            // lb_pozostaly_czas
            // 
            this.lb_pozostaly_czas.AutoSize = true;
            this.lb_pozostaly_czas.Location = new System.Drawing.Point(12, 210);
            this.lb_pozostaly_czas.Name = "lb_pozostaly_czas";
            this.lb_pozostaly_czas.Size = new System.Drawing.Size(82, 13);
            this.lb_pozostaly_czas.TabIndex = 8;
            this.lb_pozostaly_czas.Text = "Pozostały czas:";
            // 
            // btn_zapisz
            // 
            this.btn_zapisz.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_zapisz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_zapisz.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_zapisz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_zapisz.Location = new System.Drawing.Point(8, 352);
            this.btn_zapisz.Name = "btn_zapisz";
            this.btn_zapisz.Size = new System.Drawing.Size(140, 44);
            this.btn_zapisz.TabIndex = 7;
            this.btn_zapisz.Text = "Zapisz";
            this.btn_zapisz.UseVisualStyleBackColor = false;
            this.btn_zapisz.Click += new System.EventHandler(this.btn_zapisz_Click);
            // 
            // btn_zakoncz
            // 
            this.btn_zakoncz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_zakoncz.Location = new System.Drawing.Point(8, 284);
            this.btn_zakoncz.Name = "btn_zakoncz";
            this.btn_zakoncz.Size = new System.Drawing.Size(140, 44);
            this.btn_zakoncz.TabIndex = 7;
            this.btn_zakoncz.Text = "Zakończ";
            this.btn_zakoncz.UseVisualStyleBackColor = true;
            this.btn_zakoncz.Click += new System.EventHandler(this.btn_zakoncz_Click);
            // 
            // btn_rozpocznij
            // 
            this.btn_rozpocznij.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_rozpocznij.Location = new System.Drawing.Point(8, 234);
            this.btn_rozpocznij.Name = "btn_rozpocznij";
            this.btn_rozpocznij.Size = new System.Drawing.Size(140, 44);
            this.btn_rozpocznij.TabIndex = 7;
            this.btn_rozpocznij.Text = "Rozpocznij";
            this.btn_rozpocznij.UseVisualStyleBackColor = true;
            this.btn_rozpocznij.Click += new System.EventHandler(this.btn_rozpocznij_Click);
            // 
            // lb_imie_nazwisko_zalogowanego
            // 
            this.lb_imie_nazwisko_zalogowanego.AutoSize = true;
            this.lb_imie_nazwisko_zalogowanego.Dock = System.Windows.Forms.DockStyle.Right;
            this.lb_imie_nazwisko_zalogowanego.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lb_imie_nazwisko_zalogowanego.Location = new System.Drawing.Point(549, 3);
            this.lb_imie_nazwisko_zalogowanego.Name = "lb_imie_nazwisko_zalogowanego";
            this.lb_imie_nazwisko_zalogowanego.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb_imie_nazwisko_zalogowanego.Size = new System.Drawing.Size(221, 18);
            this.lb_imie_nazwisko_zalogowanego.TabIndex = 6;
            this.lb_imie_nazwisko_zalogowanego.Text = "<imię nazwisko zalogowanego>";
            this.lb_imie_nazwisko_zalogowanego.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kalendarz
            // 
            this.kalendarz.AutoSize = true;
            this.kalendarz.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.kalendarz.Location = new System.Drawing.Point(638, 379);
            this.kalendarz.Name = "kalendarz";
            this.kalendarz.Size = new System.Drawing.Size(129, 29);
            this.kalendarz.TabIndex = 3;
            this.kalendarz.Text = "01.01.2000";
            // 
            // zegar
            // 
            this.zegar.AutoSize = true;
            this.zegar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.zegar.Location = new System.Drawing.Point(647, 348);
            this.zegar.Name = "zegar";
            this.zegar.Size = new System.Drawing.Size(120, 31);
            this.zegar.TabIndex = 2;
            this.zegar.Text = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Aktualne zajęcia:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.dgv_zajęcia);
            this.tabPage2.Controls.Add(this.gb_dodawanieZajęć);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(773, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edytor zajęć";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_budynek);
            this.groupBox2.Controls.Add(this.tb_numer_sali);
            this.groupBox2.Controls.Add(this.btn_dodaj_sale);
            this.groupBox2.Controls.Add(this.label_budynek);
            this.groupBox2.Controls.Add(this.label_numer_sali);
            this.groupBox2.Location = new System.Drawing.Point(15, 298);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 106);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dodawanie Sali";
            // 
            // tb_budynek
            // 
            this.tb_budynek.Location = new System.Drawing.Point(108, 38);
            this.tb_budynek.Name = "tb_budynek";
            this.tb_budynek.Size = new System.Drawing.Size(133, 20);
            this.tb_budynek.TabIndex = 0;
            // 
            // tb_numer_sali
            // 
            this.tb_numer_sali.Location = new System.Drawing.Point(108, 15);
            this.tb_numer_sali.Name = "tb_numer_sali";
            this.tb_numer_sali.Size = new System.Drawing.Size(133, 20);
            this.tb_numer_sali.TabIndex = 0;
            // 
            // btn_dodaj_sale
            // 
            this.btn_dodaj_sale.Location = new System.Drawing.Point(5, 75);
            this.btn_dodaj_sale.Name = "btn_dodaj_sale";
            this.btn_dodaj_sale.Size = new System.Drawing.Size(75, 23);
            this.btn_dodaj_sale.TabIndex = 21;
            this.btn_dodaj_sale.Text = "Dodaj";
            this.btn_dodaj_sale.UseVisualStyleBackColor = true;
            // 
            // label_budynek
            // 
            this.label_budynek.AutoSize = true;
            this.label_budynek.Location = new System.Drawing.Point(57, 41);
            this.label_budynek.Name = "label_budynek";
            this.label_budynek.Size = new System.Drawing.Size(49, 13);
            this.label_budynek.TabIndex = 19;
            this.label_budynek.Text = "Budynek";
            // 
            // label_numer_sali
            // 
            this.label_numer_sali.AutoSize = true;
            this.label_numer_sali.Location = new System.Drawing.Point(50, 18);
            this.label_numer_sali.Name = "label_numer_sali";
            this.label_numer_sali.Size = new System.Drawing.Size(56, 13);
            this.label_numer_sali.TabIndex = 19;
            this.label_numer_sali.Text = "Numer sali";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_nazwa_przedmiotu);
            this.groupBox1.Controls.Add(this.tb_nazwa_przedmiotu);
            this.groupBox1.Controls.Add(this.btn_dodaj_przedmiot);
            this.groupBox1.Location = new System.Drawing.Point(15, 204);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 82);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dodawanie przedmiotu";
            // 
            // label_nazwa_przedmiotu
            // 
            this.label_nazwa_przedmiotu.AutoSize = true;
            this.label_nazwa_przedmiotu.Location = new System.Drawing.Point(12, 23);
            this.label_nazwa_przedmiotu.Name = "label_nazwa_przedmiotu";
            this.label_nazwa_przedmiotu.Size = new System.Drawing.Size(94, 13);
            this.label_nazwa_przedmiotu.TabIndex = 19;
            this.label_nazwa_przedmiotu.Text = "Nazwa przedmiotu";
            // 
            // tb_nazwa_przedmiotu
            // 
            this.tb_nazwa_przedmiotu.Location = new System.Drawing.Point(108, 20);
            this.tb_nazwa_przedmiotu.Name = "tb_nazwa_przedmiotu";
            this.tb_nazwa_przedmiotu.Size = new System.Drawing.Size(133, 20);
            this.tb_nazwa_przedmiotu.TabIndex = 0;
            // 
            // btn_dodaj_przedmiot
            // 
            this.btn_dodaj_przedmiot.Location = new System.Drawing.Point(5, 50);
            this.btn_dodaj_przedmiot.Name = "btn_dodaj_przedmiot";
            this.btn_dodaj_przedmiot.Size = new System.Drawing.Size(75, 23);
            this.btn_dodaj_przedmiot.TabIndex = 21;
            this.btn_dodaj_przedmiot.Text = "Dodaj";
            this.btn_dodaj_przedmiot.UseVisualStyleBackColor = true;
            // 
            // dgv_zajęcia
            // 
            this.dgv_zajęcia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_zajęcia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nazwa_zajęć,
            this.Sala,
            this.Czas,
            this.DzienTygodnia,
            this.Tydzień});
            this.dgv_zajęcia.Location = new System.Drawing.Point(292, 24);
            this.dgv_zajęcia.Name = "dgv_zajęcia";
            this.dgv_zajęcia.ReadOnly = true;
            this.dgv_zajęcia.RowHeadersVisible = false;
            this.dgv_zajęcia.Size = new System.Drawing.Size(478, 380);
            this.dgv_zajęcia.TabIndex = 22;
            // 
            // Nazwa_zajęć
            // 
            this.Nazwa_zajęć.HeaderText = "Nazwa zajęć";
            this.Nazwa_zajęć.Name = "Nazwa_zajęć";
            this.Nazwa_zajęć.ReadOnly = true;
            // 
            // Sala
            // 
            this.Sala.HeaderText = "Sala";
            this.Sala.Name = "Sala";
            this.Sala.ReadOnly = true;
            this.Sala.Width = 60;
            // 
            // Czas
            // 
            this.Czas.HeaderText = "Czas";
            this.Czas.Name = "Czas";
            this.Czas.ReadOnly = true;
            // 
            // DzienTygodnia
            // 
            this.DzienTygodnia.HeaderText = "Dzień Tygodnia";
            this.DzienTygodnia.Name = "DzienTygodnia";
            this.DzienTygodnia.ReadOnly = true;
            this.DzienTygodnia.Width = 110;
            // 
            // Tydzień
            // 
            this.Tydzień.HeaderText = "Tydzień";
            this.Tydzień.Name = "Tydzień";
            this.Tydzień.ReadOnly = true;
            // 
            // gb_dodawanieZajęć
            // 
            this.gb_dodawanieZajęć.Controls.Add(this.cb_sala);
            this.gb_dodawanieZajęć.Controls.Add(this.cb_zajecia);
            this.gb_dodawanieZajęć.Controls.Add(this.dateTime_pierwsze_zajecia);
            this.gb_dodawanieZajęć.Controls.Add(this.btn_dodaj_zajęcia);
            this.gb_dodawanieZajęć.Controls.Add(this.label_zajecia);
            this.gb_dodawanieZajęć.Controls.Add(this.label_czestosc);
            this.gb_dodawanieZajęć.Controls.Add(this.label_data_pierwszych_zajec);
            this.gb_dodawanieZajęć.Controls.Add(this.cb_czestosc);
            this.gb_dodawanieZajęć.Controls.Add(this.label_sala);
            this.gb_dodawanieZajęć.Location = new System.Drawing.Point(15, 18);
            this.gb_dodawanieZajęć.Name = "gb_dodawanieZajęć";
            this.gb_dodawanieZajęć.Size = new System.Drawing.Size(274, 178);
            this.gb_dodawanieZajęć.TabIndex = 21;
            this.gb_dodawanieZajęć.TabStop = false;
            this.gb_dodawanieZajęć.Text = "Dodawanie zajęć";
            // 
            // cb_sala
            // 
            this.cb_sala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_sala.FormattingEnabled = true;
            this.cb_sala.Location = new System.Drawing.Point(117, 51);
            this.cb_sala.Name = "cb_sala";
            this.cb_sala.Size = new System.Drawing.Size(121, 21);
            this.cb_sala.TabIndex = 24;
            // 
            // cb_zajecia
            // 
            this.cb_zajecia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_zajecia.FormattingEnabled = true;
            this.cb_zajecia.Location = new System.Drawing.Point(117, 24);
            this.cb_zajecia.Name = "cb_zajecia";
            this.cb_zajecia.Size = new System.Drawing.Size(121, 21);
            this.cb_zajecia.TabIndex = 23;
            // 
            // dateTime_pierwsze_zajecia
            // 
            this.dateTime_pierwsze_zajecia.CustomFormat = "dd.MM.yyyy, HH:mm";
            this.dateTime_pierwsze_zajecia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTime_pierwsze_zajecia.Location = new System.Drawing.Point(117, 78);
            this.dateTime_pierwsze_zajecia.Name = "dateTime_pierwsze_zajecia";
            this.dateTime_pierwsze_zajecia.Size = new System.Drawing.Size(141, 20);
            this.dateTime_pierwsze_zajecia.TabIndex = 22;
            // 
            // btn_dodaj_zajęcia
            // 
            this.btn_dodaj_zajęcia.Location = new System.Drawing.Point(5, 144);
            this.btn_dodaj_zajęcia.Name = "btn_dodaj_zajęcia";
            this.btn_dodaj_zajęcia.Size = new System.Drawing.Size(75, 23);
            this.btn_dodaj_zajęcia.TabIndex = 21;
            this.btn_dodaj_zajęcia.Text = "Dodaj";
            this.btn_dodaj_zajęcia.UseVisualStyleBackColor = true;
            // 
            // label_zajecia
            // 
            this.label_zajecia.AutoSize = true;
            this.label_zajecia.Location = new System.Drawing.Point(73, 28);
            this.label_zajecia.Name = "label_zajecia";
            this.label_zajecia.Size = new System.Drawing.Size(42, 13);
            this.label_zajecia.TabIndex = 19;
            this.label_zajecia.Text = "Zajęcia";
            // 
            // label_czestosc
            // 
            this.label_czestosc.AutoSize = true;
            this.label_czestosc.Location = new System.Drawing.Point(65, 110);
            this.label_czestosc.Name = "label_czestosc";
            this.label_czestosc.Size = new System.Drawing.Size(50, 13);
            this.label_czestosc.TabIndex = 19;
            this.label_czestosc.Text = "Częstość";
            // 
            // label_data_pierwszych_zajec
            // 
            this.label_data_pierwszych_zajec.AutoSize = true;
            this.label_data_pierwszych_zajec.Location = new System.Drawing.Point(2, 82);
            this.label_data_pierwszych_zajec.Name = "label_data_pierwszych_zajec";
            this.label_data_pierwszych_zajec.Size = new System.Drawing.Size(113, 13);
            this.label_data_pierwszych_zajec.TabIndex = 19;
            this.label_data_pierwszych_zajec.Text = "Data pierwszych zajęć";
            // 
            // cb_czestosc
            // 
            this.cb_czestosc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_czestosc.FormattingEnabled = true;
            this.cb_czestosc.Items.AddRange(new object[] {
            "Co tydzień",
            "Co dwa tygodnie"});
            this.cb_czestosc.Location = new System.Drawing.Point(117, 107);
            this.cb_czestosc.Name = "cb_czestosc";
            this.cb_czestosc.Size = new System.Drawing.Size(121, 21);
            this.cb_czestosc.TabIndex = 3;
            // 
            // label_sala
            // 
            this.label_sala.AutoSize = true;
            this.label_sala.Location = new System.Drawing.Point(87, 54);
            this.label_sala.Name = "label_sala";
            this.label_sala.Size = new System.Drawing.Size(28, 13);
            this.label_sala.TabIndex = 19;
            this.label_sala.Text = "Sala";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(773, 410);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Przeglądanie obecności";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // stoper
            // 
            this.stoper.Interval = 1000;
            this.stoper.Tick += new System.EventHandler(this.stoper_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabObecnosc.ResumeLayout(false);
            this.tabObecnosc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lista_studentow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_zajęcia)).EndInit();
            this.gb_dodawanieZajęć.ResumeLayout(false);
            this.gb_dodawanieZajęć.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabObecnosc;
        private System.Windows.Forms.DataGridView dgv_lista_studentow;
        private System.Windows.Forms.ListView lv_nastepne_zajecia;
        private System.Windows.Forms.ListView lv_aktualne_zajecia;
        private System.Windows.Forms.Button btn_usun_zaznaczone;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label lb_sekundy;
        private System.Windows.Forms.Label lb_minuty;
        private System.Windows.Forms.Label lb_dwukropek;
        private System.Windows.Forms.Label lb_stoper_min;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_pozostaly_czas;
        private System.Windows.Forms.Button btn_zapisz;
        private System.Windows.Forms.Button btn_zakoncz;
        private System.Windows.Forms.Button btn_rozpocznij;
        private System.Windows.Forms.Label lb_imie_nazwisko_zalogowanego;
        private System.Windows.Forms.Label kalendarz;
        private System.Windows.Forms.Label zegar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_zajęcia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazwa_zajęć;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sala;
        private System.Windows.Forms.DataGridViewTextBoxColumn Czas;
        private System.Windows.Forms.DataGridViewTextBoxColumn DzienTygodnia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tydzień;
        private System.Windows.Forms.GroupBox gb_dodawanieZajęć;
        private System.Windows.Forms.DateTimePicker dateTime_pierwsze_zajecia;
        private System.Windows.Forms.Button btn_dodaj_zajęcia;
        private System.Windows.Forms.Label label_zajecia;
        private System.Windows.Forms.Label label_czestosc;
        private System.Windows.Forms.Label label_data_pierwszych_zajec;
        private System.Windows.Forms.ComboBox cb_czestosc;
        private System.Windows.Forms.Label label_sala;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer stoper;
        private System.Windows.Forms.TextBox tb_numer_sali;
        private System.Windows.Forms.Label label_nazwa_przedmiotu;
        private System.Windows.Forms.TextBox tb_budynek;
        private System.Windows.Forms.Button btn_dodaj_sale;
        private System.Windows.Forms.Label label_budynek;
        private System.Windows.Forms.Label label_numer_sali;
        private System.Windows.Forms.TextBox tb_nazwa_przedmiotu;
        private System.Windows.Forms.Button btn_dodaj_przedmiot;
        private System.Windows.Forms.ComboBox cb_sala;
        private System.Windows.Forms.ComboBox cb_zajecia;
    }
}

