using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CalendarDialog
{
    class ownCanvas
    {
        public StackPanel canvas;
        public ownCanvas()
        {
            firstView();
        }
        public void firstView()
        {
            canvas = new StackPanel();
            canvas.Background = Brushes.Aqua;
            canvas.Width = 400;
            canvas.Height = 400;

            Label dialogName = new Label();
            dialogName.FontSize = 20;
            dialogName.Content = "Nazwa wydarzenia";

            TextBox tb = new TextBox();
            tb.Width = 100;
            tb.Height = 25;
            tb.FontSize = 16;

            Label godzinaWydarzenia = new Label();
            godzinaWydarzenia.FontSize = 20;
            godzinaWydarzenia.Content = "Godzina rozpoczęcia wydarzenia";

            TextBox tb2 = new TextBox();
            tb2.Width = 100;
            tb2.Height = 25;
            tb2.FontSize = 16;

            Label godzinaWydarzenia2 = new Label();
            godzinaWydarzenia2.FontSize = 20;
            godzinaWydarzenia2.Content = "Godzina zakończenia wydarzenia";

            TextBox tb3 = new TextBox();
            tb3.Width = 100;
            tb3.Height = 25;
            tb3.FontSize = 16;

            Label lokalizacja = new Label();
            lokalizacja.FontSize = 20;
            lokalizacja.Content = "Lokalizacja wydarzenia";

            TextBox tb4 = new TextBox();
            tb4.Width = 100;
            tb4.Height = 25;
            tb4.FontSize = 16;

            Label charakter = new Label();
            charakter.FontSize = 20;
            charakter.Content = "Charakter wydarzenia";

            TextBox tb5 = new TextBox();
            tb5.Width = 100;
            tb5.Height = 25;
            tb5.FontSize = 16;

            Button zapisz = new Button();
            zapisz.Content = "Zapisz";
            zapisz.FontSize = 16;
            zapisz.Width = 100;
            zapisz.Height = 30;
            zapisz.BorderThickness = new Thickness(2);
            zapisz.MouseDown += Zapisz_MouseDown; ;

            Button anuluj = new Button();
            anuluj.Content = "Anuluj";
            anuluj.FontSize = 16;
            anuluj.Width = 100;
            anuluj.Height = 30;
            anuluj.BorderThickness = new Thickness(2);
            anuluj.MouseLeftButtonDown += Anuluj_MouseLeftButtonDown1;

            canvas.Children.Add(dialogName);
            canvas.Children.Add(tb);
            canvas.Children.Add(godzinaWydarzenia);
            canvas.Children.Add(tb2);
            canvas.Children.Add(godzinaWydarzenia2);
            canvas.Children.Add(tb3);
            canvas.Children.Add(lokalizacja);
            canvas.Children.Add(tb4);
            canvas.Children.Add(charakter);
            canvas.Children.Add(tb5);

            canvas.Children.Add(zapisz);
            canvas.Children.Add(anuluj);

            Canvas.SetLeft(canvas, 40);
            Canvas.SetTop(canvas, 40);
        }

        private void Anuluj_MouseLeftButtonDown1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }

        private void Zapisz_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }
    }

}
