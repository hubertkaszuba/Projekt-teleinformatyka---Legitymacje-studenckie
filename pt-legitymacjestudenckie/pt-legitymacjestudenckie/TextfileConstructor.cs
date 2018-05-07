using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pt_legitymacjestudenckie
{
    class TextfileConstructorParams
    {
        public String SubjectName = "";
        public DateTime DateFrom;
        public DateTime DateTo;
        public bool Late;
        public bool Notes;
    }

    class TextfileConstructor
    {
        private TextfileConstructorParams tfc_params;

        public TextfileConstructor()
        {
        }

        public void SetParams(TextfileConstructorParams params_obj)
        {
            tfc_params = params_obj;
        }

        public void ObecnoscToCSV(List<Obecnosc> obecnosci)
        {
            var csv = new StringBuilder();
            csv.AppendLine(ObecnoscCreateHeader());
            var list = obecnosci.Where(o => o.Data >= tfc_params.DateFrom && o.Data <= tfc_params.DateTo)
                .OrderBy(o => o.Data)
                .ToList();

            foreach (Obecnosc ob in list)
            {
                var line = ObecnoscToString(ob);
                csv.AppendLine(line);
            }

            String PrzedmiotString = obecnosci.FirstOrDefault().Zajecia_pojedyncze.Zajecia.Przedmiot.Nazwa.Replace(' ', '-');
            String TodayDate = DateTime.Now.ToString("dd-M-yyyy");
            String FileName = "Raport-" + PrzedmiotString + "-" + TodayDate + ".csv";

            File.WriteAllText(FileName, csv.ToString());
        }

        private String ObecnoscToString(Obecnosc ob)
        {
            String row = "";
            row += ob.Student.Imie.ToString() + "," + ob.Student.Nazwisko.ToString() + "," + ob.Indeks.ToString() + ",";
            row += ob.Data.ToString();
            if (tfc_params.Late) row += "," + ob.obecny.ToString();
            if (tfc_params.Notes) row += "," + ob.notatka.ToString();

            return row;
        }

        private String ObecnoscCreateHeader()
        {
            String CoreHeader = "imie,nazwisko,index,data";
            if (tfc_params.Late) CoreHeader += ",spozniony?";
            if (tfc_params.Notes) CoreHeader += ",notatka";

            return CoreHeader;
        }
    }
}
