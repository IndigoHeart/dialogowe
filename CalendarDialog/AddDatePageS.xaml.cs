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
    /// Interaction logic for AddDatePageS.xaml
    /// </summary>
    public partial class AddDatePageS : Page
    {
        NewEvent newEvent;
        public AddDatePageS(NewEvent ne)
        {
            InitializeComponent();
            newEvent = ne;
            podsumowanie.Content = newEvent.eventName + "\nOd: " + newEvent.startHour + "\nDo: " + newEvent.endHour + "\nLokalizacja: " + newEvent.localization + "\nCharakter: " + newEvent.eventNature;
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[1].Close();
        }
    }
}
