using System;

namespace ACT00_REVISION
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodesDuProjet Outils = new MethodesDuProjet();
            string rep;
            
            double c1 = 0;
            double c2 = 0;
            double c3 = 0;
            bool ok = false;


            Console.WriteLine("Testez les polygones !");
            do
            {
                int numeroCote = 1;
                c1 =lireDouble(numeroCote);
                numeroCote = 2;
                c2 = lireDouble(numeroCote);
                numeroCote = 3;
                c3 = lireDouble(numeroCote);

                Outils.OrdonneCotes(ref c1, ref c2, ref c3);

                
                
                
                

                if (Outils.Triangle(c1, c2, c3))
                {
                    Outils.Affiche(out string infos, true, "triangle");
                    Console.WriteLine(infos);

                    if (Outils.Equi(c1, c2, c3))
                    {
                        Outils.Affiche(out infos, true, "equilateral");
                        Console.WriteLine(infos);
                    }
                    else
                    {
                        if (Outils.TriangleRectangle(c1, c2, c3))
                        {
                            Outils.Affiche(out infos, true, "rectangle");
                            Console.WriteLine(infos);
                        }
                        else
                        {
                            Outils.Affiche(out infos, false, "rectangle");
                            Console.WriteLine(infos);
                        }

                        Outils.Isocele(c1, c2, c3, out ok);
                        if (ok)
                        {
                            Outils.Affiche(out infos, ok, "isocele");
                            Console.WriteLine(infos);
                        }
                    }
                }
                else 
                {
                    Outils.Affiche(out string infos, false, "triangle");
                    Console.WriteLine(infos);
                }
                Console.WriteLine("Voulez-vous tester un autre polygône ? (Tapez espace)");
                rep = Console.ReadLine();
            } while (rep == " ");
        }
        static double lireDouble(int numeroCote)
        {
            double cote;
            Console.Write("Tapez la valeur du côté " + numeroCote + " : ");
            cote = double.Parse(Console.ReadLine());
            return cote;
        }
    }
}
