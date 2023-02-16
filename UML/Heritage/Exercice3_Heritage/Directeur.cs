using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3_Heritage
{
    class Directeur : Personne
    {
        private int _chiffreAffaire;
        private int _pourcentage;
        public Directeur(string Nom, string Prenom, int Matricule, string DateNaissance, int ChiffreAffaire, int Pourcentage) : base (Nom, Prenom, Matricule, DateNaissance)
        {
            _nom = Nom;
            _prenom = Prenom;
            _matricule = Matricule;
            _dateNaissance = DateNaissance;
            _chiffreAffaire = ChiffreAffaire;
            _pourcentage = Pourcentage;
            _salaire = Salaire();
        }
        public override int Salaire()
        {
            return _chiffreAffaire * _pourcentage / 100;
        }

        public override string AfficheStastistique()
        {
            return "Son nom est : " + _nom + " | Son prénom est : " + _prenom + " | Son matricule est : " + _matricule + " | Sa date de naissance est : " + _dateNaissance + " | Son salaire : " + _salaire + " | Son Chiffre d'affaire est : " + _chiffreAffaire + " | Son pourcentage est : " + _pourcentage + "\n";
        }
    }
}
