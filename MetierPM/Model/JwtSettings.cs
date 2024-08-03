using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetierPM.Model
{
    [DataContract]
    public class JwtSettings
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        public string SecretKey { get; set; }

        [DataMember]                        
        public string Issuer { get; set; }

        [DataMember]                        
        public string Audience { get; set; }

        [DataMember]                                            
        public int AccessTokenExpirationMinutes { get; set; }

        [DataMember]
        public int RefreshTokenExpirationDays { get; set; }
    }
}