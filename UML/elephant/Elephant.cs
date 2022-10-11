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
            Console.WriteLine(_nom + " a entendu un message \n" + quiDit._nom + " a dit : " + message);
        }

        public void EnvoieMessage(string message, Elephant quiRecoit)
        {
            quiRecoit.EcouteMessage(message, this);
        }





        public string AfficheQuiJeSuis()
        {

            string phrase = "Il s'appelle " + this._nom + " et sa taille d'oreille fait " + this._tailleOreilles + " cm\n";
            return phrase;
        }

    }
}
