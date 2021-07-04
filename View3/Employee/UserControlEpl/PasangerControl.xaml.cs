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

namespace View3.Employee.UserControlEpl
{
    /// <summary>
    /// Interaction logic for PasangerControl.xaml
    /// </summary>
    public partial class PasangerControl : UserControl
    {
        public PasangerControl()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _planes_combobox.ItemsSource = Airport.GetAllPlaneNums();
            EnumsToCmboBox();
        }


        private void plane_Changed(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataGrid();
        }
        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            var dr = dg.SelectedItem as Passanger;

            if (dr != null)
            {
                _name.Text = dr.name;
                _secondName.Text = dr.secondName;
                _nationality.Text = dr.nationality;
                _passportNum.Text = dr.passportNum;
                _dayOfBirthday.SelectedDate = dr.dateOfBirthday;
                _dayOfBirthday.DisplayDate = dr.dateOfBirthday;
                _sex.SelectedItem = dr.sex;
                _class.SelectedItem = dr.classF;
                _price.Text = dr.price.ToString();

                add_btn.IsEnabled = false;
                update_btn.IsEnabled = true;
                delete_btn.IsEnabled = true;

            }
        }

        #region btnClick
        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;

            AUDoperations(AUD.ADD);

            add_btn.IsEnabled = false;
            update_btn.IsEnabled = true;
            delete_btn.IsEnabled = true;
            ResetAll();

            Cursor = Cursors.Arrow;
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            AUDoperations(AUD.UPDATE);
            ResetAll();
            Cursor = Cursors.Arrow;
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            AUDoperations(AUD.DELETE);
            Cursor = Cursors.Arrow;
            ResetAll();
        }

        private void reset_btn_Click(object sender, RoutedEventArgs e)
        {
            ResetAll();
        }
        #endregion

        // TODO: Input data verification
        #region AUDoperations  
        private void AUDoperations(AUD state)
        {
            String str = "";
            switch (state)
            {
                case Entity.Enums.AUD.ADD:
                    Add(); str = "Row Inserted Successfully!";
                    break;
                case Entity.Enums.AUD.UPDATE:
                    Update(); str = "Row Updated Successfully!";
                    break;
                case Entity.Enums.AUD.DELETE:
                    Delete(); str = "Row Deleted Successfully!";
                    break;
                default:
                    break;
            }
            MessageBox.Show(str);
            UpdateDataGrid();
        }
        private void Add()
        {
            var pas = new Passanger()
            {
                classF = (Class)_class.SelectedIndex,
                dateOfBirthday = _dayOfBirthday.DisplayDate,
                name = _name.Text,
                nationality = _nationality.Text,
                passportNum = _passportNum.Text,
                planeNum = _planes_combobox.SelectedItem.ToString(),
                price = int.Parse(_price.Text),
                secondName = _secondName.Text,
                sex = (Sex)_sex.SelectedIndex
            };
            Airport.AddPassanger(pas);
        }

        private void Update()
        {
            var pas = new Passanger()
            {
                classF = (Class)_class.SelectedIndex,
                dateOfBirthday = _dayOfBirthday.DisplayDate,
                name = _name.Text,
                nationality = _nationality.Text,
                passportNum = _passportNum.Text,
                planeNum = _planes_combobox.SelectedItem.ToString(),
                price = int.Parse(_price.Text),
                secondName = _secondName.Text,
                sex = (Sex)_sex.SelectedIndex
            };
            Airport.DelPassanger(pas.passportNum);
            Airport.AddPassanger(pas);
        }

        private void Delete()
        {
            Airport.DelPassanger(_passportNum.Text);
        }
        #endregion





        private void UpdateDataGrid()
        {
            var passangers = Airport.GetPassangersByPlane(_planes_combobox.SelectedItem.ToString());
            myDataGrid.ItemsSource = passangers;
        }
        private void EnumsToCmboBox()
        {
            _sex.ItemsSource = Enum.GetValues(typeof(Sex)).Cast<Sex>().ToList();
            _class.ItemsSource = Enum.GetValues(typeof(Class)).Cast<Class>().ToList();
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
            _price.Text = "";

            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }
    }
}
