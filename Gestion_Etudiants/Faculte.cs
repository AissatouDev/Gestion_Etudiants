using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiants
{
    public class Faculte
    {
        public string Libelle { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public Faculte(string libelle, string adresse, string telephone, string email) 
        { 
            Libelle = libelle;
            Adresse = adresse;
            Telephone = telephone;
            Email = email;
        }
    }
}
