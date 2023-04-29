using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuichetBanquaire.Class
{
    public class CompteCourant : Banque
    {
        private double _decouvertmax;

        public CompteCourant(string NumeroBanquaire, double Solde, double DecouvertMax)
        { 
            _numerobanquaire = NumeroBanquaire;
            _solde = Solde;
            _decouvertmax = DecouvertMax;
        }

        public override string AfficheCaracteristique()
        {
            return "Le compte " + _numerobanquaire + " possède " + _solde + " € et à un découvert max de " + _decouvertmax;
        }

        public override bool Virement(double price)
        {
            if (_solde > 0)
            {
                if (price > _solde)
                {
                    if (price < _solde - _decouvertmax)
                    {
                        _solde = _solde - price;
                        return true;
                    }
                    return false;
                }
                else
                {
                    _solde -= price;
                    return true;
                }
            }
            else
            {
                if(price > _solde - _decouvertmax)
                {
                    return false;
                }
                else
                {
                    _solde -= price;
                    return true;
                }
            }
        }

        public double DecouvertMax
        {
            get
            {
                return _decouvertmax;
            }
        }
    }
}
