using MetierPM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetierPM.Contract
{
    [DataContract]
    public class EtudiantContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public string Prenom { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public DateTime DateCreation { get; set; }

        [DataMember]
        public DateTime? DateModification { get; set; }

        [DataMember]
        public int IdFiliere { get; set; }

        [DataMember]
        public Filiere Filiere { get; set; }

        [DataMember]
        public DateTime DateNaissance { get; set; }
    }

}