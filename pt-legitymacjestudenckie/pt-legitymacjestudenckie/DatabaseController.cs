using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using pt_legitymacjestudenckie.SmartCardRelated;
namespace pt_legitymacjestudenckie
{
    class DatabaseController
    {
        public void InsertObecnosc(TheConjuring_dbEntities1 conjuring, SqlConnection connection, StudentInfo studentInfo, Zajecia_pojedyncze zajecia)
        {
            var isThereStudent = conjuring.Student.Where(s => s.Indeks == Convert.ToInt32(studentInfo.index));
            if (isThereStudent == null)
            {
                Student student = new Student
                {
                    Indeks = Convert.ToInt32(studentInfo.index),
                    Imie = studentInfo.firstName,
                    Nazwisko = studentInfo.lastName,
                };

                Obecnosc obecnosc = new Obecnosc
                {
                    Indeks = Convert.ToInt32(studentInfo.index),
                    Id_Zajec_pojedynczych = zajecia.Id_Zajec_pojedynczych,
                    Data = zajecia.Data_zajec,
                    obecny = true,
                    notatka = studentInfo.note
                };
                connection.Open();
                conjuring.Student.Add(student);
                conjuring.Obecnosc.Add(obecnosc);
                conjuring.SaveChanges();
                connection.Close();
            }
            else
            {
                Obecnosc obecnosc = new Obecnosc
                {
                    Indeks = Convert.ToInt32(studentInfo.index),
                    Id_Zajec_pojedynczych = zajecia.Id_Zajec_pojedynczych,
                    Data = zajecia.Data_zajec,
                    obecny = true,
                    notatka = studentInfo.note
                };
                connection.Open();
                conjuring.Obecnosc.Add(obecnosc);
                conjuring.SaveChanges();
                connection.Close();
            }

        }

        public void InsertZajeciaPojedyncze(TheConjuring_dbEntities1 conjuring, SqlConnection connection, Zajecia zajecia)
        {
            DateTime semestr_letni = new DateTime(DateTime.Now.Year, 6, 30);
            DateTime semestr_zimowy = new DateTime(DateTime.Now.Year + 1, 1, 30);
            DateTime datyZajec = (DateTime)zajecia.Czas;
            if(zajecia.Czas < semestr_letni)
            {
                while(datyZajec < semestr_letni)
                {
                    Zajecia_pojedyncze zajecia_Pojedyncze = new Zajecia_pojedyncze
                    {
                        Id_Zajec = zajecia.Id_Zajec,
                        Data_zajec = datyZajec
                    };
                    connection.Open();
                    conjuring.Zajecia_pojedyncze.Add(zajecia_Pojedyncze);
                    conjuring.SaveChanges();
                    connection.Close();
                    if (zajecia.Tydzien == false)
                        datyZajec = datyZajec.AddDays(7);
                    else
                        datyZajec = datyZajec.AddDays(14);
                }   
            }
            else
            {
                while(datyZajec < semestr_zimowy)
                {
                    Zajecia_pojedyncze zajecia_Pojedyncze = new Zajecia_pojedyncze
                    {
                        Id_Zajec = zajecia.Id_Zajec,
                        Data_zajec = datyZajec
                    };
                    connection.Open();
                    conjuring.Zajecia_pojedyncze.Add(zajecia_Pojedyncze);
                    conjuring.SaveChanges();
                    connection.Close();
                    if (zajecia.Tydzien == false)
                        datyZajec = datyZajec.AddDays(7);
                    else
                        datyZajec = datyZajec.AddDays(14);
                }
            }
        }

        public Zajecia_pojedyncze GetZajecia_Pojedyncze(TheConjuring_dbEntities1 conjuring, SqlConnection connection, Wykladowca wykladowca)
        {
            var zajecia = conjuring.Zajecia.Where(z => z.Id_Wykladowcy == wykladowca.Id_Wykladowcy);
            IQueryable<Zajecia_pojedyncze> zajecia_pojedyncze = null;
            foreach (var z in zajecia)
            {
                zajecia_pojedyncze = conjuring.Zajecia_pojedyncze.Where(zp => zp.Id_Zajec == z.Id_Zajec);
            }
            
            var obecneZajecia = zajecia_pojedyncze.Single(oz => oz.Data_zajec >= DateTime.Now.AddMinutes(-5) && oz.Data_zajec <= DateTime.Now.AddMinutes(90));

            return obecneZajecia;
        }



        public void DeleteObecnosc(TheConjuring_dbEntities1 conjuring, SqlConnection connection, int indeks, int id_zajec, DateTime data)
        {
            connection.Open();
            List<Obecnosc> delete = conjuring.Obecnosc.Where(o => (o.Indeks == indeks && o.Id_Zajec_pojedynczych == id_zajec && o.Data == data)).ToList();
            foreach (var o in delete)
                conjuring.Obecnosc.Remove(o);
            conjuring.SaveChanges();
            connection.Close();
        }

        public void UpdateObecnosc(TheConjuring_dbEntities1 conjuring, SqlConnection connection, int indeks, int id_zajec, DateTime data)
        {
            connection.Open();
            var query = conjuring.Obecnosc.Where(o => (o.Indeks == indeks && o.Data == data)).FirstOrDefault();
            query.Id_Zajec_pojedynczych = id_zajec;
            conjuring.SaveChanges();
            connection.Close();
        }

    }
}
