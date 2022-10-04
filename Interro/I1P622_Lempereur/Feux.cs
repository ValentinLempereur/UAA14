using System;
using System.Collections.Generic;
using System.Text;

namespace I1P622_Lempereur
{
    class Feux
    {
        private string _feuxnumero;
        private string _couleur;
        public Feux(string feuxnumero, string couleur)
        {
            this._feuxnumero = feuxnumero;
            this._couleur = couleur;
        }

   


        public string Affiche()
        {
            
            string phrase = "Le feux de signalisation " + this._feuxnumero + " est " + this._couleur;
            return phrase;
        }
    }
}
