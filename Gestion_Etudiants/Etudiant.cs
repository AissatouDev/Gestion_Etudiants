using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public string Adresse { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool EstBoursier { get; set; }
        public Niveau Niveau { get; set; }


        public Etudiant() { }

        public Etudiant(string prenom, string nom, int age, string adresse, 
            string email, string telephone, bool estBoursier, Niveau niveau) 
        {
            Prenom = prenom;
            Nom = nom;
            Age = age;
            Adresse = adresse;
            Email = email;
            Telephone = telephone;
            EstBoursier= estBoursier;
            Niveau= niveau;
            Matricule = GenererMatricule(Prenom);
        }

        public static string GenererMatricule(string prenom)
        {
            Random rand = new Random();
            string matricule = rand.Next(10000, 99999).ToString() + prenom.Substring(0, 3).ToUpper();
            return matricule;
        }

     
        public void AfficherInfosEtudiant()
        {
            Console.WriteLine("Informations de l'étudiant {0}: ", Prenom);
            Console.WriteLine("Matricule: " + Matricule);
            Console.WriteLine("Prénom: " + Prenom);
            Console.WriteLine("Nom: " + Nom);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Adresse: " + Adresse);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Téléphone: " + Telephone);
            Console.WriteLine("Boursier: " + EstBoursier);
            Console.WriteLine("Grade: " + Niveau.Libelle);
            Console.WriteLine("Faculté: " + Niveau.Faculte.Libelle);

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Prenom + ".txt");

            using (StreamWriter writer = new StreamWriter(path, true, Encoding.UTF8))
            {
                writer.WriteLine("Informations de l'étudiant {0}: ", Prenom);
                writer.WriteLine("Matricule: " + Matricule);
                writer.WriteLine("Prénom: " + Prenom);
                writer.WriteLine("Nom: " + Nom);
                writer.WriteLine("Age: " + Age);
                writer.WriteLine("Adresse: " + Adresse);
                writer.WriteLine("Email: " + Email);
                writer.WriteLine("Téléphone: " + Telephone);
                writer.WriteLine("Boursier: " + EstBoursier);
                writer.WriteLine("Grade: " + Niveau.Libelle);
                writer.WriteLine("Faculté: " + Niveau.Faculte.Libelle);
                writer.WriteLine();
            }

        }

        public static Etudiant RechercherParMatricule(List<Etudiant> etudiants, string matricule)
        {
            foreach (Etudiant etudiant in etudiants)
            {
                if (etudiant.Matricule == matricule)
                {
                    return etudiant;
                }
            }
            return null;
        }

       


        public static void SupprimerEtudiant(List<Etudiant> etudiants)
        {
            Console.WriteLine("Entrez le matricule de l'étudiant à supprimer : ");
            string matricule = Console.ReadLine();

            Etudiant etudiantASupprimer = RechercherParMatricule(etudiants, matricule);

            if (etudiantASupprimer == null)
            {
                Console.WriteLine("Aucun étudiant trouvé avec ce matricule.");
                return;
            }

            etudiants.Remove(etudiantASupprimer);
            Console.WriteLine($"L'étudiant {etudiantASupprimer.Prenom} {etudiantASupprimer.Nom} ({etudiantASupprimer.Matricule}) a été supprimé.");
           
        }



        public static void ModifierEtudiant(List<Etudiant> etudiants)
        {
            Console.WriteLine("Entrez le matricule de l'étudiant à modifier : ");
            string matricule = Console.ReadLine();

            // Recherche de l'étudiant par matricule
            Etudiant etudiantAModifier = RechercherParMatricule(etudiants, matricule);

            // Si l'étudiant n'a pas été trouvé, on affiche un message d'erreur et on quitte la fonction
            if (etudiantAModifier == null)
            {
                Console.WriteLine("Aucun étudiant trouvé avec ce matricule.");
                return;
            }

            // Sinon, on demande les informations à modifier et on les affecte à l'étudiant
            Console.WriteLine($"Modification des informations pour l'étudiant {etudiantAModifier.Prenom} {etudiantAModifier.Nom} ({etudiantAModifier.Matricule}) :");

            Console.WriteLine("Entrez le nouveau prénom (ou appuyez sur Entrée pour ne rien changer) : ");
            string nouveauPrenom = Console.ReadLine();
            if (!string.IsNullOrEmpty(nouveauPrenom))
            {
                etudiantAModifier.Prenom = nouveauPrenom;
            }

            Console.WriteLine("Entrez le nouveau nom (ou appuyez sur Entrée pour ne rien changer) : ");
            string nouveauNom = Console.ReadLine();
            if (!string.IsNullOrEmpty(nouveauNom))
            {
                etudiantAModifier.Nom = nouveauNom;
            }

            Console.WriteLine("Entrez le nouvel âge (ou appuyez sur Entrée pour ne rien changer) : ");
            string nouvelAge = Console.ReadLine();
            if (!string.IsNullOrEmpty(nouvelAge))
            {
                int age;
                if (int.TryParse(nouvelAge, out age))
                {
                    etudiantAModifier.Age = age;
                }
                else
                {
                    Console.WriteLine("Age invalide !");
                }
            }

            Console.WriteLine("Entrez la nouvelle adresse (ou appuyez sur Entrée pour ne rien changer) : ");
            string nouvelleAdresse = Console.ReadLine();
            if (!string.IsNullOrEmpty(nouvelleAdresse))
            {
                etudiantAModifier.Adresse = nouvelleAdresse;
            }

            Console.WriteLine("Entrez la nouvelle adresse email (ou appuyez sur Entrée pour ne rien changer) : ");
            string nouvelleAdresseEmail = Console.ReadLine();
            if (!string.IsNullOrEmpty(nouvelleAdresseEmail))
            {
                etudiantAModifier.Email = nouvelleAdresseEmail;
            }

            Console.WriteLine("Entrez le nouveau numéro de téléphone (ou appuyez sur Entrée pour ne rien changer) : ");
            string nouveauNumeroTelephone = Console.ReadLine();
            if (!string.IsNullOrEmpty(nouveauNumeroTelephone))
            {
                etudiantAModifier.Telephone = nouveauNumeroTelephone;
            }

            etudiants.Add(etudiantAModifier);

            Console.WriteLine("Modification terminée !");
        }


    }
}
