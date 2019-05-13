using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientHandler.Classes
{
    class Patient : iPatient
    {
        

        private string name;
        private string mothersname;
        private string note;
        private bool ismypatient;

        public string Name { get; set; }

        public string MothersName { get; set; }

        public string Note { get; set; }     

        public bool isMyPatient { get; set; }

        public Patient(string name)
        {
            this.Name = name;
            this.isMyPatient = false;
        }
        

    }
}
