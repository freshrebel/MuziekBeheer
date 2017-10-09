IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Albums] (
    [AlbumId] int NOT NULL IDENTITY,
    [AlbumName] nvarchar(max),
    [AlbumReleaseDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Albums] PRIMARY KEY ([AlbumId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20171009200457_test', N'1.1.3');

GO

CREATE TABLE [Artists] (
    [ArtistId] int NOT NULL IDENTITY,
    [ArtistName] nvarchar(max),
    [BornAt] nvarchar(max),
    [BornOn] datetime2 NOT NULL,
    [Nationality] nvarchar(max),
    CONSTRAINT [PK_Artists] PRIMARY KEY ([ArtistId])
);

GO

CREATE TABLE [Genres] (
    [GenreId] int NOT NULL IDENTITY,
    [GenreName] nvarchar(max),
    CONSTRAINT [PK_Genres] PRIMARY KEY ([GenreId])
);

GO

CREATE TABLE [Playlists] (
    [PlaylistId] int NOT NULL IDENTITY,
    [PlaylistName] nvarchar(max),
    CONSTRAINT [PK_Playlists] PRIMARY KEY ([PlaylistId])
);

GO

CREATE TABLE [Songs] (
    [SongId] int NOT NULL IDENTITY,
    [Bpm] int NOT NULL,
    [Rating] int NOT NULL,
    [SongName] nvarchar(max),
    [SongReleaseDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Songs] PRIMARY KEY ([SongId])
);

GO

CREATE TABLE [SongAlbums] (
    [AlbumId] int NOT NULL,
    [SongId] int NOT NULL,
    [AlbumSequenceNumber] int NOT NULL,
    CONSTRAINT [PK_SongAlbums] PRIMARY KEY ([AlbumId], [SongId]),
    CONSTRAINT [FK_SongAlbums_Albums_AlbumId] FOREIGN KEY ([AlbumId]) REFERENCES [Albums] ([AlbumId]) ON DELETE CASCADE,
    CONSTRAINT [FK_SongAlbums_Songs_SongId] FOREIGN KEY ([SongId]) REFERENCES [Songs] ([SongId]) ON DELETE CASCADE
);

GO

CREATE TABLE [SongArtist] (
    [SongId] int NOT NULL,
    [ArtistId] int NOT NULL,
    CONSTRAINT [PK_SongArtist] PRIMARY KEY ([SongId], [ArtistId]),
    CONSTRAINT [FK_SongArtist_Artists_ArtistId] FOREIGN KEY ([ArtistId]) REFERENCES [Artists] ([ArtistId]) ON DELETE CASCADE,
    CONSTRAINT [FK_SongArtist_Songs_SongId] FOREIGN KEY ([SongId]) REFERENCES [Songs] ([SongId]) ON DELETE CASCADE
);

GO

CREATE TABLE [SongGenre] (
    [SongId] int NOT NULL,
    [GenreId] int NOT NULL,
    CONSTRAINT [PK_SongGenre] PRIMARY KEY ([SongId], [GenreId]),
    CONSTRAINT [FK_SongGenre_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([GenreId]) ON DELETE CASCADE,
    CONSTRAINT [FK_SongGenre_Songs_SongId] FOREIGN KEY ([SongId]) REFERENCES [Songs] ([SongId]) ON DELETE CASCADE
);

GO

CREATE TABLE [SongPlaylists] (
    [SongId] int NOT NULL,
    [PlaylistId] int NOT NULL,
    [DateAdded] datetime2 NOT NULL,
    [PlaylistSequence] int NOT NULL,
    CONSTRAINT [PK_SongPlaylists] PRIMARY KEY ([SongId], [PlaylistId]),
    CONSTRAINT [FK_SongPlaylists_Playlists_PlaylistId] FOREIGN KEY ([PlaylistId]) REFERENCES [Playlists] ([PlaylistId]) ON DELETE CASCADE,
    CONSTRAINT [FK_SongPlaylists_Songs_SongId] FOREIGN KEY ([SongId]) REFERENCES [Songs] ([SongId]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_SongAlbums_SongId] ON [SongAlbums] ([SongId]);

GO

CREATE INDEX [IX_SongArtist_ArtistId] ON [SongArtist] ([ArtistId]);

GO

CREATE INDEX [IX_SongGenre_GenreId] ON [SongGenre] ([GenreId]);

GO

CREATE INDEX [IX_SongPlaylists_PlaylistId] ON [SongPlaylists] ([PlaylistId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20171009200854_test2', N'1.1.3');

GO

