using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FootyDb.Domain;
using FootyDb.EFCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;

namespace FootyDb.Lab
{
    internal class Program
    {
        private const string CountriesFilePath =
            @"C:\Users\kayvaldo\source\Repos\FootyDb\FootyDb.Lab\Files\Countries.json";

        private const string LeaguesFilePath =
            @"C:\Users\kayvaldo\source\Repos\FootyDb\FootyDb.Lab\Files\France-Leagues.json";

        private const string TeamsFilePath =
            @"C:\Users\kayvaldo\source\Repos\FootyDb\FootyDb.Lab\Files\Germany-Teams.json";

        public static async Task GetCountries(FootyDbContext dbContext)
        {
            var result = JsonConvert.DeserializeObject<ApiCountriesResult>(File.ReadAllText(CountriesFilePath));
            var countries = new List<Domain.Country>();

            foreach (var item in result.api.countries)
            {
                try
                {
                    countries.Add(
                        new Domain.Country
                        {
                            Name = item.country,
                            Code = item.code,
                            ImageUrl = item.flag
                        });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            try
            {
                dbContext.Countries.AddRange(countries);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public static async Task GetLeaguesByCountry(FootyDbContext dbContext)
        {
            var result = JsonConvert.DeserializeObject<ApiLeagueResult>(File.ReadAllText(LeaguesFilePath));

            if (result?.api?.leagues == null || result.api?.leagues.Length == 0)
            {
                return;
            }

            // Get country
            var firstLeague = result.api?.leagues[0];
            var country = await dbContext.Countries.SingleAsync(x => x.Name.Equals(firstLeague.country));

            if (country == null)
            {
                throw new ArgumentException($"Country ({firstLeague?.country}: {firstLeague?.country_code}) not found");
            }

            foreach (var item in result.api.leagues)
            {
                try
                {
                    // create league
                    var league = new Domain.League
                    {
                        ApiLeagueId = item.league_id,
                        ImageUrl = item.logo,
                        Name = item.name
                    };

                    // create league season
                    league.LeagueSeasons.Add(
                        new Domain.LeagueSeason
                        {
                            Name = item.season.ToString(),
                            SeasonStart = GetDateFromString(item.season_start),
                            SeasonEnd = GetDateFromString(item.season_end)
                        });

                    country.Leagues.Add(league);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public static async Task GetClubsByLeague(FootyDbContext dbContext)
        {
            var result = JsonConvert.DeserializeObject<ApiTeamsResult>(File.ReadAllText(TeamsFilePath));
            var teams = result?.api?.teams;

            if (teams == null || teams.Length == 0)
            {
                return;
            }

            var countryTeams = teams.GroupBy(x => x.country).ToList();

            foreach (var countryTeam in countryTeams)
            {
                // Get country
                var firstTeam = countryTeam.First();
                var country = await dbContext.Countries.SingleAsync(x => x.Name.Equals(firstTeam.country));

                if (country == null)
                {
                    throw new ArgumentException($"Country ({firstTeam?.country}) not found");
                }

                foreach (var team in countryTeam)
                {
                    try
                    {
                        // create club
                        var club = new Club
                        {
                            ApiTeamId = team.team_id,
                            ImageUrl = team.logo,
                            Name = team.name,
                            Code = team.code,
                            YearFounded = team.founded
                        };

                        var stadium =
                            await dbContext.Stadiums.SingleOrDefaultAsync(x => x.Name.Equals(team.venue_name));

                        if (stadium == null)
                        {
                            // create stadium
                            stadium = new Stadium
                            {
                                Address = team.venue_address,
                                Capacity = team.venue_capacity,
                                City = team.venue_city,
                                Surface = team.venue_surface,
                                Name = team.venue_name
                            };

                            stadium.Clubs.Add(club);
                            dbContext.Stadiums.Add(stadium);
                        }
                        else
                        {
                            stadium.Clubs.Add(club);
                        }

                        country.Clubs.Add(club);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public static async Task GetClubSquadBySeason(FootyDbContext dbContext)
        {
            // Get clubs
            var clubs = await dbContext.Clubs.ToListAsync();
            var clubsByCountry = clubs.GroupBy(x => x.CountryId);

            var leaguesToPopulate = new List<string>
            {
                "Wales"
            };
            //var leagues = await dbContext.Leagues.Where(x => leaguesToPopulate.Contains(x.Name)).ToListAsync();

            foreach (var clubGroup in clubsByCountry.Where(x => x.Key == new Guid("8C7B2075-EC3D-4D5A-48D4-08D84AAF29B6")))
            {
                // Get league
                var league = dbContext.Leagues.Find(new Guid("C22F16FB-717A-4EEC-5976-08D84B369BB9"));

                if (league == null)
                {
                    continue;
                }

                var leagueSeason = dbContext.LeagueSeasons.SingleOrDefault(x => x.LeagueId == league.Id && x.Name.Equals("2018"));

                if (leagueSeason == null)
                {
                    continue;
                }

                var count = 0;

                foreach (var club in clubGroup)
                {
                    if (count >= 96)
                    {
                        break;
                    }

                    var team = await dbContext.Teams.SingleOrDefaultAsync(x => x.ClubId == club.Id);

                    if (team != null)
                    {
                        continue;
                    }

                    Console.WriteLine($"{++count}: {club.Name}");

                    // Get squad for 2018-2019 League Season
                    var template = $"https://api-football-v1.p.rapidapi.com/v2/players/squad/{club.ApiTeamId}/2018-2019";
                    var client = new RestClient(template);
                    var request = new RestRequest(Method.GET);
                    request.AddHeader("x-rapidapi-host", "api-football-v1.p.rapidapi.com");
                    request.AddHeader("x-rapidapi-key", "8a9972105dmsh8fe5e3ccc76b9d0p189432jsnd4c05aadfacc");
                    var response = client.Execute(request);

                    if (!response.IsSuccessful)
                    {
                        continue;
                    }

                    var result = JsonConvert.DeserializeObject<ApiPlayerResults>(response.Content);
                    var squad = result?.api?.players;

                    if (squad == null)
                    {
                        continue;
                    }

                    var players = new List<Domain.Player>();

                    foreach (var item in squad)
                    {
                        var player = new Domain.Player
                        {
                            ApiPlayerId = item.player_id,
                            BirthCountry = item.birth_country,
                            BirthPlace = item.birth_place,
                            BirthDate = GetBirthDateFromString(item.birth_date),
                            FirstName = item.firstname,
                            LastName = item.lastname,
                            Name = item.player_name,
                            Height = item.height,
                            Weight = item.weight,
                            Position = item.position,
                            CountryId = clubGroup.Key
                        };

                        if (item.number != null)
                        {
                            player.Number = Convert.ToInt32(item.number);
                        }

                        players.Add(player);
                    }

                    dbContext.Teams.Add(new Domain.Team
                    {
                        ClubId = club.Id,
                        LeagueSeasonId = leagueSeason.Id,
                        Squad = players
                    });
                }
            }

            await dbContext.SaveChangesAsync();
        }

        private static DateTime GetDateFromString(string date)
        {
            // format: 2018-08-10 
            var dateSplit = date.Split('-');
            var year = Convert.ToInt32(dateSplit[0]);
            var month = Convert.ToInt32(dateSplit[1]);
            var day = Convert.ToInt32(dateSplit[2]);
            return new DateTime(year, month, day);
        }

        private static DateTime GetBirthDateFromString(string date)
        {
            // format: 2018-08-10 
            var dateSplit = date.Split('/');
            var year = Convert.ToInt32(dateSplit[2]);
            var month = Convert.ToInt32(dateSplit[1]);
            var day = Convert.ToInt32(dateSplit[0]);
            return new DateTime(year, month, day);
        }

        private static async Task Main()
        {
            using (var footyDbContext = new FootyDbContext())
            {
                //await GetCountries(footyDbContext);
                ///await GetLeaguesByCountry(footyDbContext);
                //await GetClubsByLeague(footyDbContext);
                //await RemoveNullStadium(footyDbContext);
                await GetClubSquadBySeason(footyDbContext);
            }
        }

        public static async Task RemoveNullStadium(FootyDbContext footyDbContext)
        {
            var nullStadium = await footyDbContext.Stadiums.FindAsync(new Guid("ca993038-acc0-462c-78c7-08d84b7314de"));

            if (nullStadium != null)
            {
                var nullStadiumClubs = footyDbContext.Clubs.Where(x => x.StadiumId == nullStadium.Id).ToList();
                nullStadiumClubs.ForEach(x => x.Stadium = null);
                footyDbContext.Stadiums.Remove(nullStadium);
                await footyDbContext.SaveChangesAsync();
            }
        }
    }
}