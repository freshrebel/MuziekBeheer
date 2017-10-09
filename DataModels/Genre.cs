using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModels
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public List<SongGenre> SongGenres { get; set; }
    }
}
