using System;
using System.Collections.Generic;
using System.Text;

namespace elephant
{
    class Elephant
    {
        private string _nom;
        private uint _tailleOreilles;

        public Elephant(string nom, uint taille)
        {
            this._nom = nom;
            this._tailleOreilles = taille;
        }


        public void EcouteMessage(string message, Elephant quiDit)
        {
            Console.WriteLine(_nom + " a reçu un message de " + quiDit._nom + "\n" + quiDit._nom + " a dit : " + message);
        }

        public void EnvoieMessage(string message, Elephant quiRecoit)
        {
            Console.WriteLine(_nom + " a envoyé un message à " + quiRecoit._nom + "\n");
            quiRecoit.EcouteMessage(message, this);
        }





        public string AfficheQuiJeSuis()
        {

            string phrase = "Il s'appelle " + this._nom + " et sa taille d'oreille fait " + this._tailleOreilles + " cm\n";
            return phrase;
        }

        public void PlsGrandeOreille(Elephant[] Leselephants, out string Phrase)
        {
            int save = 0;

            for (int j = 0; j < 5; j++)
            {
                if (Leselephants[save]._tailleOreilles < Leselephants[j]._tailleOreilles)
                {
                    save = j;
                    j = 0;
                }
            }

            Phrase = "L'éléphant qui les plus grande oreille s'appelle " + Leselephants[save]._nom + " et c'est oreille font " + Leselephants[save]._tailleOreilles + " cm";
        }

    }
}
