using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetierPM.Model
{
    [DataContract]
    public class Departement
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Le nom du département est requis.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string Nom { get; set; }

        [DataMember]
        public ICollection<Filiere> Filieres { get; set; } = new List<Filiere>();

        public Departement(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public Departement()
        {
        }
    }
}