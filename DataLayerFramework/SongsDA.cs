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
            //delete songGenres
            //delete songPlaylists
            //delete songArtist
            songsDb.Songs.Remove(song);
            songsDb.SaveChanges();
        }

        public void Dispose()
        {
            songsDb.Dispose();
        }
    }
}
