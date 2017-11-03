using DataLayerFramework;
using DataModelsFramework;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuziekBeheer.Controllers
{
    public class PlaylistsController : Controller
    {

        PlaylistDA playlistDA = new PlaylistDA();

        // GET: Playlists
        public ActionResult Index()
        {
            List<Playlist> playlists = playlistDA.GetAllPlaylists();
            return View(playlists);
        }

        // GET: Playlists/Details/5
        public ActionResult Details(int id)
        {
            Playlist playlist = playlistDA.GetPlaylistById(id);

            bool playlistFound = playlist.PlaylistId != 0;
            if (!playlistFound)
            {
                return View("NotFound");
            }
            return View(playlist);
        }

        // GET: Playlists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Playlists/Create
        [HttpPost]
        public ActionResult Create(Playlist newPlaylist)
        {
            Playlist existingPlaylist = playlistDA.GetPlaylistByName(newPlaylist.PlaylistName);

            bool playlistExists = existingPlaylist.PlaylistId != 0;
            if (playlistExists)
            {
                return RedirectToAction("AlreadyExisting", existingPlaylist);
            }
            else
            {
                playlistDA.AddPlaylist(newPlaylist);
                return RedirectToAction("index");
            }
        }

        // GET: Playlists/Edit/5
        public ActionResult Edit(int id)
        {
            Playlist playlist = playlistDA.GetPlaylistById(id);
            bool playlistFound = playlist.PlaylistId != 0;

            if (!playlistFound)
            {
                return View("NotFound");
            }
            return View(playlist);
        }

        // POST: Playlists/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Playlist playlist)
        {
            Playlist existingPlaylist = playlistDA.GetPlaylistByName(playlist.PlaylistName);
            bool playlistExists = existingPlaylist.PlaylistId != 0;

            if (playlistExists)
            {
                return RedirectToAction("AlreadyExisting", existingPlaylist);
            }
            else
            {
                playlistDA.EditPlaylist(playlist);
                return RedirectToAction("index");
            }
        }

        // GET: Playlists/Delete/5
        public ActionResult Delete(int id)
        {
            Playlist playlist = playlistDA.GetPlaylistById(id);

            bool playlistFound = playlist.PlaylistId != 0;
            if (!playlistFound)
            {
                return View("NotFound");
            }
            return View(playlist);
        }

        // POST: Playlists/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Playlist existingPlaylist = playlistDA.GetPlaylistById(id);
            playlistDA.DeletePlaylist(existingPlaylist);
            return RedirectToAction("index");
        }

        public ActionResult AlreadyExisting(Playlist playlist)
        {
            return View("AlreadyExisting");
        }

        [HttpPost]
        public ActionResult AlreadyExisting(int PlaylistId, string submit)
        {
            bool viewDetails = submit == "yes";
            if (viewDetails)
            {
                return RedirectToAction("Details", new { id = PlaylistId });
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        public ActionResult AddSong(int id)
        {
            Playlist playlist = playlistDA.GetPlaylistById(id);
            List<Song> songsNotInPlaylist = playlistDA.GetSongsNotInPlaylist(id);
            dynamic playlistAndSongs = new ExpandoObject();
            playlistAndSongs.Playlist = playlist;
            playlistAndSongs.Songs = songsNotInPlaylist;
            return View(playlistAndSongs);
        }

        [HttpPost]
        public ActionResult AddSong(int SongId, int PlaylistId)
        {
            playlistDA.AddSong(SongId, PlaylistId);
            return RedirectToAction("AddSong");
        }

        public ActionResult DeleteSong(int songId, int playlistId)
        {
            playlistDA.DeleteSong(songId, playlistId);
            return RedirectToAction("Details", new { id = playlistId });
        }

        protected override void Dispose(bool disposing)
        {
            playlistDA.Dispose();
            base.Dispose(disposing);
        }
    }
}
