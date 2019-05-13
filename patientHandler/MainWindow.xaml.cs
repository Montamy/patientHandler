using patientHandler.Classes;
using patientHandler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace patientHandler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.MainWindowViewModell();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (patientList.SelectedItem == null)
            {
                MessageBox.Show("You did not choose a patient.");
            }
            else
            {
                PatientWindowViewModell pVM = new PatientWindowViewModell(patientList.SelectedItem);
                PatientWindow pWindow = new PatientWindow(pVM);
                pWindow.Show();
            }
        }

        private void newPatientButton_Click(object sender, RoutedEventArgs e)
        {
            PatientWindowViewModell pVM = new PatientWindowViewModell();
            PatientWindow pWindow = new PatientWindow(pVM);
            pWindow.Show();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (patientList.SelectedItem == null)
            {
                MessageBox.Show("You did not choose a patient.");
            }
            else
            {
                var x = MessageBox.Show("Are you really want to delete this patient?","Delete Patient",
                         System.Windows.MessageBoxButton.OKCancel,
                         System.Windows.MessageBoxImage.Question,
                         System.Windows.MessageBoxResult.Cancel);

                if(x == MessageBoxResult.OK)
                {
                    //delete here the choosen patient
                }
            }
        }
    }
}
