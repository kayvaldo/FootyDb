﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootyDb.Domain
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<League> Leagues { get; set; } = new List<League>();
        public ICollection<Club> Clubs { get; set; } = new List<Club>();
    }
}
