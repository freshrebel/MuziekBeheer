﻿using System;
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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BornOn { get; set; }
        public string Nationality { get; set; }
        public List<SongArtist> SongArtists { get; set; }
    }
}
