using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3_Heritage
{
    class Cadre : Personne
    {
        private int _indice;
        public Cadre(string Nom, string Prenom, int Matricule, string DateNaissance, int Indice) : base (Nom, Prenom, Matricule, DateNaissance)
        {
            _nom = Nom;
            _prenom = Prenom;
            _matricule = Matricule;
            _dateNaissance = DateNaissance;
            _indice = Indice;
            _salaire = Salaire();
        }

        public override int Salaire()
        {
            if (_indice == 1)
            {
                return 13000;
            }
            else if (_indice == 2)
            {
                return 15000;
            }
            else if (_indice == 3)
            {
                return 17000;
            }
            else
            {
                return 20000;
            }
        }

        public override string AfficheStastistique()
        {
            return "Son nom est : " + _nom + " | Son prénom est : " + _prenom + " | Son matricule est : " + _matricule + " | Sa date de naissance est : " + _dateNaissance + " | Son salaire : " + _salaire + " | Son indice est : " + _indice + "\n";
        }
    }
}
