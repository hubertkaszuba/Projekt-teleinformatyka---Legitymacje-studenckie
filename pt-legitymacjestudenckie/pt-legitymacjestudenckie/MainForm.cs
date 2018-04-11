﻿using System;
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
namespace pt_legitymacjestudenckie
{

    public partial class MainForm : Form
    {
        private bool timerIsActive = false;
        private StudentRecorder studentRecorder;
        SqlConnection connection = new SqlConnection(@"Data Source=conjuringserv.database.windows.net;Initial Catalog=TheConjuring_db;Integrated Security=False;User ID=Kierownik;Password=KieraS_246;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        
        TheConjuring_dbEntities1 conjuring = new TheConjuring_dbEntities1();
        public MainForm(string login)
        {
            InitializeComponent();

            studentRecorder = new StudentRecorder();
            studentRecorder.Initialize();

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
           
            /* Wykladowca wy = new Wykladowca
            {
                Imie = "Jan",
                Nazwisko = "Testowy",
                Haslo = "zimaLato",
                Login_uz = "test12"

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

            /*
            int j = 0;
            foreach(StudentInfo si in studentRecorder.lStudInfo)
            {
                dgv_lista_studentow.Rows[j].Cells[0].Value = si.firstName;
                dgv_lista_studentow.Rows[j].Cells[1].Value = si.lastName;
                dgv_lista_studentow.Rows[j].Cells[2].Value = si.index;
                dgv_lista_studentow.Rows[j].Cells[3].Value = si.timestamp.ToString();
                j++;
            }
            */
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

                /* Odświeżanie listy zarejestrowanych studentów */
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
            dgv_lista_studentow.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_lista_studentow.Refresh();
        }

        /*Zamknięcie procesu, podczas zamykania formy*/
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
