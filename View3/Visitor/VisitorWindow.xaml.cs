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
using View3.ViewModel.Visitor;
using View3.Visitor.VisotorControl;

namespace View3.Visitor
{
    /// <summary>
    /// Interaction logic for VisitorWindow.xaml
    /// </summary>
    public partial class VisitorWindow : Window
    {
        User curUser;
        public VisitorWindow(User user)
        {
            InitializeComponent();
            curUser = user;
        }

        private void BuyTicket_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new BuyTicket(curUser);
        }

        private void PlaneInfomation_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new PlaneInformation();
        }

        private void ChangeBio_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Employee.UserControlEpl.ChangeBio(curUser);
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            curUser = null;
            new MainWindow().Show();
            Close();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            SetHello();
            DataContext = new PlaneInformation();
        }
        private void SetHello()
        {
            switch (Airport.GetDayPart())
            {
                case 1: { helloText.Text = $"Good night, {curUser.LastName} {curUser.Name}"; break; }
                case 2: { helloText.Text = $"Good morning, {curUser.LastName} {curUser.Name}"; break; }
                case 3: { helloText.Text = $"Good afternoon, {curUser.LastName} {curUser.Name}"; break; }
                case 4: { helloText.Text = $"Good evening, {curUser.LastName} {curUser.Name}"; break; }
                default: { helloText.Text = $"Hello, {curUser.LastName} {curUser.Name}"; break; }
            }
        }

    }
}
