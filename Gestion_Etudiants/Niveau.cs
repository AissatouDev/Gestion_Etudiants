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

      

        public Niveau(string libelle, Faculte faculte, List<Cours> courses) 
        { 
            Libelle = libelle;
            Faculte = faculte;
            Courses = courses;
        }
    }
}
