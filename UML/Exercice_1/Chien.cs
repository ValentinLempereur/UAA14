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

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {      
                _age = value;
            }
        }

        public string Nom
        {
            get
            {
                return _nom;
            }
            set
            {
                _nom = value;
            }
        }

        public string Race
        {
            get
            {
                return _race;
            }
            set
            {
                _race = value;
            }
        }

    }
}
