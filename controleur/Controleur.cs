using System;
using System.Collections.Generic;

namespace Memoire 
{
    public class Controleur
    {
        private Modele unModele ; 
        public Controleur()
        {
            this.unModele = new Modele("localhost", "dev3", "root", ""); 
        }

        public List<Document> selectAllMemoires ()
        {
            return unModele.selectAllMemoires(); 
        }
        public void insertMemoire (Document unDocument)
        {
            //apres des tests sur les champs

            //appel du Modele
            unModele.insertMemoire(unDocument);
        }

        public List<string> connexion(string email, string mdp)
        {
            return unModele.connexion(email, mdp);
        }

        public List<User> selectAllUsers()
        {
            return unModele.selectAllUsers();
        }

        public List<Conge> selectAllConges()
        {
            return unModele.selectAllConges();
        }

        public User selectWhereUser(string id)
        {
            return unModele.selectWhereUser(id);
        }

        public void deleteMemoire(int idmemoire)
        {
            unModele.deleteMemoire(idmemoire);
        }
        public void updateMemoire(Document unDocument)
        {
            unModele.updateMemoire(unDocument);
        }

        public void insertConge(string date_debut, string date_fin, string id)
        {
            unModele.insertConge(date_debut, date_fin, id);
        }

        public void updateConge(string id, string approuve)
        {
            unModele.updateConge(id, approuve);
        }

        public List<Conge> selectWhereConge(string id)
        {
            return unModele.selectWhereConge(id);
        }

        public Document selectWhereDocument(int idmemoire)
        {
            return unModele.selectWhereDocument(idmemoire);
        }
    }
}
