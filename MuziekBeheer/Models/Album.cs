using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MuziekBeheer.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public DateTime? AlbumReleaseDate { get; set; }
    }
}