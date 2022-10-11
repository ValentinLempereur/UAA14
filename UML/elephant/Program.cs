using System;

namespace elephant
{
    class Program
    {
        static void Main(string[] args)
        {
            Random aleatoire = new Random();
            int Choix = aleatoire.Next(1, 3);

            string phrase = "";
            string message = "J'ai vu Dumbo s'envoler devant moi !!";

            Elephant LePremier = new Elephant("Zazou", 150);
            Elephant LeDeuxieme = new Elephant("Titi", 180);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Taper 1 : Voir les information du premier éléphant\nTaper 2 : Voir les information du deuxième éléphant\nTaper 3 : pour échanger les informations\n");
            Console.ForegroundColor = ConsoleColor.Green;
            int choose = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Cyan;

            switch (choose)
            {
                case 1:
                    phrase = LePremier.AfficheQuiJeSuis();
                    break;
                case 2:
                    phrase = LeDeuxieme.AfficheQuiJeSuis();
                    break;
                case 3:
                    Elephant echange = LePremier;
                    LePremier= LeDeuxieme;
                    LeDeuxieme= echange;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nLes informations ont été changé");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
            }
            Console.WriteLine(phrase);

            switch (Choix)
            {
                case 1:
                    LePremier.EcouteMessage(message, LeDeuxieme);
                    break;
                case 2:
                    LeDeuxieme.EcouteMessage(message, LePremier);
                    break;
            }
            
            Console.ReadLine();

        }
    }
}
