using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetierPM.Model
{

    [DataContract]
    public class Personne 
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string Nom { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Le prénom est requis.")]
        [StringLength(100, ErrorMessage = "Le prénom ne peut pas dépasser 100 caractères.")]
        public string Prenom { get; set; }

        [DataMember]
        [Required(ErrorMessage = "L'email est requis.")]
        [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }
 
        [DataMember]
        [DataType(DataType.Date)]
        public DateTime DateCreation { get; set; } = DateTime.Now;

        [DataMember]
        [DataType(DataType.Date)]
        public DateTime? DateModification { get; set; } = null;

      
        // Constructeur sans paramètres
        public Personne() { }

        // Constructeur avec paramètres
        public Personne(int id, string nom, string prenom, string email, DateTime dateCreation, DateTime? dateModification)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            DateCreation = dateCreation;
            DateModification = dateModification;
            
        }
    }
}