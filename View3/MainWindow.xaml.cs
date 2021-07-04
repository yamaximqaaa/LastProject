using Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using View3.Employee;
using View3.Registration;
using View3.Visitor;

namespace View3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RegistrationWindow registrationWindow;
        VisitorWindow visitorWindow;
        EmployeeWindow employeeWindow;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            try
            {
                var user = Airport.GetUser(loginBox.Text, passwordBox.Password);
                if (user != null)
                {
                    if (user.IsEmploee)
                    {
                        employeeWindow = new EmployeeWindow(user);
                        employeeWindow.Show();
                        Close();
                    }
                    else
                    {
                        visitorWindow = new VisitorWindow();
                        visitorWindow.Show();
                        Close();
                    }
                }
                else
                {
                    erroMassage.Content = "Wrong login or password!";
                }
            }
            catch (Exception ex)
            {
                erroMassage.Content = "Somthing went wrong!" + "\n" + ex.Message;
            }



            Cursor = Cursors.Arrow;
        }
    }
}
