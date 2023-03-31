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
        Dog[] dog;
        Person[] person;
        Pari[] parie;


        public MainWindow()
        {
            InitializeComponent();
            CreationJeu();
            Start();
        }

        public void CreationJeu()
        {
            game.Jeu(out dog, out person, out parie);

            RdnBttnjoe.Content = "joe possède " + person[0].money + " écus";
            RdnBttnBob.Content = "Bob possède " + person[1].money + " écus";
            RdnBttnBill.Content = "Bill possède " + person[2].money + " écus";

            Txtblckjoe.Text = "Joe n'a pas encore parié";
            TxtblckBob.Text = "Bob n'a pas encore parié";
            TxtblckBill.Text = "Bill n'a pas encore parié";

            Canvas[] CanvasDog = new Canvas[4];
            for (int i = 0; i < 4; i++)
            {
                CanvasDog[i] = new Canvas();
                CanvasDog[i].Children.Add(dog[i].image);
            }

        }

        public void Start()
        {
        }
        private void Parie_Click(object sender, RoutedEventArgs e)
        {
            int nbr;
            int ndog;
            if (int.TryParse(nbrparie.Text, out nbr) && int.TryParse(nbrparie.Text, out ndog))
            {
                if (ndog >= 1 && ndog <= 4)
                {
                    if (nbr >= 5)
                    {
                        if (TxtblckPerson.Text == "joe")
                        {
                            if (nbr > person[0].money)
                            {
                            Txtblckjoe.Text = "Joe a parié " + nbrparie.Text + " sur le chien n° " + nbrdog.Text;
                            }
                        }
                        else if (TxtblckPerson.Text == "Bob")
                        {
                            if (nbr > person[1].money)
                            {
                                TxtblckBob.Text = "Bob a parié " + nbrparie.Text + " sur le chien n° " + nbrdog.Text;
                            }
                        }
                        else if (TxtblckPerson.Text == "Bill")
                        {
                            if (nbr > person[2].money)
                            {
                                TxtblckBill.Text = "bill a parié " + nbrparie.Text + " sur le chien n° " + nbrdog.Text;
                            }
                        }
                    }
                }
                
            }
        }
        
        private void Start_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RdnBttn_Checked(object sender, RoutedEventArgs e)
        {
            if (RdnBttnjoe.IsChecked == true)
            {
                TxtblckPerson.Text = "joe";
            }
            else if (RdnBttnBob.IsChecked == true)
            {
                TxtblckPerson.Text = "Bob";
            }
            else
            {
                TxtblckPerson.Text = "Bill";
            }
        }
    }
}
