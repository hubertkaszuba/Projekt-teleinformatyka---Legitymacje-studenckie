using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;
using pt_legitymacjestudenckie.SmartCardRelated;
namespace pt_legitymacjestudenckie
{
    class DatabaseController
    {
        public void InsertObecnosc(TheConjuring_dbEntities1 conjuring, SqlConnection connection, StudentInfo studentInfo, Zajecia_pojedyncze zajecia)
        {
            connection.Open();
            var isThereStudent = conjuring.Student.Where(s => s.Indeks == Convert.ToInt32(studentInfo.index));
            connection.Close();
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
            connection.Open();
            var zajecia = conjuring.Zajecia.Where(z => z.Id_Wykladowcy == wykladowca.Id_Wykladowcy);
            IQueryable<Zajecia_pojedyncze> zajecia_pojedyncze = null;
            foreach (var z in zajecia)
            {
                zajecia_pojedyncze = conjuring.Zajecia_pojedyncze.Where(zp => zp.Id_Zajec == z.Id_Zajec);
            }
            

            //var obecneZajecia = zajecia_pojedyncze.Single(oz => oz.Data_zajec >= DateTime.Now.AddMinutes(-5) && oz.Data_zajec <= DateTime.Now.AddMinutes(90));
            

            Zajecia_pojedyncze obecneZajecia = zajecia_pojedyncze.Single(oz => oz.Data_zajec >= DateTime.Now.AddMinutes(-5) && oz.Data_zajec <= DateTime.Now.AddMinutes(90));
            connection.Close();

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

        //Dodawanie nowej sali
        public void InsertSala(TheConjuring_dbEntities1 conjuring, SqlConnection connection, String numer, String budynek)
        {
            connection.Open();
            var query = conjuring.Sala.Where(o => (o.Numer == numer && o.Budynek == budynek)).FirstOrDefault();
            if (query != null)
            {
                MessageBox.Show("Taka sala już istnieje w bazie");
                connection.Close();
                return;
            }

            Sala sala = new Sala()
            {
                Budynek = budynek,
                Numer = numer
            };
            conjuring.Sala.Add(sala);
            conjuring.SaveChanges();
            connection.Close();
            MessageBox.Show("Dodano poprawnie sale numer - " + numer + " w budynku - " + budynek);
        }
        //zwracanie listy sal
        public List<Sala> ListSala(TheConjuring_dbEntities1 conjuring)
        {
            List<Sala> qTyp = new List<Sala>();
            qTyp = (from s in conjuring.Sala orderby s.Id_Sali select s).Distinct().ToList();
            return qTyp;
        }

        //Dodawanie nowego przedmiotu
        public void InsertPrzedmiot(TheConjuring_dbEntities1 conjuring, SqlConnection connection, String nazwa)
        {
            connection.Open();
            var query = conjuring.Przedmiot.Where(o => (o.Nazwa == nazwa)).FirstOrDefault();
            if (query != null)
            {
                MessageBox.Show("Taki przedmiot już istnieje w bazie");
                connection.Close();
                return;
            }

            Przedmiot przedmiot = new Przedmiot
            {
                Nazwa = nazwa
            };
            conjuring.Przedmiot.Add(przedmiot);
            conjuring.SaveChanges();
            connection.Close();
            MessageBox.Show("Dodano poprawnie przedmiot - " + nazwa);
        }

        //zwracanie listy wszystkich przedmiotów
        public List<Przedmiot> ListPrzedmiot(TheConjuring_dbEntities1 conjuring)
        {
            List<Przedmiot> qTyp = new List<Przedmiot>();
            qTyp = (from p in conjuring.Przedmiot orderby p.Id_Przedmiotu select p).Distinct().ToList();
            return qTyp;
        }

        //zwracanie listy przedmiotów zalogowanego
        public List<Przedmiot> ListPrzedmiot_Zalogowanego(TheConjuring_dbEntities1 conjuring, Wykladowca wykladowca)
        {
            List<Przedmiot> qTyp = new List<Przedmiot>();
            qTyp = (from p in conjuring.Przedmiot
                    join z in conjuring.Zajecia on p.Id_Przedmiotu equals z.Id_Przedmiotu
                    join w in conjuring.Wykladowca on z.Id_Wykladowcy equals w.Id_Wykladowcy
                    where w.Id_Wykladowcy == wykladowca.Id_Wykladowcy
                    orderby p.Id_Przedmiotu
                    select p).Distinct().ToList();
            return qTyp;
        }
    }
}
