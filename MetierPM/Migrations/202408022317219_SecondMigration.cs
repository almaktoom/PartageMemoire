namespace MetierPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personnes", "Password", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personnes", "Password");
        }
    }
}
