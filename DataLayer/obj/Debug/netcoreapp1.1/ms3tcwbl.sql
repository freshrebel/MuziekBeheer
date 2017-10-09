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

