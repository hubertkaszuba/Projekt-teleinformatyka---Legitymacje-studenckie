using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

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
        private Font PDFont;

        private const float CELL_HEIGHT = 10f;

        public TextfileConstructor()
        {
        }

        public void SetParams(TextfileConstructorParams params_obj)
        {
            tfc_params = params_obj;
        }

        // Zapisuje dane z tabeli do pliku o formacie csv
        public void ObecnoscToCSV(DataTable obecnosci)
        {
            StringBuilder csv = new StringBuilder();
            csv = GridStringConstructor(obecnosci);

            var saveFileDialog = new SaveFileDialog();
            string filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*";

            saveFileDialog.FileName = FileNameConstructor();
            saveFileDialog.DefaultExt = ".csv";
            saveFileDialog.Filter = filter;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, csv.ToString());
            }
        }

        // Zapisuje dane z tabeli do pliku o formacie pdf
        public void ObecnoscToPDF(DataTable obecnosci)
        {
            PdfPTable pdfPTable = ObecnoscPDFCreateHeader(obecnosci);
            pdfPTable = ObecnoscPDFRowsConstructor(obecnosci, pdfPTable);

            var saveFileDialog = new SaveFileDialog();
            string filter = "PDF file (*.pdf)|*.pdf| All Files (*.*)|*.*";

            saveFileDialog.FileName = FileNameConstructor();
            saveFileDialog.DefaultExt = ".pdf";
            saveFileDialog.Filter = filter;

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using(FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.SetPageSize(PageSize.A4.Rotate());

                    pdfDoc.Open();
                    pdfDoc.Add(pdfPTable);
                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }

        // Tworzy domyślną nazwę pliku
        private String FileNameConstructor()
        {
            String PrzedmiotString = tfc_params.SubjectName
                .Replace(' ', '-')
                .Replace(':', '-')
                .Replace('/', '-');
            String TodayDate = DateTime.Now.ToString("dd-M-yyyy");
            String FileName = "Raport-" + PrzedmiotString + "-" + TodayDate;

            return FileName;
        }

        // Dostosowuje obiekty pobrane z bazy danych do formatu DataTable
        public DataTable ConstructObecnoscList(List<Obecnosc> list)
        {
            list = list.Where(o => o.Data >= tfc_params.DateFrom && o.Data <= tfc_params.DateTo)
                            .OrderBy(o => o.Data).ToList();

            DataTable ObecnoscTable = new DataTable();
            ObecnoscTable.Columns.Add("Imie i Nazwisko");
            ObecnoscTable.Columns.Add("Indeks");
            ObecnoscTable.Columns.Add("Data");
            if (tfc_params.Late) ObecnoscTable.Columns.Add("Spóźniony?");
            if (tfc_params.Notes) ObecnoscTable.Columns.Add("Notatka");

            foreach(Obecnosc ob in list)
            {
                DataRow row = ObecnoscTable.NewRow();
                row["Imie i Nazwisko"] = ob.Student.Imie + " " + ob.Student.Nazwisko;
                row["Indeks"] = ob.Student.Indeks;
                row["Data"] = ob.Data;
                if (tfc_params.Late)
                {
                    if ((bool)ob.Spoznienie)
                        row["Spóźniony?"] = "Tak";
                    else
                        row["Spóźniony?"] = "";
                }
                if (tfc_params.Notes) row["Notatka"] = ob.notatka;
                ObecnoscTable.Rows.Add(row);
            }
            return ObecnoscTable;
        }

        // Konstustruktory plików - CSV

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

        // Konstruktory plików - PDF

        private PdfPTable ObecnoscPDFCreateHeader(DataTable obecnosci)
        {
            BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.EMBEDDED);
            PDFont = new Font(baseFont, 8, Font.NORMAL);
            PdfPTable pdfPTable = new PdfPTable(obecnosci.Columns.Count);

            PdfPCell cellHeader = new PdfPCell(new Phrase(FileNameConstructor(), PDFont));
            cellHeader.BackgroundColor = BaseColor.LIGHT_GRAY;
            cellHeader.Colspan = obecnosci.Columns.Count;
            cellHeader.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            pdfPTable.AddCell(cellHeader);

            pdfPTable.DefaultCell.Padding = 1;
            pdfPTable.WidthPercentage = 100;
            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPTable.DefaultCell.BorderWidth = 1;

            pdfPTable.SetWidths(GetWidthsArray(obecnosci.Columns.Count));

            foreach (DataColumn o in obecnosci.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(o.ColumnName, PDFont));
                cell.BackgroundColor = new BaseColor(240, 240, 240);
                pdfPTable.AddCell(cell);
            }

            return pdfPTable;
        }

        private float[] GetWidthsArray(int count)
        {
            List<float> widths = new List<float>();
            widths.Add(2);
            for (int i = 1; i < count; i++)
                widths.Add(1);

            return widths.ToArray();
        }

        private PdfPTable ObecnoscPDFRowsConstructor(DataTable obecnosci, PdfPTable pdfPTable)
        {
            PdfPTable pdfTable = pdfPTable;

            foreach (DataRow row in obecnosci.Rows)
            {
                pdfTable = AssignCells(row, pdfTable, obecnosci.Columns.Count);
            }

            return pdfTable;
        }

        private PdfPTable AssignCells(DataRow row, PdfPTable pdfTable, int count)
        {
            for(int i = 0; i < count; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(row[i].ToString(), PDFont));
                pdfTable.AddCell(cell);
            }

            return pdfTable;
        }
    }
}
