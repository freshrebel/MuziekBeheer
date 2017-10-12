using System;
using System.Collections.Generic;

namespace DataModelsFramework
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public DateTime? AlbumReleaseDate { get; set; }
        public List<SongAlbum> SongAlbums { get; set; }
    }
}
