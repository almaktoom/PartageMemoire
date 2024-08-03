namespace MetierPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commentaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Contenu = c.String(nullable: false, maxLength: 500, storeType: "nvarchar"),
                        Date = c.DateTime(nullable: false, precision: 0),
                        EstRepondu = c.Boolean(nullable: false),
                        Reponse = c.String(unicode: false),
                        Etudiant_Id = c.Int(),
                        ExpertReponse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personnes", t => t.Etudiant_Id)
                .ForeignKey("dbo.Personnes", t => t.ExpertReponse_Id)
                .Index(t => t.Etudiant_Id)
                .Index(t => t.ExpertReponse_Id);
            
            CreateTable(
                "dbo.Personnes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Prenom = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Email = c.String(nullable: false, unicode: false),
                        DateCreation = c.DateTime(nullable: false, precision: 0),
                        DateModification = c.DateTime(precision: 0),
                        IdFiliere = c.Int(),
                        DateNaissance = c.DateTime(precision: 0),
                        Specialite = c.String(maxLength: 100, storeType: "nvarchar"),
                        AutresInformations = c.String(maxLength: 250, storeType: "nvarchar"),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Filieres", t => t.IdFiliere, cascadeDelete: true)
                .Index(t => t.IdFiliere);
            
            CreateTable(
                "dbo.Filieres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        IdDepartement = c.Int(nullable: false),
                        Departement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departements", t => t.Departement_Id)
                .Index(t => t.Departement_Id);
            
            CreateTable(
                "dbo.Departements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Juries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Professeur_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personnes", t => t.Professeur_Id, cascadeDelete: true)
                .Index(t => t.Professeur_Id);
            
            CreateTable(
                "dbo.Memoires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Resume = c.String(nullable: false, unicode: false),
                        DateSoutenance = c.DateTime(nullable: false, precision: 0),
                        IdEtudiant = c.Int(nullable: false),
                        IdProfesseur = c.Int(nullable: false),
                        Jury_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personnes", t => t.IdProfesseur, cascadeDelete: true)
                .ForeignKey("dbo.Personnes", t => t.IdEtudiant, cascadeDelete: true)
                .ForeignKey("dbo.Juries", t => t.Jury_Id)
                .Index(t => t.IdEtudiant)
                .Index(t => t.IdProfesseur)
                .Index(t => t.Jury_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Juries", "Professeur_Id", "dbo.Personnes");
            DropForeignKey("dbo.Memoires", "Jury_Id", "dbo.Juries");
            DropForeignKey("dbo.Memoires", "IdEtudiant", "dbo.Personnes");
            DropForeignKey("dbo.Memoires", "IdProfesseur", "dbo.Personnes");
            DropForeignKey("dbo.Commentaires", "ExpertReponse_Id", "dbo.Personnes");
            DropForeignKey("dbo.Commentaires", "Etudiant_Id", "dbo.Personnes");
            DropForeignKey("dbo.Personnes", "IdFiliere", "dbo.Filieres");
            DropForeignKey("dbo.Filieres", "Departement_Id", "dbo.Departements");
            DropIndex("dbo.Memoires", new[] { "Jury_Id" });
            DropIndex("dbo.Memoires", new[] { "IdProfesseur" });
            DropIndex("dbo.Memoires", new[] { "IdEtudiant" });
            DropIndex("dbo.Juries", new[] { "Professeur_Id" });
            DropIndex("dbo.Filieres", new[] { "Departement_Id" });
            DropIndex("dbo.Personnes", new[] { "IdFiliere" });
            DropIndex("dbo.Commentaires", new[] { "ExpertReponse_Id" });
            DropIndex("dbo.Commentaires", new[] { "Etudiant_Id" });
            DropTable("dbo.Memoires");
            DropTable("dbo.Juries");
            DropTable("dbo.Departements");
            DropTable("dbo.Filieres");
            DropTable("dbo.Personnes");
            DropTable("dbo.Commentaires");
        }
    }
}
