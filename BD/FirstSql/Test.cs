using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ajout des using pour la Base de donnée
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Collections;

namespace FirstSql
{
    class Test
    {
        // détermine la chaîne de connexion
        public string DefinirCheminBD()
        {
            return @"Data Source = PCI42112\SQLEXPRESS; Initial Catalog = bibliotheque_bb; Integrated Security = True";

        }

        public bool CreationSelect(string NomLivre, out DataSet ds)
        {
            bool ok = false;
            //Définir la connexion gràce à une fonction
            SqlConnection maConnexion = new SqlConnection(DefinirCheminBD());
            //Définir DataSet
            ds = new DataSet();
            //définir ma requête + ouvrir la sessions de la base de donnée
            string query = "";
            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                if (NomLivre != "")
                {
                    query = "SELECT * FROM listeLivre WHERE nom='" + NomLivre + "';";
                }
                else
                {
                    query = "SELECT * FROM listeLivre";
                }
                //on va chercher tout sa dans la bases de données grace au query et la connextion qui permet de rentrer dedans => OleDbDataAdapter
                SqlDataAdapter da = new SqlDataAdapter(query, maConnexion);
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

        //Permet d'afficher
        public string AfficheSELECT(DataSet donnees)
        {
            string infos = "";
            for (int i = 0; i < donnees.Tables[0].Rows.Count; i++)
            {
                infos += donnees.Tables[0].Rows[i]["nom"].ToString() + "|" +
                         donnees.Tables[0].Rows[i]["prenom"].ToString() + "|" +
                         donnees.Tables[0].Rows[i]["titre"].ToString() + "|" +
                         donnees.Tables[0].Rows[i]["illustrateur"].ToString() + "|" +
                         donnees.Tables[0].Rows[i]["annee_parution"].ToString() + "\n";
            }
            return infos;
        }


        public bool CreationAdd(string Name, string Prenom)
        {
            bool ok = false;
            //Définir la connexion gràce à une fonction
            SqlConnection maConnexion = new SqlConnection(DefinirCheminBD());

            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                //On crée la requête
                string query = "INSERT INTO listeLivre (nom, prenom) VALUES(@name, @prenom);";
                //on va ajouter la ligne dans la bases de données grace au query et la connextion qui permet de rentrer dedans => OleDbCommand
                SqlCommand AjoutDa = new SqlCommand(query, maConnexion);
                //on ajoute la ligne et c'est information qui suit 
                AjoutDa.Parameters.AddWithValue("@name", Name);
                AjoutDa.Parameters.AddWithValue("@prenom", Prenom);
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

        public bool CreationUptade(string Name, string Prenom)
        {
            bool ok = false;

            //Définir la connexion gràce à une fonction
            SqlConnection maConnexion = new SqlConnection(DefinirCheminBD());

            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                //On crée la requête
                string query = "UPDATE listeLivre SET prenom=@paramètre WHERE nom ='" + Name + "';";
                //on va ajouter la ligne dans la bases de données grace au query et la connextion qui permet de rentrer dedans => OleDbCommand 
                SqlCommand UptadeDa = new SqlCommand(query, maConnexion);
                //on modifie la ligne 
                UptadeDa.Parameters.AddWithValue("@paramètre", Prenom);
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
            SqlConnection maConnexion = new SqlConnection(DefinirCheminBD());
            //Définir DataSet
            ds = new DataSet();
            //définir ma requête + ouvrir la sessions de la base de donnée
            string query = "";
            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                //Création de la requête
                query = "SELECT * FROM listeLivre";
                //on va chercher tout sa dans la bases de données grace au query et la connextion qui permet de rentrer dedans => OleDbDataAdapter
                SqlDataAdapter da = new SqlDataAdapter(query, maConnexion);
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
            SqlConnection maConnexion = new SqlConnection(DefinirCheminBD());

            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                //On crée la requête
                string query = "DELETE FROM listeLivre WHERE nom='" + LeChamp + "';";
                //on va ajouter la ligne dans la bases de données grace au query et la connextion qui permet de rentrer dedans => OleDbCommand
                SqlCommand DeleteDa = new SqlCommand(query, maConnexion);
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
