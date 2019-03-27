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
    /// Interaction logic for AddDatePage1.xaml
    /// </summary>
    public partial class AddDatePage1 : Page
    {
        public AddDatePage1()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NewEvent ne = new NewEvent();
            ne.eventName = eventNameTb.Text;

            AddDatePage2 addDatePage2 = new AddDatePage2(ne);
            this.NavigationService.Navigate(addDatePage2);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[1].Close();
        }
    }
}
