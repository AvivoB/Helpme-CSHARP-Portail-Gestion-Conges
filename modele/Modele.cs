using System;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Diagnostics;
using System.Collections.Generic; 

namespace Memoire
{
    public class Modele
    {
        private string serveur, bdd, user, mdp;
        //connexion MySQL 
        private MySqlConnection maConnexion;

        public Modele(string serveur, string bdd, string user, string mdp)
        {
            this.serveur = serveur;
            this.bdd = bdd;
            this.user = user;
            this.mdp = mdp;
            //3306 Mysql et 3307 Mariadb
            string url = "server="+this.serveur+";"+"database="
                + this.bdd+ ";user="+this.user+";password="+this.mdp;
            //instanciation de la connexion
            try
            {
                this.maConnexion = new MySqlConnection(url);
                this.maConnexion.Open();
            }
            catch (Exception exp)
            {
                Debug.WriteLine("Erreur de connexion à : " + url);
            }

        }

        public List<string> connexion(string email, string mdp)
        {
            List<string> list = new List<string>();
            MySqlCommand cmd;
            try
            {
                string str = "select * from prestataire where prestataire_mail = '"+email+"' and prestataire_mdp = '"+mdp+"';";
                cmd = new MySqlCommand(str, this.maConnexion);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(reader["id"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return list;
        }

        public List<User> selectAllUsers()
        {
            string requete = "select * from prestataire_v;";
            Debug.WriteLine(requete);
            List<User> list = new List<User>();
            MySqlCommand cmd;

            try
            {
                cmd = new MySqlCommand(requete, this.maConnexion);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            User user = new User();
                            user.Iduser = reader["id"].ToString();
                            user.Nom = reader["prestataire_nom"].ToString();
                            user.Prenom = reader["prestataire_prenom"].ToString();
                            user.Email = reader["prestataire_mail"].ToString();
                            user.IdStatut = reader["id_statut"].ToString();
                            user.Mdp = reader["prestataire_mdp"].ToString();
                            user.Statut = reader["statut"].ToString();
                            list.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return list;
        }

        public User selectWhereUser(string id)
        {
            string requete = "select * from prestataire_v where id=" + id + ";";
            List<object> list = new List<object>();
            MySqlCommand cmd;
            User user = new User();
            try
            {
                cmd = new MySqlCommand(requete, this.maConnexion);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            
                            user.Iduser = reader["id"].ToString();
                            user.Nom = reader["prestataire_nom"].ToString();
                            user.Prenom = reader["prestataire_prenom"].ToString();
                            user.Email = reader["prestataire_mail"].ToString();
                            user.Mdp = reader["prestataire_mdp"].ToString();
                            user.IdStatut = reader["id_statut"].ToString();
                            user.Statut = reader["statut"].ToString();
                            list.Add(user);
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Vide");
                    }
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex);
            }
            return user;
        }

        public List<Conge> selectWhereConge(string id)
        {
            string requete = "select * from demande_conges_v where id_pres=" + id + ";";
            List<Conge> list = new List<Conge>();
            MySqlCommand cmd;
            
            try
            {
                cmd = new MySqlCommand(requete, this.maConnexion);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Conge conge = new Conge();
                            conge.IdConge = reader["id_conge"].ToString();
                            conge.Date_debut = reader["date_debut"].ToString();
                            conge.Date_fin = reader["date_fin"].ToString();
                            conge.Days = reader["days"].ToString();
                            conge.Approuve = reader["approuve"].ToString();
                            conge.IdUser = reader["id_pres"].ToString();
                            list.Add(conge);
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Vide");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return list;
        }

        public List<Conge> selectAllConges()
        {
            string requete = "select * from demande_conges_v;";
            List<Conge> list = new List<Conge>();
            MySqlCommand cmd;

            try
            {
                cmd = new MySqlCommand(requete, this.maConnexion);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Conge conge = new Conge();
                            conge.IdConge = reader["id_conge"].ToString();
                            conge.Date_debut = reader["date_debut"].ToString();
                            conge.Date_fin = reader["date_fin"].ToString();
                            conge.Days = reader["days"].ToString();
                            conge.Approuve = reader["approuve"].ToString();
                            conge.IdUser = reader["id_pres"].ToString();
                            conge.Prenom = reader["prestataire_prenom"].ToString();
                            conge.Nom = reader["prestataire_nom"].ToString();
                            list.Add(conge);
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Vide");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return list;
        }

        public void insertConge(string date_debut, string date_fin, string id)
        {
            MySqlCommand cmd;
            try
            {
                string str = "insert into demande_conges (date_debut, date_fin, id_pres) values ('"+ date_debut + "', '"+ date_fin+ "', '"+id+"')";
                cmd = new MySqlCommand(str, this.maConnexion);
                cmd.ExecuteNonQuery();
                this.maConnexion.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }        
        
        public void updateConge(string id, string approuve)
        {
            MySqlCommand cmd;
                string str = "update demande_conges set approuve='"+ approuve + "' where id_conge="+id+";";
                Debug.WriteLine(str);
                cmd = new MySqlCommand(str, this.maConnexion);
                cmd.ExecuteNonQuery();
                this.maConnexion.Close();
        }

        public List<Document> selectAllMemoires()
        {
            List<Document> lesDocuments = new List<Document>();
            string requete = "select * from memoire ;";
            this.maConnexion.Open();
            MySqlCommand uneCommande = this.maConnexion.CreateCommand();

            uneCommande.CommandText = requete;

            //execution de la requete  
            //on définit un curseur de lecture des enregistrements
            DbDataReader unReader = uneCommande.ExecuteReader();

            try
            {
                if (unReader.HasRows) //s'il ya des lignes 
                {
                    while (unReader.Read())
                    {
                        Document unDocument = new Document(unReader.GetInt32(0),
                            unReader.GetString(1), unReader.GetInt32(2),
                            unReader.GetString(3), unReader.GetString(4),
                            unReader.GetString(5), unReader.GetString(6));
                        lesDocuments.Add(unDocument);
                    }
                }

            }
            finally
            {
                Console.WriteLine("erreur d'execution de la requete " + requete);
            }

            //extraction des données 

            this.maConnexion.Close();
            return lesDocuments;
        }

        public void insertMemoire(Document unDocument)
        {
            string requete = "insert into memoire values (null, @intitule, @nbPages," +
                "@contexte, @nom, @prenom, @soutenance); ";
            try
            {
                this.maConnexion.Open();
                MySqlCommand uneCommande = this.maConnexion.CreateCommand();

                uneCommande.CommandText = requete;

                //la correspondance entre les parametres SQL et prog
                uneCommande.Parameters.AddWithValue("@intitule", unDocument.Intitule);
                uneCommande.Parameters.AddWithValue("@nbPages", unDocument.NbPages);
                uneCommande.Parameters.AddWithValue("@contexte", unDocument.Contexte);
                uneCommande.Parameters.AddWithValue("@nom", unDocument.Nom);
                uneCommande.Parameters.AddWithValue("@prenom", unDocument.Prenom);
                uneCommande.Parameters.AddWithValue("@soutenance", unDocument.Soutenance);
                //execution de la commande
                uneCommande.ExecuteNonQuery(); 

                this.maConnexion.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Erreur de connexion ");
            }
        }

        public Document selectWhereDocument(int idmemoire)
        {
            string requete = "select * from prestataire where idmemoire=@id;";
            Document unDocument = null;

            try
            {
                this.maConnexion.Open();
                MySqlCommand uneCommande = this.maConnexion.CreateCommand();
                uneCommande.CommandText = requete;
                uneCommande.Parameters.AddWithValue("@id", idmemoire);

                DbDataReader unReader = uneCommande.ExecuteReader();

                try
                {
                    if (unReader.HasRows) //s'il ya des lignes 
                    {
                        if (unReader.Read())
                        {
                            unDocument = new Document(unReader.GetInt32(0),
                               unReader.GetString(1), unReader.GetInt32(2),
                               unReader.GetString(3), unReader.GetString(4),
                               unReader.GetString(5), unReader.GetString(6));

                        }
                    }

                }
                finally
                {
                    Console.WriteLine("erreur d'execution de la requete " + requete);
                }

                this.maConnexion.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Erreur sur la requete : " + requete);
            }
            return unDocument;
        }

        public void deleteMemoire(int idmemoire)
        {
            string requete = "delete from memoire where idmemoire =@idmemoire;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand uneCommande = this.maConnexion.CreateCommand();
                uneCommande.CommandText = requete;
                uneCommande.Parameters.AddWithValue("@idmemoire", idmemoire);
                uneCommande.ExecuteNonQuery();

                this.maConnexion.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Erreur sur la requete : " + requete);
            }
        }

        public void updateMemoire(Document unDocument)
        {
            string requete = "update memoire set intitule=@intitule, nbPages=@nbPages," +
                "contexte=@contexte, nom=@nom, prenom=@prenom, soutenance=@soutenance " +
                "where idmemoire=@id;";
            try
            {
                this.maConnexion.Open();
                MySqlCommand uneCommande = this.maConnexion.CreateCommand();

                uneCommande.CommandText = requete;
                uneCommande.Parameters.AddWithValue("@id", unDocument.IDmemoire);
                uneCommande.Parameters.AddWithValue("@intitule", unDocument.Intitule);
                uneCommande.Parameters.AddWithValue("@nbPages", unDocument.NbPages);
                uneCommande.Parameters.AddWithValue("@contexte", unDocument.Contexte);
                uneCommande.Parameters.AddWithValue("@nom", unDocument.Nom);
                uneCommande.Parameters.AddWithValue("@prenom", unDocument.Prenom);
                uneCommande.Parameters.AddWithValue("@soutenance", unDocument.Soutenance);
                uneCommande.ExecuteNonQuery();

                this.maConnexion.Close();

            }catch (Exception exp)
            {
                Console.WriteLine("Erreur sur la requete : " + requete);
            }
        }

    }
    
}
