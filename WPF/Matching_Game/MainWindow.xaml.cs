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
//---ajout nécéssaire pour le timer---
using System.Windows.Threading;
//------------------------------------

namespace Matching_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
            timer.Tick += new EventHandler(Timer_Tick);
        }

        //-------------------------------Les émojis-------------------------------------------------
        private void SetUpGame()
        {
            int index;
            string nextEmoji;
            Random nbAlea = new Random();
            

            List<string> animalEmoji = new List<string>()
                {
                "🍌","🍌",
                "🍉","🍉",
                "🍗","🍗",
                "🍔","🍔",
                "🥩","🥩",
                "🍟","🍟",
                "🍕","🍕",
                "🥓","🥓",
                };

            foreach (TextBlock textBlock in grdMain.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "txtTemps")
                {
                    index = nbAlea.Next(animalEmoji.Count);// nbalea est un objet de type Random()
                    nextEmoji = animalEmoji[index];
                    textBlock.Text = nextEmoji;
                    animalEmoji.RemoveAt(index); // on retire un animal de la liste pour ne pas l’attribuer à nouveau.
                }  
            }
            timer.Interval = TimeSpan.FromSeconds(.1);
            tempsEcoule = 0;
            nbPairesTrouvees = 0;
            timer.Start();

        }

        //--------------------------------------------------------------------------------
        //---------------------------les boutons-----------------------------------------------------

        TextBlock derniereTBClique; // on va l’utiliser pour faire une référence à  la TextBlock sur laquelle on vient de cliquer
        bool trouvePaire = false;


        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            

            TextBlock textBlockActif = sender as TextBlock;
            if (!trouvePaire)
            {
                textBlockActif.Visibility = Visibility.Hidden;
                derniereTBClique = textBlockActif;
                trouvePaire = true;
            }
            else if (textBlockActif.Text == derniereTBClique.Text)
            {
                textBlockActif.Visibility = Visibility.Hidden;
                trouvePaire = false;
            }
            else if (textBlockActif.Text == derniereTBClique.Text)
            {
                nbPairesTrouvees++;
                textBlockActif.Visibility = Visibility.Hidden;
                trouvePaire = false;
            }
            else
            {
                derniereTBClique.Visibility = Visibility.Visible;
                trouvePaire = false;
            }
        }

        //--------------------------------------------------------------------------------

        //-----------------------------------timer----------------------------------------

        DispatcherTimer timer = new DispatcherTimer();
        int tempsEcoule = 0;
        int nbPairesTrouvees = 0;

        private void Timer_Tick(object sender, EventArgs e)
        {
            

            tempsEcoule++;
            txtTemps.Text = (tempsEcoule / 10F).ToString("0.0s");
            if (nbPairesTrouvees == 8)
            {
                timer.Stop();
                txtTemps.Text = txtTemps.Text + " - Rejouer ? ";
            }
        }

        //--------------------------------------------------------------------------------

        private void txtTemps_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (nbPairesTrouvees == 8)
            {
                SetUpGame();
            }
        }


    }
}
