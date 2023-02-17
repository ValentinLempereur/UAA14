using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FirstSql
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
            Console.WriteLine("Quelle Livre ? (par exemple About, Achard ou rien pour la liste complète\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string NomLivre = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (Page1.CreationSelect(NomLivre, out ds))
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
            Console.WriteLine("Par exemple ajouter un livre dans la table des listeLivre");
            Console.WriteLine("--------------------------------------------------------------\n");
            Console.WriteLine("Nom du livre à ajouter");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string Name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Prenom du livre");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string Prenom = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (Page1.CreationAdd(Name, Prenom))
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
            Console.WriteLine("\nNom du livre dont on veut modifier le prenom");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Nouveau prenom");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Prenom = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (Page1.CreationUptade(Name, Prenom))
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

            //----------------------------Listez tous les éléments d'un champ d'une table dans une base de donnée----------------------------
            Console.WriteLine("\nListe des catégories disponibles : ");
            if (Page1.CreationListe(out ds))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(Page1.AfficheSELECT(ds));
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sa ne marche pas");
                Console.ForegroundColor = ConsoleColor.White;
            }


            //----------------------------Supprimer une ligne dans une base de donnée----------------------------
            Console.WriteLine("Supprimer une ligne dans la table de listeLivre");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Séléctionné la ligne");
            Console.ForegroundColor = ConsoleColor.Yellow;
            String LeChamp = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (Page1.CreationDelete(LeChamp))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("La ligne à été suprrimer");
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
