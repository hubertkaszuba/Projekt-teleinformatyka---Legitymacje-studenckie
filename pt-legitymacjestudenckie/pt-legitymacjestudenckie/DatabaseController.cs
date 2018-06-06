using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;
using pt_legitymacjestudenckie.SmartCardRelated;
using System.Globalization;

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

                    Data = zajecia.Data_zajec,
                    Spoznienie = studentInfo.late,

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
                    Spoznienie = studentInfo.late,

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
            try
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
                DateTime shifted = now.AddMinutes(-89);
                DateTime shifted2 = now.AddMinutes(15);
                Zajecia_pojedyncze obecneZajecia = zajecia_pojedyncze.First(oz => oz.Data_zajec >= shifted && oz.Data_zajec <= shifted2);
                connection.Close();

                return obecneZajecia;
            }
            catch(Exception ex) { connection.Close(); return null; }
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
                MessageBox.Show("Takie zajecia juz istnieja w bazie");
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
            MessageBox.Show("Dodano poprawnie zajecia przedmiot - " + przedmiot.Nazwa + " w sali " + sala.Numer + " w budynku " + sala.Budynek);

            this.InsertZajeciaPojedyncze(conjuring, connection, zajecia);
                       
        }

        //zwracanie listy zajec wykladowcy
        public List<Zajecia> ListZajec(TheConjuring_dbEntities1 conjuring, SqlConnection connection, Wykladowca wykladowca)
        {
            connection.Open();
            List<Zajecia> qTyp = new List<Zajecia>();
            qTyp = (from z in conjuring.Zajecia where z.Id_Wykladowcy==wykladowca.Id_Wykladowcy orderby z.Id_Sali select z).ToList();
            connection.Close();
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

        public void DeletePrzedmiot(TheConjuring_dbEntities1 conjuring, SqlConnection connection, String nazwa)
        {

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

        //Zwraca Table obecnych uczniów pomiędz podanymi datami na danych zajeciach
        public DataTable Obecni_pomiedzy(TheConjuring_dbEntities1 conjuring, SqlConnection connection, Zajecia zajecia, DateTime od_, DateTime do_)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Imie i nazwisko");
            dt.Columns.Add("indeks");

            List<Student> qTyp = new List<Student>();
            qTyp = (from z in conjuring.Zajecia
                    join zp in conjuring.Zajecia_pojedyncze on zajecia.Id_Zajec equals zp.Id_Zajec
                    join o in conjuring.Obecnosc on zp.Id_Zajec_pojedynczych equals o.Id_Zajec_pojedynczych
                    join s in conjuring.Student on o.Indeks equals s.Indeks
                    where zp.Data_zajec >= od_ && zp.Data_zajec <= do_
                    orderby s.Indeks
                    select s).Distinct().ToList();

            foreach (var s in qTyp)
            {
                DataRow new_row = dt.NewRow();
                new_row["Imie i nazwisko"] = s.Imie + " " + s.Nazwisko;
                new_row["indeks"] = s.Indeks;
                dt.Rows.Add(new_row);
            }

            List<Zajecia_pojedyncze> Zajeciapoj = new List<Zajecia_pojedyncze>();
            Zajeciapoj = (from z in conjuring.Zajecia
                          join zp in conjuring.Zajecia_pojedyncze on zajecia.Id_Zajec equals zp.Id_Zajec
                          where zp.Data_zajec >= od_ && zp.Data_zajec <= do_
                          orderby zp.Id_Zajec_pojedynczych
                          select zp).Distinct().OrderBy(z => z.Data_zajec).ToList();
            int x = 1, y = 0;
            foreach (var zp in Zajeciapoj)
            {
                try
                {
                    dt.Columns.Add(zp.Data_zajec.ToString("MM/d"));
                }
                catch(Exception ex)
                {
                    continue;
                }

                x++;
                foreach (var s in qTyp)
                {
                    var query = conjuring.Obecnosc.Where(o => o.Indeks == s.Indeks && o.Id_Zajec_pojedynczych == zp.Id_Zajec_pojedynczych).FirstOrDefault();
                    if (query != null)
                    {

                        if(query.Spoznienie==true) dt.Rows[y][x] = "S";
                        else dt.Rows[y][x] = "O";

                    }
                    else dt.Rows[y][x] = "N";
                    y++;
                }
                y = 0;
            }

            return dt;

        }

        /// <summary>
        /// Wszystkie przeciążenia metody wyświetlającej liste obecności:
        /// </summary>

        public DataTable Lista_Obecnosci(TheConjuring_dbEntities1 conjuring, SqlConnection connection, Przedmiot przed, Wykladowca wyk)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Przedmiot");
            dt.Columns.Add("Student");
            dt.Columns.Add("Data");
            dt.Columns.Add("Spóźniony");
            dt.Columns.Add("Notatka");

            var qTyp = (from p in conjuring.Przedmiot
                        join z in conjuring.Zajecia on p.Id_Przedmiotu equals z.Id_Przedmiotu
                        join zp in conjuring.Zajecia_pojedyncze on z.Id_Zajec equals zp.Id_Zajec
                        join o in conjuring.Obecnosc on zp.Id_Zajec_pojedynczych equals o.Id_Zajec_pojedynczych
                        join s in conjuring.Student on o.Indeks equals s.Indeks
                        where z.Id_Wykladowcy == wyk.Id_Wykladowcy && p.Id_Przedmiotu == przed.Id_Przedmiotu
                        select new { Przedmiot_ = p.Nazwa, Student_ = s.Imie + " " + s.Nazwisko, Data_ = zp.Data_zajec, Spoznienie_ = o.Spoznienie, Notatka_ =o.notatka}).Distinct().ToList();

            foreach (var s in qTyp)
            {
                DataRow new_row = dt.NewRow();
                new_row["Przedmiot"] = s.Przedmiot_;
                new_row["Student"] = s.Student_;
                new_row["Data"] = s.Data_;
                new_row["Spóźniony"] = s.Spoznienie_;
                new_row["Notatka"] = s.Notatka_;
                dt.Rows.Add(new_row);
            }
            return dt;
        }
        public DataTable Lista_Obecnosci(TheConjuring_dbEntities1 conjuring, SqlConnection connection, Przedmiot przed, DateTime data_od, DateTime data_do , Wykladowca wyk)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Przedmiot");
            dt.Columns.Add("Student");
            dt.Columns.Add("Data");
            dt.Columns.Add("Spóźniony");
            dt.Columns.Add("Notatka");

            var qTyp = (from p in conjuring.Przedmiot
                        join z in conjuring.Zajecia on p.Id_Przedmiotu equals z.Id_Przedmiotu
                        join zp in conjuring.Zajecia_pojedyncze on z.Id_Zajec equals zp.Id_Zajec
                        join o in conjuring.Obecnosc on zp.Id_Zajec_pojedynczych equals o.Id_Zajec_pojedynczych
                        join s in conjuring.Student on o.Indeks equals s.Indeks
                        where z.Id_Wykladowcy == wyk.Id_Wykladowcy && p.Id_Przedmiotu == przed.Id_Przedmiotu && zp.Data_zajec>data_od && zp.Data_zajec<data_do
                        select new { Przedmiot_ = p.Nazwa, Student_ = s.Imie + " " + s.Nazwisko, Data_ = zp.Data_zajec, Spoznienie_ = o.Spoznienie, Notatka_ = o.notatka }).Distinct().ToList();

            foreach (var s in qTyp)
            {
                DataRow new_row = dt.NewRow();
                new_row["Przedmiot"] = s.Przedmiot_;
                new_row["Student"] = s.Student_;
                new_row["Data"] = s.Data_;
                new_row["Spóźniony"] = s.Spoznienie_;
                new_row["Notatka"] = s.Notatka_;
                dt.Rows.Add(new_row);
            }
            return dt;
        }

        public DataTable Lista_Obecnosci(TheConjuring_dbEntities1 conjuring, SqlConnection connection, Przedmiot przed, Student student, Wykladowca wyk)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Przedmiot");
            dt.Columns.Add("Student");
            dt.Columns.Add("Data");
            dt.Columns.Add("Spóźniony");
            dt.Columns.Add("Notatka");

            var qTyp = (from p in conjuring.Przedmiot
                        join z in conjuring.Zajecia on p.Id_Przedmiotu equals z.Id_Przedmiotu
                        join zp in conjuring.Zajecia_pojedyncze on z.Id_Zajec equals zp.Id_Zajec
                        join o in conjuring.Obecnosc on zp.Id_Zajec_pojedynczych equals o.Id_Zajec_pojedynczych
                        join s in conjuring.Student on o.Indeks equals s.Indeks
                        where z.Id_Wykladowcy == wyk.Id_Wykladowcy && p.Id_Przedmiotu == przed.Id_Przedmiotu && s.Indeks==student.Indeks
                        select new { Przedmiot_ = p.Nazwa, Student_ = s.Imie + " " + s.Nazwisko, Data_ = zp.Data_zajec, Spoznienie_ = o.Spoznienie, Notatka_ = o.notatka }).Distinct().ToList();

            foreach (var s in qTyp)
            {
                DataRow new_row = dt.NewRow();
                new_row["Przedmiot"] = s.Przedmiot_;
                new_row["Student"] = s.Student_;
                new_row["Data"] = s.Data_;
                new_row["Spóźniony"] = s.Spoznienie_;
                new_row["Notatka"] = s.Notatka_;
                dt.Rows.Add(new_row);
            }
            return dt;
        }

        public DataTable Lista_Obecnosci(TheConjuring_dbEntities1 conjuring, SqlConnection connection, Przedmiot przed, DateTime data_od, DateTime data_do,  Student student, Wykladowca wyk)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Przedmiot");
            dt.Columns.Add("Student");
            dt.Columns.Add("Data");
            dt.Columns.Add("Spóźniony");
            dt.Columns.Add("Notatka");

            var qTyp = (from p in conjuring.Przedmiot
                        join z in conjuring.Zajecia on p.Id_Przedmiotu equals z.Id_Przedmiotu
                        join zp in conjuring.Zajecia_pojedyncze on z.Id_Zajec equals zp.Id_Zajec
                        join o in conjuring.Obecnosc on zp.Id_Zajec_pojedynczych equals o.Id_Zajec_pojedynczych
                        join s in conjuring.Student on o.Indeks equals s.Indeks
                        where z.Id_Wykladowcy == wyk.Id_Wykladowcy && p.Id_Przedmiotu == przed.Id_Przedmiotu && zp.Data_zajec > data_od && zp.Data_zajec < data_do && s.Indeks==student.Indeks
                        select new { Przedmiot_ = p.Nazwa, Student_ = s.Imie + " " + s.Nazwisko, Data_ = zp.Data_zajec, Spoznienie_ = o.Spoznienie, Notatka_ = o.notatka }).Distinct().ToList();

            foreach (var s in qTyp)
            {
                DataRow new_row = dt.NewRow();
                new_row["Przedmiot"] = s.Przedmiot_;
                new_row["Student"] = s.Student_;
                new_row["Data"] = s.Data_;
                new_row["Spóźniony"] = s.Spoznienie_;
                new_row["Notatka"] = s.Notatka_;
                dt.Rows.Add(new_row);
            }
            return dt;
        }
        public DataTable Lista_Obecnosci(TheConjuring_dbEntities1 conjuring, SqlConnection connection, Student student, Wykladowca wyk)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Przedmiot");
            dt.Columns.Add("Student");
            dt.Columns.Add("Data");
            dt.Columns.Add("Spóźniony");
            dt.Columns.Add("Notatka");

            var qTyp = (from p in conjuring.Przedmiot
                        join z in conjuring.Zajecia on p.Id_Przedmiotu equals z.Id_Przedmiotu
                        join zp in conjuring.Zajecia_pojedyncze on z.Id_Zajec equals zp.Id_Zajec
                        join o in conjuring.Obecnosc on zp.Id_Zajec_pojedynczych equals o.Id_Zajec_pojedynczych
                        join s in conjuring.Student on o.Indeks equals s.Indeks
                        where z.Id_Wykladowcy == wyk.Id_Wykladowcy && s.Indeks == student.Indeks
                        select new { Przedmiot_ = p.Nazwa, Student_ = s.Imie + " " + s.Nazwisko, Data_ = zp.Data_zajec, Spoznienie_ = o.Spoznienie, Notatka_ = o.notatka }).Distinct().ToList();

            foreach (var s in qTyp)
            {
                DataRow new_row = dt.NewRow();
                new_row["Przedmiot"] = s.Przedmiot_;
                new_row["Student"] = s.Student_;
                new_row["Data"] = s.Data_;
                new_row["Spóźniony"] = s.Spoznienie_;
                new_row["Notatka"] = s.Notatka_;
                dt.Rows.Add(new_row);
            }
            return dt;
        
    }
        public DataTable Lista_Obecnosci(TheConjuring_dbEntities1 conjuring, SqlConnection connection, DateTime data_od, DateTime data_do, Student student, Wykladowca wyk)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Przedmiot");
            dt.Columns.Add("Student");
            dt.Columns.Add("Data");
            dt.Columns.Add("Spóźniony");
            dt.Columns.Add("Notatka");

            var qTyp = (from p in conjuring.Przedmiot
                        join z in conjuring.Zajecia on p.Id_Przedmiotu equals z.Id_Przedmiotu
                        join zp in conjuring.Zajecia_pojedyncze on z.Id_Zajec equals zp.Id_Zajec
                        join o in conjuring.Obecnosc on zp.Id_Zajec_pojedynczych equals o.Id_Zajec_pojedynczych
                        join s in conjuring.Student on o.Indeks equals s.Indeks
                        where z.Id_Wykladowcy == wyk.Id_Wykladowcy && zp.Data_zajec > data_od && zp.Data_zajec < data_do && s.Indeks == student.Indeks
                        select new { Przedmiot_ = p.Nazwa, Student_ = s.Imie + " " + s.Nazwisko, Data_ = zp.Data_zajec, Spoznienie_ = o.Spoznienie, Notatka_ = o.notatka }).Distinct().ToList();

            foreach (var s in qTyp)
            {
                DataRow new_row = dt.NewRow();
                new_row["Przedmiot"] = s.Przedmiot_;
                new_row["Student"] = s.Student_;
                new_row["Data"] = s.Data_;
                new_row["Spóźniony"] = s.Spoznienie_;
                new_row["Notatka"] = s.Notatka_;
                dt.Rows.Add(new_row);
            }
            return dt;
        }
    }
}
