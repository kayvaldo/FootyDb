using System.Collections.Generic;
using System.Linq;
using FootyDb.Domain;
using FootyDb.Services.Data.Contracts;

namespace FootyDb.EFCore.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        public CountryRepository(FootyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly FootyDbContext _dbContext;

        public IEnumerable<Country> GetCountries()
        {
            return _dbContext.Countries;
        }

        public IEnumerable<Country> GetCountriesWithLeagues()
        {
            return _dbContext.Countries.Where(x => x.Leagues.Any());
        }
    }
}