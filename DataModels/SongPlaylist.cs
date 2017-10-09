using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class SongPlaylist
    {
        public int SongId { get; set; }
        public Song Song { get; set; }
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        public int PlaylistSequence { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
