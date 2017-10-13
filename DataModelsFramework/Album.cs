using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModelsFramework
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? AlbumReleaseDate { get; set; }
        public List<SongAlbum> SongAlbums { get; set; }
    }
}
