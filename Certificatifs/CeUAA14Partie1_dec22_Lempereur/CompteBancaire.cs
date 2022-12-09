using System;
using System.Collections.Generic;
using System.Text;

namespace CeUAA14Partie1_dec22_Lempereur
{
    class CompteBancaire
    {
        private string _name;
        private string _compte;
        private double  _solde;
        double somme = 100;

        public CompteBancaire(string name, string compte, double solde)
        {
            this._name = name;
            this._compte = compte;
            this._solde = solde;
        }


        public string AfficheCaratéristiaque()
        {
            return "Le compte numéro " + this._compte + " au nom de " + this._name + " a un solde de " + this._solde;
        }

        public double TransfertMoins()
        {
            double valeur = this._solde - somme;
            somme = somme + 100;
            return valeur;
        }

        public double TransfertPlus(int i)
        {
            double valeur = this._solde + 100 * i;
            return valeur;
        }

        public string Vérification(int valeur)
        {
            if (this._solde > valeur)
            {
                return "le versemet à été éfectué";
            }
            else
            {
                return "Solde insuffisant sur le compte" + this._compte + " pour faire le versement !";
            }
        }

        public double Solde
        {
            get
            {
                return _solde;
            }
            set
            {
                _solde = value;
            }
        }

        public string Compte
        {
            get
            {
                return _compte;
            }
            set
            {
                _compte = value;
            }
        }
    }
}
