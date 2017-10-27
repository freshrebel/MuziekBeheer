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

        SongsDb songsDb = new SongsDb();

        // GET: Songs
        public ActionResult Index()
        {
            var selectAllSongsQuery = from s in songsDb.Songs.Include("SongArtists.Artist").Include("SongAlbums.Album")
                                      select s;
            List<Song> songs = selectAllSongsQuery.ToList();
            return View(songs);
        }

        // GET: Songs/Details/5
        public ActionResult Details(int id)
        {
            var getSongByIdQuery = from s in songsDb.Songs.Include("SongAlbums.Album")
                                              .Include("SongPlaylists.Playlist")
                                              .Include("SongArtists.Artist")
                                              .Include("SongGenres.Genre")
                        where s.SongId == id
                        select s;
            Song song = getSongByIdQuery.ToList()[0];

            bool songExists = song != null;
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
        public ActionResult Create(FormCollection collection)
        {
            //var getSongByNameQuery = from s in songsDb.Songs
            //                         where s.SongName.ToLower().Trim() == 

            return View();
        }

        // GET: Songs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Songs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Songs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Songs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
