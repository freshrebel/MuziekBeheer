using DataModelsFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerFramework
{
    public class SongGenreDA
    {
        public void DeleteGenreFromSong(int songId, int genreId, SongsDb songsDb)
        {
            var songGenreQuery = from sg in songsDb.SongGenres
                                  where sg.GenreId == genreId && sg.SongId == songId
                                  select sg;
            songsDb.SongGenres.Remove(songGenreQuery.ToList()[0]);
            songsDb.SaveChanges();
        }

        public void AddGenreToSong(int songId, int genreId, SongsDb songsDb)
        {
            SongGenre songGenre = new SongGenre();
            songGenre.GenreId = genreId;
            songGenre.SongId = songId;
            songsDb.SongGenres.Add(songGenre);
            songsDb.SaveChanges();
        }
    }
}
