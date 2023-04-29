using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Base de donnée
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace GuichetBanquaire.Modele
{
    internal class MysqlRequete
    {
        public string DefinirCheminBD()
        {
            return "Server=localhost;Database=banque;port=3306;User Id=root;password=root";
        }



        public void SelectInfosAll(string Requet, out DataSet ds, out int NbrRow)
        {
            //Définir la connexion gràce à une fonction
            MySqlConnection maConnexion = new MySqlConnection(DefinirCheminBD());
            //Définir DataSet
            ds = new DataSet();
            //définir ma requête + ouvrir la sessions de la base de donnée
            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                string query = Requet;
                //on va chercher tout sa dans la bases de données grace au query et la connextion qui permet de rentrer dedans => MySqlDataAdapter
                MySqlDataAdapter da = new MySqlDataAdapter(query, maConnexion);
                //mesDonnees ne servent à rien et on met les info dans ds
                da.Fill(ds, "mesDonnees");
                //Prendre le nombre de ligne ressortit
                NbrRow = ds.Tables[0].Rows.Count;
                //on ferme la connexion le plus vote possible 
                maConnexion.Close();
            }
            //si sa ne marche pas, permet de ne pas planter et de mettre un message d'erreur
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
        public void SelectCompte(string Requet, out DataTable ds, out int NbrRow)
        {
            //Définir la connexion gràce à une fonction
            MySqlConnection maConnexion = new MySqlConnection(DefinirCheminBD());
            //Définir DataSet
            ds = new DataTable();
            //définir ma requête + ouvrir la sessions de la base de donnée
            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                string query = Requet;
                //on va chercher tout sa dans la bases de données grace au query et la connextion qui permet de rentrer dedans => MySqlDataAdapter
                MySqlDataAdapter da = new MySqlDataAdapter(query, maConnexion);
                //mesDonnees ne servent à rien et on met les info dans ds
                da.Fill(ds);
                //Prendre le nombre de ligne ressortit
                NbrRow = ds.Rows.Count;
                //on ferme la connexion le plus vote possible 
                maConnexion.Close();
            }
            //si sa ne marche pas, permet de ne pas planter et de mettre un message d'erreur
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        public bool NewUser(string name, string password)
        {
            bool ok = false;
            SelectInfosAll("SELECT * FROM users", out DataSet ds, out int Nbr);

            //Définir la connexion gràce à une fonction
            MySqlConnection maConnexion = new MySqlConnection(DefinirCheminBD());

            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                //On crée la requête
                string query = "INSERT INTO users (user_id, user_name,user_password) VALUES(@id, @name, @password);";
                //on va ajouter la ligne dans la bases de données grace au query et la connextion qui permet de rentrer dedans => MySqlCommand
                MySqlCommand AjoutDa = new MySqlCommand(query, maConnexion);
                //on ajoute la ligne et c'est information qui suit 
                AjoutDa.Parameters.AddWithValue("@id", Nbr + 1);
                AjoutDa.Parameters.AddWithValue("@name", name);
                AjoutDa.Parameters.AddWithValue("@password", password);
                //on éxécute la comande avec => ExecuteNonQuery()
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

        public void ModifyUser(int id, string name, string mtp)
        {
            MySqlConnection maConnexion = new MySqlConnection(DefinirCheminBD());

            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                //On crée la requête
                string query = "UPDATE users SET user_name=@parametre_name, user_password=@parametre_password Where user_id =" + id;
                //on va ajouter la ligne dans la bases de données grace au query et la connextion qui permet de rentrer dedans => MySqlCommand
                MySqlCommand ResetData = new MySqlCommand(query, maConnexion);
                //on modifie la ligne
                ResetData.Parameters.AddWithValue("@parametre_name", name);
                ResetData.Parameters.AddWithValue("@parametre_password", mtp);
                //on éxécute la comande avec => ExecuteNonQuery()
                ResetData.ExecuteNonQuery();
                //on ferme la connexion le plus vote possible 
                maConnexion.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        public void ModifySolde(string compte, string numero, double solde)
        {
            MySqlConnection maConnexion = new MySqlConnection(DefinirCheminBD());

            try
            {
                //on ouvre la connexion
                maConnexion.Open();
                //On crée la requête
                string query = "UPDATE "+ compte +" SET solde=@parametre_solde Where numero =\"" + numero + "\"";
                //on va ajouter la ligne dans la bases de données grace au query et la connextion qui permet de rentrer dedans => MySqlCommand
                MySqlCommand ResetData = new MySqlCommand(query, maConnexion);
                //on modifie la ligne
                ResetData.Parameters.AddWithValue("@parametre_solde", solde);
                //on éxécute la comande avec => ExecuteNonQuery()
                ResetData.ExecuteNonQuery();
                //on ferme la connexion le plus vote possible 
                maConnexion.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        public void InfosUser(DataSet donnees, out int Id, out string Name, out string Password)
        {
            Id = (int)donnees.Tables[0].Rows[0]["user_id"];
            Name = donnees.Tables[0].Rows[0]["user_name"].ToString();
            Password = donnees.Tables[0].Rows[0]["user_password"].ToString();
        }

        public void InfosCompteCourant(DataSet donnees, int i, out string Numero, out double Solde, out double DecouvertMax)
        {
            Numero = donnees.Tables[0].Rows[i]["numero"].ToString();
            Solde = (double)donnees.Tables[0].Rows[i]["solde"];
            DecouvertMax = (double)donnees.Tables[0].Rows[i]["decouvert_max"];
        }

        public void InfosCompteEpargne(DataSet donnees, int i, out string Numero, out double Solde, out double TauxInteret)
        {
            Numero = donnees.Tables[0].Rows[i]["numero"].ToString();
            Solde = (Double)donnees.Tables[0].Rows[i]["solde"];
            TauxInteret = (double)donnees.Tables[0].Rows[i]["taux_interet"];
        }

        public void IdPerson(DataSet donnees, out int Id)
        {
            Id = (int)donnees.Tables[0].Rows[0]["user_id"];
        }

        public void AfficheCompte(DataTable donnees, int id, out string name)
        {
            name = donnees.Rows[id]["numero"].ToString();
        }

        public void AfficheSolde(DataSet donnees, out double solde)
        {
            solde = (double)donnees.Tables[0].Rows[0]["solde"];
        }
    }
}
