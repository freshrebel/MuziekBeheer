using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    class Artist
    {
        public int ArtistId { get; set; }
        [Required]
        public string ArtistName { get; set; }
        public string BornAt { get; set; }
        public DateTime? BornOn { get; set; }
        public string Nationality { get; set; }
        public List<Song> Songs { get; set; }
    }
}
