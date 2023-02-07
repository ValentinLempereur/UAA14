using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2_Heritage
{
    class Animal
    {
        protected string _nom;
        protected string _date;
        protected Double _puce;
        protected Double _taille;
        protected bool _concour;



        public Animal(String Nom, string Date, Double Puce, Double Taille, bool Concour)
        {
            _nom = Nom;
            _date = Date;
            _puce = Puce;
            _taille = Taille;
            _concour = Concour;
        }

        public string Dormir()
        {
            return "ZZZZzzZZzzZZZZZzzzzZZZzzZzZzzZZZZZzzzzzz";
        }

        public String Manger()
        {
            return "RCCHURchhu MMMMMHHHH RRROOCHUUU rochUU";
        }
    }
}
