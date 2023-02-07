using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2_Heritage
{
    class Lapin : Animal
    {
        private Double _tailleOreille;
        public Lapin(Double TailleOreille, String Nom, string Date, Double Puce, Double Taille, bool Concour) : base(Nom, Date, Puce, Taille, Concour)
        {
            _nom = Nom;
            _date = Date;
            _puce = Puce;
            _taille = Taille;
            _concour = Concour;
            _tailleOreille = TailleOreille;
        }

        public String Bonds()
        {
            return "PoooOOOooooPP     PoooOOOooooPP     PoooOOOooooPP";
        }

        public string AfficheCaractere()
        {
            return "Votre chien s'appelle : " + _nom + " sa date est : " + _date + " son numéro de puce est : " + _puce + " il mesure " + _taille + " cm et sa taille d'oreille est : " + _tailleOreille + " Pour finir il a une autorisation à participer au concour de type : " + _concour;
        }
    }
}
