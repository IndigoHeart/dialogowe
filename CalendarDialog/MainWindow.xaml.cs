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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            setGridInitial();
            setInitialDate();
        }

        // ustawia dni w tygodniu na siatce kalendarza
        private void setInitialDate()
        {
            DateTime today = DateTime.Now;
            int dayOfWeek = (int)today.DayOfWeek;


            for(int i = 1; i<calendar_grid.ColumnDefinitions.Count; i++)
            {
                String str = findDayOfWeek(today, i);
                TextBlock txtBlock = new TextBlock(new Run(str));
                txtBlock.TextAlignment = TextAlignment.Center;
                txtBlock.FontSize = 14;
                txtBlock.Background = Brushes.Coral;
                txtBlock.VerticalAlignment = VerticalAlignment.Center;
                txtBlock.FontWeight = FontWeights.Bold;
                txtBlock.Padding = new Thickness(10);

                calendar_grid.Children.Add(txtBlock);
                Grid.SetColumn(txtBlock, i);
                Grid.SetRow(txtBlock, 1);
            }

        }

        string findDayOfWeek(DateTime dateTime, int i)
        {
            string setUpDay = "";
            int dayOfWeek = (int)dateTime.DayOfWeek;

            if (dayOfWeek > 0)
            {
                setUpDay = dateTime.AddDays(-dayOfWeek + i).Day.ToString();
            }
            else if (dayOfWeek == 0)
            {
                setUpDay = dateTime.AddDays(i - 7).Day.ToString();
            }
            return setUpDay;
        }

        void setNewDates(DateTime dateTime)
        {
            for(int j=1; j<calendar_grid.ColumnDefinitions.Count; j++)
            {
                String str = findDayOfWeek(dateTime, j);
                for (int i = 0; i < calendar_grid.Children.Count; i++)
                {
                    UIElement e = calendar_grid.Children[i];
                    if (Grid.GetRow(e) == 1 && Grid.GetColumn(e) == j)
                    {
                        calendar_grid.Children.Remove(e);
                        TextBlock txtBlock = new TextBlock(new Run(str));
                        txtBlock.TextAlignment = TextAlignment.Center;
                        txtBlock.FontSize = 14;
                        txtBlock.Background = Brushes.Coral;
                        txtBlock.VerticalAlignment = VerticalAlignment.Center;
                        txtBlock.FontWeight = FontWeights.Bold;
                        txtBlock.Padding = new Thickness(10);
                        calendar_grid.Children.Add(txtBlock);
                        Grid.SetColumn(txtBlock, j);
                        Grid.SetRow(txtBlock, 1);
                    }
                }
            }
        }

        // ustawia siatkę z prostokątami wewnątrz kalendarza i godziny na kolendarzu
        private void setGridInitial()
        {
            for(int i = 1; i < calendar_grid.ColumnDefinitions.Count; i++)
            {
                for(int j=2; j< calendar_grid.RowDefinitions.Count; j++)
                {
                    Rectangle ownRectangle = new Rectangle();
                    SolidColorBrush blueBrush = new SolidColorBrush();
                    if (i % 2 == 1)
                    {
                        blueBrush.Color = Colors.Blue;
                    }
                    else
                        blueBrush.Color = Colors.BlueViolet;

                    if(j % 2 == 1)
                    {
                        blueBrush.Color = Colors.DarkBlue;
                    }


                    SolidColorBrush blackBrush = new SolidColorBrush();
                    blackBrush.Color = Colors.Black;
                    ownRectangle.StrokeThickness = 1;
                    ownRectangle.Stroke = blackBrush;

                    ownRectangle.Fill = blueBrush;
                    //cellGrid.MouseDown += OnClickGrid;
                    calendar_grid.Children.Add(ownRectangle);
                    Grid.SetColumn(ownRectangle, i);
                    Grid.SetRow(ownRectangle, j);
                }
            }

            void OnClickGrid(object sender, RoutedEventArgs e)
            {
                //Grid g = (Grid)sender;
                //TextBlock tb = new TextBlock();
                //tb.Background = Brushes.Orange;
                //tb.Text = "kszak";
                //tb.Margin = new Thickness(10);
                //g.Children.Add(tb);
            }

            // ustawia godziny na siatce kalendarza
            for(int i=2; i<calendar_grid.RowDefinitions.Count; i++)
            {
                String str = "";
                if (i > 10)
                {
                    str = (i-1) + ":00";
                }
                else
                {
                    str = "0" + (i - 1) + ":00";
                }

                TextBlock txtBlock = new TextBlock(new Run(str));
                txtBlock.TextAlignment = TextAlignment.Center;
                txtBlock.FontSize = 14;
                txtBlock.FontWeight = FontWeights.Bold;
                txtBlock.Padding = new Thickness(10);

                calendar_grid.Children.Add(txtBlock);
                Grid.SetColumn(txtBlock, 0);
                Grid.SetRow(txtBlock, i);
            }
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            textbox1.Text = calendar.SelectedDate.Value.DayOfWeek.ToString() + " " + calendar.SelectedDate.Value.ToString();
            setNewDates(calendar.SelectedDate.Value);
        }

        private void Button_close_app_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Calendar_grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid g = (Grid)sender;
            TextBlock tb = new TextBlock();
            tb.Width = 80;
            tb.Margin = new Thickness(1);
            tb.Background = Brushes.Orange;
            tb.Text = "kszak";
            UIElement element = (UIElement)g.InputHitTest(e.GetPosition(g));
            int row = Grid.GetRow(element);
            int column = Grid.GetColumn(element);
            if(row>1 && column > 0)
            {
                calendar_grid.Children.Add(tb);
                Grid.SetRowSpan(tb, 2);
                Grid.SetColumn(tb, column);
                Grid.SetRow(tb, row);
            }
            ownCanvas oc = new ownCanvas();
            topWindow.Children.Add(oc.canvas);
            AddDate x = new AddDate();
            x.Show();
        }
    }
}
