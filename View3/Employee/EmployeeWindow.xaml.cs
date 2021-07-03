using Model;
using Model.Entities;
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
using View3.Employee.UserControlEpl;
using View3.ViewModel.Employee;

namespace View3.Employee
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        private User _currentUser;

        public EmployeeWindow(User user)
        {
            _currentUser = user;
            InitializeComponent();
            switch (Airport.GetDayPart())
            {
                case 1: { helloText.Text = $"Good night, {_currentUser.LastName} {_currentUser.Name}"; break; }
                case 2: { helloText.Text = $"Good morning, {_currentUser.LastName} {_currentUser.Name}"; break; }
                case 3: { helloText.Text = $"Good afternoon, {_currentUser.LastName} {_currentUser.Name}"; break; }
                case 4: { helloText.Text = $"Good evening, {_currentUser.LastName} {_currentUser.Name}"; break; }
                default: { helloText.Text = $"Hello, {_currentUser.LastName} {_currentUser.Name}"; break; }
            }
            DataContext = new PlaneControlViewModel();
        }




        #region MenuButtonsClick
        private void ChangeBio_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ChangeBioViewModel();
        }

        private void PlaneControl_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new PlaneControlViewModel();
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            _currentUser = null;
            Close();
            new MainWindow().Show();
        }
        #endregion

    }
}
