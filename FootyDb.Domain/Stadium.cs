using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootyDb.Domain
{
    public class Stadium
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Address { get; set; }
        public int? Capacity { get; set; }
        public string City { get; set; }
        public ICollection<Club> Clubs { get; set; } = new List<Club>();
        public string Name { get; set; }
        public string Surface { get; set; }
    }
}