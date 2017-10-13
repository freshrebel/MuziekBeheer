using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelsFramework
{
    public class SongPlaylist
    {
        public int SongId { get; set; }
        public Song Song { get; set; }
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        public int PlaylistSequence { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateAdded { get; set; }
    }
}
