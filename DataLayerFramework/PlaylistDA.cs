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
            var playlistByIdQuery = from p in songsDb.Playlists
                                    where p.PlaylistName.ToLower().Trim() == name.ToLower().Trim()
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
            songsDb.Playlists.Remove(playlist);
            songsDb.SaveChanges();
        }

        public void Dispose()
        {
            songsDb.Dispose();
        }
    }
}
