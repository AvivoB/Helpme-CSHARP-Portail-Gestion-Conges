using System;
namespace Memoire 
{
    public class Document
    {
        private int idmemoire;
        private string intitule;
        private int nbPages;
        private string contexte, nom, prenom, soutenance;

        public Document(int idmemoire, string intitule, int nbPages,
            string contexte, string nom, string prenom, string soutenance)
        {
            this.idmemoire = idmemoire;
            this.intitule = intitule;
            this.nbPages = nbPages;
            this.contexte = contexte;
            this.nom = nom;
            this.prenom = prenom;
            this.soutenance = soutenance; 
        }
        public Document( string intitule, int nbPages,
            string contexte, string nom, string prenom, string soutenance)
        {
            this.idmemoire = 0;
            this.intitule = intitule;
            this.nbPages = nbPages;
            this.contexte = contexte;
            this.nom = nom;
            this.prenom = prenom;
            this.soutenance = soutenance;
        }
        public string Intitule
        {
            get { return intitule; }
            set { this.intitule = value; }
        }
        public string Contexte
        {
            get { return contexte; }
            set { this.contexte = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { this.nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { this.prenom = value; }
        }
        public int NbPages
        {
            get { return nbPages; }
            set { this.nbPages = value; }
        }
        public string Soutenance
        {
            get { return soutenance; }
            set { this.soutenance = value; }
        }
        public int IDmemoire
        {
            get { return idmemoire; }
            set { this.idmemoire = value; }
        }
    }
}
