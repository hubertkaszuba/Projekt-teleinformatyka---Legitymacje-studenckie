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
            int studentIndex = Convert.ToInt32(studentInfo.index);
            var isThereStudent = conjuring.Student.Where(s => s.Indeks == studentIndex).FirstOrDefault();
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
<<<<<<< HEAD
                    Data = studentInfo.timestamp,
                    obecny = true,
=======
                    Data = zajecia.Data_zajec,
                    obecny = studentInfo.late,
>>>>>>> 74475ee27f474d59db5574c5e3674af6414b867e
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
<<<<<<< HEAD
                    Data = studentInfo.timestamp,
                    obecny = true,
=======
                    Data = zajecia.Data_zajec,
                    obecny = studentInfo.late,
>>>>>>> 74475ee27f474d59db5574c5e3674af6414b867e
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

            DateTime now = DateTime.Now;
            DateTime shifted = now.AddMinutes(-15);
            Zajecia_pojedyncze obecneZajecia = zajecia_pojedyncze.First(oz => oz.Data_zajec >= shifted);
            connection.Close();

            return obecneZajecia;
        }

        public List<Obecnosc> GetObecnosc(TheConjuring_dbEntities1 conjuring, SqlConnection connection)
        {
            try
            {
                connection.Open();
                List<Obecnosc> obecnosci = conjuring.Obecnosc.ToList();
                connection.Close();
                return obecnosci;
            }
            catch (SqlException ex)
            {
                return null;
            }
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

        //Dodawanie nowych zajęć
        public void InsertZajecia(TheConjuring_dbEntities1 conjuring, SqlConnection connection, Wykladowca wykladowca , Przedmiot przedmiot, Sala sala, DateTime data, bool tydzien)
        {
            connection.Open();
            var query = conjuring.Zajecia.Where(o => (o.Id_Przedmiotu == przedmiot.Id_Przedmiotu && o.Id_Sali == sala.Id_Sali && o.Id_Wykladowcy == wykladowca.Id_Wykladowcy && o.Tydzien == tydzien && o.Czas == data)).FirstOrDefault();
            if (query != null)
            {
                MessageBox.Show("Takie zajecia juz istnieja  w bazie");
                connection.Close();
                return;
            }

            Zajecia zajecia = new Zajecia()
            {
               Id_Przedmiotu=przedmiot.Id_Przedmiotu,
               Id_Sali=sala.Id_Sali,
               Czas=data,
               Tydzien=tydzien,
               Id_Wykladowcy=wykladowca.Id_Wykladowcy
            };
            
            conjuring.Zajecia.Add(zajecia);
            conjuring.SaveChanges();
            connection.Close();
            MessageBox.Show("Dodano poprawnie zajecia przedmiot - " + przedmiot.Nazwa + " w sali - " + sala.Numer + " w budynku " + sala.Budynek);

            this.InsertZajeciaPojedyncze(conjuring, connection, zajecia);
                       
        }

        //zwracanie listy zajec wykladowcy
        public List<Zajecia> ListZajec(TheConjuring_dbEntities1 conjuring, Wykladowca wykladowca)
        {
            List<Zajecia> qTyp = new List<Zajecia>();
            qTyp = (from z in conjuring.Zajecia where z.Id_Wykladowcy==wykladowca.Id_Wykladowcy orderby z.Id_Sali select z).ToList();
            return qTyp;
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

        // Zwraca list przedmiotów prowadzonych przez prowadzącego
        public List<String> GetSubjects(TheConjuring_dbEntities1 conjuring, SqlConnection connection, Wykladowca wykladowca)
        {
            connection.Open();
            List<Zajecia> lessons = conjuring.Zajecia.Where(z => z.Wykladowca.Id_Wykladowcy == wykladowca.Id_Wykladowcy).ToList();
            List<String> subjects = lessons.Select(l => l.Przedmiot.Nazwa).Distinct().ToList();

            connection.Close();
            return subjects;
        }
    }
}
