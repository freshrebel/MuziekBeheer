using DataModelsFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerFramework
{
    public class ArtistDA
    {
        SongsDb songsDb = new SongsDb();

        public List<Artist> GetAllArtists()
        {
            return songsDb.Artists.ToList<Artist>();
        }

        public Artist GetArtistById(int id)
        {
            var getArtistByIdQuery = from a in songsDb.Artists.Include("SongArtists.Song")
                                     where a.ArtistId == id
                                     select a;
            return getArtistByIdQuery.ToList<Artist>()[0];
        }

        public Artist GetArtistByName(string name)
        {
            var getArtistByNameQuery = from a in songsDb.Artists
                                       where a.ArtistName.ToLower().Trim() == name.ToLower().Trim()
                                       select a;
            bool artistFound = getArtistByNameQuery.Count() != 0;
            if (artistFound)
            {
                return getArtistByNameQuery.ToList<Artist>()[0];
            }
            else
            {
                return new Artist();
            }
        }

        public void AddArtist(Artist artist)
        {
            songsDb.Artists.Add(artist);
            songsDb.SaveChanges();
        }

        public void EditArtist(Artist artist)
        {
            Artist originalArtist = songsDb.Artists.Find(artist.ArtistId);
            songsDb.Entry(originalArtist).CurrentValues.SetValues(artist);
            songsDb.SaveChanges();
        }

        public void DeleteArtist(Artist artist)
        {
            songsDb.Artists.Remove(artist);
            songsDb.SaveChanges();
        }

        public void Dispose()
        {
            songsDb.Dispose();
        }
    }
}
