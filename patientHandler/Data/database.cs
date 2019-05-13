using patientHandler.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patientHandler.Data
{
    public class Database : iDatabase
    {
        private static Database _peldany;

        public ObservableCollection<iPatient> patientCollection;

        public string path;

        public int lastDataItem; 

        public static Database Get()
        {
            if(_peldany == null)
                _peldany = new Database();
            return _peldany;
        }
           

        public Database ()
        {
            patientCollection = new ObservableCollection<iPatient>();
            path = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            path += @"\DataText.txt";
            
            getItemList();

        }

        public void addItem(iPatient patient)
        {
            string stringPatient = "";
            stringPatient += this.lastDataItem++ + ";"+ patient.Name + ";" + patient.MothersName + ";" + patient.Note + ";" +
                             patient.isMyPatient.ToString() + ";0";

            File.AppendAllText(path, stringPatient + Environment.NewLine);



        }

        public void deleteItem(object p)
        {
            iPatient patient = (iPatient) p;
            StreamReader tr = new StreamReader(path, Encoding.GetEncoding("iso-8859-1"));

            int lineNumber = 0;

            string line = tr.ReadLine();

            string[] s = {"-1"};
            

            while (line != null && int.Parse(s[0]) != patient.ID)
            {
                lineNumber++;
                s = line.Split(';');               
                line = tr.ReadLine();
            }

            tr.Close();

            if (lineNumber == 0 && s[0] == "-1")
            {
                throw new System.Exception();
            }
            else
            {
                string stringPatient = "";
                stringPatient += patient.ID + ";" + patient.Name + ";" + patient.MothersName + ";" + patient.Note + ";" +
                                 patient.isMyPatient.ToString() + ";1";
                lineChanger(stringPatient,lineNumber);
                
            }

            
        }

        public void getItem()
        {
            throw new NotImplementedException();
        }

        public void getItemList()
        {
            StreamReader tr = new StreamReader(path, Encoding.GetEncoding("iso-8859-1"));

            int lineNumber = 0;

            string line = tr.ReadLine();

            while (line != null)
            {
                lineNumber++;

                string[] s = line.Split(';');
                if (s[5] == "0")
                {
                    patientCollection.Add(new Patient()
                    {
                        ID = int.Parse(s[0]),
                        Name = s[1],
                        MothersName = s[2],
                        Note = s[3],
                        isMyPatient = s[4] == "true" ? true : false

                    });
                }

                lastDataItem = int.Parse(s[0]);
                line = tr.ReadLine();
            }

            tr.Close();
        }

        public void updateItem(iPatient patient)
        {
            StreamReader tr = new StreamReader(path, Encoding.GetEncoding("iso-8859-1"));

            int lineNumber = 0;

            string line = tr.ReadLine();

            string[] s = {"-1"};

            while (line != null && int.Parse(s[0]) != patient.ID)
            {
                lineNumber++;
                s = line.Split(';');
                line = tr.ReadLine();
            }

            tr.Close();

            if (lineNumber == 0 && s[0] == "-1")
            {
                throw new System.Exception();
            }
            else
            {
                string stringPatient = "";
                stringPatient += patient.ID + ";" + patient.Name + ";" + patient.MothersName + ";" + patient.Note + ";" +
                                 patient.isMyPatient.ToString() + ";0";
                lineChanger(stringPatient, lineNumber);

            }

            
        }

        private void lineChanger(string newText, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(this.path);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(this.path, arrLine);
        }

    }
}
