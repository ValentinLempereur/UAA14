using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuichetBanquaire.Class
{
   public class Personne
    {
        private int _id;
        private string _name;
        private string _motDePasse;

        public Personne(int id, string Name, string MotDePasse)
        {
            _id = id;
            _name = Name;
            _motDePasse = MotDePasse;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string MotDePasse
        {
            get
            {
                return _motDePasse;
            }
            set
            {
                _motDePasse = value;
            }
        }
    }
}
