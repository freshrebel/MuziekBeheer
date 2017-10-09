using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModels
{
    public class Artist
    {
        public int ArtistId { get; set; }
        [Required]
        public string ArtistName { get; set; }
        public string BornAt { get; set; }
        public DateTime? BornOn { get; set; }
        public string Nationality { get; set; }
    }
}
