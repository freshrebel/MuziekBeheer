using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelsFramework
{
    public class Song
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public TimeSpan? Lenght { get; set; }
        public int? Bpm { get; set; }
        public int? Rating { get; set; }
        public DateTime? SongReleaseDate { get; set; }
        public List<SongArtist> SongArtists { get; set; }
        public List<SongGenre> SongGenres { get; set; }
        public List<SongAlbum> Albums { get; set; }
        public List<SongPlaylist> Playlists { get; set; }
    }
}
