using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FootyDb.Domain
{
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int ApiPlayerId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Number { get; set; }
        public string Position { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string BirthCountry { get; set; }
        public Country Country { get; set; }
        public Guid? CountryId { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
    }
}
