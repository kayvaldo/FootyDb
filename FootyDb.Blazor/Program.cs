using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using FootyDb.Blazor.Services.Contracts;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FootyDb.Blazor.Services;

namespace FootyDb.Blazor
{
    public class Program
    {
        private const string BaseUri = "https://localhost:44331/api/";

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(
                sp => new HttpClient
                {
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
                });

            builder.Services.AddHttpClient<ICountriesService, CountriesService>(client => client.BaseAddress = new Uri(BaseUri));
            await builder.Build().RunAsync();
        }
    }
}
