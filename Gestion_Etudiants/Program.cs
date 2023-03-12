using Gestion_Etudiants;
using Newtonsoft.Json;
using System.ComponentModel;

// Création de la faculté

Faculte faculte = new Faculte("School of Engennering and Technology",
    "Campus point E 2e étage", "+221338599595", "set@supdeco.sn");


// Création de Cours

var coursesL1 = new List<Cours>() {
    new Cours("Informatique générale", "INFO", 20, 3, "C'est un cours d'initiation à l'informatique"),
    new Cours("Algorithmique", "ALGO", 50, 5, "C'est un cours d'initiation à l'algorithme"),
    new Cours("Langage C", "LC", 50, 5, "C'est un cours d'initiation à la programmation C"),
};

var coursesL2 = new List<Cours>() {
    new Cours("Base de données", "BD", 30, 3, "C'est un cours d'initiation aux bases de données"),
    new Cours("Modélisation", "MOD", 30, 5, "C'est un cours d'initiation à la conception SI"),
    new Cours("Langage Java", "LJ", 20, 5, "C'est un cours de programmation Java")
};

var coursesL3 = new List<Cours>() {
    new Cours("Réseaux et Systèmes", "RS", 30, 5, "C'est un cours de réseaux"),
    new Cours("Analyse de données", "DATA", 30, 5, "C'est un cours d'initiation à l'analyse de données"),
    new Cours("Sécurité Informatique", "SI", 20, 5, "C'est un cours d'initiation à la sécurité informatique")
};


// Création des Niveaux 

List<Niveau> niveauxProposes = new List<Niveau>()
{
    new Niveau("Licence 1", faculte, coursesL1),
    new Niveau("Licence 2", faculte, coursesL2),
    new Niveau("Licence 3", faculte, coursesL3)
};

var etudiants = new List<Etudiant>();
string etudiantsEnJson;
int numeroEtudiant = 1;

void AfficherListeEtudiants(){

	Console.WriteLine("Liste des étudiants:");
	foreach (var etudiant in etudiants)
	{
		Console.WriteLine($"[{etudiant.Matricule}] {etudiant.Prenom} {etudiant.Nom} inscrit(e) en {etudiant.Niveau.Libelle}");
	}

}

Niveau SelectNiveau(List<Niveau> niveaux)
{
    Console.WriteLine("Liste des niveaux: ");
    for(int i = 0; i < niveaux.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {niveaux[i].Libelle}");
    }
    Console.Write("Choissisez un niveau: ");
    int choix = int.Parse(Console.ReadLine());
    return niveaux[ choix - 1];
}

void EnregistrerEtudiant()
{
    // sérializer la liste des étudiants en format json
    etudiantsEnJson = JsonConvert.SerializeObject(etudiants, Formatting.Indented);

    // Enregistrer les étudiants dans un fichier json
    //File.AppendAllText("etudiants.json", etudiantsEnJson);
    File.WriteAllText("etudiants.json", etudiantsEnJson);
}


// Création Etudiant
Console.WriteLine("Inscription Etudiant");

while (true)
{
    Console.WriteLine("Entrer les informations de l'étudiant {0}:", numeroEtudiant);

    Console.Write("Entrer le prénom: ");
    string prenom = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(prenom))
    {
        Console.Write("Le prénom ne peut pas être vide. Entrer le prénom: ");
        prenom = Console.ReadLine();
    }

    Console.Write("Entrer le nom: ");
    string nom = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(nom))
    {
        Console.Write("Le nom ne peut pas être vide. Entrer le nom: ");
        nom = Console.ReadLine();
    }

    Console.Write("Entrer l'âge: ");
    int age;
    while (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
    {
        Console.Write("L'âge doit être un entier positif. Entrer l'âge: ");
    }

    Console.Write("Entrer l'adresse: ");
    string adresse = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(adresse))
    {
        Console.Write("L'adresse ne peut pas être vide. Entrer l'adresse: ");
        adresse = Console.ReadLine();
    }

    Console.Write("Entrer l'email: ");
    string email = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(email))
    {
        Console.Write("L'email ne peut pas être vide et doit être valide. Entrer l'email: ");
        email = Console.ReadLine();
    }

    Console.Write("Entrer le numéro de téléphone: ");
    string telephone = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(telephone))
    {
        Console.Write("Le numéro de téléphone ne peut pas être vide et doit être valide. Entrer le numéro de téléphone: ");
        telephone = Console.ReadLine();
    }

    Console.Write("L'étudiant est-il boursier ou non? true ou false? ");
    bool estBoursier;
    while (!bool.TryParse(Console.ReadLine(), out estBoursier))
    {
        Console.Write("Entrez 'true' ou 'false'. L'étudiant est-il boursier ou non? ");
    }

    Niveau niveau = SelectNiveau(niveauxProposes);

    Etudiant etudiant = new Etudiant(prenom, nom, age, adresse, email, telephone, estBoursier, niveau);

    // Afficher infos etudiant
    etudiant.AfficherInfosEtudiant();

    // Cours suivis
    niveau.ListerCours();

    etudiants.Add(etudiant);

    numeroEtudiant++;

    // demande à l'utilisateur s'il veut ajouter un autre étudiant
    Console.Write("Ajouter un autre étudiant ? (o/n) : ");
    string reponse = Console.ReadLine();

    if (reponse.ToLower() == "n")
    {
        break;
    }
}


// afficher la liste des étudiants
    AfficherListeEtudiants();

    EnregistrerEtudiant();

//*************************************

bool continuer = true;

while(continuer)
{
    Console.WriteLine("Que voulez-vous faire ?");
    Console.WriteLine("1. Modifier les informations d'un étudiant");
    Console.WriteLine("2. Supprimer un étudiant");
    Console.WriteLine("0. Quitter");

    // Lecture de la réponse de l'utilisateur
    int choix = int.Parse(Console.ReadLine());

    // Traitement de la réponse de l'utilisateur
    switch (choix)
    {
        case 1:
            // Modification des informations d'un étudiant
           Etudiant.ModifierEtudiant(etudiants);
            break;

        case 2:
			// Suppression d'un étudiant
			Etudiant.SupprimerEtudiant(etudiants);
            break;

        case 0: 
            // Quitter le programme
            continuer= false;
            break;

        default:
            Console.WriteLine("Choix invalide.");
            break;
    }
}
AfficherListeEtudiants();



