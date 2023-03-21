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

namespace CourseDeLevriers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game = new Game();
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        public void Start()
        {
            game.Jeu();
        }
        private void Parie_Click(object sender, RoutedEventArgs e)
        {
            game.Parie();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RdnBttn_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
