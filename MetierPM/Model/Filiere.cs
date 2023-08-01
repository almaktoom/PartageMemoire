using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetierPM.Model
{
    [DataContract]
    public class Filiere
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Le nom de la filière est requis.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string Nom { get; set; }

        [DataMember]
        [Required(ErrorMessage = "L'identifiant du département est requis.")]
        public int IdDepartement { get; set; }

        [DataMember]
        public Departement Departement { get; set; }

        public Filiere(int id, string nom, int idDepartement)
        {
            Id = id;
            Nom = nom;
            IdDepartement = idDepartement;
        }

        public Filiere()
        {
        }
    }
}