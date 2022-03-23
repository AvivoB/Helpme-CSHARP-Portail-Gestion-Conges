using System;
using MySql.Data.MySqlClient;
using System.Data.Common;
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
            string url = "SERVER="+this.serveur+";Port=8889"+";Database="
                + this.bdd+ ";User Id="+this.user+";password="+this.mdp;

            //instanciation de la connexion
            try
            {
                this.maConnexion = new MySqlConnection(url);
                Console.WriteLine("Connexion reussie");
            }
            catch(Exception exp)
            {
                Console.WriteLine("Erreur de connexion à : " + url);
            }

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

        public Document selectWhereDocument (int idmemoire)
        {
            string requete = "select * from memoire where idmemoire=@id;";
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

        public User selectWhereUser(User unUser)
        {
            string requete = "select * from user where email=@email and mdp=@mdp ;";
            User leUser = null;

            try
            {
                this.maConnexion.Open();
                MySqlCommand uneCommande = this.maConnexion.CreateCommand();
                uneCommande.CommandText = requete;
                uneCommande.Parameters.AddWithValue("@email", unUser.Email);
                uneCommande.Parameters.AddWithValue("@mdp", unUser.Mdp);

                DbDataReader unReader = uneCommande.ExecuteReader();

                try
                {
                    if (unReader.HasRows) //s'il ya des lignes 
                    {
                        if (unReader.Read())
                        {
                            leUser = new User(unReader.GetInt32(0),
                               unReader.GetString(1), unReader.GetString(2),
                               unReader.GetString(3), unReader.GetString(4),
                               unReader.GetString(5));

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
                Console.WriteLine(exp.Message);
                Console.WriteLine(exp.StackTrace);
            }
            return leUser;
        }
    }
    
}
