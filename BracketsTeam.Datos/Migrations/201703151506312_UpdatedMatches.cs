namespace BracketsTeam.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMatches : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "MatchTestName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "MatchTestName");
        }
    }
}
