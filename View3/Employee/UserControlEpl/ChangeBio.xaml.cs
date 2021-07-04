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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace View3.Employee.UserControlEpl
{
    /// <summary>
    /// Interaction logic for ChangeBio.xaml
    /// </summary>
    public partial class ChangeBio : UserControl
    {
        User currUser;
        public ChangeBio()
        {
            InitializeComponent();
            //currUser = user;
            //textBoxFirstName.Text = user.Name;
            //textBoxLastName.Text = user.LastName;
            //textBoxLogin.Text = user.Login;
            //passwordBox1.Password = user.Password;
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            Airport.DelUser(currUser.Login);
            Airport.AddUser(new User()
            {
                IsEmploee = currUser.IsEmploee,
                LastName = textBoxLastName.Text,
                Login = textBoxLogin.Text,
                Password = passwordBox1.Password,
                Name = textBoxFirstName.Text
            });
            Cursor = Cursors.Arrow;
        }
    }
}
