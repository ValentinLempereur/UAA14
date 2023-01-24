using System;
using System.Collections.Generic;
using System.Text;

namespace nommé_I623_Lempereur
{
    class PaintBallGun
    {
        private Double _ballePoche;
        private Double _balleChargeur;

        public PaintBallGun()
        {
            _ballePoche = 30;
            _balleChargeur = 0;
        }

        public void AjoutBallepoche()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=> recharge de votre poche de 30 balles");
            Console.ForegroundColor = ConsoleColor.White;
            _ballePoche = _ballePoche + 30;
        }

        public void Rechargement()
        {
            Double ballesC = 0;

            ballesC = 16 - _balleChargeur;
            
            if (_balleChargeur == 16)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Votre chargeur est déjà plein !");
                Console.ForegroundColor = ConsoleColor.White;
                
            }
            else if (_ballePoche < ballesC)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Impossible de faire le rechargement de votre arme, Vous n'avez pas assez de balles dans votre poches");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            { 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=> recharge de " + ballesC + " balles éffectués");
                Console.ForegroundColor = ConsoleColor.White;
                _balleChargeur = _balleChargeur + ballesC;
                _ballePoche = _ballePoche - ballesC;
            }
        }


        public void Fire()
        {
            if (_balleChargeur == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Impossible de tirer ! Vous n'avez plus de balles dans votre chargeur\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vous avez tirer !");
                Console.ForegroundColor = ConsoleColor.White;
                _balleChargeur = _balleChargeur - 1;
            }
        }


        public bool VerifCaratere(string Choix)
        {
            if (Choix == " " || Choix == "r" || Choix == "+" || Choix == "q")
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCe choix n'est pas valide..");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }

        public void VerifChargeur()
        {
            if (_balleChargeur == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Attention votre chargeur est vide");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void AfficheCaracteristique()
        {
            Console.WriteLine("Vous avez un total de " + _ballePoche + " balles dans votre poche et " + _balleChargeur + " balles dans le chargeur");
        }
    }
}
