using System;

namespace Exercice2_Heritage
{
    class Program
    {
        static void Main(string[] args)
        {
            Chien Dog = new Chien("Tobi", "01/20/2004", 104, 186, true);
            Chat Cat = new Chat("Popeille", "02/20/2005", 105, 200, true);
            Lapin Rabbit = new Lapin(30, "Maya", "03/20/2006", 106, 89, false);

            string Phrase = Dog.AfficheCaractere();
            string Cara = "\nVotre chien aboie :\n";
            Cara += Dog.Aboyer();
            Console.WriteLine(Phrase);
            Console.WriteLine(Cara);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Cara = "\nVotre chat miaule et ronrone :\n";
            Cara += Cat.Miauler();
            Cara += Cat.Ronronner();
            Phrase = Cat.AfficheCaractere();
            Console.WriteLine(Phrase);
            Console.WriteLine(Cara);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Cara = "\nVotre Lapin fait des bonds :\n";
            Cara += Rabbit.Bonds();
            Phrase = Rabbit.AfficheCaractere();
            Console.WriteLine(Phrase);
            Console.WriteLine(Cara);
            Console.ReadLine();
        }
    }
}
