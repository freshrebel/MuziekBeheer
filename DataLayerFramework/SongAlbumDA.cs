using DataModelsFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerFramework
{
    public class SongAlbumDA
    {

        public void AddSongToAlbum(int songId, int albumId, SongsDb songsDb)
        {
            int maxSeqNumb = GetMaxSeqNumb(albumId, songsDb);
            SongAlbum songAlbum = new SongAlbum();
            songAlbum.SongId = songId;
            songAlbum.AlbumId = albumId;
            songAlbum.AlbumSequenceNumber = maxSeqNumb + 1;
            songsDb.SongAlbums.Add(songAlbum);
            songsDb.SaveChanges();
        }

        private int GetMaxSeqNumb(int albumId, SongsDb songsDb)
        {
            var AlbumSongQuery = from s in songsDb.SongAlbums
                                 where s.AlbumId == albumId
                                 select s;
            bool anySongAdded = AlbumSongQuery.Count() != 0;
            if (anySongAdded)
            {
                List<int> seqNumbList = new List<int>();
                foreach (SongAlbum sa in AlbumSongQuery.ToList<SongAlbum>())
                {
                    seqNumbList.Add(sa.AlbumSequenceNumber);
                }
                return seqNumbList.Max();
            }
            else
            {
                return 0;
            }
        }

        public void DeleteAlbum(int albumId, SongsDb songsDb)
        {
            var songAlbumQuery = from s in songsDb.SongAlbums
                                 where s.AlbumId == albumId
                                 select s;
            List<SongAlbum> toDelete = songAlbumQuery.ToList();
            foreach (SongAlbum s in songAlbumQuery)
            {
                songsDb.SongAlbums.Remove(s);
            }
            songsDb.SaveChanges();
        }

        public void DeleteSong(int songId, SongsDb songsDb)
        {
            var songAlbumQuery = from s in songsDb.SongAlbums
                                 where s.SongId == songId
                                 select s;
            List<SongAlbum> toDelete = songAlbumQuery.ToList();
            foreach (SongAlbum s in songAlbumQuery)
            {
                songsDb.SongAlbums.Remove(s);
            }
            songsDb.SaveChanges();
        }

        public void DeleteSongFromAlbum(int songId, int albumId, SongsDb songsDb)
        {
            var songAlbum = from sa in songsDb.SongAlbums
                                  where sa.AlbumId == albumId && sa.SongId == songId
                                  select sa;
            songsDb.SongAlbums.Remove(songAlbum.ToList()[0]);
            songsDb.SaveChanges();
        }
    }
}
