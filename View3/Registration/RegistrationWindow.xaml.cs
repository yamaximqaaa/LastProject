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

namespace View3.Registration
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxLogin.Text = "";
            passwordBox1.Password = "";
            IsEmployee.IsChecked = false;
        }
        private void Submit_Click(object sender, RoutedEventArgs e) // TODO: create user with existed login 
        {
            string firstName = textBoxFirstName.Text;
            string secondName = textBoxLastName.Text;
            string login = textBoxLogin.Text;
            string password = passwordBox1.Password;
            bool _isEmployee = (bool)IsEmployee.IsChecked;

            using (Cursor = Cursors.Wait)
            {
                if (_isEmployee == true)
                {
                    var checkResult = Airport.IsUserEmploee(textBoxLogin2.Text, passwordBox2.Password);
                    if (checkResult == false)
                    {
                        errormessage.Text = "Incorrect emploee user";
                        return;
                    }
                }

                var newUser = new User()
                {
                    Name = firstName,
                    LastName = secondName,
                    Login = login,
                    Password = password,
                    IsEmploee = _isEmployee
                };

                bool tick = Airport.AddUser(newUser);

                if (tick == false)
                {
                    errormessage.Text = "Something went wrong";
                }
                if (tick == true)
                {
                    Close();
                }
            }
            Cursor = Cursors.Arrow;
        }
    }
}
