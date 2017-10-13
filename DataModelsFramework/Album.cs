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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AlbumReleaseDate { get; set; }
        public List<SongAlbum> SongAlbums { get; set; }
    }
}
