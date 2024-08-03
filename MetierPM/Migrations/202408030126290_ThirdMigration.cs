namespace MetierPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JwtSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SecretKey = c.String(unicode: false),
                        Issuer = c.String(unicode: false),
                        Audience = c.String(unicode: false),
                        AccessTokenExpirationMinutes = c.Int(nullable: false),
                        RefreshTokenExpirationDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccessToken = c.String(unicode: false),
                        RefreshToken = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tokens");
            DropTable("dbo.JwtSettings");
        }
    }
}
