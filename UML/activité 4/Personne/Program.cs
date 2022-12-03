using System;

namespace Personne
{
    class Program
    {
        static void Main(string[] args)
        {

            Personne[] Personnes = new Personne[2];
            string Pers = "Première";
            string Prénom;
            double Argent;
            bool ok = true;
            int pers1 = 0;
            int pers2 = 1;

            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenue dans notre gestionnaire de porte monnaie !\n");

                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine(Pers + " personne, quel est votre nom");
                    Prénom = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Taper une somme d'argent");
                    Argent = double.Parse(Console.ReadLine());
                    Personnes[i] = new Personne(Prénom, Argent);
                    Console.Clear();
                    Pers = "Deuxième";
                }

                int o = 1;
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine(Personnes[i].Nom + " Combien voulez-vous donner à " + Personnes[o].Nom);
                    Console.WriteLine("Taper une somme d'argent en euros.");
                    double Nbr = double.Parse(Console.ReadLine());
                    Personnes[o].Monnaie = Personnes[o].PerdeArgent(Nbr);
                    Personnes[i].Monnaie = Personnes[i].AjoutArgent(Nbr);
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ajout effectué !\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(Personnes[pers1].Nom + " a " + Personnes[pers1].Monnaie + " Euros dans son porte monnaie");
                    Console.WriteLine(Personnes[pers2].Nom + " a " + Personnes[pers2].Monnaie + " Euros dans son porte monnaie");
                    Console.ReadLine();
                    Console.Clear();

                    o = 0;
                }


                o = 1;
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("Voulez-Vous ajouter de l'argent au porte de feuille de " + Personnes[i].Nom + " ? (si oui faites un espace)");
                    string yes = Console.ReadLine();
                    Console.Clear();
                    if (yes == " ")
                    {
                        Console.WriteLine("Combien voulez-vous ajouter ?");
                        Console.WriteLine("Taper une somme d'argent en euros.");
                        double Nbr = double.Parse(Console.ReadLine());
                        double nbr = Personnes[i].AjoutArgent(Nbr);
                        Personnes[i].Monnaie = Personnes[i].Monnaie + nbr;
                        Console.Clear();

                        Console.WriteLine(Personnes[pers1].Nom + " a " + Personnes[pers1].Monnaie + " Euros dans son porte monnaie");
                        Console.WriteLine(Personnes[pers2].Nom + " a " + Personnes[pers2].Monnaie + " Euros dans son porte monnaie\n");
                        Console.WriteLine("appuyer sur ENTER pour passer à la suite");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    o = 0;
                }


                Console.WriteLine("Voulez-vous recommencer ? (si oui faites un espace)");

                if (" " == Console.ReadLine())
                {
                    ok = true;
                }
                else
                {
                    ok = false;
                    Environment.Exit(0);
                }
            } while (ok);
        }
    }
}
