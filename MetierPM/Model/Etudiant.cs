using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetierPM.Model
{
    [DataContract]
    public class Etudiant : Personne
    {
        [DataMember]
        [Required(ErrorMessage = "L'identifiant de la filière est requis.")]
        public int IdFiliere { get; set; }

        [DataMember]
        public Filiere Filiere { get; set; }

        [DataMember]
        [Required(ErrorMessage = "La date de naissance est requise.")]
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }


        public Etudiant(int id, string nom, string prenom, string email, DateTime dateCreation, DateTime? dateModification, int idFiliere, Filiere filiere, DateTime dateNaissance)
            : base(id, nom, prenom, email, dateCreation, dateModification)
        {
            IdFiliere = idFiliere;
            Filiere = filiere;
            DateNaissance = dateNaissance;
        }

        public Etudiant()
        {
            
        }

        // Propriété calculée pour l'âge
        //public int Age => DateTime.Now.Year - DateNaissance.Year - (DateTime.Now.DayOfYear < DateNaissance.DayOfYear ? 1 : 0);
    }
}