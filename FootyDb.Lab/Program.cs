using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FootyDb.Lab
{
    internal class Program
    {
        private const string FilePath = @"c:\videogames.json";

        public static void GetCountries()
        {
            var o1 = JObject.Parse(File.ReadAllText(FilePath));

            // read JSON directly from a file
            using (var file = File.OpenText(FilePath))
            using (var reader = new JsonTextReader(file))
            {
                var o2 = (JObject)JToken.ReadFrom(reader);
            }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}