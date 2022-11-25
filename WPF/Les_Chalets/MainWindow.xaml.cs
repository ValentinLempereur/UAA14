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
        int prix;
        bool reservation = false;
        bool vacance = false;

        int GChalet1P = 547;
        int GChalet2P = 581;
        int GChalet3P = 599;
        int GChalet4P = 600;
        int GChalet5P = 650;
        int GChalet6P = 690;

        int Chalet1P = 150;
        int Chalet2P = 200;
        int Chalet3P = 250;
        int Chalet4P = 297;
        int Chalet5P = 330;
        int Chalet6P = 347;

        int GTente1p = 349;
        int GTente2p = 380;
        int GTente3p = 390;
        int GTente4p = 400;
        int GTente5p = 415;
        int GTente6p = 467;

        int Tente1p = 80;
        int Tente2p = 100;
        int Tente3p = 150;
        int Tente4p = 198;
        int Tente5p = 220;
        int Tente6p = 250;

        public MainWindow()
        {
            InitializeComponent();
            TxtBoxNbr.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);
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

        private void BtnCalculer_Click(object sender, RoutedEventArgs e)
        {
            TextBox person = this.FindName("TxtBoxNbr") as TextBox;
            if (logement == "Tente")
            {
                if (vacance == true)
                {
                    switch (person.Text)
                    {
                        case "1":
                            prix = GTente1p;
                            break;
                        case "2":
                            prix = GTente2p;
                            break;
                        case "3":
                            prix = GTente3p;
                            break;
                        case "4":
                            prix = GTente4p;
                            break;
                        case "5":
                            prix = GTente5p;
                            break;
                        case "6":
                            prix = GTente6p;
                            break;
                    }
                }
                else
                {
                    switch (person.Text)
                    {
                        case "1":
                            prix = Tente1p;
                            break;
                        case "2":
                            prix = Tente2p;
                            break;
                        case "3":
                            prix = Tente3p;
                            break;
                        case "4":
                            prix = Tente4p;
                            break;
                        case "5":
                            prix = Tente5p;
                            break;
                        case "6":
                            prix = Tente6p;
                            break;
                    }
                }
                
            }
            else
            {
                if (vacance == false)
                {
                    switch (person.Text)
                    {
                        case "1":
                            prix = Chalet1P;
                            break;
                        case "2":
                            prix = Chalet2P;
                            break;
                        case "3":
                            prix = Chalet3P;
                            break;
                        case "4":
                            prix = Chalet4P;
                            break;
                        case "5":
                            prix = Chalet5P;
                            break;
                        case "6":
                            prix = Chalet6P;
                            break;
                    }
                }
                else
                {
                    switch (person.Text)
                    {
                        case "1":
                            prix = GChalet1P;
                            break;
                        case "2":
                            prix = GChalet2P;
                            break;
                        case "3":
                            prix = GChalet3P;
                            break;
                        case "4":
                            prix = GChalet4P;
                            break;
                        case "5":
                            prix = GChalet5P;
                            break;
                        case "6":
                            prix = GChalet6P;
                            break;
                    }
                }
                
            }

            if (reservation == true)
            {
                prix = prix + 15;
            }

            txtblckPrix.Text = "Prix à payer : " + prix;
        }

        private void VerifTextInput(object sender, TextCompositionEventArgs e)
        {
            

            if (!int.TryParse(e.Text, out int nbr))
            {
                e.Handled = true;
            }

            if (nbr < 1 || nbr > 6)
            {
                e.Handled = true;
            }

            if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
            {
                e.Handled = true;
            }
        }

        private void BtnDureeSortie_Click(object sender, RoutedEventArgs e)
        {
            TextBox Date1 = this.FindName("TxtBoxArrive") as TextBox;
            TextBox Date2 = this.FindName("TxtBoxSortie") as TextBox;
            string messageError = "Date Invalide";

            if (DateTime.TryParse(Date1.Text, out DateTime DateArrive) && DateTime.TryParse(Date2.Text, out DateTime DateSortie))
            {
                int mois1 = DateArrive.Month;
                int mois2 = DateSortie.Month;

                if ((mois1 == 4 && mois2 == 4) || ((mois1 == 7 || mois1 == 8) && (mois2 == 7 || mois2 == 8)) || ((mois1 == 12 || mois1 == 1) && (mois2 == 12 || mois2 == 1)))
                {
                    
                }
                else
                {
                    txtblckNbrsemaine.Text = "Nombre de semaines : " + messageError;
                }
            }
            else
            {
                txtblckNbrsemaine.Text = "Nombre de semaines : " + messageError;
            }
        }
    }
}
