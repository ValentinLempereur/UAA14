using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3_Heritage
{
    class Personne
    {
        protected string _nom;
        protected string _prenom;
        protected int _matricule;
        protected string _dateNaissance;
        protected int _salaire;


        public Personne(string Nom, string Prenom, int Matricule, string DateNaissance)
        {
            _nom = Nom;
            _prenom = Prenom;
            _matricule = Matricule;
            _dateNaissance = DateNaissance;
            _salaire = Salaire();
        }

        public virtual string AfficheStastistique()
        {
            return "Son nom est : " + _nom + " | Son prénom est : " + _prenom + " | Son matricule est : " + _matricule + " | Sa date de naissance est : " + _dateNaissance + "\n";
        }

        public virtual int Salaire()
        {
            return 0;
        }
    }
}
