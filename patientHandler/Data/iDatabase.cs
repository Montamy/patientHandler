using patientHandler.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientHandler.Data
{
    public interface iDatabase
    {

        void addItem(iPatient patient);

        void updateItem(iPatient patient);

        void getItem();

        void deleteItem(object p);

        void getItemList();

    }
}
