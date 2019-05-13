using patientHandler.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientHandler.ViewModels
{
    public class PatientWindowViewModell : BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #region Declaration

        private iPatient mnewPatient;
        public iPatient newPatient
        {
            get { return mnewPatient; }
            set
            {
                if (mnewPatient == value)
                    return;
                mnewPatient = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(newPatient)));
            }
        }

        public iPatient currentIPatient { get; set; }

        public bool isNewPatient { get; set; }
        #endregion

        #region Constructors
        public PatientWindowViewModell(object o)
        {
            
            newPatient = (iPatient)o;
            currentIPatient = (iPatient)newPatient.Clone();
            isNewPatient = false;
        }

        public PatientWindowViewModell()
        {            
            newPatient = new Patient("");
            currentIPatient = (iPatient)newPatient.Clone();
            isNewPatient = true;
        }

        #endregion

        public void resetToOldpatient()
        {
            currentIPatient = new Patient();           
        }

        public void saveStatus()
        {
            this.newPatient = this.currentIPatient;
        }
    }
}
