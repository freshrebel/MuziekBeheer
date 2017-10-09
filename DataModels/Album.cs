using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainModels
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public DateTime AlbumReleaseDate { get; set; }
    }
}