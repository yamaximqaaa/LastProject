using Entity.Enums;
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

namespace View3.Visitor.VisotorControl
{
    /// <summary>
    /// Interaction logic for BuyTicket.xaml
    /// </summary>
    public partial class BuyTicket : UserControl
    {
        User curUser;
        Airline selectedAirline;
        String selectedPlane;
        public BuyTicket(User user)
        {
            InitializeComponent();
            curUser = user;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            SetUser();
            EnumsToCmboBox();
        }


        private void buy_btn_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            var pas = new Passanger()
            {
                classF = (Class)_class.SelectedIndex,
                dateOfBirthday = _dayOfBirthday.DisplayDate,
                name = _name.Text,
                nationality = _nationality.Text,
                passportNum = _passportNum.Text,
                planeNum = selectedPlane,
                price = int.Parse(_price.Text),
                secondName = _secondName.Text,
                sex = (Sex)_sex.SelectedIndex
            };
            Airport.AddPassanger(pas);
            ResetAll();
            Cursor = Cursors.Arrow;
            MessageBox.Show("Ticket bought!");
        }


        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            var dr = dg.SelectedItem as Plane;

            if (dr != null)
            {
                _class.SelectedItem = null;
                plane_num.Text = dr.planeNum;
                selectedPlane = dr.planeNum;
                _airline.Text = dr.airline.ToString();
                selectedAirline = dr.airline;
                _city.Text = dr.city;
            }
        }
        private void UpdateDataGrid()
        {
            var planes = Airport.GetPlaneAfterDate(DateTime.Now);
            myDataGrid.ItemsSource = planes;
        }
        private void EnumsToCmboBox()
        {
            _sex.ItemsSource = Enum.GetValues(typeof(Sex)).Cast<Sex>().ToList();
            _class.ItemsSource = Enum.GetValues(typeof(Class)).Cast<Class>().ToList();
        }
        private void SetUser()
        {
            _name.Text = curUser.Name;
            _secondName.Text = curUser.LastName;
        }

        private void class_changed(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _price.Text = Airport.GetPrice((Class)_class.SelectedIndex, selectedAirline).ToString();
            }
            catch (Exception)
            {
                _price.Text = "Choose class";
            }
        }
        private void ResetAll()
        {
            _name.Text = "";
            _secondName.Text = "";
            _nationality.Text = "";
            _passportNum.Text = "";
            _dayOfBirthday.SelectedDate = null;
            _sex.SelectedItem = null;
            _class.SelectedItem = null;
            _price.Text = "Choose class";

            add_btn.IsEnabled = true;
        }
    }
}
