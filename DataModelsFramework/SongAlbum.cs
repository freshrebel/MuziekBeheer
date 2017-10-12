using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelsFramework
{
    public class SongAlbum
    {
        public int SongId { get; set; }
        public Song Song { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public int AlbumSequenceNumber { get; set; }
    }
}
