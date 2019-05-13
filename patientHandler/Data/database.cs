using patientHandler.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace patientHandler.Data
{
    public class Database :  iDatabase
    {
        private static Database _peldany;

        private ObservableCollection<iPatient> patientCollection;

        public string path;

        public int lastDataItem;

        public ObservableCollection<iPatient> PatientCollection
        {
            get { return patientCollection; }
            set { patientCollection = value; }
        }


        public static Database Get()
        {
            if(_peldany == null)
                _peldany = new Database();
            
            return _peldany;
        }

        #region Manipulate Database

      
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
                             patient.isMyPatient.ToString().ToLower() + ";0";

            File.AppendAllText(path, stringPatient + Environment.NewLine);
            getItemList();


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

            getItemList();

        }

        public void getItem()
        {
            throw new NotImplementedException();
        }

        public void getItemList()
        {
            patientCollection = new ObservableCollection<iPatient>();
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

            lastDataItem++;
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
                                 patient.isMyPatient.ToString().ToLower() + ";0";
                lineChanger(stringPatient, lineNumber);

            }
            getItemList();


        }

        #endregion

        #region Logic    

        
        private void lineChanger(string newText, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(this.path);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(this.path, arrLine);
        }

        #endregion
    }
}
