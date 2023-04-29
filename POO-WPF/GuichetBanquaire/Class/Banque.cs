using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuichetBanquaire.Class
{
    public abstract class Banque
    {
        protected string _numerobanquaire;
        protected double _solde;

        public abstract string AfficheCaracteristique();


        public abstract bool Virement(double price);


        //------------------------------------------------
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

        public string NumeroBanquaire
        {
            get
            {
                return _numerobanquaire;
            }
            set
            {
                _numerobanquaire = value;
            }
        }
    }
}
