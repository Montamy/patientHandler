using patientHandler.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientHandler.ViewModels
{
    public class PatientWindowViewModell : BaseViewModel
    {
        #region Declaration
        public iPatient newPatient { get; set; }

        public iPatient oldPatient { get; set; }

        private bool isNewPatientOrMine { get; set; }
        #endregion

        #region Constructores
        public PatientWindowViewModell(object o)
        {
            isNewPatientOrMine = false;

            oldPatient = (iPatient)o;
            if (oldPatient == null)
                isNewPatientOrMine = true;
            newPatient = oldPatient;
        }

        #endregion
    }
}
