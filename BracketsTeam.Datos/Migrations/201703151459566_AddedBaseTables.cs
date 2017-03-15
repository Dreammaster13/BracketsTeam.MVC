namespace BracketsTeam.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBaseTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        IdGame = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.IdGame);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        IdMatch = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.IdMatch);
            
            CreateTable(
                "dbo.Match_Player",
                c => new
                    {
                        IdMatch_Player = c.Int(nullable: false, identity: true),
                        Match_IdMatch = c.Int(),
                        Player_IdPlayer = c.Int(),
                        Team_Tournament_IdTeam_Tournament = c.Int(),
                    })
                .PrimaryKey(t => t.IdMatch_Player)
                .ForeignKey("dbo.Matches", t => t.Match_IdMatch)
                .ForeignKey("dbo.Players", t => t.Player_IdPlayer)
                .ForeignKey("dbo.Team_Tournament", t => t.Team_Tournament_IdTeam_Tournament)
                .Index(t => t.Match_IdMatch)
                .Index(t => t.Player_IdPlayer)
                .Index(t => t.Team_Tournament_IdTeam_Tournament);
            
            CreateTable(
                "dbo.Team_Tournament",
                c => new
                    {
                        IdTeam_Tournament = c.Int(nullable: false, identity: true),
                        Team_IdTeam = c.Int(),
                        Tournament_IdTournament = c.Int(),
                    })
                .PrimaryKey(t => t.IdTeam_Tournament)
                .ForeignKey("dbo.Teams", t => t.Team_IdTeam)
                .ForeignKey("dbo.Tournaments", t => t.Tournament_IdTournament)
                .Index(t => t.Team_IdTeam)
                .Index(t => t.Tournament_IdTournament);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        IdTournament = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.IdTournament);
            
            CreateTable(
                "dbo.Prizes",
                c => new
                    {
                        IdPrize = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.IdPrize);
            
            CreateTable(
                "dbo.Team_Player",
                c => new
                    {
                        IdTeam_Player = c.Int(nullable: false, identity: true),
                        Player_IdPlayer = c.Int(),
                        Team_IdTeam = c.Int(),
                    })
                .PrimaryKey(t => t.IdTeam_Player)
                .ForeignKey("dbo.Players", t => t.Player_IdPlayer)
                .ForeignKey("dbo.Teams", t => t.Team_IdTeam)
                .Index(t => t.Player_IdPlayer)
                .Index(t => t.Team_IdTeam);
            
            AddColumn("dbo.Teams", "Game_IdGame", c => c.Int());
            AlterColumn("dbo.Players", "FullName", c => c.String());
            AlterColumn("dbo.Players", "NickName", c => c.String());
            AlterColumn("dbo.Teams", "Name", c => c.String());
            CreateIndex("dbo.Teams", "Game_IdGame");
            AddForeignKey("dbo.Teams", "Game_IdGame", "dbo.Games", "IdGame");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Team_Player", "Team_IdTeam", "dbo.Teams");
            DropForeignKey("dbo.Team_Player", "Player_IdPlayer", "dbo.Players");
            DropForeignKey("dbo.Match_Player", "Team_Tournament_IdTeam_Tournament", "dbo.Team_Tournament");
            DropForeignKey("dbo.Team_Tournament", "Tournament_IdTournament", "dbo.Tournaments");
            DropForeignKey("dbo.Team_Tournament", "Team_IdTeam", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Game_IdGame", "dbo.Games");
            DropForeignKey("dbo.Match_Player", "Player_IdPlayer", "dbo.Players");
            DropForeignKey("dbo.Match_Player", "Match_IdMatch", "dbo.Matches");
            DropIndex("dbo.Team_Player", new[] { "Team_IdTeam" });
            DropIndex("dbo.Team_Player", new[] { "Player_IdPlayer" });
            DropIndex("dbo.Teams", new[] { "Game_IdGame" });
            DropIndex("dbo.Team_Tournament", new[] { "Tournament_IdTournament" });
            DropIndex("dbo.Team_Tournament", new[] { "Team_IdTeam" });
            DropIndex("dbo.Match_Player", new[] { "Team_Tournament_IdTeam_Tournament" });
            DropIndex("dbo.Match_Player", new[] { "Player_IdPlayer" });
            DropIndex("dbo.Match_Player", new[] { "Match_IdMatch" });
            AlterColumn("dbo.Teams", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Players", "NickName", c => c.String(nullable: false));
            AlterColumn("dbo.Players", "FullName", c => c.String(nullable: false));
            DropColumn("dbo.Teams", "Game_IdGame");
            DropTable("dbo.Team_Player");
            DropTable("dbo.Prizes");
            DropTable("dbo.Tournaments");
            DropTable("dbo.Team_Tournament");
            DropTable("dbo.Match_Player");
            DropTable("dbo.Matches");
            DropTable("dbo.Games");
        }
    }
}
