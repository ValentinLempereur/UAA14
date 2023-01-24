using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Exercices
{
    public class Test
    {
        public int _choix;
        public string _nom;
        public Double _date;
        public Double _puce;
        public Double _taille;
        public Double _tailleOreille;
        public string _concour;
        public string _aboyer;
        public string _mialuer;
        public string _ronronner;
        public string _bonds;
        public string _dormir;
        public string _manger;

        public Test(String Nom, Double Date, Double Puce, Double Taille, string Dormir, string Manger, string Concour)
        {
            _nom = Nom;
            _date = Date;
            _puce = Puce;
            _taille = Taille;
            _dormir = Dormir;
            _manger = Manger;
            _concour = Concour;
        }
    }

    public class Chien : Test
    {
        public Chien(string Aboyer, String Nom, Double Date, Double Puce, Double Taille, string Dormir, string Manger, string Concour) : base(Nom, Date, Puce, Taille, Dormir, Manger, Concour)
        {
            _aboyer = Aboyer;
        }
    }
    public class Chat : Test
    {
        public Chat(string Miauler, string Ronronner, String Nom, Double Date, Double Puce, Double Taille, string Dormir, string Manger, string Concour) : base(Nom, Date, Puce, Taille, Dormir, Manger, Concour)
        {
            _mialuer = Miauler;
            _ronronner = Ronronner;
        }
    }
    public class Lapin : Test
    {
        public Lapin(double TailleOreille, string Bonds, String Nom, Double Date, Double Puce, Double Taille, string Dormir, string Manger, string Concour) : base(Nom, Date, Puce, Taille, Dormir, Manger, Concour)
        {
            _tailleOreille = TailleOreille;
            _bonds = Bonds;
        }
    }
}