namespace MuziekBeheer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MuziekBeheer.Models.SongsDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MuziekBeheer.Models.SongsDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //context.Albums.AddOrUpdate(a => a.AlbumId,
            //    new Models.Album { AlbumId = 1, AlbumName = "Soul Greats [Disc 1]" },
            //    new Models.Album { AlbumId = 2, AlbumName = "Thriller 25" },
            //    new Models.Album { AlbumId = 3, AlbumName = "Q-Music Greatest Hits 2006 Vol. 2 [Disc 1]" }
            //    );
            //context.Artists.AddOrUpdate(a => a.ArtistId,
            //    new Models.Artist { ArtistId = 1, ArtistName = "Michael Jackson" }
            //  );
            //context.Genres.AddOrUpdate(g => g.GenreId,
            //    new Models.Genre { GenreId = 1, GenreName = "Pop" });
            //context.Playlists.AddOrUpdate(p => p.PlaylistId,
            //    new Models.Playlist { PlaylistId = 1, PlaylistName = "Test 1" });
            context.Songs.AddOrUpdate(s => s.SongId,
            new Models.Song { SongId = 1, SongName = "Billie Jean"});
        }
    }
}
