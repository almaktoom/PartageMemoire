using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetierPM.Contract
{
    [DataContract]
    public class FiliereContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public int DepartementId { get; set; }

        // DepartementContract can be nested here if needed for full representation
    }

    
}