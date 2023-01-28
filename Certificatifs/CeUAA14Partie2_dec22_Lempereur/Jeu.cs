using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace CeUAA14Partie2_dec22_Lempereur
{
    internal class Jeu
    {
        MainWindow jeu = (CeUAA14Partie2_dec22_Lempereur.MainWindow)App.Current.MainWindow;

        public void TourJoueur(string symboleJoueur, int numeroJoueur, ref int totaljoueur, ref int totalJoueur, ref int[] positionPionJoueur, ref string ancienneValeur)
        {
            Random alea = new Random();
            int de = alea.Next(1, 7);
            jeu.TxtBlckJoue.Text = "Joueur : " + numeroJoueur;
            jeu.TxtBlckDe.Text = "Dé : " + de;
            int reste;
            positionPionJoueur = new int[2];
            //jeu.Btn[positionPionJoueur[0], positionPionJoueur[1]].Content = ancienneValeur;
            //jeu.Btn[positionPionJoueur[0], positionPionJoueur[1]].Foreground = Brsuhes.Black;
            totaljoueur += de;
            reste = totaljoueur - 10 * (positionPionJoueur[0] + 1);

            if (reste < 0)
            {
                reste = reste + 10;
            }
            else
            {
                positionPionJoueur[0] += 1;
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
                //ancienneValeur = jeu.Btn[positionPionJoueur[0], positionPionJoueur[1]].Content.ToString();
                //jeu.Btn[positionPionJoueur[0], positionPionJoueur[1]].Content = symboleJoueur;
                //jeu.Btn[positionPionJoueur[0], positionPionJoueur[1]].Foreground = Brsuhes.Gold;
            }
            else
            {
                jeu.TxtBlckJoue.Text = "Fin !";
                //jeu.Btn[9, 0].Content = symboleJoueur;
                //jeu.Btn[9, 0].Foreground = Brsuhes.Gold;
                jeu.BtnPlay.IsEnabled = false;
            }
        }

    }
}
