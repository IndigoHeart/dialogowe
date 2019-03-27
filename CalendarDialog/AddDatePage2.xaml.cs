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

namespace CalendarDialog
{
    /// <summary>
    /// Interaction logic for AddDatePage2.xaml
    /// </summary>
    public partial class AddDatePage2 : Page
    {
        NewEvent newEvent;
        public AddDatePage2(NewEvent ne)
        {
            InitializeComponent();
            newEvent = ne;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            newEvent.startHour = startHourTb.Text;

            AddDatePage3 addDatePage3 = new AddDatePage3(newEvent);
            this.NavigationService.Navigate(addDatePage3);
        }
 
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[1].Close();
        }
    }
}
