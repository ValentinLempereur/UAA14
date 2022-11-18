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

namespace Les_Chalets
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string logement;
        bool reservation = false;
        public MainWindow()
        {
            InitializeComponent();
            Prepare();
        }

        public void Prepare()
        {
            
        }

        private void Radio_Click(object sender, RoutedEventArgs e)
        {
            logement = ((RadioButton)sender).Name;
        }

        private void BoxReservation_Click(object sender, RoutedEventArgs e)
        {
            if (reservation == true)
            {
                reservation = false;
            }
            else 
            {
                reservation = true;
            }
        }
    }
}
