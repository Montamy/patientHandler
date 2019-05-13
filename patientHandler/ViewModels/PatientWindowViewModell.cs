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
        

        #region Declaration

        private iPatient currentipatient;
        private iPatient mnewPatient;
        public iPatient newPatient
        {
            get { return mnewPatient; }
            set
            {
                
                mnewPatient = value;
                this.OnPropertyChanged();
            }
        }

        public iPatient currentIPatient
        {
            get { return currentipatient; }
            set
            {
                currentipatient = value;
                this.OnPropertyChanged();
            }
        }

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
            if(!isNewPatient)
                currentIPatient = (iPatient) newPatient.Clone();
            else      
                currentIPatient = new Patient() {ID = currentIPatient.ID, isMyPatient = false};           
        }

        public void saveStatus()
        {
            this.newPatient = this.currentIPatient;
        }
    }
}
