using System;

namespace nommé_I623_Lempereur
{
    class Program
    {
        static void Main(string[] args)
        {
            PaintBallGun Page2 = new PaintBallGun();
            bool ok;
            bool Quitte = false;
            String Choix;

            Console.WriteLine("Bienvenue dans ce jeude tir... Vous démmarer avec 30 balles");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------");
            do
            {
                Page2.AfficheCaracteristique();
                Page2.VerifChargeur();
                Console.WriteLine("\n");

                do
                {   
                    Console.WriteLine("Espace pour tirer.\n r pour recharger.\n + pour reprendre des munitions.\n q pour quitter.");
                    Choix = Console.ReadLine();
                    ok = Page2.VerifCaratere(Choix);
                } while (!ok);

                Console.Clear();
                
                switch (Choix)
                {
                    case " ":
                        Page2.Fire();
                        break;
                    case "r":
                        Page2.Rechargement();
                        break;
                    case "+":
                        Page2.AjoutBallepoche();
                        break;
                    case "q":
                        Quitte = true;
                        break;
                }
            }
            while (!Quitte);
        }
    }
}
