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

            /*Pobranie imienia i nazwiska zalogowanego*/
            wykladowca = conjuring.Wykladowca.Where(w => w.Login_uz == login).SingleOrDefault();
            lb_imie_nazwisko_zalogowanego.Text = "Zalogowany jako: " + wykladowca.Imie + " " + wykladowca.Nazwisko;

            /* Poprawienie formatu wyświetlania czasu w komórkach - wyświetlanie sekund */
            dgv_lista_studentow.DefaultCellStyle.Format = "dd /MM/yyyy hh:mm:ss";


            /* Odświeżenie wartości w comboboxie */
            CourseComboBox.DataSource = databaseController.GetSubjects(conjuring, connection, wykladowca);

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

                refreshStudentList();
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
                    refreshStudentList();
                }
                
            }
            else
            {
                MessageBox.Show("Lista studentów jest pusta.", "Uwaga", MessageBoxButtons.OK);
            }
        }

        ///<summary>Odświeżanie listy zarejestrowanych studentów.</summary>
        private void refreshStudentList()
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

            CurrentIndex = -1;
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
            refreshStudentList();
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
            dgv_zajęcia.Rows[0].Cells[0].Value = cb_zajecia.Text;
            dgv_zajęcia.Rows[0].Cells[1].Value = cb_sala.Text;

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


            dgv_zajęcia.Rows[0].Cells[2].Value = godziny + ":" + minuty;
            databaseController.InsertZajecia(conjuring, connection, wykladowca, przedmiot, sala, data, tydzien);
            dgv_zajęcia.Rows[0].Cells[3].Value = data.ToString("dddd", new CultureInfo("pl-PL"));
            dgv_zajęcia.Rows[0].Cells[4].Value = cb_czestosc.Text;
        }

        /// <summary>Dodawanie nowego obiektu przedmiotu do bazy danych</summary>
        private void btn_dodaj_przedmiot_Click(object sender, EventArgs e)
        {
            databaseController.InsertPrzedmiot(conjuring, connection, tb_nazwa_przedmiotu.Text);
            RefreshComboBoxes();
        }

        /// <summary>Dodawanie nowego obiektu sali do bazy danych</summary>
        private void btn_dodaj_sale_Click(object sender, EventArgs e)
        {
            databaseController.InsertSala(conjuring, connection,tb_numer_sali.Text, tb_budynek.Text);
            RefreshComboBoxes();
        }

        private void RefreshComboBoxes() {
            //sale
            cb_sala.Items.Clear();
            List<Sala> sale = databaseController.ListSala(conjuring);
            foreach (Sala x in sale)
            {
                cb_sala.Items.Add(x.Numer + "-" + x.Budynek);
            }

            //przedmioty
            cb_zajecia.Items.Clear();
            List<Przedmiot> przedmioty = databaseController.ListPrzedmiot(conjuring);
            foreach (Przedmiot x in przedmioty)
            {
                cb_zajecia.Items.Add(x.Nazwa);
            }
        }

        // Zakładka - Generowanie raportów

        private void button2_Click(object sender, EventArgs e)
        {
            GenerateRaportDataGrid.DataSource = databaseController.GetObecnosc(conjuring, connection).OrderBy(o => o.Data).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textfileConstructor.SetParams(GetParamsFromUI());
            if (CsvRadioButton.Enabled)
            {
                List<Obecnosc> list = (List<Obecnosc>)GenerateRaportDataGrid.DataSource;
                textfileConstructor.ObecnoscToCSV(list);
            }
        }

        private TextfileConstructorParams GetParamsFromUI()
        {
            TextfileConstructorParams tfc_params = new TextfileConstructorParams();
            tfc_params.SubjectName = CourseComboBox.Text;
            tfc_params.DateFrom = RaportDateFromPicker.Value;
            tfc_params.DateTo = RaportDateToPicker.Value;
            tfc_params.Late = RaportLateCheckBox.Checked;
            tfc_params.Notes = RaportNotesCheckBox.Checked;
            return tfc_params;
        }

        private void CourseComboBox_DropDown(object sender, EventArgs e)
        {
        }
    }
}
