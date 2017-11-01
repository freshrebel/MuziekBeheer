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

        public List<Album> GetAllAlbums()
        {
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
            songsDb.Albums.Remove(album);
            songsDb.SaveChanges();
        }

        public void Dispose()
        {
            songsDb.Dispose();
        }
    }
}
