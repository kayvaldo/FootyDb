using System.Collections.Generic;
using FootyDb.Domain;

namespace FootyDb.Services.Data.Contracts
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        IEnumerable<Country> GetCountries();
    }
}