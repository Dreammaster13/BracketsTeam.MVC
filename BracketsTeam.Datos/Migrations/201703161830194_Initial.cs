namespace BracketsTeam.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropIndex("brk.Matches", new[] { "IdTeamOne" });
            DropIndex("brk.Matches", new[] { "IdTeamTwo" });
            DropIndex("brk.Matches", new[] { "IdTeamWinner" });
            AlterColumn("brk.Matches", "IdTeamOne", c => c.Int());
            AlterColumn("brk.Matches", "IdTeamTwo", c => c.Int());
            AlterColumn("brk.Matches", "IdTeamWinner", c => c.Int());
            CreateIndex("brk.Matches", "IdTeamOne");
            CreateIndex("brk.Matches", "IdTeamTwo");
            CreateIndex("brk.Matches", "IdTeamWinner");
        }
        
        public override void Down()
        {
            DropIndex("brk.Matches", new[] { "IdTeamWinner" });
            DropIndex("brk.Matches", new[] { "IdTeamTwo" });
            DropIndex("brk.Matches", new[] { "IdTeamOne" });
            AlterColumn("brk.Matches", "IdTeamWinner", c => c.Int(nullable: false));
            AlterColumn("brk.Matches", "IdTeamTwo", c => c.Int(nullable: false));
            AlterColumn("brk.Matches", "IdTeamOne", c => c.Int(nullable: false));
            CreateIndex("brk.Matches", "IdTeamWinner");
            CreateIndex("brk.Matches", "IdTeamTwo");
            CreateIndex("brk.Matches", "IdTeamOne");
        }
    }
}
