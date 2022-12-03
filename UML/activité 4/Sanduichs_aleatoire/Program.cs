using System;

namespace Sanduichs_aleatoire
{
    class Program
    {
        static void Main(string[] args)
        {
            SandwichMaker B = new SandwichMaker();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Bienvenue dans notre concepteur de sandwich !");

            bool ok = true;
            do
            {
                
                Console.WriteLine("taper sur espace pour générer un sandwich, sinon le concepteur se coupera\n");
                Console.Clear();

                if (" " == Console.ReadLine())
                {
                    Console.WriteLine(B.ComposeSandwich());
                }
                else
                {
                    Environment.Exit(0);
                }


            } while (ok);       
        }
    }
}
