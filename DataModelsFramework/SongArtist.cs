﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelsFramework
{
    public class SongArtist
    {
        public int SongId { get; set; }
        public Song Song { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
