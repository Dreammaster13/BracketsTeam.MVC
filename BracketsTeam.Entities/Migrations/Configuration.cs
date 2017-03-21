namespace BracketsTeam.Entities.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BracketsTeam.Entities.DBContext_BracketsTeam>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
            ContextKey = "BracketsTeam.Entities.DBContext_BracketsTeam";
        }

        protected override void Seed(BracketsTeam.Entities.DBContext_BracketsTeam context)
        {
            context.Game.AddOrUpdate(
                new Models.Game() { Name = "Dota2", Alias = "Dota2", IsActive = true },
                new Models.Game() { Name = "Counter Strike: Global Offensive", Alias = "CSGO", IsActive = true },
                new Models.Game() { Name = "League of Legends", Alias = "LoL", IsActive = true }
            );
        }
    }
}
