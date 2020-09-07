namespace FootyDb.Lab
{
    public class ApiCountriesResult
    {
        public CountriesResult api { get; set; }
    }

    public class CountriesResult
    {
        public Country[] countries { get; set; }
        public int results { get; set; }
    }

    public class Country
    {
        public string code { get; set; }
        public string country { get; set; }
        public string flag { get; set; }
    }
}