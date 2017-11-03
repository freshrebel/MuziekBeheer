using DataModelsFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerFramework
{
    public class SongPlaylistDA
    {

        public void AddSongToPlaylist(int songId, int playlistId, SongsDb songsDb)
        {
            int maxSeqNumb = GetMaxSeqNumb(playlistId, songsDb);
            SongPlaylist songPlaylist = new SongPlaylist();
            songPlaylist.SongId = songId;
            songPlaylist.PlaylistId = playlistId;
            songPlaylist.PlaylistSequence = maxSeqNumb + 1;
            songsDb.SongPlaylists.Add(songPlaylist);
            songsDb.SaveChanges();
        }

        private int GetMaxSeqNumb(int playlistId, SongsDb songsDb)
        {
            var playlistSongQuery = from s in songsDb.SongPlaylists
                                 where s.PlaylistId == playlistId
                                 select s;
            bool anySongAdded = playlistSongQuery.Count() != 0;
            if (anySongAdded)
            {
                List<int> seqNumbList = new List<int>();
                foreach (SongPlaylist sa in playlistSongQuery.ToList<SongPlaylist>())
                {
                    seqNumbList.Add(sa.PlaylistSequence);
                }
                return seqNumbList.Max();
            }
            else
            {
                return 0;
            }
        }

        public void DeletePlaylist(int playlistId, SongsDb songsDb)
        {
            var songPlaylistQuery = from s in songsDb.SongPlaylists
                                 where s.PlaylistId == playlistId
                                 select s;
            List<SongPlaylist> toDelete = songPlaylistQuery.ToList();
            foreach (SongPlaylist s in songPlaylistQuery)
            {
                songsDb.SongPlaylists.Remove(s);
            }
            songsDb.SaveChanges();
        }

        public void DeleteSong(int songId, SongsDb songsDb)
        {
            var songPlaylistQuery = from s in songsDb.SongPlaylists
                                 where s.SongId == songId
                                 select s;
            List<SongPlaylist> toDelete = songPlaylistQuery.ToList();
            foreach (SongPlaylist s in songPlaylistQuery)
            {
                songsDb.SongPlaylists.Remove(s);
            }
            songsDb.SaveChanges();
        }

        public void DeleteSongFromPlaylist(int songId, int playlistId, SongsDb songsDb)
        {
            var songPlaylist = from sa in songsDb.SongPlaylists
                            where sa.PlaylistId == playlistId && sa.SongId == songId
                            select sa;
            songsDb.SongPlaylists.Remove(songPlaylist.ToList()[0]);
            songsDb.SaveChanges();
        }

    }
}
