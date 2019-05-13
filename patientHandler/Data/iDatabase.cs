using patientHandler.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientHandler.Data
{
    public interface iDatabase
    {
        ObservableCollection<iPatient> PatientCollection { get; set; }

        void addItem(iPatient patient);

        void updateItem(iPatient patient);

        void getItem();

        void deleteItem(object p);

        void getItemList();

    }
}
