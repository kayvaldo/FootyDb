using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootyDb.Domain
{
    public class LeagueSeason
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public virtual League League { get; set; }
        public Guid LeagueId { get; set; }
        public string Name { get; set; }
        public DateTime SeasonEnd { get; set; }
        public DateTime SeasonStart { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}