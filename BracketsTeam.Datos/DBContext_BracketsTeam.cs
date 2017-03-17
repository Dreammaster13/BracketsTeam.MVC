using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BracketsTeam.Datos.Models;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual DbSet<Team_Player> Team_Player { get; set; }
        public virtual DbSet<Team_Tournament> Team_Tournament { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }
        public virtual DbSet<Tournament_Prize> Tournament_Prize { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("brk");

            #region Game
            modelBuilder.Entity<Game>().HasKey(x => x.IdGame).Property(x => x.IdGame).HasColumnOrder(1);
            modelBuilder.Entity<Game>().Property(x => x.Name).HasColumnOrder(2).IsRequired().HasMaxLength(128);
            modelBuilder.Entity<Game>().Property(x => x.IsActive).HasColumnOrder(3).IsRequired();
            #endregion

            #region Match
            modelBuilder.Entity<Match>().HasKey(x => x.IdMatch).Property(x => x.IdMatch).HasColumnOrder(1);
            modelBuilder.Entity<Match>().Property(x => x.IdTeamOne).IsOptional().HasColumnOrder(2);
            modelBuilder.Entity<Match>().Property(x => x.IdTeamTwo).IsOptional().HasColumnOrder(3);
            modelBuilder.Entity<Match>().Property(x => x.IdTeamWinner).IsOptional().HasColumnOrder(4);
            modelBuilder.Entity<Match>().Property(x => x.DatePlayed).IsRequired().HasColumnOrder(5);
            modelBuilder.Entity<Match>().Property(x => x.MatchCode).IsOptional().HasColumnOrder(6);
            modelBuilder.Entity<Match>().Property(x => x.Observation).IsOptional().HasColumnOrder(7);
            modelBuilder.Entity<Match>().HasOptional(one => one.TeamOne).WithMany().HasForeignKey(one => one.IdTeamOne).WillCascadeOnDelete(false);
            modelBuilder.Entity<Match>().HasOptional(two => two.TeamTwo).WithMany().HasForeignKey(two => two.IdTeamTwo).WillCascadeOnDelete(false);
            modelBuilder.Entity<Match>().HasOptional(winner => winner.TeamWinner).WithMany().HasForeignKey(winner => winner.IdTeamWinner).WillCascadeOnDelete(false);
            #endregion

            #region Match_Player
            modelBuilder.Entity<Match_Player>().HasKey(x => x.IdMatch_Player).Property(x => x.IdMatch_Player).HasColumnOrder(1);
            modelBuilder.Entity<Match_Player>().Property(x => x.IdPlayer).HasColumnOrder(2);
            modelBuilder.Entity<Match_Player>().Property(x => x.IdMatch).HasColumnOrder(3);
            modelBuilder.Entity<Match_Player>().Property(x => x.IdTeam_Tournament).HasColumnOrder(4);
            #endregion

            #region Player
            modelBuilder.Entity<Player>().HasKey(x => x.IdPlayer).Property(x => x.IdPlayer).HasColumnOrder(1);
            modelBuilder.Entity<Player>().Property(x => x.RUT)
                .IsRequired().HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_RUT", 1) { IsUnique = true }))
                .HasColumnOrder(2);
            modelBuilder.Entity<Player>().Property(x => x.DV).IsRequired().HasMaxLength(1).HasColumnOrder(3);
            modelBuilder.Entity<Player>().Property(x => x.Name).IsRequired().HasMaxLength(32).HasColumnOrder(4);
            modelBuilder.Entity<Player>().Property(x => x.LastName).IsRequired().HasMaxLength(32).HasColumnOrder(5);
            modelBuilder.Entity<Player>().Property(x => x.UserName)
                .IsRequired().HasMaxLength(32).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_UserName", 1) { IsUnique = true }))
                .HasColumnOrder(6);
            modelBuilder.Entity<Player>().Property(x => x.NickName).IsRequired().HasMaxLength(32).HasColumnOrder(7);
            modelBuilder.Entity<Player>().Property(x => x.AltNickName).HasMaxLength(32).HasColumnOrder(8);
            modelBuilder.Entity<Player>().Property(x => x.BirthDate).HasColumnOrder(9);
            modelBuilder.Entity<Player>().Property(x => x.IsActive).HasColumnOrder(10);
            #endregion

            #region Prize
            modelBuilder.Entity<Prize>().HasKey(x => x.IdPrize).Property(x=> x.IdPrize).HasColumnOrder(1);
            modelBuilder.Entity<Prize>().Property(x => x.Name).IsRequired().HasMaxLength(256).HasColumnOrder(2);
            modelBuilder.Entity<Prize>().Property(x => x.ExchangeRate).IsRequired().HasMaxLength(3).HasColumnOrder(3);
            modelBuilder.Entity<Prize>().Property(x => x.Value).HasPrecision(10, 3).HasColumnOrder(4);
            #endregion

            #region Team
            modelBuilder.Entity<Team>().HasKey(x => x.IdTeam).Property(x=> x.IdTeam).HasColumnOrder(1);
            modelBuilder.Entity<Team>().Property(x => x.IdGame).HasColumnOrder(2);
            modelBuilder.Entity<Team>().Property(x => x.Name).IsRequired().HasMaxLength(64).HasColumnOrder(3);
            modelBuilder.Entity<Team>().Property(x => x.NameShort).IsRequired().HasMaxLength(4).HasColumnOrder(4);
            modelBuilder.Entity<Team>().Property(x => x.IsActive).IsRequired().HasColumnOrder(5);
            #endregion

            #region Team_Player
            modelBuilder.Entity<Team_Player>().HasKey(x => x.IdTeam_Player).Property(x=> x.IdTeam_Player).HasColumnOrder(1);
            modelBuilder.Entity<Team_Player>().Property(x => x.IdTeam).HasColumnOrder(2);
            modelBuilder.Entity<Team_Player>().Property(x => x.IdPlayer).HasColumnOrder(3);
            modelBuilder.Entity<Team_Player>().Property(x => x.IsPlayerMain).IsRequired().HasColumnOrder(4);
            modelBuilder.Entity<Team_Player>().Property(x => x.IsPlayerAdmin).IsRequired().HasColumnOrder(5);
            #endregion

            #region Team_Tournament
            modelBuilder.Entity<Team_Tournament>().HasKey(x => x.IdTeam_Tournament).Property(x=> x.IdTeam_Tournament).HasColumnOrder(1);
            modelBuilder.Entity<Team_Tournament>().Property(x => x.IdTeam).HasColumnOrder(2);
            modelBuilder.Entity<Team_Tournament>().Property(x => x.IdTournament).HasColumnOrder(3);
            #endregion

            #region Tournament
            modelBuilder.Entity<Tournament>().HasKey(x => x.IdTournament).Property(x=> x.IdTournament).HasColumnOrder(1);
            modelBuilder.Entity<Tournament>().Property(x => x.Name).IsRequired().HasMaxLength(256).HasColumnOrder(2);
            modelBuilder.Entity<Tournament>().Property(x => x.MaxPlayers).IsRequired().HasColumnOrder(3);
            modelBuilder.Entity<Tournament>().Property(x => x.MaxPlayersTeam).IsRequired().HasColumnOrder(4);
            modelBuilder.Entity<Tournament>().Property(x => x.HasStarted).IsRequired().HasColumnOrder(5);
            modelBuilder.Entity<Tournament>().Property(x => x.HasEnded).IsRequired().HasColumnOrder(6);
            #endregion

            #region Tournament_Prize
            modelBuilder.Entity<Tournament_Prize>().HasKey(x => x.IdTournament_Prize).Property(x => x.IdTournament_Prize).HasColumnOrder(1);
            modelBuilder.Entity<Tournament_Prize>().Property(x => x.IdTournament).HasColumnOrder(2);
            modelBuilder.Entity<Tournament_Prize>().Property(x => x.IdPrize).HasColumnOrder(3);
            modelBuilder.Entity<Tournament_Prize>().Property(x => x.ApproximateValue).HasPrecision(10, 3).HasColumnOrder(4);
            #endregion
        }
    }
}
