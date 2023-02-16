using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ajout des using pour la Base de donnée
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Collections;

namespace PremiereTestBD
{
    public struct Test
    {
        //Fonction qui permet de Définir la connexion
        public string DefinirCheminBD()
        {
            string CheminBDRelatif = System.IO.Directory.GetCurrentDirectory() + "\\Comptoirs.accdb";
            return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + CheminBDRelatif;
        }


        public bool CreationSelect(string NomSociete, out DataSet ds)
        {
            bool ok = false;
            //Définir la connexion gràce à une fonction
            OleDbConnection maConnexion = new OleDbConnection(DefinirCheminBD());
            //Définir DataSet
            ds = new DataSet();
            //définir ma requête + ouvrir la sessions de la base de donnée
            string query = "";
            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                if (NomSociete != "")
                {
                    query = "SELECT * FROM Clients WHERE Société=\"" + NomSociete + "\";";
                }
                else
                {
                    query = "SELECT * FROM Clients";
                }
                //on va chercher tout sa dans la bases de données grace au query et la connextion qui permet de rentrer dedans => OleDbDataAdapter
                OleDbDataAdapter da = new OleDbDataAdapter(query, maConnexion);
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
                infos += donnees.Tables[0].Rows[i]["Code client"].ToString() + "|" +
                         donnees.Tables[0].Rows[i]["Société"].ToString() + "|" +
                         donnees.Tables[0].Rows[i]["Contact"].ToString() + "|" +
                         donnees.Tables[0].Rows[i]["Adresse"].ToString() + "|" +
                         donnees.Tables[0].Rows[i]["Code postal"].ToString() + "|" +
                         donnees.Tables[0].Rows[i]["Ville"].ToString();
            }
            return infos;
        }








        public bool CreationAdd(string NameCategorie, string Description)
        {
            bool ok = false;
            //Définir la connexion gràce à une fonction
            OleDbConnection maConnexion = new OleDbConnection(DefinirCheminBD());

            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                //On crée la requête
                string query = "INSERT INTO Catégories (NomdeCategorie, Description) VALUES(@nomdecatégorie, description);";
                //on va ajouter la ligne dans la bases de données grace au query et la connextion qui permet de rentrer dedans => OleDbCommand
                OleDbCommand AjoutDa = new OleDbCommand(query, maConnexion);
                //on ajoute la ligne et c'est information qui suit 
                AjoutDa.Parameters.AddWithValue("@nomdecatégorie", NameCategorie);
                AjoutDa.Parameters.AddWithValue("@description", Description);
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


        public bool CreationUptade(string NomMessager, string Numero)
        {
            bool ok = false;

            //Définir la connexion gràce à une fonction
            OleDbConnection maConnexion = new OleDbConnection(DefinirCheminBD());

            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                //On crée la requête
                string query = "UPDATE Messagers SET Telephone=@paramètre WHERE NomDuMessager =" + NomMessager + ";";
                //on va ajouter la ligne dans la bases de données grace au query et la connextion qui permet de rentrer dedans => OleDbCommand 
                OleDbCommand UptadeDa = new OleDbCommand(query, maConnexion);
                //on modifie la ligne 
                UptadeDa.Parameters.AddWithValue("@paramètre", Numero);
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
            OleDbConnection maConnexion = new OleDbConnection(DefinirCheminBD());
            //Définir DataSet
            ds = new DataSet();
            //définir ma requête + ouvrir la sessions de la base de donnée
            string query = "";
            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                //Création de la requête
                query = "SELECT * FROM Catégories";
                //on va chercher tout sa dans la bases de données grace au query et la connextion qui permet de rentrer dedans => OleDbDataAdapter
                OleDbDataAdapter da = new OleDbDataAdapter(query, maConnexion);
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

        //Permte d'afficher la liste
        public string AfficheList(DataSet donnees)
        {
            string infos = "";
            for (int i = 0; i < donnees.Tables[0].Rows.Count; i++)
            {
                infos += donnees.Tables[0].Rows[i].ToString() + "\n";
            }
            return infos;
        }





        //Permet de supprimer une ligne
        public bool CreationDelete(string LeChamp, string Table)
        {
            bool ok = false;
            //Définir la connexion gràce à une fonction
            OleDbConnection maConnexion = new OleDbConnection(DefinirCheminBD());

            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                //On crée la requête
                string query = "DELETE FROM " + Table + " SET Société=\"" + LeChamp + "\";";
                //on va ajouter la ligne dans la bases de données grace au query et la connextion qui permet de rentrer dedans => OleDbCommand
                OleDbCommand DeleteDa = new OleDbCommand(query, maConnexion);
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
