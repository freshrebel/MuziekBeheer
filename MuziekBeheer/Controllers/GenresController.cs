using DataLayerFramework;
using DataModelsFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuziekBeheer.Controllers
{
    public class GenresController : Controller
    {

        SongsDb songsDb = new SongsDb();

        // GET: Genres
        public ActionResult Index()
        {
            var genres = songsDb.Genres;

            return View(genres);
        }

        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            var getGenreByNameQuery = from g in songsDb.Genres
                                 where g.GenreName.ToLower().Trim() == genre.GenreName.ToLower().Trim()
                                 select g;

            bool genreExists = getGenreByNameQuery.Count() != 0;
            if (!genreExists)
            {
                songsDb.Genres.Add(genre);
                songsDb.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                List<Genre> existingGenres = getGenreByNameQuery.ToList();
                return RedirectToAction("AlreadyExisting", existingGenres[0]);
            }
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int id)
        {
            //genre genre = songsdb.genres.find(id);
            //if (genre == null)
            //{
            //    return view("notfound");
            //}
            //return view(genre);
            return View();
        }

        // POST: Genres/Edit/5
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

        // GET: Genres/Delete/5
        public ActionResult Delete(int id)
        {
            Genre genre = songsDb.Genres.Find(id);
            bool genreExists = genre != null;
            if (!genreExists)
            {
                return View("NotFound");
            }
            return View();
        }

        // POST: Genres/Delete/5
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

        public ActionResult AlreadyExisting(Genre genre)
        {
            return View("AlreadyExisting");
        }

        protected override void Dispose(bool disposing)
        {
            songsDb.Dispose();
            base.Dispose(disposing);
        }
    }
}
