using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Diagnostics;

namespace Memoire
{

    public class Conge
    {
        private string id_conge, date_debut, date_fin, id_user, days, approuve;
        private string prenom, nom;
        public Conge()
        {
            this.id_conge = "";
            this.date_debut = "";
            this.date_fin = "";
            this.id_user = "";
            this.days = "";
            this.approuve = "";
        }

        public Conge(string date_debut, string date_fin, string id_user, string days, string approuve)
        {
            this.id_conge = "";
            this.date_debut = date_debut;
            this.date_fin = date_fin;
            this.id_user = id_user;
            this.days = days;
            this.approuve = approuve;
        }

        public Conge(string id_conge, string date_debut, string date_fin, string id_user, string days, string approuve)
        {
            this.id_conge = id_conge;
            this.date_debut = date_debut;
            this.date_fin = date_fin;
            this.id_user = id_user;
            this.days = days;
            this.approuve = approuve;
        }

        public Conge(string id_conge, string date_debut, string date_fin, string id_user, string days, string approuve, string prenom, string nom)
        {
            this.id_conge = id_conge;
            this.date_debut = date_debut;
            this.date_fin = date_fin;
            this.id_user = id_user;
            this.days = days;
            this.approuve = approuve;
            this.prenom = prenom;
            this.nom = nom;
        }

        public string congeDate(string date)
        {
            date = date.Substring(0, 10);
            Debug.WriteLine(date);
            DateTime dt = DateTime.ParseExact(date.Substring(0, 10), "yyyy/MM/dd", CultureInfo.InvariantCulture);
            // for both "1/1/2000" or "25/1/2000" formats
            string newString = dt.ToString("MM/dd/yyyy");
            return newString;
        }

        public string IdConge
        {
            get
            {
                return id_conge;
            }
            set
            {
                this.id_conge = value;
            }
        }

        public string Date_debut
        {
            get
            {
                return date_debut;
            }
            set
            {
                this.date_debut= value;
            }
        }

        public string Date_fin
        {
            get
            {
                return date_fin;
            }
            set
            {
                this.date_fin = value;
            }
        }

        public string IdUser
        {
            get
            {
                return id_user;
            }
            set
            {
                this.id_user = value;
            }
        }

        public string Days
        {
            get
            {
                return days;
            }
            set
            {
                this.days = value;
            }
        }

        public string Approuve
        {
            get
            {
                return approuve;
            }
            set
            {
                this.approuve = value;
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

    }
}