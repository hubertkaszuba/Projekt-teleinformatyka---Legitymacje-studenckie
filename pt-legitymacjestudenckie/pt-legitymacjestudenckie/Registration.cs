using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace pt_legitymacjestudenckie
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }

        private void Zarejestrujbutton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=conjuringserv.database.windows.net;Initial Catalog=TheConjuring_db;Integrated Security=False;User ID=Kierownik;Password=KieraS_246;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            TheConjuring_dbEntities1 conjuring = new TheConjuring_dbEntities1();

            string login = LoginTextBox.Text.Trim();
            string log = "Select  Id_wykladowcy from Wykladowca Where Login_uz='" + login + "'" ;
            SqlDataAdapter sda = new SqlDataAdapter(log, connection);
            DataTable table = new DataTable();
            sda.Fill(table);
            if (table.Rows.Count >= 1)
            {
                MessageBox.Show("Uzytkownik o takiej nazwie już istnieje");
                return;
            }
            string haslo, haslo_pon;
            haslo = HasloTextBox.Text.Trim();
            haslo_pon = Haslo2TextBox.Text.Trim();

            if (haslo_pon != haslo || haslo=="" || haslo_pon=="" )
            {
                MessageBox.Show("Hasła różnią się");
                return;
            }

            string imie = ImieTextBox.Text.Trim();
            string nazwisko = NazwiskoTextBox.Text.Trim();
            haslo = SHA2.GenerateSHA256String(haslo);

            Wykladowca wy = new Wykladowca
            {
                Imie = imie,
                Nazwisko = nazwisko,
                Login_uz = login,
                Haslo = haslo
            };

            connection.Open();
            conjuring.Wykladowca.Add(wy);
            conjuring.SaveChanges();
            connection.Close();

            MessageBox.Show("Rejestracja powiodła się");
            this.Close();
        }
    }
}
