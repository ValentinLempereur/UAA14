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

namespace resolution_du_trinome
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            A.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);
            B.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);
            C.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);
            trynome();
        }

        private void trynome()
        {
            int a = A;
            int b = B;
            int c = C;

            int delta = b * b - 4 * a * c;
            if (delta > 0)
            {
                -b+Math.Sqrt(delta) / 2*a = int x1;
            }
        }
        private void VerifTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != "," && !EstEntier(e.Text))
            {
                e.Handled = true;
            }

            if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
            {
                e.Handled = true;
            }
        }

        private bool EstEntier(string texteUser)
        {
            bool ok;
            if (int.TryParse(texteUser, out int text))
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
            return ok;
        }



        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Result.Background = Brushes.Red;
            Result.Foreground = Brushes.Black;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Result.Background = Brushes.CadetBlue;
            Result.Foreground = Brushes.CadetBlue;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            string message = "";
            page2 essaie = new page2();
            essaie.TxtResult.Text = message;
            essaie.Show();
        }
    }
}
