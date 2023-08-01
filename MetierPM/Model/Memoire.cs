using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetierPM.Model
{
    [DataContract]
    public class Memoire
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre du mémoire est requis.")]
        [StringLength(200, ErrorMessage = "Le titre ne peut pas dépasser 200 caractères.")]
        [DataMember]
        public string Titre { get; set; }

        [Required(ErrorMessage = "Le résumé est requis.")]
        [DataMember]
        public string Resume { get; set; }

        [Required(ErrorMessage = "La date de soutenance est requise.")]
        [DataType(DataType.Date)]
        [DataMember]
        public DateTime DateSoutenance { get; set; }

        [Required(ErrorMessage = "L'identifiant de l'étudiant est requis.")]
        [DataMember]
        public int IdEtudiant { get; set; }

        [DataMember]
        public Etudiant Etudiant { get; set; }

        [Required(ErrorMessage = "L'encadrant est requis.")]
        [DataMember]
        public int IdProfesseur { get; set; }

        [DataMember]
        public Professeur Encadrant { get; set; }

        public Memoire(int id, string titre, string resume, DateTime dateSoutenance, int idEtudiant, Etudiant etudiant, int idProfesseur, Professeur encadrant)
        {
            Id = id;
            Titre = titre;
            Resume = resume;
            DateSoutenance = dateSoutenance;
            IdEtudiant = idEtudiant;
            Etudiant = etudiant;
            IdProfesseur = idProfesseur;
            Encadrant = encadrant;
        }

        public Memoire() { } // Constructeur par défaut pour la sérialisation
    }
}