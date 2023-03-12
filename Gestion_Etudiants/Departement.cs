using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiants
{
    public class Departement
    {
        public String Libelle { get; set; }

        public List<Niveau[]> list_niveaux = new List<Niveau[]>();

        public Departement (string departement)
        {
            Libelle = departement;
        }
    }
}
