using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ajout des using pour la Base de donnée
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Collections;

namespace FirstMySQL
{
    class MySQL
    {
        public string DefinirCheminBD()
        {
            return "Server=localhost;Database=firstmysql;port=3306;User Id=root;password=root";
        }

        public bool CreationSelect(string Nom, out DataSet ds)
        {
            bool ok = false;
            //Définir la connexion gràce à une fonction
            MySqlConnection maConnexion = new MySqlConnection(DefinirCheminBD());
            //Définir DataSet
            ds = new DataSet();
            //définir ma requête + ouvrir la sessions de la base de donnée
            string query = "";
            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                if (Nom != "")
                {
                    query = "SELECT * FROM utilisateurs WHERE nomUser=\"" + Nom + "\"";
                }
                else
                {
                    query = "SELECT * FROM utilisateurs";
                }
                //on va chercher tout sa dans la bases de données grace au query et la connextion qui permet de rentrer dedans => MySqlDataAdapter
                MySqlDataAdapter da = new MySqlDataAdapter(query, maConnexion);
                //mesDonnees ne servent à rien et on met les info dans ds
                da.Fill(ds, "mesDonnees");
                //Vérifie si on à bien récupré quelques choses
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    ok = true;
                }

                //on ferme la connexion le plus vote possible 
                maConnexion.Close();
            }
            //si sa ne marche pas, permet de ne pas planter et de mettre un message d'erreur
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }

            return ok;
        }




        public string AfficheSELECT(DataSet donnees)
        {
            string infos = "";
            for (int i = 0; i < donnees.Tables[0].Rows.Count; i++)
            {
                infos += donnees.Tables[0].Rows[i]["nomUser"].ToString() + "|" +
                         donnees.Tables[0].Rows[i]["prenomUser"].ToString() + "|" +
                         donnees.Tables[0].Rows[i]["loginUser"].ToString() + "|" +
                         donnees.Tables[0].Rows[i]["passWorduser"].ToString() + "|" +
                         donnees.Tables[0].Rows[i]["role"].ToString() + "\n";
            }
            return infos;
        }



        public bool CreationAdd(string Name, string Chemin)
        {
            bool ok = false;
            //Définir la connexion gràce à une fonction
            MySqlConnection maConnexion = new MySqlConnection(DefinirCheminBD());

            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                //On crée la requête
                string query = "INSERT INTO images (name, image) VALUES(@name, @image)";
                //on va ajouter la ligne dans la bases de données grace au query et la connextion qui permet de rentrer dedans => MySqlCommand
                MySqlCommand AjoutDa = new MySqlCommand(query, maConnexion);
                //on ajoute la ligne et c'est information qui suit 
                AjoutDa.Parameters.AddWithValue("@name", Name);
                AjoutDa.Parameters.AddWithValue("@image", "images/DB/" + Chemin + ".jpg");
                //on éxécute la comande avec => ExecuteNonQuery() et sa renvoie le nombre de ligne on vérifie donc si il y en a au moins 1 ou plus éffectué
                if (AjoutDa.ExecuteNonQuery() >= 1)
                {
                    ok = true;
                }
                //on ferme la connexion le plus vote possible 
                maConnexion.Close();
            }
            //si sa ne marche pas, permet de ne pas planter et de mettre un message d'erreur
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }

            return ok;
        }


        public bool CreationUptade(string Name, string colonne, string infochanger)
        {
            bool ok = false;

            //Définir la connexion gràce à une fonction
            MySqlConnection maConnexion = new MySqlConnection(DefinirCheminBD());

            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                //On crée la requête
                string query = "UPDATE utilisateurs SET " + colonne + "=@parametre WHERE nomUser =\"" + Name + "\"";
                //on va ajouter la ligne dans la bases de données grace au query et la connextion qui permet de rentrer dedans => MySqlCommand 
                MySqlCommand UptadeDa = new MySqlCommand(query, maConnexion);
                //on modifie la ligne 
                UptadeDa.Parameters.AddWithValue("@parametre", infochanger);
                //on éxécute la comande avec => ExecuteNonQuery() et sa renvoie le nombre de ligne on vérifie donc si il y en a au moins 1 ou plus éffectué
                if (UptadeDa.ExecuteNonQuery() >= 1)
                {
                    ok = true;
                }
                //on ferme la connexion le plus vote possible 
                maConnexion.Close();
            }
            //si sa ne marche pas, permet de ne pas planter et de mettre un message d'erreur
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }

            return ok;
        }


        public bool CreationListe(out DataSet ds)
        {
            bool ok = false;
            //Définir la connexion gràce à une fonction
            MySqlConnection maConnexion = new MySqlConnection(DefinirCheminBD());
            //Définir DataSet
            ds = new DataSet();
            //définir ma requête + ouvrir la sessions de la base de donnée
            string query = "";
            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                //Création de la requête
                query = "SELECT * FROM utilisateurs";
                //on va chercher tout sa dans la bases de données grace au query et la connextion qui permet de rentrer dedans => MySqlDataAdapter
                MySqlDataAdapter da = new MySqlDataAdapter(query, maConnexion);
                //mesDonnees ne servent à rien et on met les info dans ds
                da.Fill(ds, "mesDonnees");
                //Vérifie si on à bien récupré quelques choses
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    ok = true;
                }

                //on ferme la connexion le plus vote possible 
                maConnexion.Close();
            }
            //si sa ne marche pas, permet de ne pas planter et de mettre un message d'erreur
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }

            return ok;
        }



        public bool CreationDelete(string LeChamp)
        {
            bool ok = false;
            //Définir la connexion gràce à une fonction
            MySqlConnection maConnexion = new MySqlConnection(DefinirCheminBD());

            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                //On crée la requête
                string query = "DELETE FROM utilisateurs WHERE nomUser='" + LeChamp + "'";
                //on va ajouter la ligne dans la bases de données grace au query et la connextion qui permet de rentrer dedans => MySqlCommand
                MySqlCommand DeleteDa = new MySqlCommand(query, maConnexion);
                //on éxécute la comande avec => ExecuteNonQuery() et sa renvoie le nombre de ligne on vérifie donc si il y en a au moins 1 ou plus éffectué
                if (DeleteDa.ExecuteNonQuery() >= 1)
                {
                    ok = true;
                }
                //on ferme la connexion le plus vote possible 
                maConnexion.Close();
            }
            //si sa ne marche pas, permet de ne pas planter et de mettre un message d'erreur
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }

            return ok;
        }
    }
}
