using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    class SongAlbum
    {
        public int SongId { get; set; }
        public virtual Song Song { get; set; }
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }
        public int AlbumSequenceNumber { get; set; }
    }
}
