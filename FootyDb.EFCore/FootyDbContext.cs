using FootyDb.Domain;
using Microsoft.EntityFrameworkCore;

namespace FootyDb.EFCore
{
    public class FootyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FootyDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
            optionsBuilder.UseSqlServer("Persist Security Info=False;User ID=sa;password=password1;Initial Catalog=FootyDb;Data Source=.");
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<LeagueSeason> LeagueSeasons { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Team>().HasOne(ur => ur.LeagueSeason)
            .WithMany(x => x.Teams)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}