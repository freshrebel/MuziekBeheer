/*use master;

Drop database SongsDb;*/

use SongsDb;

Insert Into Albums(AlbumName)
	Values('Soul Greats [Disc 1]'), ('Thriller 25'), 
	('Q-Music Greatest Hits 2006 Vol. 2 [Disc 1]');

Insert Into Artists(ArtistName) Values ('Michael Jackson');

Insert Into Genres(GenreName) Values('Pop');

Insert Into Playlists(PlaylistName) Values('Test 1');

select * from Playlists;

Insert Into Songs(SongName) Values('Thriller'), ('Billie Jean');

Select * from Songs;

Insert Into SongAlbums(SongId, AlbumId, AlbumSequenceNumber) Values
	((Select SongId From Songs where SongName = 'Billie Jean'),
		(Select AlbumId from Albums where AlbumName = 'Thriller 25'),
		1),
	((Select SongId From Songs where SongName = 'Thriller'),
		(Select AlbumId from Albums where AlbumName = 'Thriller 25'),
		2),
	((Select SongId From Songs where SongName = 'Billie Jean'),
		(Select AlbumId from Albums where AlbumName= 'Q-Music Greatest Hits 2006 Vol. 2 [Disc 1]'),
		1);

Select * from SongAlbums;

Insert Into SongPlaylists(SongId, PlaylistId, PlaylistSequence, DateAdded) Values
	((Select SongId From Songs where SongName = 'Billie Jean'),
		(Select PlaylistId from Playlists where PlaylistName = 'Test 1'),
		1, GETDATE()),
	((Select SongId From Songs where SongName = 'Thriller'),
		(Select PlaylistId from Playlists where PlaylistName = 'Test 1'),
		1, GETDATE());

select * from SongPlaylists;

Insert Into SongArtists(ArtistId, SongId) Values
	((Select ArtistId from Artists where ArtistName = 'Michael Jackson'),
		(Select SongId from Songs where SongName = 'Thriller')),
	((Select ArtistId from Artists where ArtistName = 'Michael Jackson'),
		(Select SongId from Songs where SongName = 'Billie Jean'));

select * from SongArtists;

Insert Into SongGenres(GenreId, SongId) Values
	((Select GenreId from Genres where GenreName = 'Pop'),
		(Select SongId from Songs where SongName = 'Thriller')),
	((Select GenreId from Genres where GenreName = 'Pop'),
		(Select SongId from Songs where SongName = 'Billie Jean'));

select * from SongGenres;