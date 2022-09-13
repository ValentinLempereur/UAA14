using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice_1
{
    class Chien
    {
        // attribut privé par convention
        private string _nom;
        private string _race;
        private int _age;

        //le constructeur
        public Chien(string nom, string race, int age)
        {
            this._nom = nom;
            this._race = race;
            this._age = age;
        }

        //une méthode pour afficher
        public string AfficheCaracteristique()
        {
            string phrase= "Nom : " + this._nom + " - Age : " + this._age + " ans" + "  - Race : " + this._race;
            return phrase;
        }
        
    }
}
