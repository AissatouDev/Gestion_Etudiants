using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiants
{
    public class Etudiant
    {
        public string Matricule { get; init; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int Age { get; set; }
        public string Adresse { get; init; }
        public string Email { get; init; }
        public string Telephone { get; init; }
        public bool EstBoursier { get; set; }
        public Niveau Niveau { get; set; }

        public Etudiant(string matricule, string prenom, string nom, int age, string adresse, 
            string email, string telephone, bool estBoursier, Niveau niveau) 
        {
            Matricule = matricule;
            Prenom = prenom;
            Nom = nom;
            Age = age;
            Adresse = adresse;
            Email = email;
            Telephone = telephone;
            EstBoursier= estBoursier;
            Niveau= niveau;
        }
        
    }
}
