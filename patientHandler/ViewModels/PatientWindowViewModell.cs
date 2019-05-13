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
        public iPatient newPatient { get; set; }
        private iPatient mnewPatient;

        public iPatient oldPatient { get; set; }

        private bool isNewPatientOrMine { get; set; }
        #endregion

        #region Constructors
        public PatientWindowViewModell(object o)
        {            
            oldPatient = (iPatient)o;           
            newPatient = oldPatient;
        }

        public PatientWindowViewModell()
        {
            oldPatient = new Patient("");
            newPatient = oldPatient;
        }

        #endregion

        public void resetToOldpatient()
        {
            newPatient = oldPatient;
        }

    }
}
