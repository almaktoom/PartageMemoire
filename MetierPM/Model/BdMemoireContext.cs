using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MetierPM.Model
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdMemoireContext : DbContext
    {
        public BdMemoireContext() : base("name=connDbMemoire1")
        {
        }

        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Professeur> Professeurs { get; set; }
        public DbSet<Jury> Juries { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Filiere> Filieres { get; set; }
        public DbSet<Memoire> Memoires { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<JwtSettings> JwtSettings  { get; set; }


        //public DbSet<Role> Roles { get => roles; set => roles = value; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configurer les relations et les clés primaires si nécessaire
            modelBuilder.Entity<Etudiant>()
                .HasRequired(e => e.Filiere)
                .WithMany()
                .HasForeignKey(e => e.IdFiliere);

            modelBuilder.Entity<Memoire>()
                .HasRequired(m => m.Etudiant)
                .WithMany()
                .HasForeignKey(m => m.IdEtudiant);

            modelBuilder.Entity<Memoire>()
                .HasRequired(m => m.Encadrant)
                .WithMany()
                .HasForeignKey(m => m.IdProfesseur);


            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}