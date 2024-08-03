using MetierPM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierPM
{
    public interface IBdMemoireContext
    {
        DbSet<Personne> Personnes { get; set; }
        DbSet<Etudiant> Etudiants { get; set; }
        DbSet<Professeur> Professeurs { get; set; }
        DbSet<Jury> Jurys { get; set; }
        DbSet<Departement> Departements { get; set; }
        DbSet<Filiere> Filieres { get; set; }
        DbSet<Memoire> Memoires { get; set; }
        DbSet<Commentaire> Commentaires { get; set; }

        int SaveChanges();
    }
}
