using System;

namespace Exercice_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodeDuProjet Outils = new MethodeDuProjet();
            double[] T = new double[10];
            double result;
            bool ok = false;

            do
            {
                Console.WriteLine("Quelle couleur voulez vous ?\nGreen\nRed\nYellow\nBlue\nWhite");
                string Choix = Console.ReadLine();
                if (Choix == "Green")
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    ok = true;
                }
                else if (Choix == "Red")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    ok = true;
                }
                else if (Choix == "Yellow")
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    ok = true;
                }
                else if (Choix == "Blue")
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Black;
                    ok = true;
                }
                else if (Choix == "White")
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    ok = true;
                }

            } while (!ok);


            Console.Clear();
            
            
            string question = "encoder un chiffre";

            for (int i = 0; i < 10; i++)
            {
                T[i] = Outils.Lecture(question);
                Console.Clear();
            }

            result = Outils.Moyenne(T);

            Console.Clear();
            Console.WriteLine("Le tableau :");
            Outils.Affiche(T);
            Console.WriteLine();
            Console.WriteLine("La moyenne du tableau :");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
