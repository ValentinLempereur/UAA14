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
//permet de voir cette page 
using GuichetBanquaire.View;
using GuichetBanquaire.Class;

namespace GuichetBanquaire
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Personne perso;
        public CompteCourant[] compteCourant;
        public CompteEpargne[] compteEpargne;

        public MainWindow()
        {
            InitializeComponent();
            PrepareInitialize();
        }

        public void PrepareInitialize()
        {
            Button Exit = new Button();

            Exit.Content = "quitter";
            Exit.Background = Brushes.Red;
            Exit.Foreground = Brushes.Black;
            Exit.FontWeight = FontWeights.Bold;
            Exit.FontSize = 20;
            Exit.Width = 200;
            Exit.Height = 80;
            Exit.VerticalAlignment = VerticalAlignment.Bottom;
            Exit.HorizontalAlignment = HorizontalAlignment.Right;
            Exit.Click += new RoutedEventHandler(Exit_Click);
            grdMain.Children.Add(Exit);

            frame.Content = new Login();

            Thickness margin = new Thickness();
            margin.Left = 100;
            margin.Top = 30;

            TextBlock Name = new TextBlock();
            Name.Text = "Bienvenue au guichet Bancaire Asty-Moulin";
            Name.VerticalAlignment = VerticalAlignment.Top;
            Name.HorizontalAlignment = HorizontalAlignment.Left;
            Name.Margin = margin;
            Name.FontWeight = FontWeights.Bold;
            Name.FontSize = 60;

            grdMain.Children.Add(Name);
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
