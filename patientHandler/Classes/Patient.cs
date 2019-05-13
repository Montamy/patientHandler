using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientHandler.Classes
{
    class Patient : iPatient , INotifyPropertyChanged
    {


        private string name;
        private string mothersname;
        private string note;
        private bool ismypatient;

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public  int ID { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                if (name == value)
                    return;
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }


        public string MothersName
        {
            get { return mothersname; }
            set
            {
                if (mothersname == value)
                    return;
                mothersname = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(MothersName)));
            }
        }

        public string Note
        {
            get { return note; }
            set
            {
                if (note == value)
                    return;
                note = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Note)));
            }
        }

        public bool isMyPatient
        {
            get { return ismypatient; }
            set
            {
                if (ismypatient == value)
                    return;
                ismypatient = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(isMyPatient)));
            }
        }

        public Patient(string name)
        {
            this.Name = name;
            this.ID = -1;
            this.isMyPatient = false;
        }

        public Patient()
        {
            this.ID = -1;
        }

        public object Clone()
        {
            return new Patient
            {
                ID = this.ID,
                Name = this.Name,
                MothersName = this.MothersName,
                isMyPatient = this.isMyPatient
            };
        }
    }
}
