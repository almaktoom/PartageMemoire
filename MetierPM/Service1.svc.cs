using MetierPM.Contract;
using MetierPM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Entity;


namespace MetierPM
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        private readonly BdMemoireContext _context;

        public Service1()
        {
            _context = new BdMemoireContext(); // Ou une autre logique d'initialisation
        } 

        public Service1(BdMemoireContext context)
        {
            _context = context;
        }

        public bool ValidatePersonne(string email, string password)
        {
            // Rechercher la personne par email
            var personne = _context.Personnes.FirstOrDefault(p => p.Email == email);

            // Vérifier si la personne existe et comparer le mot de passe
            if (personne != null)
            {
                // Comparer le hachage du mot de passe
                return personne.Password == PasswordHelper.HashPassword(password);
            }

            return false;
        }

        public void UpdatePersonne(Personne personne)
        {
            _context.Personnes.Attach(personne);
            _context.Entry(personne).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateEtudiant(Etudiant etudiant)
        {
            _context.Etudiants.Attach(etudiant);
            _context.Entry(etudiant).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateProfesseur(Professeur professeur)
        {
            _context.Professeurs.Attach(professeur);
            _context.Entry(professeur).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Méthodes pour Personne
        public void RegisterPersonne(Personne newPersonne)
        {
            newPersonne.Password = PasswordHelper.HashPassword(newPersonne.Password);
            _context.Personnes.Add(newPersonne);
            _context.SaveChanges();
        }
        public void AddPersonne(Personne personne)
        {
            _context.Personnes.Add(personne);
            _context.SaveChanges();
        }

        public Personne GetPersonneById(int id)
        {
            return _context.Personnes.Find(id);
        }

        public IEnumerable<Personne> GetAllPersonnes()
        {
            return _context.Personnes.ToList();
        }

        //public void UpdatePersonne(Personne personne)
        //{
        //    _context.Personnes.Update(personne);
        //    _context.SaveChanges();
        //}

        public void DeletePersonne(int id)
        {
            var personne = GetPersonneById(id);
            if (personne != null)
            {
                _context.Personnes.Remove(personne);
                _context.SaveChanges();
            }
        }

        // Implémentation des méthodes pour Etudiant
        public void AddEtudiant(Etudiant etudiant)
        {
            _context.Etudiants.Add(etudiant);
            _context.SaveChanges();
        }

        public Etudiant GetEtudiantById(int id)
        {
            return _context.Etudiants.Find(id);
        }

        public IEnumerable<Etudiant> GetAllEtudiants()
        {
            return _context.Etudiants.ToList();
        }

        //public void UpdateEtudiant(Etudiant etudiant)
        //{
        //    _context.Etudiants.Update(etudiant);
        //    _context.SaveChanges();
        //}

        public void DeleteEtudiant(int id)
        {
            var etudiant = GetEtudiantById(id);
            if (etudiant != null)
            {
                _context.Etudiants.Remove(etudiant);
                _context.SaveChanges();
            }
        }

        // Implémentation des méthodes pour Professeur
       

        public void AddProfesseur(Professeur professeur)
        {
            _context.Professeurs.Add(professeur);
            _context.SaveChanges();
        }

        public Professeur GetProfesseurById(int id)
        {
            return _context.Professeurs.Find(id);
        }

        public IEnumerable<Professeur> GetAllProfesseurs()
        {
            return _context.Professeurs.ToList();
        }

        //public void UpdateProfesseur(Professeur professeur)
        //{
        //    _context.Professeurs.Update(professeur);
        //    _context.SaveChanges();
        //}

        public void DeleteProfesseur(int id)
        {
            var professeur = GetProfesseurById(id);
            if (professeur != null)
            {
                _context.Professeurs.Remove(professeur);
                _context.SaveChanges();
            }
        }

        //
        public void AddCommentaire(Commentaire commentaire)
        {
            _context.Commentaires.Add(commentaire);
            _context.SaveChanges();
        }

        public Commentaire GetCommentaireById(int id)
        {
            return _context.Commentaires.Find(id);
        }

        public IEnumerable<Commentaire> GetAllCommentaires()
        {
            return _context.Commentaires.ToList();
        }

        public void UpdateCommentaire(Commentaire commentaire)
        {
            _context.Commentaires.Attach(commentaire);
            _context.Entry(commentaire).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCommentaire(int id)
        {
            var commentaire = GetCommentaireById(id);
            if (commentaire != null)
            {
                _context.Commentaires.Remove(commentaire);
                _context.SaveChanges();
            }
        }

        //
        public void AddDepartement(Departement departement)
        {
            _context.Departements.Add(departement);
            _context.SaveChanges();
        }

        public Departement GetDepartementById(int id)
        {
            return _context.Departements.Find(id);
        }

        public IEnumerable<Departement> GetAllDepartements()
        {
            return _context.Departements.ToList();
        }

        public void UpdateDepartement(Departement departement)
        {
            _context.Departements.Attach(departement);
            _context.Entry(departement).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteDepartement(int id)
        {
            var departement = GetDepartementById(id);
            if (departement != null)
            {
                _context.Departements.Remove(departement);
                _context.SaveChanges();
            }
        }

        //
        public void AddFiliere(Filiere filiere)
        {
            _context.Filieres.Add(filiere);
            _context.SaveChanges();
        }

        public Filiere GetFiliereById(int id)
        {
            return _context.Filieres.Find(id);
        }

        public IEnumerable<Filiere> GetAllFilieres()
        {
            return _context.Filieres.ToList();
        }

        public void UpdateFiliere(Filiere filiere)
        {
            _context.Filieres.Attach(filiere);
            _context.Entry(filiere).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteFiliere(int id)
        {
            var filiere = GetFiliereById(id);
            if (filiere != null)
            {
                _context.Filieres.Remove(filiere);
                _context.SaveChanges();
            }
        }

        //
        public void AddMemoire(Memoire memoire)
        {
            _context.Memoires.Add(memoire);
            _context.SaveChanges();
        }

        public Memoire GetMemoireById(int id)
        {
            return _context.Memoires.Find(id);
        }

        public IEnumerable<Memoire> GetAllMemoires()
        {
            return _context.Memoires.ToList();
        }

        public void UpdateMemoire(Memoire memoire)
        {
            _context.Memoires.Attach(memoire);
            _context.Entry(memoire).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMemoire(int id)
        {
            var memoire = GetMemoireById(id);
            if (memoire != null)
            {
                _context.Memoires.Remove(memoire);
                _context.SaveChanges();
            }
        }

        //
        // Jury
        public void AddJury(Jury jury)
        {
            _context.Juries.Add(jury);
            _context.SaveChanges();
        }

        public Jury GetJuryById(int id)
        {
            return _context.Juries.Find(id);
        }

        public IEnumerable<Jury> GetAllJuries()
        {
            return _context.Juries.ToList();
        }

        public void UpdateJury(Jury jury)
        {
            _context.Juries.Attach(jury);
            _context.Entry(jury).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteJury(int id)
        {
            var jury = GetJuryById(id);
            if (jury != null)
            {
                _context.Juries.Remove(jury);
                _context.SaveChanges();
            }
        }

        // Implémentation des méthodes pour Token
        public void AddToken(Token token)
        {
            _context.Tokens.Add(token);
            _context.SaveChanges();
        }

        public Token GetTokenById(int id)
        {
            return _context.Tokens.Find(id);
        }

        public IEnumerable<Token> GetAllTokens()
        {
            return _context.Tokens.ToList();
        }

        public void UpdateToken(Token token)
        {
            _context.Tokens.Attach(token);
            _context.Entry(token).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteToken(int id)
        {
            var token = GetTokenById(id);
            if (token != null)
            {
                _context.Tokens.Remove(token);
                _context.SaveChanges();
            }
        }

        // Implémentation des méthodes pour JwtSettings
        public void AddJwtSettings(JwtSettings jwtSettings)
        {
            _context.JwtSettings.Add(jwtSettings);
            _context.SaveChanges();
        }

        public JwtSettings GetJwtSettingsById(int id)
        {
            return _context.JwtSettings.Find(id);
        }

        public IEnumerable<JwtSettings> GetAllJwtSettings()
        {
            return _context.JwtSettings.ToList();
        }

        public void UpdateJwtSettings(JwtSettings jwtSettings)
        {
            _context.JwtSettings.Attach(jwtSettings);
            _context.Entry(jwtSettings).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteJwtSettings(int id)
        {
            var jwtSettings = GetJwtSettingsById(id);
            if (jwtSettings != null)
            {
                _context.JwtSettings.Remove(jwtSettings);
                _context.SaveChanges();
            }
        }
    }
}
