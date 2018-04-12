using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
namespace pt_legitymacjestudenckie
{
    class DatabaseController
    {
        public void InsertObecnosc(TheConjuring_dbEntities1 conjuring, SqlConnection connection, int indeks, int id_zajec, DateTime data)
        {
            Obecnosc obecnosc = new Obecnosc {
                Indeks = indeks,
                Id_Zajec = id_zajec,
                Data = data
            };
            connection.Open();
            conjuring.Obecnosc.Add(obecnosc);
            conjuring.SaveChanges();
            connection.Close();
        }

        public void DeleteObecnosc(TheConjuring_dbEntities1 conjuring, SqlConnection connection, int indeks, int id_zajec, DateTime data)
        {
            connection.Open();
            List<Obecnosc> delete = conjuring.Obecnosc.Where(o => (o.Indeks == indeks && o.Id_Zajec == id_zajec && o.Data == data)).ToList();
            foreach (var o in delete)
                conjuring.Obecnosc.Remove(o);
            conjuring.SaveChanges();
            connection.Close();
        }

        public void UpdateObecnosc(TheConjuring_dbEntities1 conjuring, SqlConnection connection, int indeks, int id_zajec, DateTime data)
        {
            connection.Open();
            var query = conjuring.Obecnosc.Where(o => (o.Indeks == indeks && o.Data == data)).FirstOrDefault();
            query.Id_Zajec = id_zajec;
            conjuring.SaveChanges();
            connection.Close();
        }
    }
}
