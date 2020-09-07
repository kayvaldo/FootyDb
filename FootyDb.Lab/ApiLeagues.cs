namespace FootyDb.Lab
{
    public class ApiLeagueResult
    {
        public LeagueResult api { get; set; }
    }

    public class LeagueResult
    {
        public League[] leagues { get; set; }
        public int results { get; set; }
    }

    public class League
    {
        public string country { get; set; }
        public string country_code { get; set; }
        public Coverage coverage { get; set; }
        public string flag { get; set; }
        public int is_current { get; set; }
        public int league_id { get; set; }
        public string logo { get; set; }
        public string name { get; set; }
        public int season { get; set; }
        public string season_end { get; set; }
        public string season_start { get; set; }
        public int standings { get; set; }
        public string type { get; set; }
    }

    public class Coverage
    {
        public Fixtures fixtures { get; set; }
        public bool odds { get; set; }
        public bool players { get; set; }
        public bool predictions { get; set; }
        public bool standings { get; set; }
        public bool topScorers { get; set; }
    }

    public class Fixtures
    {
        public bool events { get; set; }
        public bool lineups { get; set; }
        public bool players_statistics { get; set; }
        public bool statistics { get; set; }
    }
}