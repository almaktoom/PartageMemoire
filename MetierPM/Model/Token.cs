using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetierPM.Model
{
    [DataContract]
    public class Token
    {

        public Token() { }

        public Token(string token) { }


        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        public string AccessToken { get; set; }

        [DataMember]
        public string RefreshToken { get; set; }
    }
}