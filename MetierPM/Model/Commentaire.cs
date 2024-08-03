using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetierPM.Model
{
    [DataContract]
    public class Commentaire
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Le contenu du commentaire est requis.")]
        [StringLength(500)]
        public string Contenu { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public bool EstRepondu { get; set; } // Indique si le commentaire a été répondu

        [DataMember]
        public Professeur ExpertReponse { get; set; } // L'expert qui a répondu, si applicable

        [DataMember]
        public Etudiant Etudiant { get; set; } // L'étudiant qui a fait le commentaire

        [DataMember]
        public string Reponse { get; set; } // Réponse à fournir par l'expert


        public Commentaire(string contenu, Etudiant etudiant)
        {
            Contenu = contenu;
            Etudiant = etudiant;
            Date = DateTime.Now;
            EstRepondu = false;
            Reponse = string.Empty; // Initialiser la réponse
        }
    }
}