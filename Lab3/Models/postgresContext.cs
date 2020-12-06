using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataBase3
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Goals> Goals { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<Stadiums> Stadiums { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=2749");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack");

            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.GameId)
                    .HasName("Games_pkey");

                entity.Property(e => e.GameId)
                    .HasColumnName("GameID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.MatchId).HasColumnName("MatchID");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("matchid");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("teamid");
            });

            modelBuilder.Entity<Goals>(entity =>
            {
                entity.HasKey(e => e.GoalId)
                    .HasName("Goals_pkey");

                entity.Property(e => e.GoalId)
                    .HasColumnName("GoalID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.MatchId).HasColumnName("MatchID");

                entity.Property(e => e.Minute).HasColumnName("minute");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Goals)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("matchid");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Goals)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("teamid");
            });

            modelBuilder.Entity<Matches>(entity =>
            {
                entity.HasKey(e => e.MatchId)
                    .HasName("Matches_pkey");

                entity.Property(e => e.MatchId)
                    .HasColumnName("MatchID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.StadiumId).HasColumnName("StadiumID");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("date");

                entity.HasOne(d => d.Stadium)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.StadiumId)
                    .HasConstraintName("stadiumid");
            });

            modelBuilder.Entity<Stadiums>(entity =>
            {
                entity.HasKey(e => e.StadiumId)
                    .HasName("Stadiums_pkey");

                entity.Property(e => e.StadiumId)
                    .HasColumnName("StadiumID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(60);

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.SName)
                    .IsRequired()
                    .HasColumnName("s_name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(e => e.TeamId)
                    .HasName("Teams_pkey");

                entity.Property(e => e.TeamId)
                    .HasColumnName("TeamID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.TName)
                    .IsRequired()
                    .HasColumnName("t_name")
                    .HasMaxLength(30);

                entity.Property(e => e.Trainer)
                    .IsRequired()
                    .HasColumnName("trainer")
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
