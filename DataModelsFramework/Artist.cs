using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModelsFramework
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string BornAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BornOn { get; set; }
        public string Nationality { get; set; }
        public List<SongArtist> SongArtists { get; set; }
    }
}
