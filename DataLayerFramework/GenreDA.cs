﻿using DataModelsFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerFramework
{
    public class GenreDA
    {
        SongsDb songsDb = new SongsDb();
        SongGenreDA songGenreDA = new SongGenreDA();

        public List<Genre> GetAllGenres()
        {
            var query = songsDb.Genres.SqlQuery("Select * from Genres");
            List<Genre> genres = query.ToList();
            return genres;
        }

        public Genre GetGenreById(int id)
        {
            Genre GenreById = songsDb.Genres.Find(id);
            bool genreFound = GenreById != null;
            if (genreFound)
            {
                return GenreById;
            }
            else
            {
                return new Genre();
            }
        }

        public Genre GetGenreByName(string name)
        {
            var getGenreByNameQuery = from a in songsDb.Genres
                                      where a.GenreName.ToLower().Trim() == name.ToLower().Trim()
                                      select a;

            bool genreFound = getGenreByNameQuery.Count() != 0;
            if (genreFound)
            {
                return getGenreByNameQuery.ToList<Genre>()[0];
            }
            else
            {
                return new Genre();
            }
            
        }

        public void AddGenre(Genre genre)
        {
            songsDb.Genres.Add(genre);
            songsDb.SaveChanges();
        }

        public void EditGenre(Genre genre)
        {
            Genre originalGenre = songsDb.Genres.Find(genre.GenreId);
            songsDb.Entry(originalGenre).CurrentValues.SetValues(genre);
            songsDb.SaveChanges();
        }

        public void DeleteGenre(Genre genre)
        {
            songGenreDA.DeleteGenre(genre.GenreId, songsDb);
            songsDb.Genres.Remove(genre);
            songsDb.SaveChanges();
        }

        public void Dispose()
        {
            songsDb.Dispose();
        }

    }
}
