using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pt_legitymacjestudenckie
{
    public partial class MainForm : Form
    {
        private bool timerIsActive = false;

        public MainForm()
        {
            InitializeComponent();

            CardReader cr = new CardReader();

            int i = 0;

            cr.Initialize();
            if(cr.Connect())
                i = cr.ReadData();
            cr.Release();
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
    }
}
