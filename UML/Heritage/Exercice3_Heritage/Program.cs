using System;

namespace Exercice3_Heritage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor= ConsoleColor.Cyan;
            Ouvrier ouvrier = new Ouvrier("Valentin ", "Lempereur ", 1, "20/01/2004", "20/01/2023");
            Console.WriteLine(ouvrier.AfficheStastistique());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Cadre Cadre1 = new Cadre("Valentin ", "Lempereur ", 2, "20/01/2004", 1);
            Cadre Cadre2 = new Cadre("Audry ", "Lauwers ", 3, "20/01/2004", 2);
            Console.WriteLine(Cadre1.AfficheStastistique());
            Console.WriteLine(Cadre2.AfficheStastistique());

            Console.ForegroundColor = ConsoleColor.Green;
            Directeur directeur1 = new Directeur("Valentin ", "Lempereur ", 2, "20/01/2004", 40000, 20);
            Console.WriteLine(directeur1.AfficheStastistique());
            Console.ReadLine();
        }
    }
}
