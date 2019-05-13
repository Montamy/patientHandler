using patientHandler.Classes;
using patientHandler.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private MainWindowViewModell vm;

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public MainWindowViewModell VM
        {
            get { return vm; }
            set
            {               
                vm = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(VM)));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            VM= new MainWindowViewModell();
            this.DataContext = VM;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (patientList.SelectedItem == null)
            {
                MessageBox.Show("You did not choose a patient.");
            }
            else
            {
               
                PatientWindow pWindow = new PatientWindow((patientList.SelectedItem as iPatient));
                pWindow.ShowDialog();
                this.VM.RefreshData();
            }
        }

        private void newPatientButton_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow pWindow = new PatientWindow();
            pWindow.ShowDialog();
            this.VM.RefreshData();
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
                    this.vm.db.deleteItem(patientList.SelectedItem);
                }
            }
            this.VM.RefreshData();
        }
    }
}
