using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuichetBanquaire.Class
{
    public class CompteEpargne : Banque
    {
        private double _tauxinteret;

        public CompteEpargne(string NumeroBanquaire, double Solde, double TauxInteret)
        {
            _numerobanquaire = NumeroBanquaire;
            _solde = Solde;
            _tauxinteret = TauxInteret;
        }

        public override string AfficheCaracteristique()
        {
            return "Le compte " + _numerobanquaire + " possède " + _solde + " € et votre taux d'intérêt est de " + _tauxinteret;

        }

        public override bool Virement(double price)
        {
            if (price > _solde)
            {
                return false;
            }
            else
            {
                _solde -=  price;
                return true;
            }
        }

        public void tanxInteret()
        {
            _solde = _solde * _tauxinteret / 100;
        }

        public double TauxInteret
        {
            get
            {
                return _tauxinteret;
            }
        }
    }
}
