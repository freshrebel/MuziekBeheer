using DataLayerFramework;
using DataModelsFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuziekBeheer.Controllers
{
    public class SongsController : Controller
    {

        SongsDA songsDA = new SongsDA();

        // GET: Songs
        public ActionResult Index()
        {
            return View(songsDA.GetAllSongs());
        }

        // GET: Songs/Details/5
        public ActionResult Details(int id)
        {
            Song song = songsDA.GetSongById(id);

            bool songExists = song.SongId != 0;
            if (!songExists)
            {
                return View("NotFound");
            }
            return View(song);
        }

        // GET: Songs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
        [HttpPost]
        public ActionResult Create(Song song, string Time)
        {
            Song originalSong = songsDA.GetSongByName(song.SongName);

            bool songFound = originalSong.SongId != 0;

            if (songFound)
            {
                return RedirectToAction("AlreadyExisting", originalSong);
            }
            else
            {
                songsDA.AddSong(song);
                return RedirectToAction("index");
            }
        }

        // GET: Songs/Edit/5
        public ActionResult Edit(int id)
        {
            Song song = songsDA.GetSongById(id);

            bool songExists = song.SongId != 0;

            if (songExists)
            {
                return View(song);
            }
            else
            {
                return View("NotFound");
            }
        }

        // POST: Songs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Song song)
        {
            Song originalSong = songsDA.GetSongByName(song.SongName);

            TimeSpan newLength = new TimeSpan(0, song.Lenght.Value.Hours, song.Lenght.Value.Minutes);
            song.Lenght = newLength;

            bool songFound = originalSong.SongId != 0;

            if (songFound)
            {
                return RedirectToAction("AlreadyExisting", originalSong);
            }
            else
            {
                songsDA.EditSong(song);
                return RedirectToAction("Details", id);
            }
        }

        // GET: Songs/Delete/5
        public ActionResult Delete(int id)
        {
            Song song = songsDA.GetSongById(id);

            bool songExists = song.SongId != 0;

            if (songExists)
            {
                return View(song);
            }
            else
            {
                return View("NotFound");
            }
        }

        // POST: Songs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Song song = songsDA.GetSongById(id);
            songsDA.DeleteSong(song);
            return RedirectToAction("index");
        }

        public ActionResult AlreadyExisting(Song song)
        {
            return View("AlreadyExisting");
        }

        [HttpPost]
        public ActionResult AlreadyExisting(int Albumid, string submit)
        {
            bool viewDetails = submit == "yes";
            if (viewDetails)
            {
                return RedirectToAction("Details", new { id = Albumid });
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            songsDA.Dispose();
            base.Dispose(disposing);
        }
    }
}
