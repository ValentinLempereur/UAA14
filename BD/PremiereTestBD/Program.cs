using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ajout pour le DataSet
using System.Data;


namespace PremiereTestBD
{
    class Program
    {
        static void Main(string[] args)
        {
            Test Page1 = new Test();
            DataSet ds;
            //----------------------------Sélectionné des infos et les affichées----------------------------
            Console.WriteLine("Teston les accès aux bases de Données !");
            Console.WriteLine("========================================");
            Console.WriteLine("Chercher une information particulière ou lister toute la table : \nPar exemple dans la table des clients, faire une recherchesur base du nom de la société");
            Console.WriteLine("---------------------------------------------------------------------------------------\n");
            Console.WriteLine("Quelle société ? (par exemple Around the Horn, France restauration ou rien pour la liste complète\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string NomSociete = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (Page1.CreationSelect(NomSociete, out ds))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n" + Page1.AfficheSELECT(ds));
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sa ne marche pas");
                Console.ForegroundColor = ConsoleColor.White;
            }
            //----------------------------Ajouter une ligne dans la base de donnée----------------------------
            Console.WriteLine("\nAjouter une ligne dans une table : ");
            Console.WriteLine("Par exemple ajouter une catégorie dans la table des catégories");
            Console.WriteLine("--------------------------------------------------------------\n");
            Console.WriteLine("Nom de la catégorie à ajouter");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string NameCategorie = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Description");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string Description = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (Page1.CreationAdd(NameCategorie, Description))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nAjout éffectué");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sa ne marche pas");
                Console.ForegroundColor = ConsoleColor.White;
            }


            //----------------------------Modifier des information dans une base de donnée----------------------------
            Console.WriteLine("\nNom du messager dont on veut modifier le numéro de téléphone (Speedy Express / united Package / Federal Shipping)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string NomMessager = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Nouveau numéro de téléphone");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string Numero = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (Page1.CreationUptade(NomMessager, Numero))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nModification éffectué");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sa ne marche pas");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ReadLine();
        }
    }
}
