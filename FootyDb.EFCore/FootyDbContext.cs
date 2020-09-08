using FootyDb.Domain;
using Microsoft.EntityFrameworkCore;

namespace FootyDb.EFCore
{
    public class FootyDbContext : DbContext
    {
        private readonly string _connectionString;

        public FootyDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public FootyDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<LeagueSeason> LeagueSeasons { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(_connectionString))
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Team>()
                .HasOne(ur => ur.LeagueSeason)
                .WithMany(x => x.Teams)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}