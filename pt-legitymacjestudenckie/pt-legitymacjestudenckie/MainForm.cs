using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pt_legitymacjestudenckie.SmartCardRelated;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Globalization;
using System.IO;

namespace pt_legitymacjestudenckie
{

    public partial class MainForm : Form
    {
        /// <summary>Informuje, czy stoper odpowiadający za liczenie pozostałego czasu do sprawdzania obecności jest aktywny.</summary>
        private bool timerIsActive = false;

        // Adapter do obsługi czytnika kart
        private StudentRecorder studentRecorder;

        // Kontroler zakładki generowania raportów
        private TextfileConstructor textfileConstructor;

        //Inicjalizacja połączenia
        SqlConnection connection = new SqlConnection(@"Data Source=conjuringserv.database.windows.net;Initial Catalog=TheConjuring_db;Integrated Security=False;User ID=Kierownik;Password=KieraS_246;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
		TheConjuring_dbEntities1 conjuring = new TheConjuring_dbEntities1();
        DatabaseController databaseController;

        // informacje o wykladowcy i zajeciach
        Wykladowca wykladowca;
		
        /* Aby zaznaczać cały wiersz w tabeli obecności */
        private int CurrentIndex;

        public MainForm(string login){
            InitializeComponent();
            databaseController = new DatabaseController();
            textfileConstructor = new TextfileConstructor();

            /*Stworzenie nowego obiektu StudentRecorder*/
            studentRecorder = new StudentRecorder();
            studentRecorder.Initialize();
            CurrentIndex = -1;
            studentRecorder.ReadedWithSuccess += RefreshStudentGridView;

            /*Pobranie imienia i nazwiska zalogowanego*/
            wykladowca = conjuring.Wykladowca.Where(w => w.Login_uz == login).SingleOrDefault();
            lb_imie_nazwisko_zalogowanego.Text = "Zalogowany jako: " + wykladowca.Imie + " " + wykladowca.Nazwisko;

            /* Poprawienie formatu wyświetlania czasu w komórkach - wyświetlanie sekund */
            dgv_lista_studentow.DefaultCellStyle.Format = "dd /MM/yyyy hh:mm:ss";

            /* Wypełnienie comboboxów w zakładce Edytor zajęć*/
            RefreshComboBoxes();

            /* Wypełnienie comboboxów w zakładce Przeglądanie obecności*/
            RefreshComboboxes_PrzegladanieObecnosci();

            /* Odświeżenie listy zajęć w zakładce Edytor zajęć */
            Refresh_dvg_zajecia();
            UstawZajecia();
        }


        /// <summary>Ustawienie wartości domyślnych</summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            setCurrentTime();
            btn_zakoncz.Enabled = false;
            lb_minuty.Visible = false;
            lb_sekundy.Visible = false;
            lb_dwukropek.Visible = false;
            btn_rozpocznij.Enabled = true;
            timer1.Start();
        }
		
    //<ZAKŁADKA: Sprawdzanie obecności>

        /// <summary> Rozpoczyna odliczanie stopera, uruchamia czytnik. </summary>
        private void btn_rozpocznij_Click(object sender, EventArgs e)
        {
            /*Uruchomienie stopera, wyświetlenie licznika, ukrycie wyboru minut*/
            timerIsActive = true;
            btn_rozpocznij.Enabled = false;
            btn_zakoncz.Enabled = true;
            numericUpDown.Visible = false;
            lb_stoper_min.Visible = false;
            lb_minuty.Visible = true;
            lb_sekundy.Visible = true;
            lb_dwukropek.Visible = true;
            int minuty = (int)numericUpDown.Value;
            if (minuty < 10) lb_minuty.Text = "0" + minuty.ToString();
            else lb_minuty.Text = minuty.ToString();
            lb_sekundy.Text = "00";
            stoper.Start();

            /*Rozpoczęcie czytania kart */
            studentRecorder.OpenRecorder(minuty*60);
        }

        /// <summary> Timer o okresie 1s, potrzebny do wyświetlania aktualnego czasu.</summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            setCurrentTime();
        }

        /// <summary>Ustawia wartości aktualnych i następnych zajęć w zakładce Sprawdzanie obecności</summary>
        private void UstawZajecia()
        {
            try
            {
                lv_aktualne_zajecia.Clear();
                Zajecia_pojedyncze zajecia = databaseController.GetZajecia_Pojedyncze(conjuring, connection, wykladowca);
                lv_aktualne_zajecia.Items.Add(zajecia.Zajecia.Przedmiot.Nazwa);
                lv_aktualne_zajecia.Items.Add(zajecia.Zajecia.Sala.Numer + " " + zajecia.Zajecia.Sala.Budynek);
                lv_aktualne_zajecia.Items.Add(zajecia.Data_zajec.ToShortTimeString());
            }
            catch(Exception ex)
            {
                return;
            }
        }

        /// <summary>Pobranie aktualnego czasu systemowego, przeparsowanie 
        /// do odpowiedniego formatu oraz wyświetlenie w zakładce "Sprawdzanie obecności".</summary>
        private void setCurrentTime()
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;
            int dd = DateTime.Now.Day;
            int mon = DateTime.Now.Month;
            int yy = DateTime.Now.Year;
            string time = "";
            string date = "";
            if (hh < 10) { time += "0" + hh; } else { time += hh; }
            time += ":";
            if (mm < 10) { time += "0" + mm; } else { time += mm; }
            time += ":";
            if (ss < 10) { time += "0" + ss; } else { time += ss; }
            if (dd < 10) { date += "0" + dd; } else { date += dd; }
            date += ".";
            if (mon < 10) { date += "0" + mon; } else { date += mon; }
            date += ".";
            date += yy;
            zegar.Text = time;
            kalendarz.Text = date;
        }

        ///<summary>Odświeżanie czasu pozostałego do sprawdzania obecności oraz listy obecnych studentów.</summary>
        private void stoper_Tick(object sender, EventArgs e)
        {
            if (timerIsActive == true)
            {
                int minuty = Convert.ToInt32(lb_minuty.Text);
                int sekundy = Convert.ToInt32(lb_sekundy.Text);
                if (minuty <= 0 && sekundy <= 0)
                {
                    btn_zakoncz_Click(sender, e);
                }
                if (sekundy <= 0) { sekundy = 60; minuty--; }
                sekundy--;
                if (minuty < 10) lb_minuty.Text = "0" + minuty.ToString();
                else lb_minuty.Text = minuty.ToString();
                if (sekundy < 10) lb_sekundy.Text = "0" + sekundy.ToString();
                else lb_sekundy.Text = sekundy.ToString();

            }
        }
		
        /// <summary>Zatrzymanie stopera, ukrycie odliczanego czasu.</summary>
        private void btn_zakoncz_Click(object sender, EventArgs e) {
            lb_minuty.Visible = false;
            lb_sekundy.Visible = false;
            lb_dwukropek.Visible = false;
            lb_stoper_min.Visible = true;
            btn_rozpocznij.Enabled = true;
            btn_zakoncz.Enabled = false;
            numericUpDown.Visible = true;
            stoper.Stop();
            timerIsActive = false;

            studentRecorder.StopRecorder();
        }

        /// <summary> Zapisanie listy studentów w bazie danych.</summary>
        private void btn_zapisz_Click(object sender, EventArgs e)
        {
            if (studentRecorder.GetListLength() > 0)
            {
                Zajecia_pojedyncze _zajecia = databaseController.GetZajecia_Pojedyncze(conjuring, connection, wykladowca);
                if (_zajecia == null)
                    MessageBox.Show("Lista studentów jest pusta.", "Uwaga", MessageBoxButtons.OK);
                else
                {
                    foreach (StudentInfo stud in studentRecorder.lStudInfo)
                        databaseController.InsertObecnosc(conjuring, connection, stud, _zajecia);

                    studentRecorder.lStudInfo.Clear();
                    CurrentIndex = -1;
                    RefreshStudentGridViewOnce();
                }
                
            }
            else
            {
                MessageBox.Show("Lista studentów jest pusta.", "Uwaga", MessageBoxButtons.OK);
            }
        }

        ///<summary>Odświeżanie listy zarejestrowanych studentów.</summary>
        delegate void RefreshStudentInfosGridViewDelegate();
        private void RefreshStudentGridView()
        {
            if (this.dgv_lista_studentow.InvokeRequired)
            {
                RefreshStudentInfosGridViewDelegate d = new RefreshStudentInfosGridViewDelegate(RefreshStudentGridView);
                this.Invoke(d, new object[] { });
            }
            else
            {
                dgv_lista_studentow.DataSource = studentRecorder.lStudInfo.ToList();

                if (CurrentIndex != -1)
                    dgv_lista_studentow.Rows[CurrentIndex].Selected = true;

                dgv_lista_studentow.Refresh();
            }
        }

        private void RefreshStudentGridViewOnce()
        {
            dgv_lista_studentow.DataSource = studentRecorder.lStudInfo.ToList();

            if (CurrentIndex != -1)
                dgv_lista_studentow.Rows[CurrentIndex].Selected = true;

            dgv_lista_studentow.Refresh();
        }

        /// <summary>W ComboBox "Wybrany student" wyświetla informacje o wybranym studencie w liście studentów.</summary>
        private void dgv_lista_studentow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentIndex = dgv_lista_studentow.CurrentRow.Index;
            dgv_lista_studentow.Rows[CurrentIndex].Selected = true;

            StudentNameLabel.Text = "Imię i nazwisko: " +
                dgv_lista_studentow.CurrentRow.Cells[0].Value.ToString() + " " +
                dgv_lista_studentow.CurrentRow.Cells[1].Value.ToString();
            IndexLabel.Text = dgv_lista_studentow.CurrentRow.Cells[2].Value.ToString();
            LateCheckBox.Checked = (bool)dgv_lista_studentow.CurrentRow.Cells[3].Value;

            NoteRichTextBox.Clear();
            NoteRichTextBox.Text = dgv_lista_studentow.CurrentRow.Cells[4].Value.ToString();
        }

        /// <summary>Zapisanie edytowanych informacji o studencie.</summary>
        private void ApplyStudentInformation_Button_Click(object sender, EventArgs e)
        {
            bool late = LateCheckBox.Checked;
            string note = NoteRichTextBox.Text;
            string index = IndexLabel.Text;

            StudentInfo stud = studentRecorder.GetStudentByIndex(index);
            if (stud == null)
                MessageBox.Show("Studenta nie ma na liście.", "Uwaga!", MessageBoxButtons.OK);
            else
            {
                stud.late = late;
                stud.note = note;
                studentRecorder.UpdateStudent(stud);
            }

            //CurrentIndex = -1;
            RefreshStudentGridViewOnce();
        }
        private void btn_usun_zaznaczone_Click(object sender, EventArgs e)
        {
            string index = IndexLabel.Text;

            StudentInfo stud = studentRecorder.GetStudentByIndex(index);
            if (stud == null)
                MessageBox.Show("Studenta nie ma na liście.", "Uwaga!", MessageBoxButtons.OK);
            else
                studentRecorder.RemoveStudent(stud);

            CurrentIndex = -1;
            RefreshStudentGridViewOnce();
        }

        ///<summary>Zamknięcie procesu, podczas zamykania formy.</summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
        }
		
    //</ZAKŁADKA: Sprawdzanie obecności>

    //<ZAKŁADKA: Edytor zajęć>

        /// <summary>Dodawanie nowego obiektu zajęć do bazy danych</summary>
        private void btn_dodaj_zajęcia_Click(object sender, EventArgs e)
        {
            DateTime data = Convert.ToDateTime(dateTime_pierwsze_zajecia.Value);
            string minuty = Convert.ToString(data.Minute);
            string godziny = Convert.ToString(data.Hour);
            if (minuty.Length < 2) minuty = "0" + minuty;
            if (godziny.Length < 2) godziny = "0" + godziny;

            Przedmiot przedmiot = conjuring.Przedmiot.Where(o => (o.Nazwa == cb_zajecia.Text)).FirstOrDefault();

            String sala_zczytane = cb_sala.Text;
            Char delimiter = '-';
            String[] substrings = sala_zczytane.Split(delimiter);
            string pom1 = substrings[0];
            string pom2 = substrings[1];
            Sala sala = conjuring.Sala.Where(o => (o.Numer == pom1&& o.Budynek==pom2)).FirstOrDefault();
            bool tydzien = false;
            string tydzien_zczyatane = cb_czestosc.Text;
            if (tydzien_zczyatane == "Co tydzien") tydzien = false;
            else if (tydzien_zczyatane == "Co dwa tygodnie") tydzien = true;

            databaseController.InsertZajecia(conjuring, connection, wykladowca, przedmiot, sala, data, tydzien);
            Refresh_dvg_zajecia();
            RefreshComboboxes_PrzegladanieObecnosci();
        }

        /// <summary> Odświeżanie listy zajęć w edytorze zajęć </summary>
        private void Refresh_dvg_zajecia()
        {
            DateTime data = new DateTime();
            List<Zajecia> zajecia = databaseController.ListZajec(conjuring,connection, wykladowca);
 
            dgv_zajęcia.Rows.Clear();
            foreach (var x in zajecia)
            {
                data = Convert.ToDateTime(x.Czas);
                dgv_zajęcia.Rows.Add(x.Przedmiot.Nazwa, x.Sala.Numer, data.ToShortTimeString(), data.ToString("dddd", new CultureInfo("pl-PL")), data.ToShortDateString());
            }
        }
 
        /// <summary>Dodawanie nowego obiektu przedmiotu do bazy danych</summary>
        private void btn_dodaj_przedmiot_Click(object sender, EventArgs e)
        {
            try
            {
                databaseController.InsertPrzedmiot(conjuring, connection, tb_nazwa_przedmiotu.Text);
                RefreshComboBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     
       
        
        /// <summary>Dodawanie nowego obiektu sali do bazy danych</summary>
        private void btn_dodaj_sale_Click(object sender, EventArgs e)
        {
            try
            {
                databaseController.InsertSala(conjuring, connection, tb_numer_sali.Text, tb_budynek.Text);
                RefreshComboBoxes();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>Aktualizacja obiektu sali w bazie danych</summary>
        private void btn_aktualizuj_sale_Click(object sender, EventArgs e)
        {

        }

        private void RefreshComboBoxes()
        {
            // Pobranie zajęć do comboboxa w zakładce generowanie raportów
            CourseComboBox.Items.Clear();
            List<Zajecia> zajecia = databaseController.ListZajec(conjuring, connection, wykladowca);
            CourseComboBox.DataSource = zajecia;
            CourseComboBox.DisplayMember = "DisplayName";

            //sale
            cb_sala.Items.Clear();
            List<Sala> sale = databaseController.ListSala(conjuring);
            foreach (Sala x in sale)
            {
                cb_sala.Items.Add(x.Numer + "-" + x.Budynek);
            }

            //przedmioty
            cb_zajecia.Items.Clear();
            List<Przedmiot> przedmioty = databaseController.ListPrzedmiot_Zalogowanego(conjuring, wykladowca);
            foreach (Przedmiot x in przedmioty)
            {
                cb_zajecia.Items.Add(x.Nazwa);
            }
        }

        // Zakładka - Generowanie raportów

        // Przycisk podglądu tabeli przed zapisaniem
        private void button2_Click(object sender, EventArgs e)
        {
            GenerateRaportDataGrid.DataSource = GetDataForFile();
            if (GenerateRaportDataGrid.DataSource == null)
                MessageBox.Show("Nie wybrano trybu wyświetlania, lub nie zarejestrowano żadnych obecności.", "Wiadomość", MessageBoxButtons.OK);
        }

        // Przycisk inicjujący zapisanie danych do pliku
        private void button1_Click(object sender, EventArgs e)
        {
            textfileConstructor.SetParams(GetParamsFromUI());
            if (CsvRadioButton.Checked)
            {
                var list = GetDataForFile();
                textfileConstructor.ObecnoscToCSV(list);

                MessageBox.Show("Ukończono zapisywanie pliku.", "Wiadomość", MessageBoxButtons.OK);
            }
            else if (PdfRadioButton.Checked)
            {
                var list = GetDataForFile();
                textfileConstructor.ObecnoscToPDF(list);

                MessageBox.Show("Ukończono zapisywanie pliku.", "Wiadomość", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Nie wybrano formatu zapisu.", "Wiadomość", MessageBoxButtons.OK);
        }

        // Zebranie danych z wejść do obiektu z parametrami klasy TextfileConstructor
        private TextfileConstructorParams GetParamsFromUI()
        {
            TextfileConstructorParams tfc_params = new TextfileConstructorParams
            {
                SubjectName = CourseComboBox.Text,
                DateFrom = RaportDateFromPicker.Value,
                DateTo = RaportDateToPicker.Value,
                Late = RaportLateCheckBox.Checked,
                Notes = RaportNotesCheckBox.Checked
            };
            return tfc_params;
        }

        // Pobranie danych do zapisu z bazy danych
        private DataTable GetDataForFile()
        {
            TextfileConstructorParams tfc_params = GetParamsFromUI();
            textfileConstructor.SetParams(tfc_params);

            Zajecia zajecia = (Zajecia)CourseComboBox.SelectedItem;
            if (zajecia == null)
            {
                MessageBox.Show("Prosze wybrać zajęcia.");
                return null;
            }
            else
            {
                Zajecia z = (Zajecia) CourseComboBox.SelectedItem;

                switch (CheckExportType())
                {
                    case ExportType.GRID:
                        return databaseController.Obecni_pomiedzy(conjuring, connection, zajecia, tfc_params.DateFrom, tfc_params.DateTo);
                    case ExportType.TABLE:
                        var list = databaseController.GetObecnosc(conjuring, connection)
                            .Where(o => o.Data >= tfc_params.DateFrom && o.Data <= tfc_params.DateTo)
                            .Where(o => o.Zajecia_pojedyncze.Id_Zajec == z.Id_Zajec)
                            .OrderBy(o => o.Data).ToList();
                        return textfileConstructor.ConstructObecnoscList(list);
                    default:
                        return null;
                }
               
            }
        }

        // Zebranie z wejść RadioButton informacji o wybranym trybie zapisu
        private ExportType CheckExportType()
        {
            if (RadioTabel.Checked)
                return ExportType.TABLE;
            else if (RadioGrid.Checked)
                return ExportType.GRID;
            else
                return ExportType.UNKNOWN;
        }


        private void CourseComboBox_DropDown(object sender, EventArgs e)
        {
        }


        //<ZAKŁADKA: Przeglądanie obecności>

        /// <summary> Wyszukuje obecności na podstawie ustawionych parametrów w zakładce Przeglądanie obecności </summary>
        private void btn_szukaj_obecnosci_Click(object sender, EventArgs e)
        {
            List<Przedmiot> przedmioty = databaseController.ListPrzedmiot_Zalogowanego(conjuring, wykladowca);
            List<Obecnosc> studenci = databaseController.GetObecnosc(conjuring, connection);
            Przedmiot przedmiot = null;
            Student student = null;
            DateTime data, data_od, data_do;
            //Przygotowanie daty w zakresie której będzie sprawdzana obecność
            data = cb_data_przegladanie.Value;
            data_od = new DateTime(data.Year, data.Month, data.Day, 0, 0, 0, 0);
            data_do = new DateTime(data.Year, data.Month, data.Day, 23, 59, 59, 0);

            //Przygotowanie obiektu studenta do sprawdzenia
            if (cb_student_przegladanie.Text != "")
            {
                string index_str = cb_student_przegladanie.Text;
                index_str = index_str.Split('(', ')')[1];
                int Index = Convert.ToInt32(index_str);
                student = conjuring.Student.Where(o => (o.Indeks == Index)).FirstOrDefault();
            }
            //Przygotowanie obiektu przedmiotu do sprawdzenia
            if (cb_przedmiot_przegladanie.Text != "")
            {
                przedmiot = conjuring.Przedmiot.Where(o => (o.Nazwa == cb_przedmiot_przegladanie.Text)).FirstOrDefault();
            }

            //Rozpatrzenie wszystkich przypadków podania parametrów:
            if (cb_przedmiot_przegladanie.Text == "" && cb_student_przegladanie.Text == "")
            {
                MessageBox.Show("Wprowadź wartość do co najmniej jednego pola!", "Uwaga!");
            }

            else if (cb_przedmiot_przegladanie.Text != "" && cb_uwzglednij_date.Checked == false && cb_student_przegladanie.Text == "")
            {
                dgv_lista_obecnosci.DataSource = databaseController.Lista_Obecnosci(conjuring, connection, przedmiot, wykladowca);
            }
            else if (cb_przedmiot_przegladanie.Text != "" && cb_uwzglednij_date.Checked == true && cb_student_przegladanie.Text == "")
            {
                dgv_lista_obecnosci.DataSource = databaseController.Lista_Obecnosci(conjuring, connection, przedmiot, data_od, data_do, wykladowca);
            }
            else if (cb_przedmiot_przegladanie.Text != "" && cb_uwzglednij_date.Checked == false && cb_student_przegladanie.Text != "")
            {
                dgv_lista_obecnosci.DataSource = databaseController.Lista_Obecnosci(conjuring, connection, przedmiot, student, wykladowca);
            }
            else if (cb_przedmiot_przegladanie.Text != "" && cb_uwzglednij_date.Checked == true && cb_student_przegladanie.Text != "")
            {
                dgv_lista_obecnosci.DataSource = databaseController.Lista_Obecnosci(conjuring, connection, przedmiot, data_od, data_do, student, wykladowca);
            }
            else if (cb_przedmiot_przegladanie.Text == "" && cb_uwzglednij_date.Checked == false && cb_student_przegladanie.Text != "")
            {
                dgv_lista_obecnosci.DataSource = databaseController.Lista_Obecnosci(conjuring, connection, student, wykladowca);
            }
            else if (cb_przedmiot_przegladanie.Text == "" && cb_uwzglednij_date.Checked == true && cb_student_przegladanie.Text != "")
            {
                dgv_lista_obecnosci.DataSource = databaseController.Lista_Obecnosci(conjuring, connection, data_od, data_do, student, wykladowca);
            }
        }




        /// <summary> Odświeża zawartość comboboxów w zakładce Przeglądanie obecności </summary>
        private void RefreshComboboxes_PrzegladanieObecnosci()
        {
            cb_przedmiot_przegladanie.Items.Clear();
            cb_student_przegladanie.Items.Clear();
            List<Przedmiot> przedmioty = databaseController.ListPrzedmiot_Zalogowanego(conjuring, wykladowca);
            foreach (Przedmiot x in przedmioty)
            {
                cb_przedmiot_przegladanie.Items.Add(x.Nazwa);
            }
            List<Obecnosc> studenci = databaseController.GetObecnosc(conjuring, connection);
        
            foreach (Obecnosc x in studenci)
            {

                if (!cb_student_przegladanie.Items.Contains(x.Student.Imie + " " + x.Student.Nazwisko + " (" + x.Student.Indeks + ")"))
                {
                    cb_student_przegladanie.Items.Add(x.Student.Imie + " " + x.Student.Nazwisko + " (" + x.Student.Indeks + ")");
                }
            }

        }

        /// <summary>Sprawdzenie czy użytkownik chce uwzględnić datę podczas przeglądania obecności </summary>
        private void cb_uwzglednij_date_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_uwzglednij_date.Checked) cb_data_przegladanie.Enabled = true;
            else cb_data_przegladanie.Enabled = false;
        }

        private void btn_edytuj_zajęcia_Click(object sender, EventArgs e)
        {
            ZajeciaForm zajeciaForm = new ZajeciaForm(conjuring, connection, wykladowca);
            zajeciaForm.Show();
        }
    }
}
