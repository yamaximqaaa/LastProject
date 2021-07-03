using Entity.Enums;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for PlaneControl.xaml
    /// </summary>
    public partial class PlaneControl : UserControl
    {
        public PlaneControl()
        {
            InitializeComponent();
        }
        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            SetTimeComboBox();
            EnumsToCmboBox();
        }

        

        #region ButtonClick
        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;

            AUDoperations(AUD.ADD);

            add_btn.IsEnabled = false;
            update_btn.IsEnabled = true;
            delete_btn.IsEnabled = true;

            Cursor = Cursors.Arrow;
        }
        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            AUDoperations(AUD.UPDATE);
            Cursor = Cursors.Arrow;
            ResetAll();
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            AUDoperations(AUD.DELETE);
            ResetAll();
            Cursor = Cursors.Arrow;
        }

        private void reset_btn_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            ResetAll();
            Cursor = Cursors.Arrow;
        }

        #endregion

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataGrid dg = sender as DataGrid;
            var dr = dg.SelectedItem as Plane;

            if (dr != null)
            {
                plane_num.IsEnabled = true;
                plane_num.Text = dr.planeNum;
                _city.Text = dr.city;
                _gate.Text = dr.gate;
                _status.SelectedItem = dr.status;
                _trminal.SelectedItem = dr.terminal;
                _airline.SelectedItem = dr.airline;
                day_In.DisplayDate = dr.timeIn.Date;
                day_In.Text = dr.timeIn.Date.ToString();
                day_Out.DisplayDate = dr.timeOut.Date;
                day_Out.Text = dr.timeOut.Date.ToString();
                in_Hours.SelectedItem = dr.timeIn.Hour;
                in_Minutes.SelectedItem = dr.timeIn.Minute;
                out_Hours.SelectedItem = dr.timeOut.Hour;
                out_Minutes.SelectedItem = dr.timeOut.Minute;

                add_btn.IsEnabled = false;
                update_btn.IsEnabled = true;
                delete_btn.IsEnabled = true;

            }
        }

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

        #region AUDoperations

        private void Add()
        {
            var plane = new Plane()
            {
                planeNum = plane_num.Text,
                city = _city.Text,
                gate = _gate.Text,
                status = (Status)_status.SelectedIndex,
                airline = (Airline)_airline.SelectedIndex,
                terminal = (Terminal)_trminal.SelectedIndex,
                timeIn = day_In.DisplayDate.AddHours(in_Hours.SelectedIndex).AddMinutes(in_Minutes.SelectedIndex),
                timeOut = day_In.DisplayDate.AddHours(in_Hours.SelectedIndex).AddMinutes(in_Minutes.SelectedIndex)
            };
            Airport.AddPlane(plane);
        }

        private void Update()
        {
            var plane = new Plane()
            {
                planeNum = plane_num.Text,
                city = _city.Text,
                gate = _gate.Text,
                status = (Status)_status.SelectedIndex,
                airline = (Airline)_airline.SelectedIndex,
                terminal = (Terminal)_trminal.SelectedIndex,
                timeIn = day_In.DisplayDate.AddHours(in_Hours.SelectedIndex).AddMinutes(in_Minutes.SelectedIndex),
                timeOut = day_In.DisplayDate.AddHours(in_Hours.SelectedIndex).AddMinutes(in_Minutes.SelectedIndex)
            };
            Airport.DelPlane(plane_num.Text);
            Airport.AddPlane(plane);
            plane_num.IsEnabled = true;
        }

        private void Delete()
        {
            Airport.DelPlane(plane_num.Text);
        }
        #endregion

        private void SetTimeComboBox()
        {
            in_Hours.ItemsSource = Enumerable.Range(1, 24).ToList();
            out_Hours.ItemsSource = Enumerable.Range(1, 24).ToList();
            in_Minutes.ItemsSource = Enumerable.Range(1, 60).ToList();
            out_Minutes.ItemsSource = Enumerable.Range(1, 60).ToList();
        }
        private void EnumsToCmboBox()
        {
            _status.ItemsSource = Enum.GetValues(typeof(Status)).Cast<Status>().ToList();
            _trminal.ItemsSource = Enum.GetValues(typeof(Terminal)).Cast<Terminal>().ToList();
            _airline.ItemsSource = Enum.GetValues(typeof(Airline)).Cast<Airline>().ToList();
        }
        private void UpdateDataGrid()
        {
            var planes = Airport.GetPlanes();
            myDataGrid.ItemsSource = planes;
        }
        private void ResetAll()
        {
            plane_num.Text = "";
            _city.Text = "";
            _gate.Text = "";
            _status.SelectedItem = null;
            _trminal.SelectedItem = null;
            _airline.SelectedItem = null;
            day_In.SelectedDate = null;
            day_Out.SelectedDate = null;
            in_Hours.SelectedItem = null;
            in_Minutes.SelectedItem = null;
            out_Hours.SelectedItem = null;
            out_Minutes.SelectedItem = null;

            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;

            plane_num.IsEnabled = true;
        }
        
    }
}
