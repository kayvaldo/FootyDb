using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootyDb.Domain;

namespace FootyDb.Blazor.Services.Contracts
{
    public interface ICountriesService
    {
        Task<IEnumerable<Country>> GetCountries();
    }
}
