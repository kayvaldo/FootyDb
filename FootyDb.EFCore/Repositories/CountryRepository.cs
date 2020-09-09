using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using FootyDb.Domain;
using FootyDb.Services.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FootyDb.EFCore.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        public CountryRepository(FootyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly FootyDbContext _dbContext;

        public IEnumerable<Country> GetAllCountries()
        {
            return _dbContext.Countries;
        }

        public IEnumerable<Country> GetCountries()
        {
            var result = _dbContext.Countries.Where(x => x.Leagues.Any()).Include(y => y.Leagues).Include(z => z.Clubs).ToList();
            return result;
        }
    }
}