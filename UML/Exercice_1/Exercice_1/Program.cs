using System;

namespace Exercice_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string phrase;
            Console.WriteLine("Bienvenue dans notre chenil !\nLes chiens à GoGo\n");
            //Chien tobi = new Chien("Tobi", "Bichon", 3);
            //phrase = tobi.AfficheCaracteristique();
            //Console.WriteLine(phrase);

            //tableau 
            Chien[] mesChiens = new Chien[3];

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Quel est le nom de votre chien ?");
                string nomChien = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Quel est la race de votre chien ?");
                string raceChien = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Quel est l'age de votre chien ?");
                int ageChien = int.Parse(Console.ReadLine());
                Console.Clear();

                mesChiens[i] = new Chien(nomChien, raceChien, ageChien);
            }

            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(mesChiens[i].AfficheCaracteristique());
            }
        }
    }
}
