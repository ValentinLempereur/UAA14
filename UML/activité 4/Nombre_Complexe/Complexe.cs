using System;
using System.Collections.Generic;
using System.Text;

namespace Nombre_Complexe
{
    class Complexe
    {
        private double _NbrReelle;
        private double _NbrImaginaire;

        public Complexe(double NbrReelle, double NbrImaginaire)
        {
            this._NbrReelle = NbrReelle;
            this._NbrImaginaire = NbrImaginaire;
        }

        public double  CalculeModule()
        {
            double Value = Math.Round(Math.Sqrt(this._NbrReelle * this._NbrReelle + this._NbrImaginaire * this._NbrImaginaire), 2);
            return Value;
        }

        public string AfficheCaracteristique(double Value)
        {
            string phrase = "complexe vaut : (" + this._NbrReelle + " | " + this._NbrImaginaire + ") a pour module : " + Value;
            return phrase;
        }

        public double Reelle
        {
            get
            {
                return _NbrReelle;
            }
            set
            {
                _NbrReelle = value;
            }
        }
        public double Imaginaire
        {
            get
            {
                return _NbrImaginaire;
            }
            set
            {
                _NbrImaginaire = value;
            }
        }
    }
}
