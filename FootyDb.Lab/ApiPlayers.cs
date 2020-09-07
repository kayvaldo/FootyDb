using System;
using System.Collections.Generic;
using System.Text;

namespace FootyDb.Lab
{
    public class ApiPlayerResults
    {
        public PlayerResults api { get; set; }
    }

    public class PlayerResults
    {
        public int results { get; set; }
        public Player[] players { get; set; }
    }

    public class Player
    {
        public int player_id { get; set; }
        public string player_name { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public object number { get; set; }
        public string position { get; set; }
        public int age { get; set; }
        public string birth_date { get; set; }
        public string birth_place { get; set; }
        public string birth_country { get; set; }
        public string nationality { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
    }

}
