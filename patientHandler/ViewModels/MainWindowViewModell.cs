using patientHandler.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using patientHandler.Data;

namespace patientHandler.ViewModels
{
    public class MainWindowViewModell :BaseViewModel
    {

        

        #region Declaration
        private ObservableCollection<iPatient> mPatientCollection;
        public ObservableCollection<iPatient> PatientCollection
        {
            get { return mPatientCollection;  }
            set
            {
               
                mPatientCollection = value;
                this.OnPropertyChanged();
            }
        }

        public Database data;

        public iPatient selectedIPatient;
        #endregion

        #region constructor
        public MainWindowViewModell()
            :base()
        {
            PatientCollection = new ObservableCollection<iPatient>();
            db = Database.Get();
            PatientCollection = db.PatientCollection;
            ////AddPatient();           
        }
        #endregion

        public void RefreshData()
        {
            data = null;
            data = Database.Get();
            PatientCollection = data.PatientCollection;
        }


    }
}
