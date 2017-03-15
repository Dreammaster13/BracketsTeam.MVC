using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BracketsTeam.Datos.Models;

namespace BracketsTeam.Datos
{
    public class DBContext_BracketsTeam : DbContext
    {
        public DBContext_BracketsTeam()
            : base("name=ConStr-DB_BracketsTeam")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DBContext_BracketsTeam, Migrations.Configuration>());
        }

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<Match_Player> Match_Player { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Prize> Prize { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("brk");

            modelBuilder.Entity<Game>().HasKey(x => x.IdGame);
            modelBuilder.Entity<Match>().HasKey(x => x.IdMatch);
            modelBuilder.Entity<Match_Player>().HasKey(x => x.IdMatch_Player);
            modelBuilder.Entity<Player>().HasKey(x => x.IdPlayer);
            modelBuilder.Entity<Prize>().HasKey(x => x.IdPrize);
            modelBuilder.Entity<Team>().HasKey(x => x.IdTeam);
            modelBuilder.Entity<Team_Player>().HasKey(x => x.IdTeam_Player);
            modelBuilder.Entity<Team_Tournament>().HasKey(x => x.IdTeam_Tournament);
            modelBuilder.Entity<Tournament>().HasKey(x => x.IdTournament);

            modelBuilder.Entity<Match>()
                .HasRequired(one => one.TeamOne)
                .WithMany()
                .HasForeignKey(one => one.IdTeamOne)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasRequired(two => two.TeamTwo)
                .WithMany()
                .HasForeignKey(two => two.IdTeamTwo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasRequired(winner => winner.TeamWinner)
                .WithMany()
                .HasForeignKey(winner => winner.IdTeamWinner)
                .WillCascadeOnDelete(false);
        }
    }
}
