using DataModelsFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerFramework
{
    public class SongsDA
    {
        SongsDb songsDb = new SongsDb();
        SongAlbumDA songAlbumDA = new SongAlbumDA();
        SongArtistDA songArtistDA = new SongArtistDA();
        SongPlaylistDA songPlaylistDA = new SongPlaylistDA();
        SongGenreDA songGenreDA = new SongGenreDA();

        public List<Song> GetAllSongs()
        {
            var selectAllSongsQuery = from s in songsDb.Songs.Include("SongArtists.Artist").Include("SongAlbums.Album")
                                      select s;
            List<Song> songs = selectAllSongsQuery.ToList();
            return songs;
        }

        public Song GetSongById(int id)
        {
            var getSongByIdQuery = from s in songsDb.Songs.Include("SongAlbums.Album")
                                              .Include("SongPlaylists.Playlist")
                                              .Include("SongArtists.Artist")
                                              .Include("SongGenres.Genre")
                                   where s.SongId == id
                                   select s;
            bool songFound = getSongByIdQuery.Count() != 0;
            if (!songFound)
            {
                return new Song();
            }
            return getSongByIdQuery.ToList()[0];
        }

        public Song GetSongByName(string name)
        {
            var getSongByNameQuery = from s in songsDb.Songs.Include("SongAlbums.Album")
                                              .Include("SongPlaylists.Playlist")
                                              .Include("SongArtists.Artist")
                                              .Include("SongGenres.Genre")
                                   where s.SongName == name
                                   select s;
            bool songFound = getSongByNameQuery.Count() != 0;
            if (!songFound)
            {
                return new Song();
            }
            return getSongByNameQuery.ToList()[0];
        }

        public void AddSong(Song song)
        {
            songsDb.Songs.Add(song);
            songsDb.SaveChanges();
        }

        public void EditSong(Song song)
        {
            Song originalSong = songsDb.Songs.Find(song.SongId);
            songsDb.Entry(originalSong).CurrentValues.SetValues(song);
            songsDb.SaveChanges();
        }

        public void DeleteSong(Song song)
        {
            songAlbumDA.DeleteSong(song.SongId, songsDb);
            songGenreDA.DeleteSong(song.SongId, songsDb);
            songPlaylistDA.DeleteSong(song.SongId, songsDb);
            songArtistDA.DeleteSong(song.SongId, songsDb);
            songsDb.Songs.Remove(song);
            songsDb.SaveChanges();
        }

        public void Dispose()
        {
            songsDb.Dispose();
        }

        public List<Artist> GetArtistsNotInSong(int songId)
        {
            List<Artist> allArtists = songsDb.Artists.Include("SongArtists").ToList();
            List<Artist> artistsNotInSong = new List<Artist>();
            foreach (Artist a in allArtists)
            {
                var songArtistWithSong = from sa in a.SongArtists
                                         where sa.SongId == songId
                                         select sa;
                bool artistInSong = songArtistWithSong.Count() != 0;
                if (!artistInSong)
                {
                    artistsNotInSong.Add(a);
                }

            }

            return artistsNotInSong;
        }

        public void DeleteArtist(int songId, int artistId)
        {
            songArtistDA.DeleteArtistFromSong(songId, artistId, songsDb);
        }

        public void AddArtist(int songId, int artistId)
        {
            songArtistDA.AddArtistToSong(songId, artistId, songsDb);
        }

        public List<Genre> GetGenresNotInSong(int songId)
        {
            List<Genre> allGenres = songsDb.Genres.Include("SongGenres").ToList();
            List<Genre> genresNotInSong = new List<Genre>();
            foreach (Genre g in allGenres)
            {
                var songGenreWithSong = from sg in g.SongGenres
                                        where sg.SongId == songId
                                        select sg;
                bool genreInSong = songGenreWithSong.Count() != 0;
                if (!genreInSong)
                {
                    genresNotInSong.Add(g);
                }

            }

            return genresNotInSong;
        }

        public void DeleteGenre(int songId, int genreId)
        {
            songGenreDA.DeleteGenreFromSong(songId, genreId, songsDb);
        }

        public void AddGenre(int songId, int genreId)
        {
            songGenreDA.AddGenreToSong(songId, genreId, songsDb);
        }
    }
}
