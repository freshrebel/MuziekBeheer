using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Song
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public TimeSpan? Lenght { get; set; }
        public int? Bpm { get; set; }
        public int? Rating { get; set; }
        public DateTime? SongReleaseDate { get; set; }
        public virtual List<SongArtist> SongArtists { get; set; }
        public virtual List<SongGenre> SongGenres { get; set; }
        public virtual List<SongAlbum> Albums { get; set; }
        public virtual List<SongPlaylist> Playlists { get; set; }
    }
}
