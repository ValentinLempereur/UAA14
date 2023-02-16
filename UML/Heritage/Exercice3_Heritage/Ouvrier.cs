using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3_Heritage
{
    class Ouvrier : Personne
    {
        private string _DateEntree;
        public Ouvrier(string Nom, string Prenom, int Matricule, string DateNaissance, string DateEntree) : base (Nom, Prenom, Matricule, DateNaissance)
        {
            _nom = Nom;
            _prenom = Prenom;
            _matricule = Matricule;
            _dateNaissance = DateNaissance;
            _DateEntree = DateEntree;
            _salaire = Salaire();
        }

        public override int Salaire()
        {
            return 2500;
        }

        public override string AfficheStastistique()
        {
            return "Son nom est : " + _nom + " | Son prénom est : " + _prenom + " | Son matricule est : " + _matricule + " | Sa date de naissance est : " + _dateNaissance + " | Son salaire : " + _salaire + "\n";
        }
    }
}
