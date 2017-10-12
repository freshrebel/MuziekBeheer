using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DataLayer;

namespace DataLayer.Migrations
{
    [DbContext(typeof(SongsDb))]
    [Migration("20171012123235_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataModels.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlbumName");

                    b.Property<DateTime?>("AlbumReleaseDate");

                    b.HasKey("AlbumId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("DataModels.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtistName");

                    b.Property<string>("BornAt");

                    b.Property<DateTime?>("BornOn");

                    b.Property<string>("Nationality");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("DataModels.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GenreName");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("DataModels.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PlaylistName");

                    b.HasKey("PlaylistId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("DataModels.Song", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Bpm");

                    b.Property<TimeSpan?>("Lenght");

                    b.Property<int?>("Rating");

                    b.Property<string>("SongName");

                    b.Property<DateTime?>("SongReleaseDate");

                    b.HasKey("SongId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("DataModels.SongAlbum", b =>
                {
                    b.Property<int>("AlbumId");

                    b.Property<int>("SongId");

                    b.Property<int>("AlbumSequenceNumber");

                    b.HasKey("AlbumId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("SongAlbums");
                });

            modelBuilder.Entity("DataModels.SongArtist", b =>
                {
                    b.Property<int>("SongId");

                    b.Property<int>("ArtistId");

                    b.HasKey("SongId", "ArtistId");

                    b.HasIndex("ArtistId");

                    b.ToTable("SongArtists");
                });

            modelBuilder.Entity("DataModels.SongGenre", b =>
                {
                    b.Property<int>("SongId");

                    b.Property<int>("GenreId");

                    b.HasKey("SongId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("SongGenres");
                });

            modelBuilder.Entity("DataModels.SongPlaylist", b =>
                {
                    b.Property<int>("SongId");

                    b.Property<int>("PlaylistId");

                    b.Property<DateTime?>("DateAdded");

                    b.Property<int>("PlaylistSequence");

                    b.HasKey("SongId", "PlaylistId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("SongPlaylists");
                });

            modelBuilder.Entity("DataModels.SongAlbum", b =>
                {
                    b.HasOne("DataModels.Album", "Album")
                        .WithMany("SongAlbums")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataModels.Song", "Song")
                        .WithMany("Albums")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataModels.SongArtist", b =>
                {
                    b.HasOne("DataModels.Artist", "Artist")
                        .WithMany("SongArtists")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataModels.Song", "Song")
                        .WithMany("SongArtists")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataModels.SongGenre", b =>
                {
                    b.HasOne("DataModels.Genre", "Genre")
                        .WithMany("SongGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataModels.Song", "Song")
                        .WithMany("SongGenres")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataModels.SongPlaylist", b =>
                {
                    b.HasOne("DataModels.Playlist", "Playlist")
                        .WithMany("SongPlaylists")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataModels.Song", "Song")
                        .WithMany("Playlists")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
