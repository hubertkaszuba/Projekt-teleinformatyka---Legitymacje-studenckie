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

        // Rejestrowanie odbicia karty
        [System.ComponentModel.DisplayName("Znacznik")]
        public DateTime timestamp { get; set; }

        public StudentInfo(string fName, string lName, string idx, DateTime stamp)
        {
            firstName = fName;
            lastName = lName;
            index = idx;
            timestamp = stamp;
        }

        public string printStudent()
        {
            return firstName + " " + lastName + " " + index + " " + timestamp.ToString();
        }

    }
}
