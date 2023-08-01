using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetierPM.Model
{
    [DataContract]
    public class Jury
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Le professeur est requis.")]
        public Professeur Professeur { get; set; }

        [DataMember]
        public ICollection<Memoire> Memoires { get; set; } = new List<Memoire>();
    }
}