namespace BracketsTeam.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Games", newSchema: "brk");
            MoveTable(name: "dbo.Matches", newSchema: "brk");
            MoveTable(name: "dbo.Teams", newSchema: "brk");
            MoveTable(name: "dbo.Match_Player", newSchema: "brk");
            MoveTable(name: "dbo.Players", newSchema: "brk");
            MoveTable(name: "dbo.Team_Tournament", newSchema: "brk");
            MoveTable(name: "dbo.Tournaments", newSchema: "brk");
            MoveTable(name: "dbo.Prizes", newSchema: "brk");
            MoveTable(name: "dbo.Team_Player", newSchema: "brk");
        }
        
        public override void Down()
        {
            MoveTable(name: "brk.Team_Player", newSchema: "dbo");
            MoveTable(name: "brk.Prizes", newSchema: "dbo");
            MoveTable(name: "brk.Tournaments", newSchema: "dbo");
            MoveTable(name: "brk.Team_Tournament", newSchema: "dbo");
            MoveTable(name: "brk.Players", newSchema: "dbo");
            MoveTable(name: "brk.Match_Player", newSchema: "dbo");
            MoveTable(name: "brk.Teams", newSchema: "dbo");
            MoveTable(name: "brk.Matches", newSchema: "dbo");
            MoveTable(name: "brk.Games", newSchema: "dbo");
        }
    }
}
