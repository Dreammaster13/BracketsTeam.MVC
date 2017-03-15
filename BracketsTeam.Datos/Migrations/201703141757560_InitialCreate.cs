namespace BracketsTeam.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        IdPlayer = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        NickName = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdPlayer);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        IdTeam = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdTeam);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teams");
            DropTable("dbo.Players");
        }
    }
}
