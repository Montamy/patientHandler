using patientHandler.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientHandler.ViewModels
{
    public class MainWindowViewModell :BaseViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #region Declaration
        private ObservableCollection<iPatient> mPatientCollection;
        public ObservableCollection<iPatient> PatientCollection
        {
            get { return mPatientCollection;  }
            set
            {
                if (mPatientCollection == value)
                    return;
                mPatientCollection = value;
                PropertyChanged(this,new PropertyChangedEventArgs(nameof(PatientCollection)));
            }
        }

        public iPatient selectedIPatient;
        #endregion

        #region constructor
        public MainWindowViewModell()
            :base()
        {
            PatientCollection = new ObservableCollection<iPatient>();
            AddPatient();           
        }
        #endregion
        public void AddPatient()
        {
            mPatientCollection.Add(new Patient("Domokos Roland"));
            mPatientCollection.Add(new Patient("Valaki AKinek hosszu a neve"));
            mPatientCollection.Add(new Patient("DFFDSF"));
            mPatientCollection.Add(new Patient("Proba"));
        }
        


    }
}
