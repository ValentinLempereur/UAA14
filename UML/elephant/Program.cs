using System;

namespace elephant
{
    class Program
    {
        static void Main(string[] args)
        {
            Random aleatoire = new Random();
            int Choix = aleatoire.Next(1, 3);
            bool restart = true;

            string phrase = "";
            string message = "J'ai vu Dumbo s'envoler devant moi !!";

            Elephant LePremier = new Elephant("Zazou", 150);
            Elephant LeDeuxieme = new Elephant("Titi", 180);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Taper 1 : Voir les information du premier éléphant\nTaper 2 : Voir les information du deuxième éléphant\nTaper 3 : pour échanger les informations\nTaper 4 : pour faire marcher les messages\nTaper 5 : pour faire marcher le tableau\n");
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                int choose = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Cyan;

                switch (choose)
                {
                    case 1:
                        phrase = LePremier.AfficheQuiJeSuis();
                        Console.WriteLine(phrase);
                        break;
                    case 2:
                        phrase = LeDeuxieme.AfficheQuiJeSuis();
                        Console.WriteLine(phrase);
                        break;
                    case 3:
                        Elephant echange = LePremier;
                        LePremier = LeDeuxieme;
                        LeDeuxieme = echange;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nLes informations ont été changé");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 4:
                        switch (Choix)
                        {
                            case 1:
                                LeDeuxieme.EnvoieMessage(message, LePremier);
                                break;
                            case 2:
                                LePremier.EnvoieMessage(message, LeDeuxieme);
                                break;
                        }
                        break;
                    case 5:
                        Letableau();
                        break;
                } 
            } while (restart);
            
        }

        static void Letableau()
        {
            int i = 0;
            Elephant[] Leselephants = new Elephant[5];

            Leselephants[i] = new Elephant("papou", 100);
            i++;
            Leselephants[i] = new Elephant("pipou", 20);
            i++;
            Leselephants[i] = new Elephant("pupou", 40);
            i++;
            Leselephants[i] = new Elephant("pepou", 110);
            i++;
            Leselephants[i] = new Elephant("popou", 90);

            Leselephants[i].PlsGrandeOreille(Leselephants, out string PlsGrandeO);
            Console.WriteLine(PlsGrandeO);
        }
    }
}
