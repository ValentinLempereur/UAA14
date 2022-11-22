using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation
{
    class Cercle
    {
        private double _rayon;

        public Cercle(double rayon)
        {
            this._rayon = rayon;
        }

        public double CalculePerimetre()
        {
            double value = Math.Round(2 * this._rayon * Math.PI,2);
            return value;
        }

        public double CalculeAire()
        {
            double value = Math.Round(Math.PI * this._rayon * this._rayon,2);
            return value;
        }

        public string AfficheCaracteristique()
        {
            string phrase = "le cercle de rayon " + this._rayon;
            return phrase;
        }


        public double Rayon
        {
            get 
            { 
                return _rayon; 
            }
            set 
            { 
                _rayon = value; 
            }
        }

    }
}
