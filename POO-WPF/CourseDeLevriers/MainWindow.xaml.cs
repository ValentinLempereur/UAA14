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
using System.Windows.Threading;

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
        DispatcherTimer timer = new DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();
            game.Jeu(out dog, out person, out parie);
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += new EventHandler(Timer_Tick);
            CreationJeu();
        }

        public void CreationJeu()
        {

            RdnBttnjoe.Content = "Joe possède " + person[0].money + " écus";
            RdnBttnBob.Content = "Bob possède " + person[1].money + " écus";
            RdnBttnBill.Content = "Bill possède " + person[2].money + " écus";

            Txtblckjoe.Text = "Joe n'a pas encore parié";
            TxtblckBob.Text = "Bob n'a pas encore parié";
            TxtblckBill.Text = "Bill n'a pas encore parié";
        }

        private void Parie_Click(object sender, RoutedEventArgs e)
        {
            int nbr;
            int ndog;
            
            if (int.TryParse(nbrparie.Text, out nbr) && int.TryParse(nbrdog.Text, out ndog))
            {
                game.Parie(person, nbr, ndog, TxtblckPerson.Text, out string text, parie);

                if (TxtblckPerson.Text == "Joe")
                {
                    Txtblckjoe.Text = text;
                    RdnBttnjoe.Content = "Joe possède " + person[0].money + " écus";
                }
                else if (TxtblckPerson.Text == "Bob")
                {
                    TxtblckBob.Text = text;
                    RdnBttnBob.Content = "Bob possède " + person[1].money + " écus";

                }
                else if (TxtblckPerson.Text == "Bill")
                {
                    TxtblckBill.Text = text;
                    RdnBttnBill.Content = "Bill possède " + person[2].money + " écus";
                }
            }
        }
        
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            TxtblckPerson.Text = "";
            nbrdog.Text = "";
            nbrparie.Text = "";

            person[0].money = 50;
            person[1].money = 75;
            person[2].money = 45;

            for (int i = 0; i < 3; i++)
            {
                parie[i].montant = 0;
                parie[i].numberDog = 0;
            }

            Txtblckjoe.Text = "Joe n'a pas encore parié";
            TxtblckBob.Text = "Bob n'a pas encore parié";
            TxtblckBill.Text = "Bill n'a pas encore parié";
        }

        private void RdnBttn_Checked(object sender, RoutedEventArgs e)
        {
            if (RdnBttnjoe.IsChecked == true)
            {
                TxtblckPerson.Text = "Joe";
            }
            else if (RdnBttnBob.IsChecked == true)
            {
                TxtblckPerson.Text = "Bob";
            }
            else
            {
                TxtblckPerson.Text = "Bill";
            }

            nbrdog.Text = "";
            nbrparie.Text = "";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (dog[i].MoovDog())
                {
                    timer.Stop();
                    for (int chiengagnant = 0; chiengagnant < 4; chiengagnant++)
                    {
                        if(dog[chiengagnant].IsWin())
                        {
                            chiengagnant += 1;
                            MessageBox.Show("Le gagnant est le chien n° " + chiengagnant);
                            

                            for (i = 0; i < 3; i++)
                            {
                                if (parie[i].numberDog == chiengagnant)
                                {
                                    person[i].money += parie[i].montant * 2;
                                }
                            }
                            chiengagnant -= 1;

                            //reset--------
                            for (i = 0; i < 3; i++)
                            {
                                parie[i].montant = 0;
                                parie[i].numberDog = 0;
                            }

                            for (i = 0; i < 4; i++)
                            {
                                dog[i].ResetMoov();
                            }

                            dog[chiengagnant].win = false;

                            CreationJeu();
                        }
                    }
                }
            }
        }
    }
}
