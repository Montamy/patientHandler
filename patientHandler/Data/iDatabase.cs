using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientHandler.Data
{
    public interface iDatabase
    {

        void addItem();

        void updateItem();

        void getItem();

        void deleteItem();

        void getItemList();

    }
}
