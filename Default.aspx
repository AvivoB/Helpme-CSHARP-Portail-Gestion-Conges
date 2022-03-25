<%@ Page Language="C#" %>
<%@ Import Namespace="Memoire" %>
<%@ Import Namespace="System.Collections.Generic" %>

            <% 
                //le code C# 
                Controleur unControleur = new Controleur ();
                string message = "";
            %>

           <%
            if (Session["email"] == null){
            %>
            <%
                string message = "";
                if (Request.Form["connecter"] != null) {
                    string email = Request.Form["email"];
                    string mdp = Request.Form["mdp"];
                    User unUser = new User(email, mdp, "", "", "");
                    unUser = unControleur.selectWhereUser(unUser);

                    if (unUser != null) {
                        message = "Connexion Bienvenue : " + unUser.Nom;
                        Session.Add("email", unUser.Email);
                        Session.Add("droits", unUser.Droits);

                    } else {
                        message = "<div class=\"alert alert-danger\" role=\"alert\">Identifiants inccorects</div>";
                    }
                }
            %>
            
            <!--#include file="vue/vue_connexion.aspx"-->
            <%
                }
            %>
 
            
            
            
            <%
                if (Session["email"] != null) {

                    Document leDocument = null;

                    if (Request["action"] != null) {
                        string action = Request["action"];
                        int idmemoire = int.Parse(Request["idmemoire"]);

                        if (action == "sup") {
                            unControleur.deleteMemoire(idmemoire);
                        } else if (action == "edit") {

                            //récupérer le document sélectionné pour être modifié 
                            leDocument = unControleur.selectWhereDocument(idmemoire);

                        }
                    }
                }
            %>
            <!--#include file="vue/vue_insert.aspx"-->
            
            <%
                if(Request.Form["modifier"] != null){
                    int idmemoire  = int.Parse(Request.Form["idmemoire"]);
                    string intitule = Request.Form["intitule"]; 
                    int nbPages  = int.Parse(Request.Form["nbPages"]);
                    string contexte = Request.Form["contexte"];
                    string nom = Request.Form["nom"];
                    string prenom = Request.Form["prenom"];
                    string soutenance = Request.Form["soutenance"];
                
                    //instanciation d'un Document 
                    Document unDocument = new Document (idmemoire,intitule, nbPages, contexte, nom,prenom, soutenance); 
                    //appel pour update 
                    unControleur.updateMemoire(unDocument); 
                }
            
                if(Request.Form["valider"] != null){
                string intitule = Request.Form["intitule"]; 
                int nbPages  = int.Parse(Request.Form["nbPages"]);
                string contexte = Request.Form["contexte"];
                string nom = Request.Form["nom"];
                string prenom = Request.Form["prenom"];
                string soutenance = Request.Form["soutenance"];
                
                //instanciation d'un Document 
        Document unDocument = new Document (intitule, nbPages, contexte, nom,prenom, soutenance); 
                //insertion dans la base via le controleur 
                unControleur.insertMemoire(unDocument); 
                
                }
            %>
            <h3> Liste des mémoires  </h3>
            <%
            //recupération des memoires de la base 
             List<Document> lesMemoires = unControleur.selectAllMemoires();
            %>
            <!--#include file="vue/vue_lister.aspx"-->
            <a href="Default.aspx?connexion=DeConnexion">Deconnexion</a>
            <% 
            
            }
            
            if (Request["connexion"] == "DeConnexion") {
                Session.Clear(); 
                Response.Redirect("Default.aspx"); 
            }
            
            %>
