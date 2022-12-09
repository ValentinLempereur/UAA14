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
        public MainWindow()
        {
            InitializeComponent();
            prepareInterface();
            test(sender);
        }

        public void prepareInterface()
        {
            //------------------------------Main Dimension---------------------------------
            this.Width = 800;
            this.Height = 720;
            //-----------------------------------------------------------------------------
            Button[] Btn = new Button[100];
            int Compte = 0;


            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    Compte = 10 * i;
                    for (int j = 0; j < 10; j++)
                    {
                        Compte++;
                        Btn[i] = new Button();
                        Btn[i].Content = Compte;
                        Btn[i].Width = 40;
                        Btn[i].Height = 40;
                        Btn[i].VerticalAlignment = VerticalAlignment.Center;
                        Btn[i].HorizontalAlignment = HorizontalAlignment.Center;
                        if (j == 1 || j == 3 || j == 5 || j == 7 || j == 9)
                        {
                            Btn[i].Background = Brushes.Red;
                        }
                        else
                        {
                            Btn[i].Background = Brushes.Aqua;
                        }

                        Grid.SetRow(Btn[i], i);
                        Grid.SetColumn(Btn[i], j);
                        grdMain2.Children.Add(Btn[i]);
                    }
                }
                else
                {
                    Compte = 10 * i + 10;
                    for (int j = 0; j < 10; j++)
                    {
                        Btn[i] = new Button();
                        Btn[i].Content = Compte;
                        Btn[i].Width = 40;
                        Btn[i].Height = 40;
                        Btn[i].VerticalAlignment = VerticalAlignment.Center;
                        Btn[i].HorizontalAlignment = HorizontalAlignment.Center;
                        if (j == 1 || j == 3 || j == 5 || j == 7 || j == 9)
                        {                  
                            Btn[i].Background = Brushes.Aqua;
                        }
                        else
                        {
                            Btn[i].Background = Brushes.Red;
                        }

                        Grid.SetRow(Btn[i], i);
                        Grid.SetColumn(Btn[i], j);
                        grdMain2.Children.Add(Btn[i]);
                        Compte--;
                    }
                }
            }
        }

        public void test(object sender)
        {
            Random alea = new Random();
            int de;
            int reste;
            int totaljoueur = 0;
            int[] positionPionJoueur = new int[2];

            int ancienneValeur = int.Parse(((Button)sender).Content);
            de = alea.Next(1, 7);
            Btn[de].Content = "X";
            Btn[de].Foreground = Burshes.Gold;
            totaljoueur = totaljoueur + de;
            reste = totaljoueur - 10 * (positionPionJoueur[0] + 1);

            if (reste < 0)
            {
                reste = reste + 10;
            }
            else
            {
                positionPionJoueur[0] = positionPionJoueur[0] + 1;
            }

            if (positionPionJoueur[0] % 2 != 0)
            {
                positionPionJoueur[1] = 9 - reste;
            }
            else
            {
                positionPionJoueur[1] = reste;
            }

            if (positionPionJoueur[0] <= 9)
            {
                ((Button)sender).Content = ancienneValeur;
            }
            else
            {
                BtnPlay.Content = "plus d'isponible";
            }
        }
    }
}
