﻿using System;
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
    /// Interaction logic for AddDatePage3.xaml
    /// </summary>
    public partial class AddDatePage3 : Page
    {
        NewEvent newEvent;
        public AddDatePage3(NewEvent ne)
        {
            InitializeComponent();
            newEvent = ne;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            newEvent.endHour = endHourTb.Text;

            AddDatePage4 addDatePage4 = new AddDatePage4(newEvent);
            this.NavigationService.Navigate(addDatePage4);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[1].Close();
        }
    }
}
