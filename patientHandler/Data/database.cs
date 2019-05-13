using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientHandler.Data
{
    public class database : iDatabase
    {
       


        public static Get ()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");
        }

        public void addItem()
        {
            throw new NotImplementedException();
        }

        public void deleteItem()
        {
            throw new NotImplementedException();
        }

        public void getItem()
        {
            throw new NotImplementedException();
        }

        public void getItemList()
        {
            throw new NotImplementedException();
        }

        public void updateItem()
        {
            throw new NotImplementedException();
        }
    }
}
