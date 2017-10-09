using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public string PlaylistName { get; set; }
        public List<SongPlaylist> SongPlaylists { get; set; }
    }
}
