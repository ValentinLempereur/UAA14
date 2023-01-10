using System;

namespace CeUAA14Partie1_dec22_Lempereur
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string compte;
            double solde = 20000;
            CompteBancaire[] Personne = new CompteBancaire[10];


            string[] Compte = new string[10]
            {
                "BE43350006467801",
                "BE43350006467811",
                "BE43350006467821",
                "BE43350006467831",
                "BE43350006467841",
                "BE43350006467851",
                "BE43350006467861",
                "BE43350006467871",
                "BE43350006467881",
                "BE43350006467891"
            };

            string[] Pers = new string[10]
            {
                "Personne 1",
                "Personne 2",
                "Personne 3",
                "Personne 4",
                "Personne 5",
                "Personne 6",
                "Personne 7",
                "Personne 8",
                "Personne 9",
                "Personne 10"
            };

            for (int i = 0; i < 10; i++)
            {
                compte = Compte[i];
                name = Pers[i];
                Personne[i] = new CompteBancaire(name, compte, solde);
                solde = 200;
            }



            //----------------------------------------------------------------------------------------------------------
            Console.WriteLine("Bienvenue dans la banque du centre Asty-Moulin !\n");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("Préparation  des comptes :");
            Console.WriteLine("-----------------------------------------------------------------------------");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Personne[i].AfficheCaratéristiaque());  
            }
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("Versements de la personne 1 vers les autres comptes : ");
            Console.WriteLine("-----------------------------------------------------------------------------");
            solde = 100;
            for (int i = 1; i < 10; i++)
            {
                Personne[0].Solde = Personne[0].TransfertMoins();
                Personne[i].Solde = Personne[i].TransfertPlus(i);
            }
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(Personne[i].AfficheCaratéristiaque());  
            }
            Console.WriteLine("Il reste " + Personne[0].Solde + " sur le compte " + Personne[0].Compte);
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("versement de 500 euros du compte de la personne 3 sur le compte de la personne 1 !");
            Console.WriteLine("-----------------------------------------------------------------------------");
            //bonus avec valeur en ajoutant des console.readline
            int valeur = 500;
            int choixPersonne = 2;
            Console.WriteLine(Personne[choixPersonne].Vérification(valeur));
            Console.ReadLine();
        }
    }
}
