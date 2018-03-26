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
        string firstName { get; }
        string lastName { get; }
        string index { get; }

        // Rejestrowanie odbicia karty
        DateTime timestamp { get; set; }

        public StudentInfo(string fName, string lName, string idx, DateTime stamp)
        {
            firstName = fName;
            lastName = lName;
            index = idx;
            timestamp = stamp;
        }
        

    }
}
