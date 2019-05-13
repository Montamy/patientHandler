using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientHandler.Classes
{
    class Patient : iPatient
    {
        public string Name { get; set; }

        public string MothersName { get; set; }

        public string Note { get; set; }

        public Patient(string name)
        {
            this.Name = name;
            this.isMyPatient = false;
        }

        public bool isMyPatient { get; set; }
        
    }
}
