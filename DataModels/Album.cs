﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public DateTime? AlbumReleaseDate { get; set; }
    }
}
