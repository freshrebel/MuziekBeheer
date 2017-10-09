using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace MuziekBeheer.Models
{
    public class SongsDb : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<SongAlbum> SongAlbums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongAlbum>().HasKey(k => new { k.AlbumId, k.SongId });
        }
    }
}