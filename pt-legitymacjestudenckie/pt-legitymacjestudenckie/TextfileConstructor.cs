using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace pt_legitymacjestudenckie
{
    public enum ExportType
    {
        TABLE = 0,
        GRID = 1,
        UNKNOWN = -1
    }

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

        public void ObecnoscToCSV(DataTable obecnosci)
        {
            StringBuilder csv = new StringBuilder();
            csv = GridStringConstructor(obecnosci);

            String PrzedmiotString = tfc_params.SubjectName
                .Replace(' ', '-')
                .Replace(':','-')
                .Replace('/','-');
            String TodayDate = DateTime.Now.ToString("dd-M-yyyy");
            String FileName = "Raport-" + PrzedmiotString + "-" + TodayDate + ".csv";

            File.WriteAllText(FileName, csv.ToString());
        }

        public DataTable ConstructObecnoscList(List<Obecnosc> list)
        {
            list = list.Where(o => o.Data >= tfc_params.DateFrom && o.Data <= tfc_params.DateTo)
                            .OrderBy(o => o.Data).ToList();

            DataTable ObecnoscTable = new DataTable();
            ObecnoscTable.Columns.Add("imie");
            ObecnoscTable.Columns.Add("nazwisko");
            ObecnoscTable.Columns.Add("index");
            ObecnoscTable.Columns.Add("data");
            if (tfc_params.Late) ObecnoscTable.Columns.Add("spozniony?");
            if (tfc_params.Notes) ObecnoscTable.Columns.Add("notatka");

            foreach(Obecnosc ob in list)
            {
                DataRow row = ObecnoscTable.NewRow();
                row["imie"] = ob.Student.Imie;
                row["nazwisko"] = ob.Student.Nazwisko;
                row["index"] = ob.Student.Indeks;
                row["data"] = ob.Data;
                if (tfc_params.Late) row["spozniony?"] = ob.Spoznienie;
                if (tfc_params.Notes) row["notatka"] = ob.notatka;
                ObecnoscTable.Rows.Add(row);
            }
            return ObecnoscTable;
        }

        // Konstustruktory plików

        private StringBuilder GridStringConstructor(DataTable obecnosci)
        {
            var csv = new StringBuilder();
            DataTable DataTableForObecnosci = obecnosci;

            csv.AppendLine(ObecnoscGridCreateHeader(DataTableForObecnosci));

            foreach(DataRow row in DataTableForObecnosci.Rows)
            {
                var line = ObecnoscGridToString(row, DataTableForObecnosci.Columns.Count);
                csv.AppendLine(line);
            }

            return csv;
        }

        private String ObecnoscGridToString(DataRow row, int NumberofColumns)
        {
            String r = "";
            for (int i = 0; i < NumberofColumns; i++)
                r += row[i].ToString() + ",";

            return r.Remove(r.Length - 1);
        }

        private string ObecnoscGridCreateHeader(DataTable obecnosci)
        {
            String CoreHeader = "";
            foreach (DataColumn name in obecnosci.Columns)
            {
                String CName = name.ColumnName.Replace(',', ' ');
                CoreHeader += CName + ",";
            }

            return CoreHeader.Remove(CoreHeader.Length - 1);
        }

    }
}
