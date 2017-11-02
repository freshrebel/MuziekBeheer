using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelsFramework
{
    public class Song
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh\\:mm\\:ss}", ApplyFormatInEditMode = true)]
        public TimeSpan? Lenght { get; set; }
        public int? Bpm { get; set; }
        [Range(0, 5)]
        public int? Rating { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SongReleaseDate { get; set; }
        public List<SongArtist> SongArtists { get; set; }
        public List<SongGenre> SongGenres { get; set; }
        public List<SongAlbum> SongAlbums { get; set; }
        public List<SongPlaylist> SongPlaylists { get; set; }

        public string ArtistsToString
        {
            get
            {
                List<string> artistNames = new List<string>();
                foreach (var songArtist in SongArtists)
                {
                    artistNames.Add(songArtist.Artist.ArtistName);
                }
                return string.Join(",", artistNames);
            }
        }

        public string GenresToString
        {
            get
            {
                List<string> genreNames = new List<string>();
                foreach (var songGenre in SongGenres)
                {
                    genreNames.Add(songGenre.Genre.GenreName);
                }

                return string.Join(",", genreNames);
            }
        }

        public string AlbumsToString
        {
            get
            {
                List<string> albumNames = new List<string>();
                foreach (var songAlbum in SongAlbums)
                {
                    albumNames.Add(songAlbum.Album.AlbumName);
                }

                return string.Join(",", albumNames);
            }
        }

        public string PlaylistsToString
        {
            get
            {
                List<string> playlistNames = new List<string>();
                foreach (var songPlaylists in SongPlaylists)
                {
                    playlistNames.Add(songPlaylists.Playlist.PlaylistName);
                }
                return string.Join(",", playlistNames);
            }
        }
    }
}
