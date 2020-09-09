using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using FootyDb.Blazor.Services.Contracts;
using FootyDb.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace FootyDb.Blazor.Pages
{
    public class CountriesBase : ComponentBase
    {
        [Inject]
        public ICountriesService CountriesService { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<League> Leagues { get; set; } = new List<League>();
        public List<Club> Clubs { get; set; } = new List<Club>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Countries = (await CountriesService.GetCountries())?.ToList();

                if (Countries?.Any() == true)
                {
                    Leagues = Countries.SelectMany(x => x.Leagues).ToList();
                    Clubs = Countries.SelectMany(x => x.Clubs).ToList();
                    SetRelationships();
                }
            }
            catch (Exception exception)
            {
                await JsRuntime.InvokeVoidAsync("alert", $"Error occurred: {exception.Message}");
            }
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            JsRuntime.InvokeVoidAsync("App.init");
            JsRuntime.InvokeVoidAsync("Portfolio.init");
            return base.OnAfterRenderAsync(firstRender);
        }

        private void SetRelationships()
        {
            foreach (var country in Countries)
            {
                var countryLeagues = Leagues.Where(x => x.CountryId == country.Id).ToList();

                if (countryLeagues.Any())
                {
                    countryLeagues.ForEach(league => league.Country = country);
                }

                var countryClubs = Clubs.Where(x => x.CountryId == country.Id).ToList();

                if (countryClubs.Any())
                {
                    countryClubs.ForEach(league => league.Country = country);
                }
            }
        }
    }
}
