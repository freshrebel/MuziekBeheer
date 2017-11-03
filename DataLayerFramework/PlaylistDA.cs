using DataModelsFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerFramework
{
    public class PlaylistDA
    {

        SongsDb songsDb = new SongsDb();
        SongPlaylistDA songPlaylistDA = new SongPlaylistDA();

        public List<Playlist> GetAllPlaylists()
        {
            return songsDb.Playlists.ToList<Playlist>();
        }

        public Playlist GetPlaylistById(int id)
        {
            var playlistByIdQuery = from p in songsDb.Playlists.Include("SongPlaylists.Song")
                                    where p.PlaylistId == id
                                    select p;

            bool playlistFound = playlistByIdQuery.Count() != 0;
            if (playlistFound)
            {
                return playlistByIdQuery.ToList<Playlist>()[0];
            }
            else
            {
                return new Playlist();
            }

        }

        public Playlist GetPlaylistByName(string name)
        {
            var playlistByNameQuery = from p in songsDb.Playlists
                                    where p.PlaylistName.ToLower().Trim() == name.ToLower().Trim()
                                    select p;

            bool playlistFound = playlistByNameQuery.Count() != 0;
            if (playlistFound)
            {
                return playlistByNameQuery.ToList<Playlist>()[0];
            }
            else
            {
                return new Playlist();
            }
        }

        public void AddPlaylist(Playlist playlist)
        {
            songsDb.Playlists.Add(playlist);
            songsDb.SaveChanges();
        }

        public void EditPlaylist(Playlist playlist)
        {
            Playlist originalPlaylist = songsDb.Playlists.Find(playlist.PlaylistId);
            songsDb.Entry(originalPlaylist).CurrentValues.SetValues(playlist);
            songsDb.SaveChanges();
        }

        public void DeletePlaylist(Playlist playlist)
        {
            songPlaylistDA.DeletePlaylist(playlist.PlaylistId, songsDb);
            songsDb.Playlists.Remove(playlist);
            songsDb.SaveChanges();
        }

        public List<Song> GetSongsNotInPlaylist(int playlistId)
        {
            List<Song> allSongs = songsDb.Songs.Include("SongPlaylists").Include("SongArtists.Artist").ToList();
            List<Song> songsNotInPlaylist = new List<Song>();

            foreach (Song s in allSongs)
            {
                var songAlbumWithPlaylist = from sa in s.SongPlaylists
                                         where sa.PlaylistId == playlistId
                                         select sa;
                bool songInAlbum = songAlbumWithPlaylist.Count() != 0;
                if (!songInAlbum)
                {
                    songsNotInPlaylist.Add(s);
                }

            }

            return songsNotInPlaylist;
        }

        public void AddSong(int songId, int playlistId)
        {
            songPlaylistDA.AddSongToPlaylist(songId, playlistId, songsDb);
        }

        public void DeleteSong(int songId, int playlistId)
        {
            songPlaylistDA.DeleteSongFromPlaylist(songId, playlistId, songsDb);
        }

        public void Dispose()
        {
            songsDb.Dispose();
        }

    }
}
