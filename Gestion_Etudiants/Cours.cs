
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiants
{
    public class Cours
    {
        public string Libelle { get; set; }
        public string Code { get; set; }
        public int VolumeHoraires { get; set; }
        public int Credits { get; set; }
        public string Description { get; set; }

        public Niveau niveau;
       
        public Cours(string libelle, string code, int volumeHoraires, int credits, string description)
        {
            Libelle = libelle;
            Code = code;
            VolumeHoraires = volumeHoraires;
            Credits = credits;
            Description = description;
        }

        public void GetNiveau()
        {
            Console.WriteLine("Niveau: {0}", niveau.Libelle);
        }
    }

   
}
