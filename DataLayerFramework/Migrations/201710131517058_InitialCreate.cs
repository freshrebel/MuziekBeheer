namespace DataLayerFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        AlbumName = c.String(),
                        AlbumReleaseDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.AlbumId);
            
            CreateTable(
                "dbo.SongAlbums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false),
                        SongId = c.Int(nullable: false),
                        AlbumSequenceNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AlbumId, t.SongId })
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .Index(t => t.AlbumId)
                .Index(t => t.SongId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        SongName = c.String(),
                        Lenght = c.Time(precision: 7),
                        Bpm = c.Int(),
                        Rating = c.Int(),
                        SongReleaseDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SongId);
            
            CreateTable(
                "dbo.SongPlaylists",
                c => new
                    {
                        SongId = c.Int(nullable: false),
                        PlaylistId = c.Int(nullable: false),
                        PlaylistSequence = c.Int(nullable: false),
                        DateAdded = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.SongId, t.PlaylistId })
                .ForeignKey("dbo.Playlists", t => t.PlaylistId, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .Index(t => t.SongId)
                .Index(t => t.PlaylistId);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        PlaylistId = c.Int(nullable: false, identity: true),
                        PlaylistName = c.String(),
                    })
                .PrimaryKey(t => t.PlaylistId);
            
            CreateTable(
                "dbo.SongArtists",
                c => new
                    {
                        SongId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SongId, t.ArtistId })
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .Index(t => t.SongId)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        ArtistName = c.String(),
                        BornAt = c.String(),
                        BornOn = c.DateTime(),
                        Nationality = c.String(),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.SongGenres",
                c => new
                    {
                        SongId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SongId, t.GenreId })
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .Index(t => t.SongId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongGenres", "SongId", "dbo.Songs");
            DropForeignKey("dbo.SongGenres", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.SongArtists", "SongId", "dbo.Songs");
            DropForeignKey("dbo.SongArtists", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.SongPlaylists", "SongId", "dbo.Songs");
            DropForeignKey("dbo.SongPlaylists", "PlaylistId", "dbo.Playlists");
            DropForeignKey("dbo.SongAlbums", "SongId", "dbo.Songs");
            DropForeignKey("dbo.SongAlbums", "AlbumId", "dbo.Albums");
            DropIndex("dbo.SongGenres", new[] { "GenreId" });
            DropIndex("dbo.SongGenres", new[] { "SongId" });
            DropIndex("dbo.SongArtists", new[] { "ArtistId" });
            DropIndex("dbo.SongArtists", new[] { "SongId" });
            DropIndex("dbo.SongPlaylists", new[] { "PlaylistId" });
            DropIndex("dbo.SongPlaylists", new[] { "SongId" });
            DropIndex("dbo.SongAlbums", new[] { "SongId" });
            DropIndex("dbo.SongAlbums", new[] { "AlbumId" });
            DropTable("dbo.Genres");
            DropTable("dbo.SongGenres");
            DropTable("dbo.Artists");
            DropTable("dbo.SongArtists");
            DropTable("dbo.Playlists");
            DropTable("dbo.SongPlaylists");
            DropTable("dbo.Songs");
            DropTable("dbo.SongAlbums");
            DropTable("dbo.Albums");
        }
    }
}
