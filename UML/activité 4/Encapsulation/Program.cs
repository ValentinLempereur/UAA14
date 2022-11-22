using System;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string fin;
            Console.WriteLine("Bienvenue dans ce programme sur le cercle !\n");
            do
            {           
                Console.WriteLine("Taper un rayon pour votre cercle\n");
                Cercle mescercles = new Cercle(int.Parse(Console.ReadLine()));
                Console.Clear();

                double perimetre = mescercles.CalculePerimetre();
                double aire = mescercles.CalculeAire();
                string phrase = mescercles.AfficheCaracteristique();
                Console.WriteLine(phrase + " a un périmètre de " + perimetre + " et une aire de " + aire);
                Console.WriteLine("----------------------------------------------------------------------");
                mescercles.Rayon /= 2;
                Double moitperi = mescercles.CalculePerimetre();
                double moitaire = mescercles.CalculeAire();
                string moitphrase = mescercles.AfficheCaracteristique();
                Console.WriteLine(moitphrase + " a un périmètre de " + moitperi + " et une aire de " + moitaire);

                Console.WriteLine("\nun autre cercle (appuyer sur espace)");
                fin = Console.ReadLine();
                Console.Clear();
            } while (fin == " ");
        }
    }
}
