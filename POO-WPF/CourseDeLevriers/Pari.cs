using System;
using System.Collections.Generic;
using System.Text;

namespace CourseDeLevriers
{
    public class Pari
    {
        private string _joueur;
        private int _montant;
        private int _numberDog;

        public Pari(string Joueuer, int Montant, int numberDog)
        {
            _joueur = Joueuer;
            _montant = Montant;
            _numberDog = numberDog;
        }


        public string joueur
        {
            get
            {
                return _joueur;
            }
            set
            {
                _joueur = value;
            }
        }

        public int montant
        {
            get
            {
                return _montant;
            }
            set
            {
                _montant = value;
            }
        }

        public int numberDog
        {
            get
            {
                return _numberDog;
            }
            set
            {
                _numberDog = value;
            }
        }

    }
}
