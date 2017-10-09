using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MuziekBeheer.Models
{
    public class Song
    {
        public int SongId { get; set; }
        [Required]
        public string SongName { get; set; }
        public TimeSpan Lenght { get; set; }
        public int Bpm { get; set; }
        public int Rating { get; set; }
        public DateTime SongReleaseDate { get; set; }
        public virtual List<Artist> Artists { get; set; }
        public virtual List<Genre> Genres { get; set; }
        public virtual List<SongAlbum> Albums { get; set; }
        //public virtual List<SongPlaylist> Playlists { get; set; }
    }
}