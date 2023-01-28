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

namespace CeUAA14Partie2_dec22_Lempereur
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Jeu jeu = new Jeu();
        Quadrillage Test = new Quadrillage();
        public MainWindow()
        {
            InitializeComponent();
            grid();
            Test.prepareInterface();
            //jeu.TourJoueur(string symboleJoueur, int numeroJoueur, ref int totaljoueur, ref int totalJoueur, ref int[] positionPionJoueur, ref string ancienneValeur);
        }

        public void grid()
        {
            this.Width = 800;
            this.Height = 800;

            this.FontSize = 36;
            this.Title = "Des serpens et des échelles";

            ColumnDefinition[] ColDef = new ColumnDefinition[10];
            RowDefinition[] RowDef = new RowDefinition[10];

            for (int i = 0; i < 10; i++)
            {
                ColDef[i] = new ColumnDefinition();
                grdMain2.ColumnDefinitions.Add(ColDef[i]);
            }

            for (int i = 0; i < 10; i++)
            {
                RowDef[i] = new RowDefinition();
                grdMain2.RowDefinitions.Add(RowDef[i]);
            }
        }

    }
}
