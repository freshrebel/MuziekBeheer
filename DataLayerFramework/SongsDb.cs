using DataModelsFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerFramework
{
    public class SongsDb : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<SongAlbum> SongAlbums { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<SongPlaylist> SongPlaylists { get; set; }
        public DbSet<SongGenre> SongGenres { get; set; }
        public DbSet<SongArtist> SongArtists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongAlbum>().HasKey(k => new { k.AlbumId, k.SongId });
            modelBuilder.Entity<SongPlaylist>().HasKey(k => new { k.SongId, k.PlaylistId });
            modelBuilder.Entity<SongGenre>().HasKey(k => new { k.SongId, k.GenreId });
            modelBuilder.Entity<SongArtist>().HasKey(k => new { k.SongId, k.ArtistId });
        }
    }
}
