using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootyDb.Blazor.Services.Contracts;
using FootyDb.Domain;
using Microsoft.AspNetCore.Components;

namespace FootyDb.Blazor.Pages
{
    public class CountriesBase : ComponentBase
    {
        [Inject]
        public ICountriesService CountriesService { get; set; }
        public List<Country> Countries { get; set; } = new List<Country>();

        protected override async Task OnInitializedAsync()
        {
            Countries = (await CountriesService.GetCountries()).ToList();
        }
    }
}
