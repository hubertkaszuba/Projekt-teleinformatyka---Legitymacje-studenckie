using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pt_legitymacjestudenckie
{
    public partial class ZajeciaForm : Form
    {
        TheConjuring_dbEntities1 conjuring;
        SqlConnection connection;
        Wykladowca wykladowca;
        DatabaseController databaseController;
        List<Zajecia_pojedyncze> lista_zajec_pojedynczych = new List<Zajecia_pojedyncze>();
        Przedmiot przedmiotSzukany;
        public ZajeciaForm(TheConjuring_dbEntities1 conjuring, SqlConnection connection, Wykladowca wykladowca)
        {
            InitializeComponent();
            this.conjuring = conjuring;
            this.connection = connection;
            this.wykladowca = wykladowca;
            databaseController = new DatabaseController();
            RefreshComboboxes_PrzegladanieObecnosci();
        }



        private void btn_szukaj_obecnosci_Click(object sender, EventArgs e)
        {
            Zajecia_pojedyncze zajecia_Pojedyncze = new Zajecia_pojedyncze();
            Zajecia_pojedyncze zajecia_Zedytowane = new Zajecia_pojedyncze();
            Przedmiot przedmiot = null;
            Zajecia zajecia = new Zajecia();
            DateTime data_od, data_do;
        
            
            //Przygotowanie daty w zakresie której będzie sprawdzana obecność
            data_od = cb_data_od.Value;
            data_do = cb_data_do.Value;
            //Przygotowanie obiektu przedmiotu do sprawdzenia
            if (cb_przedmiot_przegladanie.Text != "")
            {
                przedmiot = conjuring.Przedmiot.Where(o => (o.Nazwa == cb_przedmiot_przegladanie.Text)).FirstOrDefault();
            }
            if (cb_przedmiot_przegladanie.Text == "")
            {
                MessageBox.Show("Wypełnij pola!");
            }
            else
            {
                Znajdz_przedmiot_szukany();
                zajecia = przedmiotSzukany.Zajecia.FirstOrDefault();
                lista_zajec_pojedynczych = databaseController.Pojedyncz_od_do(conjuring, cb_data_od.Value, cb_data_do.Value, zajecia, wykladowca);
                dgv_lista_obecnosci.DataSource = FillDataTable(lista_zajec_pojedynczych);
            }

        }
        /// <summary>
        /// Tworzy obiekt tabeli dla zajec_pojedynczych
        /// </summary>
        /// <returns></returns>
        private DataTable Create()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Przedmiot");
            dt.Columns.Add("Data");
            dt.Columns.Add("Godzina");
            dt.Columns.Add("Sala");
            return dt;
        }
        private DataTable FillDataTable(List<Zajecia_pojedyncze> lista_zajec_pojedynczych)
        {
            DataTable dt = Create();

            foreach (Zajecia_pojedyncze s in lista_zajec_pojedynczych)
            {
                DataRow new_row = dt.NewRow();
                new_row["Przedmiot"] = s.Zajecia.Przedmiot.Nazwa;
                new_row["Data"] = s.Data_zajec.ToLongDateString();

                DateTime pom = (DateTime)s.Zajecia.Czas;
                new_row["Godzina"] = pom.ToShortTimeString();
                new_row["Sala"] = s.Zajecia.Sala.Numer + " " + s.Zajecia.Sala.Budynek;
                dt.Rows.Add(new_row);
            }
            return dt;
        }
        /// <summary> Odświeża zawartość comboboxów w zakładce Przeglądanie obecności </summary>
        private void RefreshComboboxes_PrzegladanieObecnosci()
        {
            cb_data_od.Value = DateTime.Now.AddMonths(-1);
            cb_przedmiot_przegladanie.Items.Clear();
            List<Przedmiot> przedmioty = databaseController.ListPrzedmiot_Zalogowanego(conjuring, wykladowca);
            foreach (Przedmiot x in przedmioty)
            {
                cb_przedmiot_przegladanie.Items.Add(x.Nazwa);
            }
            //sale
            cb_sala.Items.Clear();
            List<Sala> sale = databaseController.ListSala(conjuring);
            foreach (Sala x in sale)
            {
                cb_sala.Items.Add(x.Numer + " " + x.Budynek);
            }
        }

        private void Znajdz_przedmiot_szukany()
        {
            List<Przedmiot> przedmioty = databaseController.ListPrzedmiot_Zalogowanego(conjuring, wykladowca);
            Zajecia pom;
            foreach (Przedmiot x in przedmioty)
            {
                pom = x.Zajecia.FirstOrDefault();   
                if(pom.Przedmiot.Nazwa == cb_przedmiot_przegladanie.Text)
                {
                    przedmiotSzukany = x;
                }
            }
        }

        /* Aby zaznaczać cały wiersz w tabeli */
        private int CurrentIndex=0;
        private void dgv_lista_obecnosci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_usun.Enabled = true;
            btn_aktualizuj.Enabled = true;
            CurrentIndex = dgv_lista_obecnosci.CurrentRow.Index;
            data_zajec.Text = dgv_lista_obecnosci.CurrentRow.Cells[1].Value.ToString();
            godzina_zajec.Text = dgv_lista_obecnosci.CurrentRow.Cells[2].Value.ToString();
            cb_sala.SelectedIndex = cb_sala.FindStringExact(dgv_lista_obecnosci.CurrentRow.Cells[3].Value.ToString());
        }

        private void btn_usun_Click(object sender, EventArgs e)
        {
            Zajecia_pojedyncze zajecia_Pojedyncze = lista_zajec_pojedynczych[CurrentIndex];
            try
            {
                //Tutaj wywołanie metody:
                //      NazwaUsuwającejMetody(Zajecia_pojedyncze zajecia_Pojedyncze);
                //Jedynym argumentem przekazywanym ode mnie są zajęcia_Pojedyncze, które są zajęciami zaznaczonymi przez użytkownika w tabeli.
            }
            catch(Exception ex)
            {

            }
        }

        private void btn_aktualizuj_Click(object sender, EventArgs e)
        {
            Zajecia_pojedyncze zajecia_Pojedyncze = lista_zajec_pojedynczych[CurrentIndex];

            DateTime NowaDataZajec = Convert.ToDateTime(data_zajec.Text);
            DateTime NowaGodzinaZajec = Convert.ToDateTime(godzina_zajec.Text);
            
            List<Sala> sale = databaseController.ListSala(conjuring);
            Sala NowaSala = sale[cb_sala.SelectedIndex];

            try
            {
                //Tutaj wywołanie metody:
                //     NazwaMetody(Zajecia_pojedyncze zajecia_Pojedyncze, DateTime NowaDataZajec, DateTime NowaGodzinaZajec, Sala NowaSala);
                // NowaDataZajec to jest to co jest pod: obiektZajęćPojedyńczych.Data_zajec
                // NowaGodzinaZajec to jest to co jest pod: obiektZajęćPojedyńczych.Zajecia.Czas
                // NowaSala to jest to co jest pod: obiektZajęćPojedyńczych.Zajecia.Sala
            }
            catch (Exception ex)
            {

            }
        }
    }
}
