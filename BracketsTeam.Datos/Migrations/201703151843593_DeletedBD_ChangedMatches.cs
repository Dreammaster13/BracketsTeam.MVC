namespace BracketsTeam.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedBD_ChangedMatches : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "IdTeamOne", c => c.Int(nullable: false));
            AddColumn("dbo.Matches", "IdTeamTwo", c => c.Int(nullable: false));
            AddColumn("dbo.Matches", "IdTeamWinner", c => c.Int(nullable: false));
            AddColumn("dbo.Matches", "DatePlayed", c => c.DateTime(nullable: false));
            AddColumn("dbo.Matches", "MatchCode", c => c.String());
            AddColumn("dbo.Matches", "Observation", c => c.String());
            CreateIndex("dbo.Matches", "IdTeamOne");
            CreateIndex("dbo.Matches", "IdTeamTwo");
            CreateIndex("dbo.Matches", "IdTeamWinner");
            AddForeignKey("dbo.Matches", "IdTeamOne", "dbo.Teams", "IdTeam");
            AddForeignKey("dbo.Matches", "IdTeamTwo", "dbo.Teams", "IdTeam");
            AddForeignKey("dbo.Matches", "IdTeamWinner", "dbo.Teams", "IdTeam");
            DropColumn("dbo.Matches", "MatchTestName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matches", "MatchTestName", c => c.String());
            DropForeignKey("dbo.Matches", "IdTeamWinner", "dbo.Teams");
            DropForeignKey("dbo.Matches", "IdTeamTwo", "dbo.Teams");
            DropForeignKey("dbo.Matches", "IdTeamOne", "dbo.Teams");
            DropIndex("dbo.Matches", new[] { "IdTeamWinner" });
            DropIndex("dbo.Matches", new[] { "IdTeamTwo" });
            DropIndex("dbo.Matches", new[] { "IdTeamOne" });
            DropColumn("dbo.Matches", "Observation");
            DropColumn("dbo.Matches", "MatchCode");
            DropColumn("dbo.Matches", "DatePlayed");
            DropColumn("dbo.Matches", "IdTeamWinner");
            DropColumn("dbo.Matches", "IdTeamTwo");
            DropColumn("dbo.Matches", "IdTeamOne");
        }
    }
}
