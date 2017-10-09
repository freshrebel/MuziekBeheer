using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class SongAlbum
    {
        public int SongId { get; set; }
        public Song Song { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public int AlbumSequenceNumber { get; set; }
    }
}
