using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootyDb.Domain
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid ClubId { get; set; }
        public Club Club { get; set; }
        public Guid LeagueSeasonId { get; set; }
        public LeagueSeason LeagueSeason { get; set; }
        public ICollection<Player> Squad { get; set; } = new List<Player>();
    }
}
