using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetierPM.Model
{
    [DataContract]
    public class Professeur : Personne
    {
        [DataMember]
        [Required(ErrorMessage = "La spécialité est requise.")]
        [StringLength(100, ErrorMessage = "La spécialité ne peut pas dépasser 100 caractères.")]
        public string Specialite { get; set; }

        [DataMember]
        [StringLength(250, ErrorMessage = "Les autres informations ne peuvent pas dépasser 250 caractères.")]
        public string AutresInformations { get; set; }


        public Professeur(int id, string nom, string prenom, string email, string specialite, string autresInformations)
            : base(id, nom, prenom, email, DateTime.Now, null)
        {
            Specialite = specialite;
            AutresInformations = autresInformations;
        }

        public void Repondre(Commentaire commentaire, string reponse)
        {
            if (commentaire.EstRepondu)
            {
                Console.WriteLine("Ce commentaire a déjà reçu une réponse. Les autres experts ne peuvent plus répondre.");
                return;
            }

            commentaire.ExpertReponse = this;
            commentaire.EstRepondu = true;

            Console.WriteLine($"Expert {Nom} ({Specialite}) a répondu au commentaire de {commentaire.Etudiant.Nom}: {reponse}");
        }

        public Professeur()
        {

        }
    }
}