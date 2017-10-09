using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MuziekBeheer.Models
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongAlbum>().HasKey(k => new { k.AlbumId, k.SongId });
            modelBuilder.Entity<SongPlaylist>().HasKey(k => new { k.SongId, k.PlaylistId });
        }
    }
}