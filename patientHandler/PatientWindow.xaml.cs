using patientHandler.Classes;
using patientHandler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace patientHandler
{
    /// <summary>
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window
    {
        private PatientWindowViewModell pVM;
        
        public PatientWindow(PatientWindowViewModell pVM)
        {
            InitializeComponent();
            this.pVM = pVM;
            this.DataContext = this.pVM;
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Reset(object sender, RoutedEventArgs e)
        {
            this.pVM.resetToOldpatient();
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            this.pVM.saveStatus();

            if(this.pVM.isNewPatient == true)
                this.pVM.db.addItem(this.pVM.newPatient);
            else
                this.pVM.db.updateItem(this.pVM.newPatient);
                           
            Close();
        }
    }
}
