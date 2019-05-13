using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientHandler.Classes
{
    public interface iPatient 
    {       

        string Name { get; set; }

        string MothersName { get; set; }

        string Note { get; set; }

        bool isMyPatient { get; set; }

    }
}
