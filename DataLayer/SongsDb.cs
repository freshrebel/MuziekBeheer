using Microsoft.EntityFrameworkCore;
using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    class SongsDb : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<SongAlbum> SongAlbums { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<SongPlaylist> SongPlaylists { get; set; }
        public DbSet<SongGenre> SongGenre { get; set; }
        public DbSet<SongArtist> SongArtist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "data source=./;Database=SongsDb;integrated security = true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongAlbum>().HasKey(k => new { k.AlbumId, k.SongId });
            modelBuilder.Entity<SongPlaylist>().HasKey(k => new { k.SongId, k.PlaylistId });
            modelBuilder.Entity<SongGenre>().HasKey(k => new { k.SongId, k.GenreId });
            modelBuilder.Entity<SongArtist>().HasKey(k => new { k.SongId, k.ArtistId });
        }
    }
}
