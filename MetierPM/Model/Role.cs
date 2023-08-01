using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetierPM.Model
{
    [DataContract]
    public enum Role
    {
        Etudiant,
        Professeur,
        Bibliothecaire,
        Administrateur
    }
}