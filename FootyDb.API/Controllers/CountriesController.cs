using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootyDb.Domain;
using FootyDb.Services.Data.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FootyDb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepo;

        public CountriesController(ICountryRepository countryRepo)
        {
            _countryRepo = countryRepo;
        }

        // GET: api/<CountriesController>
        [HttpGet]
        public IEnumerable<Country> GetCountries()
        {
            return _countryRepo.GetCountriesWithLeagues();
        }

        [HttpGet("All")]
        public IEnumerable<Country> Get()
        {
            return _countryRepo.GetCountries();
        }

        // GET api/<CountriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
