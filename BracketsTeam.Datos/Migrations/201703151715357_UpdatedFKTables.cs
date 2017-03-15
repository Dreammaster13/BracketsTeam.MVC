namespace BracketsTeam.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedFKTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Match_Player", "Match_IdMatch", "dbo.Matches");
            DropForeignKey("dbo.Match_Player", "Player_IdPlayer", "dbo.Players");
            DropForeignKey("dbo.Match_Player", "Team_Tournament_IdTeam_Tournament", "dbo.Team_Tournament");
            DropForeignKey("dbo.Team_Tournament", "Team_IdTeam", "dbo.Teams");
            DropForeignKey("dbo.Team_Tournament", "Tournament_IdTournament", "dbo.Tournaments");
            DropForeignKey("dbo.Teams", "Game_IdGame", "dbo.Games");
            DropForeignKey("dbo.Team_Player", "Player_IdPlayer", "dbo.Players");
            DropForeignKey("dbo.Team_Player", "Team_IdTeam", "dbo.Teams");
            DropIndex("dbo.Match_Player", new[] { "Match_IdMatch" });
            DropIndex("dbo.Match_Player", new[] { "Player_IdPlayer" });
            DropIndex("dbo.Match_Player", new[] { "Team_Tournament_IdTeam_Tournament" });
            DropIndex("dbo.Team_Tournament", new[] { "Team_IdTeam" });
            DropIndex("dbo.Team_Tournament", new[] { "Tournament_IdTournament" });
            DropIndex("dbo.Teams", new[] { "Game_IdGame" });
            DropIndex("dbo.Team_Player", new[] { "Player_IdPlayer" });
            DropIndex("dbo.Team_Player", new[] { "Team_IdTeam" });
            RenameColumn(table: "dbo.Match_Player", name: "Match_IdMatch", newName: "IdMatch");
            RenameColumn(table: "dbo.Match_Player", name: "Player_IdPlayer", newName: "IdPlayer");
            RenameColumn(table: "dbo.Match_Player", name: "Team_Tournament_IdTeam_Tournament", newName: "IdTeam_Tournament");
            RenameColumn(table: "dbo.Team_Tournament", name: "Team_IdTeam", newName: "IdTeam");
            RenameColumn(table: "dbo.Team_Tournament", name: "Tournament_IdTournament", newName: "IdTournament");
            RenameColumn(table: "dbo.Teams", name: "Game_IdGame", newName: "IdGame");
            RenameColumn(table: "dbo.Team_Player", name: "Player_IdPlayer", newName: "IdPlayer");
            RenameColumn(table: "dbo.Team_Player", name: "Team_IdTeam", newName: "IdTeam");
            AlterColumn("dbo.Match_Player", "IdMatch", c => c.Int(nullable: false));
            AlterColumn("dbo.Match_Player", "IdPlayer", c => c.Int(nullable: false));
            AlterColumn("dbo.Match_Player", "IdTeam_Tournament", c => c.Int(nullable: false));
            AlterColumn("dbo.Team_Tournament", "IdTeam", c => c.Int(nullable: false));
            AlterColumn("dbo.Team_Tournament", "IdTournament", c => c.Int(nullable: false));
            AlterColumn("dbo.Teams", "IdGame", c => c.Int(nullable: false));
            AlterColumn("dbo.Team_Player", "IdPlayer", c => c.Int(nullable: false));
            AlterColumn("dbo.Team_Player", "IdTeam", c => c.Int(nullable: false));
            CreateIndex("dbo.Match_Player", "IdPlayer");
            CreateIndex("dbo.Match_Player", "IdMatch");
            CreateIndex("dbo.Match_Player", "IdTeam_Tournament");
            CreateIndex("dbo.Team_Tournament", "IdTeam");
            CreateIndex("dbo.Team_Tournament", "IdTournament");
            CreateIndex("dbo.Teams", "IdGame");
            CreateIndex("dbo.Team_Player", "IdTeam");
            CreateIndex("dbo.Team_Player", "IdPlayer");
            AddForeignKey("dbo.Match_Player", "IdMatch", "dbo.Matches", "IdMatch", cascadeDelete: true);
            AddForeignKey("dbo.Match_Player", "IdPlayer", "dbo.Players", "IdPlayer", cascadeDelete: true);
            AddForeignKey("dbo.Match_Player", "IdTeam_Tournament", "dbo.Team_Tournament", "IdTeam_Tournament", cascadeDelete: true);
            AddForeignKey("dbo.Team_Tournament", "IdTeam", "dbo.Teams", "IdTeam", cascadeDelete: true);
            AddForeignKey("dbo.Team_Tournament", "IdTournament", "dbo.Tournaments", "IdTournament", cascadeDelete: true);
            AddForeignKey("dbo.Teams", "IdGame", "dbo.Games", "IdGame", cascadeDelete: true);
            AddForeignKey("dbo.Team_Player", "IdPlayer", "dbo.Players", "IdPlayer", cascadeDelete: true);
            AddForeignKey("dbo.Team_Player", "IdTeam", "dbo.Teams", "IdTeam", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Team_Player", "IdTeam", "dbo.Teams");
            DropForeignKey("dbo.Team_Player", "IdPlayer", "dbo.Players");
            DropForeignKey("dbo.Teams", "IdGame", "dbo.Games");
            DropForeignKey("dbo.Team_Tournament", "IdTournament", "dbo.Tournaments");
            DropForeignKey("dbo.Team_Tournament", "IdTeam", "dbo.Teams");
            DropForeignKey("dbo.Match_Player", "IdTeam_Tournament", "dbo.Team_Tournament");
            DropForeignKey("dbo.Match_Player", "IdPlayer", "dbo.Players");
            DropForeignKey("dbo.Match_Player", "IdMatch", "dbo.Matches");
            DropIndex("dbo.Team_Player", new[] { "IdPlayer" });
            DropIndex("dbo.Team_Player", new[] { "IdTeam" });
            DropIndex("dbo.Teams", new[] { "IdGame" });
            DropIndex("dbo.Team_Tournament", new[] { "IdTournament" });
            DropIndex("dbo.Team_Tournament", new[] { "IdTeam" });
            DropIndex("dbo.Match_Player", new[] { "IdTeam_Tournament" });
            DropIndex("dbo.Match_Player", new[] { "IdMatch" });
            DropIndex("dbo.Match_Player", new[] { "IdPlayer" });
            AlterColumn("dbo.Team_Player", "IdTeam", c => c.Int());
            AlterColumn("dbo.Team_Player", "IdPlayer", c => c.Int());
            AlterColumn("dbo.Teams", "IdGame", c => c.Int());
            AlterColumn("dbo.Team_Tournament", "IdTournament", c => c.Int());
            AlterColumn("dbo.Team_Tournament", "IdTeam", c => c.Int());
            AlterColumn("dbo.Match_Player", "IdTeam_Tournament", c => c.Int());
            AlterColumn("dbo.Match_Player", "IdPlayer", c => c.Int());
            AlterColumn("dbo.Match_Player", "IdMatch", c => c.Int());
            RenameColumn(table: "dbo.Team_Player", name: "IdTeam", newName: "Team_IdTeam");
            RenameColumn(table: "dbo.Team_Player", name: "IdPlayer", newName: "Player_IdPlayer");
            RenameColumn(table: "dbo.Teams", name: "IdGame", newName: "Game_IdGame");
            RenameColumn(table: "dbo.Team_Tournament", name: "IdTournament", newName: "Tournament_IdTournament");
            RenameColumn(table: "dbo.Team_Tournament", name: "IdTeam", newName: "Team_IdTeam");
            RenameColumn(table: "dbo.Match_Player", name: "IdTeam_Tournament", newName: "Team_Tournament_IdTeam_Tournament");
            RenameColumn(table: "dbo.Match_Player", name: "IdPlayer", newName: "Player_IdPlayer");
            RenameColumn(table: "dbo.Match_Player", name: "IdMatch", newName: "Match_IdMatch");
            CreateIndex("dbo.Team_Player", "Team_IdTeam");
            CreateIndex("dbo.Team_Player", "Player_IdPlayer");
            CreateIndex("dbo.Teams", "Game_IdGame");
            CreateIndex("dbo.Team_Tournament", "Tournament_IdTournament");
            CreateIndex("dbo.Team_Tournament", "Team_IdTeam");
            CreateIndex("dbo.Match_Player", "Team_Tournament_IdTeam_Tournament");
            CreateIndex("dbo.Match_Player", "Player_IdPlayer");
            CreateIndex("dbo.Match_Player", "Match_IdMatch");
            AddForeignKey("dbo.Team_Player", "Team_IdTeam", "dbo.Teams", "IdTeam");
            AddForeignKey("dbo.Team_Player", "Player_IdPlayer", "dbo.Players", "IdPlayer");
            AddForeignKey("dbo.Teams", "Game_IdGame", "dbo.Games", "IdGame");
            AddForeignKey("dbo.Team_Tournament", "Tournament_IdTournament", "dbo.Tournaments", "IdTournament");
            AddForeignKey("dbo.Team_Tournament", "Team_IdTeam", "dbo.Teams", "IdTeam");
            AddForeignKey("dbo.Match_Player", "Team_Tournament_IdTeam_Tournament", "dbo.Team_Tournament", "IdTeam_Tournament");
            AddForeignKey("dbo.Match_Player", "Player_IdPlayer", "dbo.Players", "IdPlayer");
            AddForeignKey("dbo.Match_Player", "Match_IdMatch", "dbo.Matches", "IdMatch");
        }
    }
}
