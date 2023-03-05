using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiants
{
    public class Niveau
    {
        public string Libelle { get; set; }
        public Faculte Faculte { get; set; }
        public List<Cours> Courses { get; set; }

        public List<Etudiant> etudiants;
      

        public Niveau(string libelle, Faculte faculte, List<Cours> courses) 
        { 
            Libelle = libelle;
            Faculte = faculte;
            Courses = courses;
        }

        public void ListerCours()
        {
            Console.WriteLine("Les cours suivis en {0} sont:", Libelle);
            foreach (var cour in Courses)
            {
                Console.WriteLine(cour.Libelle);
            }

        }

        public void GetFaculte()
        {
            Console.WriteLine("Faculté: {0}", Faculte.Libelle);
        }


        public void ListerEtudiants()
        {
            Console.WriteLine($"Liste des étudiants inscrits en {Libelle} :");
            foreach (Etudiant etudiant in etudiants)
            {
                Console.WriteLine($"- {etudiant.Prenom} {etudiant.Nom}");
            }
        }
    }
}
