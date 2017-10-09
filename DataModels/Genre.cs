using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    class Genre
    {
        public int GenreId { get; set; }
        [Required]
        public string GenreName { get; set; }
        public List<Song> Songs { get; set; }
    }
}
