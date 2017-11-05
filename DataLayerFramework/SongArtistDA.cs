using DataModelsFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerFramework
{
    public class SongArtistDA
    {
        public void AddArtistToSong(int songId, int artistId , SongsDb songsDb)
        {
            SongArtist songArtist = new SongArtist();
            songArtist.ArtistId = artistId;
            songArtist.SongId = songId;
            songsDb.SongArtists.Add(songArtist);
            songsDb.SaveChanges();
        }

        internal void DeleteArtistFromSong(int songId, int artistId, SongsDb songsDb)
        {
            var songArtistQuery = from sa in songsDb.SongArtists
                                  where sa.ArtistId == artistId && sa.SongId == songId
                                  select sa;
            songsDb.SongArtists.Remove(songArtistQuery.ToList()[0]);
            songsDb.SaveChanges();
        }
    }
}
