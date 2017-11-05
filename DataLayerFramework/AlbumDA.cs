using DataModelsFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerFramework
{
    public class AlbumDA
    {

        SongsDb songsDb = new SongsDb();
        SongAlbumDA songAlbumDA = new SongAlbumDA();

        public List<Album> GetAllAlbums()
        {
            var query = songsDb.Albums.SqlQuery("spGetAllAlbums");
            List<Album> albums = query.ToList();
            return songsDb.Albums.ToList<Album>();
        }

        public Album GetAlbumById(int id)
        {
            var getAlbumByIdQuery = from a in songsDb.Albums.Include("SongAlbums.Song")
                                    where a.AlbumId == id
                                    select a;

            bool albumFound = getAlbumByIdQuery.Count() != 0;
            if (albumFound)
            {
                return getAlbumByIdQuery.ToList<Album>()[0];
            }
            else
            {
                return new Album();
            }
        }

        public Album GetAlbumByName(string name)
        {
            var getAlbumByNameQuery = from a in songsDb.Albums
                                      where a.AlbumName.ToLower().Trim() == name.ToLower().Trim()
                                      select a;
            bool albumFound = getAlbumByNameQuery.Count() != 0;
            if (albumFound)
            {
                return getAlbumByNameQuery.ToList<Album>()[0];
            }
            else
            {
                return new Album();
            }
        }

        public void AddAlbum(Album album)
        {
            songsDb.Albums.Add(album);
            songsDb.SaveChanges();
        }

        public void EditAlbum(Album album)
        {
            Album originalAlbum = songsDb.Albums.Find(album.AlbumId);
            songsDb.Entry(originalAlbum).CurrentValues.SetValues(album);
            songsDb.SaveChanges();
        }

        public void DeleteAlbum(Album album)
        {
            songAlbumDA.DeleteAlbum(album.AlbumId, songsDb);
            songsDb.Albums.Remove(album);
            songsDb.SaveChanges();
        }

        public List<Song> GetSongsNotInAlbum(int albumId)
        {
            List<Song> allSongs = songsDb.Songs.Include("SongAlbums").Include("SongArtists.Artist").ToList();
            List<Song> songsNotInAlbum = new List<Song>();
            foreach (Song s in allSongs)
            {
                var songAlbumWithAlbum = from sa in s.SongAlbums
                                         where sa.AlbumId == albumId
                                         select sa;
                bool songInAlbum = songAlbumWithAlbum.Count() != 0;
                if (!songInAlbum)
                {
                    songsNotInAlbum.Add(s);
                }

            }

            return songsNotInAlbum;
        }

        public void AddSong(int songId, int albumId)
        {
            songAlbumDA.AddSongToAlbum(songId, albumId, songsDb);
        }

        public void DeleteSong(int songId, int albumId)
        {
            songAlbumDA.DeleteSongFromAlbum(songId, albumId, songsDb);
        }

        public void Dispose()
        {
            songsDb.Dispose();
        }
    }
}
