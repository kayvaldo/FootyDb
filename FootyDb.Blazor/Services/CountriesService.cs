using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FootyDb.Blazor.Services.Contracts;
using FootyDb.Domain;
using static System.Net.HttpStatusCode;

namespace FootyDb.Blazor.Services
{
    public class CountriesService : ICountriesService
    {
        private const string CountriesEndpoint = "countries";

        public CountriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private readonly HttpClient _httpClient;

        public async Task<IEnumerable<Country>> GetCountries()
        {
            var responseMessage = await _httpClient.GetAsync(CountriesEndpoint);

            if (responseMessage.StatusCode == OK)
            {
                return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>(
                    await responseMessage.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }

            throw new WebException($"Error occurred: {responseMessage.ReasonPhrase}");
        }
    }
}