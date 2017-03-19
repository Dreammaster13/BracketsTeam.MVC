namespace BracketsTeam.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "brk.Games",
                c => new
                    {
                        IdGame = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdGame);
            
            CreateTable(
                "brk.Matches",
                c => new
                    {
                        IdMatch = c.Int(nullable: false, identity: true),
                        IdTeamOne = c.Int(),
                        IdTeamTwo = c.Int(),
                        IdTeamWinner = c.Int(),
                        DatePlayed = c.DateTime(nullable: false),
                        MatchCode = c.String(),
                        Observation = c.String(),
                    })
                .PrimaryKey(t => t.IdMatch)
                .ForeignKey("brk.Teams", t => t.IdTeamOne)
                .ForeignKey("brk.Teams", t => t.IdTeamTwo)
                .ForeignKey("brk.Teams", t => t.IdTeamWinner)
                .Index(t => t.IdTeamOne)
                .Index(t => t.IdTeamTwo)
                .Index(t => t.IdTeamWinner);
            
            CreateTable(
                "brk.Teams",
                c => new
                    {
                        IdTeam = c.Int(nullable: false, identity: true),
                        IdGame = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 64),
                        NameShort = c.String(nullable: false, maxLength: 4),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdTeam)
                .ForeignKey("brk.Games", t => t.IdGame, cascadeDelete: true)
                .Index(t => t.IdGame);
            
            CreateTable(
                "brk.Match_Player",
                c => new
                    {
                        IdMatch_Player = c.Int(nullable: false, identity: true),
                        IdPlayer = c.Int(nullable: false),
                        IdMatch = c.Int(nullable: false),
                        IdTeam_Tournament = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdMatch_Player)
                .ForeignKey("brk.Matches", t => t.IdMatch, cascadeDelete: true)
                .ForeignKey("brk.Players", t => t.IdPlayer, cascadeDelete: true)
                .ForeignKey("brk.Team_Tournament", t => t.IdTeam_Tournament, cascadeDelete: true)
                .Index(t => t.IdPlayer)
                .Index(t => t.IdMatch)
                .Index(t => t.IdTeam_Tournament);
            
            CreateTable(
                "brk.Players",
                c => new
                    {
                        IdPlayer = c.Int(nullable: false, identity: true),
                        RUT = c.Int(nullable: false),
                        DV = c.String(nullable: false, maxLength: 1),
                        Name = c.String(nullable: false, maxLength: 32),
                        LastName = c.String(nullable: false, maxLength: 32),
                        UserName = c.String(nullable: false, maxLength: 32),
                        NickName = c.String(nullable: false, maxLength: 32),
                        AltNickName = c.String(maxLength: 32),
                        BirthDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdPlayer)
                .Index(t => t.RUT, unique: true)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "brk.Team_Tournament",
                c => new
                    {
                        IdTeam_Tournament = c.Int(nullable: false, identity: true),
                        IdTeam = c.Int(nullable: false),
                        IdTournament = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTeam_Tournament)
                .ForeignKey("brk.Teams", t => t.IdTeam, cascadeDelete: true)
                .ForeignKey("brk.Tournaments", t => t.IdTournament, cascadeDelete: true)
                .Index(t => t.IdTeam)
                .Index(t => t.IdTournament);
            
            CreateTable(
                "brk.Tournaments",
                c => new
                    {
                        IdTournament = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        MaxPlayers = c.Int(nullable: false),
                        MaxPlayersTeam = c.Int(nullable: false),
                        HasStarted = c.Boolean(nullable: false),
                        HasEnded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdTournament);
            
            CreateTable(
                "brk.Prizes",
                c => new
                    {
                        IdPrize = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        ExchangeRate = c.String(nullable: false, maxLength: 3),
                        Value = c.Decimal(nullable: false, precision: 10, scale: 3),
                    })
                .PrimaryKey(t => t.IdPrize);
            
            CreateTable(
                "brk.Team_Player",
                c => new
                    {
                        IdTeam_Player = c.Int(nullable: false, identity: true),
                        IdTeam = c.Int(nullable: false),
                        IdPlayer = c.Int(nullable: false),
                        IsPlayerMain = c.Boolean(nullable: false),
                        IsPlayerAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdTeam_Player)
                .ForeignKey("brk.Players", t => t.IdPlayer, cascadeDelete: true)
                .ForeignKey("brk.Teams", t => t.IdTeam, cascadeDelete: true)
                .Index(t => t.IdTeam)
                .Index(t => t.IdPlayer);
            
            CreateTable(
                "brk.Tournament_Prize",
                c => new
                    {
                        IdTournament_Prize = c.Int(nullable: false, identity: true),
                        IdTournament = c.Int(nullable: false),
                        IdPrize = c.Int(nullable: false),
                        ApproximateValue = c.Decimal(nullable: false, precision: 10, scale: 3),
                    })
                .PrimaryKey(t => t.IdTournament_Prize)
                .ForeignKey("brk.Prizes", t => t.IdPrize, cascadeDelete: true)
                .Index(t => t.IdPrize);
            
        }
        
        public override void Down()
        {
            DropForeignKey("brk.Tournament_Prize", "IdPrize", "brk.Prizes");
            DropForeignKey("brk.Team_Player", "IdTeam", "brk.Teams");
            DropForeignKey("brk.Team_Player", "IdPlayer", "brk.Players");
            DropForeignKey("brk.Match_Player", "IdTeam_Tournament", "brk.Team_Tournament");
            DropForeignKey("brk.Team_Tournament", "IdTournament", "brk.Tournaments");
            DropForeignKey("brk.Team_Tournament", "IdTeam", "brk.Teams");
            DropForeignKey("brk.Match_Player", "IdPlayer", "brk.Players");
            DropForeignKey("brk.Match_Player", "IdMatch", "brk.Matches");
            DropForeignKey("brk.Matches", "IdTeamWinner", "brk.Teams");
            DropForeignKey("brk.Matches", "IdTeamTwo", "brk.Teams");
            DropForeignKey("brk.Matches", "IdTeamOne", "brk.Teams");
            DropForeignKey("brk.Teams", "IdGame", "brk.Games");
            DropIndex("brk.Tournament_Prize", new[] { "IdPrize" });
            DropIndex("brk.Team_Player", new[] { "IdPlayer" });
            DropIndex("brk.Team_Player", new[] { "IdTeam" });
            DropIndex("brk.Team_Tournament", new[] { "IdTournament" });
            DropIndex("brk.Team_Tournament", new[] { "IdTeam" });
            DropIndex("brk.Players", new[] { "UserName" });
            DropIndex("brk.Players", new[] { "RUT" });
            DropIndex("brk.Match_Player", new[] { "IdTeam_Tournament" });
            DropIndex("brk.Match_Player", new[] { "IdMatch" });
            DropIndex("brk.Match_Player", new[] { "IdPlayer" });
            DropIndex("brk.Teams", new[] { "IdGame" });
            DropIndex("brk.Matches", new[] { "IdTeamWinner" });
            DropIndex("brk.Matches", new[] { "IdTeamTwo" });
            DropIndex("brk.Matches", new[] { "IdTeamOne" });
            DropTable("brk.Tournament_Prize");
            DropTable("brk.Team_Player");
            DropTable("brk.Prizes");
            DropTable("brk.Tournaments");
            DropTable("brk.Team_Tournament");
            DropTable("brk.Players");
            DropTable("brk.Match_Player");
            DropTable("brk.Teams");
            DropTable("brk.Matches");
            DropTable("brk.Games");
        }
    }
}
