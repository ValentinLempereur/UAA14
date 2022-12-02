using System;
using System.Collections.Generic;
using System.Text;

namespace Personne
{
    class Personne
    {
        private string _Prénom;
        private double _Argent;

        public Personne(string Prénom, double Argent)
        {
            this._Prénom = Prénom;
            this._Argent = Argent;
        }


        public double Monnaie
        {
            get
            {
                return _Argent;
            }
            set
            {
                _Argent = value;
            }
        }

        public string Nom
        {
            get
            {
                return _Prénom;
            }
            set
            {
                _Prénom = value;
            }
        }

        public double AjoutArgent(double Nbr)
        {
            double value = this.Monnaie - Nbr;
            return value;
        }

        public double PerdeArgent(double Nbr)
        {
            double value = this.Monnaie + Nbr;
            return value;

        }
    }
}
