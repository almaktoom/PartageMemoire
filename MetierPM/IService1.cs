using MetierPM.Contract;
using MetierPM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MetierPM
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: ajoutez vos opérations de service ici
        [OperationContract]
        bool ValidatePersonne(string email, string password);

        [OperationContract]
        void RegisterPersonne(Personne newPersonne);

        // Opérations pour Etudiant
        [OperationContract]
        void AddEtudiant(Etudiant etudiant);

        [OperationContract]
        Etudiant GetEtudiantById(int id);

        [OperationContract]
        IEnumerable<Etudiant> GetAllEtudiants();

        [OperationContract]
        void UpdateEtudiant(Etudiant etudiant);

        [OperationContract]
        void DeleteEtudiant(int id);

        // Opérations pour Professeur
        [OperationContract]
        void AddProfesseur(Professeur professeur);

        [OperationContract]
        Professeur GetProfesseurById(int id);

        [OperationContract]
        IEnumerable<Professeur> GetAllProfesseurs();

        [OperationContract]
        void UpdateProfesseur(Professeur professeur);

        [OperationContract]
        void DeleteProfesseur(int id);

        // Opérations pour Personne
        [OperationContract]
        void AddPersonne(Personne personne);

        [OperationContract]
        Personne GetPersonneById(int id);

        [OperationContract]
        IEnumerable<Personne> GetAllPersonnes();

        [OperationContract]
        void UpdatePersonne(Personne personne);

        [OperationContract]
        void DeletePersonne(int id);

      
        // Commentaires
        [OperationContract]
        void AddCommentaire(Commentaire commentaire);

        [OperationContract]
        Commentaire GetCommentaireById(int id);

        [OperationContract]
        IEnumerable<Commentaire> GetAllCommentaires();

        [OperationContract]
        void UpdateCommentaire(Commentaire commentaire);

        [OperationContract]
        void DeleteCommentaire(int id);

        // Départements
        [OperationContract]
        void AddDepartement(Departement departement);

        [OperationContract]
        Departement GetDepartementById(int id);

        [OperationContract]
        IEnumerable<Departement> GetAllDepartements();

        [OperationContract]
        void UpdateDepartement(Departement departement);

        [OperationContract]
        void DeleteDepartement(int id);

        // Filières
        [OperationContract]
        void AddFiliere(Filiere filiere);

        [OperationContract]
        Filiere GetFiliereById(int id);

        [OperationContract]
        IEnumerable<Filiere> GetAllFilieres();

        [OperationContract]
        void UpdateFiliere(Filiere filiere);

        [OperationContract]
        void DeleteFiliere(int id);

        // Mémoires
        [OperationContract]
        void AddMemoire(Memoire memoire);

        [OperationContract]
        Memoire GetMemoireById(int id);

        [OperationContract]
        IEnumerable<Memoire> GetAllMemoires();

        [OperationContract]
        void UpdateMemoire(Memoire memoire);

        [OperationContract]
        void DeleteMemoire(int id);

        // Jury
        [OperationContract]
        void AddJury(Jury jury);

        [OperationContract]
        Jury GetJuryById(int id);

        [OperationContract]
        IEnumerable<Jury> GetAllJuries();

        [OperationContract]
        void UpdateJury(Jury jury);

        [OperationContract]
        void DeleteJury(int id);

        // Opérations pour Token
        [OperationContract]
        void AddToken(Token token);

        [OperationContract]
        Token GetTokenById(int id);

        [OperationContract]
        IEnumerable<Token> GetAllTokens();

        [OperationContract]
        void UpdateToken(Token token);

        [OperationContract]
        void DeleteToken(int id);

        // Opérations pour JwtSettings
        [OperationContract]
        void AddJwtSettings(JwtSettings jwtSettings);

        [OperationContract]
        JwtSettings GetJwtSettingsById(int id);

        [OperationContract]
        IEnumerable<JwtSettings> GetAllJwtSettings();

        [OperationContract]
        void UpdateJwtSettings(JwtSettings jwtSettings);

        [OperationContract]
        void DeleteJwtSettings(int id);
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
   
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
