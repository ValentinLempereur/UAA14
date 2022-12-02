using System;

namespace Nombre_Complexe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Taper un nombre réelle");
            double reel = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Taper un nombre imaginaire");
            double ima = int.Parse(Console.ReadLine());
            Console.Clear();
            Complexe Nbr1 = new Complexe(reel, ima);
            double Value = Nbr1.CalculeModule();

            Console.WriteLine("Le Premier " + Nbr1.AfficheCaracteristique(Value));

            Console.WriteLine("\nEncoder un second nombre complexe : \n");
            Console.WriteLine("Taper un nombre réelle");
            Nbr1.Reelle = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Taper un nombre imaginaire");
            Nbr1.Imaginaire = int.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Le premier complexe devient " + Nbr1.AfficheCaracteristique(Value));


        }
    }
}
