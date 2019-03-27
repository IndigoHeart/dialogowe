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
    /// Interaction logic for AddDatePage5.xaml
    /// </summary>
    public partial class AddDatePage5 : Page
    {
        NewEvent newEvent;
        public AddDatePage5(NewEvent ne)
        {
            InitializeComponent();
            newEvent = ne;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            newEvent.eventNature = eventNatureTb.Text;

            AddDatePageS addDatePageS = new AddDatePageS(newEvent);
            this.NavigationService.Navigate(addDatePageS);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[1].Close();
        }
    }
}
