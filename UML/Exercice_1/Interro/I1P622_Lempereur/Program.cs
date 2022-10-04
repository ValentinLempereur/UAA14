using System;

namespace I1P622_Lempereur
{
    class Program
    {
        static void Main(string[] args)
        {
            int coul;
            Feux premier = new Feux("001", "Rouge");
            Feux deuxieme = new Feux("002", "Vert");
            Console.WriteLine("état des Feux : \n-----------------");
            string phrase = premier.Affiche();
            Console.WriteLine(phrase);
            phrase = deuxieme.Affiche();
            Console.WriteLine(phrase);
            Console.WriteLine("\nChangement d'état : \n----------------------");
            for (int i = 0; i < 2; i++)
            {
                coul = int.Parse(Console.ReadLine());
                Couleur(coul, out string color);
                premier = new Feux("001", color);
                phrase = premier.Affiche();
                Console.WriteLine(phrase);
            }
            
            
            Console.WriteLine("\nFeux clignotant : \n-----------------");
            for (int i = 0; i < 10; i++) 
            {
                deuxieme = new Feux("002", "éteind");
                phrase = deuxieme.Affiche();
                Console.WriteLine(phrase);
                deuxieme = new Feux("002", "allumer");
                phrase = deuxieme.Affiche();
                Console.WriteLine(phrase);
            }

            Console.ReadLine();


        }
        static void Couleur(int coul, out string color)
        {
            color = "";
            if (coul == 1)
            {
                color = "rouge";
            }
            else if (coul == 2)
            {
                color = "orange";
            }
            else if (coul == 3)
            {
                color = "vert";
            }
        }

    }
}
