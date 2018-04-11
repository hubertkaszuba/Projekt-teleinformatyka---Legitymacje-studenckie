using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
namespace pt_legitymacjestudenckie
{
    class SalaManagement
    {
        SqlConnection connection = new SqlConnection(@"Data Source=conjuringserv.database.windows.net;Initial Catalog=TheConjuring_db;Integrated Security=False;User ID=Kierownik;Password=KieraS_246;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        TheConjuring_dbEntities1 conjuring = new TheConjuring_dbEntities1();

        public void InsertSala(String _budynek, String _numer)
        {
            Sala sala = new Sala()
            {
                Budynek = _budynek,
                Numer = _numer
            };
            connection.Open();
            conjuring.Sala.Add(sala);
            conjuring.SaveChanges();
            connection.Close();
        }
        
        public void DeleteSala()
        {

        }

        public void UpdateSala()
        {

        }

        public Sala ReturnAll()
        {
            Sala sala = new Sala();
            return sala;
        }

    }
}
