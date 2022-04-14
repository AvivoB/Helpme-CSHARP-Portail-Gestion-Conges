using System;
namespace Memoire
{
    public class User
    {
        private string iduser, email, mdp, nom, prenom, idstatut, statut;

        public User()
        {
            this.iduser = "";
            this.nom = "";
            this.prenom = "";
            this.email = "";
            this.mdp = "";
            this.idstatut = "";
            this.statut = "";
        }

        public User(string iduser, string nom, string prenom, string email, string mdp, string idstatut, string statut)
        {
            this.iduser = iduser;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.mdp = mdp;
            this.statut = statut;
        }        
        
        public User(string iduser, string nom, string prenom, string email, string mdp)
        {
            this.iduser = iduser;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.mdp = mdp;
        }

        public User( string email, string mdp, string nom, string prenom)
        {
            this.iduser = "";
            this.email = email;
            this.mdp = mdp;
            this.nom = nom;
            this.prenom = prenom;

        }        
        

        public string Iduser
        {
            get
            {
                return iduser;
            }
            set
            {
                this.iduser = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                this.email = value;
            }
        }

        public string Mdp
        {
            get
            {
                return mdp;
            }
            set
            {
                this.mdp = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                this.nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return prenom;
            }
            set
            {
                this.prenom = value;
            }
        }

        public string IdStatut
        {
            get
            {
                return idstatut;
            }
            set
            {
                this.idstatut = value;
            }
        }        
        
        public string Statut
        {
            get
            {
                return statut;
            }
            set
            {
                this.statut = value;
            }
        }
    }
}
