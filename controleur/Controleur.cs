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

        public void deleteMemoire(int idmemoire)
        {
            unModele.deleteMemoire(idmemoire);
        }
        public void updateMemoire(Document unDocument)
        {
            unModele.updateMemoire(unDocument);
        }

        public Document selectWhereDocument(int idmemoire)
        {
            return unModele.selectWhereDocument(idmemoire);
        }

        public User selectWhereUser(User unUser)
        {
            return unModele.selectWhereUser(unUser);
        }
    }
}
