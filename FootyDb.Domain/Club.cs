using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootyDb.Domain
{
    public class Club
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int ApiTeamId { get; set; }
        public string Code { get; set; }
        public virtual Country Country { get; set; }
        public Guid CountryId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public Stadium Stadium { get; set; }
        public Guid? StadiumId { get; set; }
        public int YearFounded { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}