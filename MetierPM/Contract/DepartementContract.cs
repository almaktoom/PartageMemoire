using MetierPM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetierPM.Contract
{
    
    [DataContract]
    public class DepartementContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nom { get; set; }

        // FiliereContract can be nested here if needed for full representation
    }

}