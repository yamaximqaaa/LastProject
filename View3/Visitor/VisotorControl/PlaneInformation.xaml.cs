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

namespace View3.Visitor.VisotorControl
{
    /// <summary>
    /// Interaction logic for PlaneInformation.xaml
    /// </summary>
    public partial class PlaneInformation : UserControl
    {
        public PlaneInformation()
        {
            InitializeComponent();
        }

        private void loaded(object sender, RoutedEventArgs e)
        {
            var planes = Airport.GetPlanes();
            myDataGrid.ItemsSource = planes;
        }
    }
}
