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
namespace pt_legitymacjestudenckie
{

    public partial class MainForm : Form
    {
        private bool timerIsActive = false;
        private StudentRecorder studentRecorder;
        SqlConnection connection = new SqlConnection(@"Data Source=conjuringserv.database.windows.net;Initial Catalog=TheConjuring_db;Integrated Security=False;User ID=Kierownik;Password=KieraS_246;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        /* Aby zaznaczać cały wiersz w tabeli obecności */
        private int CurrentIndex;

        TheConjuring_dbEntities1 conjuring = new TheConjuring_dbEntities1();
        public MainForm(string login)
        {
            InitializeComponent();

            studentRecorder = new StudentRecorder();
            studentRecorder.Initialize();

            CurrentIndex = -1;

            /*Pobranie imienia i nazwiska zalogowanego*/
            string pom = "Select Imie, Nazwisko from Wykladowca Where Login_uz='" + login + "'" ;
            SqlDataAdapter sda = new SqlDataAdapter(pom, connection);
            DataTable table = new DataTable();
            sda.Fill(table);
            string imie = table.Rows[0][0].ToString();
            string nazwisko = table.Rows[0][1].ToString();

            /* Poprawienie formatu wyświetlania czasu w komórkach - wyświetlanie sekund */

            dgv_lista_studentow.DefaultCellStyle.Format = "dd /MM/yyyy hh:mm:ss";
            lb_imie_nazwisko_zalogowanego.Text = "Zalogowany jako: " + imie + " " + nazwisko;

            /*Wykladowca wy = new Wykladowca
            {
                Imie = "Jakub",
                Nazwisko = "Dutkiewicz",
                Login_uz = "Dudi1",
                Haslo = "LigoLego"

            };
            connection.Open();
            conjuring.Wykladowca.Add(wy);
            conjuring.SaveChanges();
            connection.Close();*/

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setCurrentTime();
            btn_zakoncz.Enabled = false;
            lb_minuty.Visible = false;
            lb_sekundy.Visible = false;
            lb_dwukropek.Visible = false;
            btn_rozpocznij.Enabled = true;
            timer1.Start();
        }

        private void btn_rozpocznij_Click(object sender, EventArgs e)
        {
            /*Uruchomienie stopera, wyświetlenie licznika, ukrycie co niepotrzebne*/
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            setCurrentTime();
        }

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

        private void btn_zakoncz_Click(object sender, EventArgs e)
        {
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

        private void btn_zapisz_Click(object sender, EventArgs e)
        {

        }

        /* ======================================================================== */
        /* metody do odświeżania elementów GUI */
        
        private void refreshStudentList()
        {
            /* Odświeżanie listy zarejestrowanych studentów */
            dgv_lista_studentow.DataSource = studentRecorder.lStudInfo.ToList();

            if (CurrentIndex != -1)
                dgv_lista_studentow.Rows[CurrentIndex].Selected = true;

            dgv_lista_studentow.Refresh();

        }


        /*Zamknięcie procesu, podczas zamykania formy*/
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);}

        private void btn_dodaj_zajęcia_Click(object sender, EventArgs e)
        {
            dgv_zajęcia.Rows[0].Cells[0].Value = cb_zajecia.Text;
            dgv_zajęcia.Rows[0].Cells[1].Value = cb_sala.Text;

            DateTime data = Convert.ToDateTime(dateTime_pierwsze_zajecia.Text);
            string minuty = Convert.ToString(data.Minute);
            string godziny = Convert.ToString(data.Hour);
            if (minuty.Length < 2) minuty = "0" + minuty;
            if (godziny.Length < 2) godziny = "0" + godziny;
            dgv_zajęcia.Rows[0].Cells[2].Value = godziny + ":" + minuty;

            dgv_zajęcia.Rows[0].Cells[3].Value = data.ToString("dddd", new CultureInfo("pl-PL"));
            dgv_zajęcia.Rows[0].Cells[4].Value = cb_czestosc.Text;
        }

        private void btn_dodaj_przedmiot_Click(object sender, EventArgs e)
        {

        }

        private void btn_dodaj_sale_Click(object sender, EventArgs e)
        {
            SalaManagement sm = new SalaManagement();
            sm.InsertSala(tb_numer_sali.Text, tb_numer_sali.Text);
        }

        private void cb_sala_Click(object sender, EventArgs e)
        {

        }

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
    }
}
