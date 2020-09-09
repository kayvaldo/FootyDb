using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootyDb.Domain
{
    public class League
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int ApiLeagueId { get; set; }
        public virtual Country Country { get; set; }
        public Guid CountryId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public ICollection<LeagueSeason> LeagueSeasons { get; set; } = new List<LeagueSeason>();
    }
}