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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        /*Logowanie*/
        private void Zalogujbutton_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(@"Data Source=conjuringserv.database.windows.net;Initial Catalog=TheConjuring_db;Integrated Security=False;User ID=Kierownik;Password=KieraS_246;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            TheConjuring_dbEntities1 conjuring = new TheConjuring_dbEntities1();
            string login = LogintextBox.Text.Trim();
            string haslo = HasłotextBox.Text.Trim();
            login = "krzwio";
            haslo = "zimalato";
            //szyfrowanie hasła
            haslo = SHA2.GenerateSHA256String(haslo);

            string log = "Select  * from Wykladowca Where Login_uz='" + login + "' and Haslo = '" + haslo + "'";
            SqlDataAdapter sda = new SqlDataAdapter(log, connection);
            DataTable table = new DataTable();
            sda.Fill(table);
            if (table.Rows.Count == 1)
            {
                MainForm main = new MainForm(login);
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show("Błędna nazwa użytkownika lub hasło");
                
            }
        }

        private void Rejestracjabutton_Click(object sender, EventArgs e)
        {
            Registration reje = new Registration();
            reje.Owner = this;
            this.Hide();
            reje.Show();
        }
    }
}
