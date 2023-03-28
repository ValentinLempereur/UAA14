using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FirstMySQL
{
    class Program
    {

        static void Main(string[] args)
        {
            MySQL mysql = new MySQL();
            DataSet ds;

            //----------------------------Sélectionné des infos et les affichées----------------------------
            Console.WriteLine("Teston les accès aux bases de Données !");
            Console.WriteLine("========================================");
            Console.WriteLine("Chercher une information particulière ou lister toute la table : \nPar exemple dans la table des utilisateur, faire une recherchesur base du nom de la société");
            Console.WriteLine("---------------------------------------------------------------------------------------\n");
            Console.WriteLine("quelle personne voulez-vous savoir c'est information (nom) ? (par exemple haddock, ben ou rien pour la liste complète\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string nom = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            test(nom);


            //----------------------------Ajouter une ligne dans la base de donnée----------------------------
            Console.WriteLine("\nAjouter une ligne dans une table : ");
            Console.WriteLine("Par exemple ajouter une image dans la table des images");
            Console.WriteLine("--------------------------------------------------------------\n");
            Console.WriteLine("Nom de l'image à ajouter");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string Name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("nom du pour le liens d'image");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string Chemin = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (mysql.CreationAdd(Name, Chemin))
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
            nom = "";
            Console.WriteLine("\nEntrez le nom d'une personne pour voir c'est information et ansi changer une information");
            Console.ForegroundColor = ConsoleColor.Yellow;
            nom = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("nomUser | prenomUser | loginUser | passWordUser | role");
            Console.ForegroundColor = ConsoleColor.White;

            test(nom);
            if (nom == "")
            {
                Console.WriteLine("\nEntrez le nom de la personne que vous voulez modifier");
                Console.ForegroundColor = ConsoleColor.Yellow;
                nom = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            Console.WriteLine("\nQuelle colonne voulez vous changer");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string colonne = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nEntrer la nouvelle information");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string infochanger = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (mysql.CreationUptade(nom, colonne, infochanger))
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
            if (mysql.CreationListe(out ds))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(mysql.AfficheSELECT(ds));
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sa ne marche pas");
                Console.ForegroundColor = ConsoleColor.White;
            }
            


            //----------------------------Supprimer une ligne dans une base de donnée----------------------------
            Console.WriteLine("Supprimer une ligne dans la table de utilisateurs");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Séléctionné la ligne");
            Console.ForegroundColor = ConsoleColor.Yellow;
            String LeChamp = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (mysql.CreationDelete(LeChamp))
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

        static void test(string nom)
        {
            DataSet ds;
            MySQL mysql = new MySQL();
            
            if (mysql.CreationSelect(nom, out ds))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n" + mysql.AfficheSELECT(ds));
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sa ne marche pas");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
