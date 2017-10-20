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
            return View();
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
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
