using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pt_legitymacjestudenckie.SmartCardRelated
{
    class StudentInfo
    {
        // Sparsowane z karty informacje o studencie
        [System.ComponentModel.DisplayName("Imię")]
        public string firstName { get; }
        [System.ComponentModel.DisplayName("Nazwisko")]
        public string lastName { get; }
        [System.ComponentModel.DisplayName("Index")]
        public string index { get; }

        // Informacje dodatkowe dla prowadzącego
        [System.ComponentModel.DisplayName("Spóźniony?")]
        public bool late { get; set; }
        [System.ComponentModel.DisplayName("Notatka")]
        public string note { get; set; }

        // Rejestrowanie odbicia karty
        [System.ComponentModel.DisplayName("Znacznik")]
        public DateTime timestamp { get; set; }

        public StudentInfo(string fName, string lName, string idx, DateTime stamp)
        {
            firstName = fName;
            lastName = lName;
            index = idx;
            timestamp = stamp;

            late = false;
            note = "Pusta";
        }

        public string printStudent()
        {
            return firstName + " " + lastName + " " + index + " " + timestamp.ToString();
        }

        public void SetLate(bool flag) { late = flag; }
        public void SetNote(string mess) { note = mess; }


    }
}
