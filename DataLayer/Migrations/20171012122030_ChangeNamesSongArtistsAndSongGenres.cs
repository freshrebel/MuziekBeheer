using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ChangeNamesSongArtistsAndSongGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongArtist_Artists_ArtistId",
                table: "SongArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_SongArtist_Songs_SongId",
                table: "SongArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_SongGenre_Genres_GenreId",
                table: "SongGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_SongGenre_Songs_SongId",
                table: "SongGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongGenre",
                table: "SongGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongArtist",
                table: "SongArtist");

            migrationBuilder.RenameTable(
                name: "SongGenre",
                newName: "SongGenres");

            migrationBuilder.RenameTable(
                name: "SongArtist",
                newName: "SongArtists");

            migrationBuilder.RenameIndex(
                name: "IX_SongGenre_GenreId",
                table: "SongGenres",
                newName: "IX_SongGenres_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_SongArtist_ArtistId",
                table: "SongArtists",
                newName: "IX_SongArtists_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongGenres",
                table: "SongGenres",
                columns: new[] { "SongId", "GenreId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongArtists",
                table: "SongArtists",
                columns: new[] { "SongId", "ArtistId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtists_Artists_ArtistId",
                table: "SongArtists",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtists_Songs_SongId",
                table: "SongArtists",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongGenres_Genres_GenreId",
                table: "SongGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongGenres_Songs_SongId",
                table: "SongGenres",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongArtists_Artists_ArtistId",
                table: "SongArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_SongArtists_Songs_SongId",
                table: "SongArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_SongGenres_Genres_GenreId",
                table: "SongGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_SongGenres_Songs_SongId",
                table: "SongGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongGenres",
                table: "SongGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongArtists",
                table: "SongArtists");

            migrationBuilder.RenameTable(
                name: "SongGenres",
                newName: "SongGenre");

            migrationBuilder.RenameTable(
                name: "SongArtists",
                newName: "SongArtist");

            migrationBuilder.RenameIndex(
                name: "IX_SongGenres_GenreId",
                table: "SongGenre",
                newName: "IX_SongGenre_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_SongArtists_ArtistId",
                table: "SongArtist",
                newName: "IX_SongArtist_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongGenre",
                table: "SongGenre",
                columns: new[] { "SongId", "GenreId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongArtist",
                table: "SongArtist",
                columns: new[] { "SongId", "ArtistId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtist_Artists_ArtistId",
                table: "SongArtist",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtist_Songs_SongId",
                table: "SongArtist",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongGenre_Genres_GenreId",
                table: "SongGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongGenre_Songs_SongId",
                table: "SongGenre",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
