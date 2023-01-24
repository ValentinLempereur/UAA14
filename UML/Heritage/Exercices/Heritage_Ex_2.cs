using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices
{
    internal class Heritage_Ex_2
    {
        private int _choix;
        private string _nom;
        private Double _date;
        private Double _puce;
        private Double _taille;
        private Double _tailleOreille;
        private string _concour;
        private string _aboyer;
        private string _mialuer;
        private string _ronronner;
        private string _bonds;
        private string _dormir;
        private string _manger;

        public Heritage_Ex_2(String Nom, Double Date, Double Puce, Double Taille, string Dormir, string Manger, string Concour)
        {
            _nom = Nom;
            _date = Date;
            _puce = Puce;
            _taille = Taille;
            _dormir = Dormir;
            _manger = Manger;
            _concour = Concour;
        }

        public Chien(string Aboyer) : base()
        {
            _aboyer = Aboyer;
        }
        public Chat(string Miauler, string Ronronner) : base()
        {
            _mialuer = Miauler;
            _ronronner = Ronronner;
        }
        public Lapin(double TailleOreille, string Bonds) : base()
        {
            _tailleOreille = TailleOreille;
            _bonds = Bonds;
        }
    }
}
