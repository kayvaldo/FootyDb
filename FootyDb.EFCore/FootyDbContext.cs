using FootyDb.Domain;
using Microsoft.EntityFrameworkCore;

namespace FootyDb.EFCore
{
    public class FootyDbContext : DbContext
    {
        public FootyDbContext(DbContextOptions<FootyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Season> Seasons { get; set; }
    }
}