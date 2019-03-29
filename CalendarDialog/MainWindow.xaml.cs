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
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;



namespace CalendarDialog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NewEvent mainEvent;
        public DateTime firstDayOfTheWeek { get; set; }
        public int supportRow { get; set; }
        public int supportColumn { get; set; }

        EventContext _context;
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("pl-PL"));
        public MainWindow()
        {
            InitializeComponent();
            setGridInitial();
            setInitialDate();
            Choices commandsChoices = new Choices();
            commandsChoices.Add(new string[] {"Nowe zadanie", "Dodaj"});
            try
            {
                GrammarBuilder gBuilder = new GrammarBuilder();
                gBuilder.Append(commandsChoices);
                Grammar grammar = new Grammar(gBuilder);
                recEngine.LoadGrammarAsync(grammar);
                recEngine.SetInputToDefaultAudioDevice();
                recEngine.RecognizeAsync(RecognizeMode.Multiple);
                recEngine.SpeechRecognized += recEngine_SpeachRecognized;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            _context = new EventContext();
        }

        private void recEngine_SpeachRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence >= 0.70)
            {
                Console.WriteLine("Wykrylem " + e.Result.Text);
                AddDate createNewEvent = new AddDate();
                createNewEvent.Show();

            }
            else
                Console.WriteLine("Unknown word: " + e.Result.Text + ", Confidence: " + e.Result.Confidence);
        }

        // ustawia dni w tygodniu na siatce kalendarza
        private void setInitialDate()
        {
            DateTime today = DateTime.Now;
            int dayOfWeek = (int)today.DayOfWeek;
            firstDayOfTheWeek = setFirstDayOfWeek(today, 0);

            for (int i = 1; i<calendar_grid.ColumnDefinitions.Count; i++)
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

        DateTime setFirstDayOfWeek(DateTime dT, int i)
        {
            DateTime newDateTime = new DateTime();
            int dayOfWeek = (int)dT.DayOfWeek;

            if (dayOfWeek > 0)
            {
                newDateTime = dT.AddDays(-dayOfWeek + i);
            }
            else if (dayOfWeek == 0)
            {
                newDateTime = dT.AddDays(i - 7);
            }
            return newDateTime;
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
            firstDayOfTheWeek = setFirstDayOfWeek(dateTime, 0);

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

            UIElement element = (UIElement)g.InputHitTest(e.GetPosition(g));
            supportRow = Grid.GetRow(element);
            supportColumn = Grid.GetColumn(element);

            AddDate createNewEvent = new AddDate();
            createNewEvent.Show();
        }

        public void setNewEventOnGrid()
        {
            TextBlock tb = new TextBlock();
            mainEvent.dateOfEvent = firstDayOfTheWeek.AddDays(supportColumn);
            tb.Width = 80;
            tb.Margin = new Thickness(1);
            tb.Background = Brushes.Orange;
            tb.Text = mainEvent.eventName + "\nOd: " + mainEvent.startHour + "\nDo: " + mainEvent.endHour + "\nLokalizacja: " + 
                mainEvent.localization + "\nCharakter: " + mainEvent.eventNature + "\nData: " + mainEvent.dateOfEvent.ToString();
            calendar_grid.Children.Add(tb);
            Grid.SetRowSpan(tb, Int32.Parse(mainEvent.endHour) - Int32.Parse(mainEvent.startHour));
            Grid.SetColumn(tb, supportColumn);
            Grid.SetRow(tb, Int32.Parse(mainEvent.startHour)+1);
            _context.newEvents.Add(mainEvent);
            _context.SaveChanges();
        }
    }
}
