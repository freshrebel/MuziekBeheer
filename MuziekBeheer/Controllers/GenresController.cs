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
        GenreDA genreDA = new GenreDA();

        // GET: Genres
        public ActionResult Index()
        {
            return View(genreDA.GetAllGenres());
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
            Genre existingGenre = genreDA.GetGenreByName(genre.GenreName);

            bool genreExists = existingGenre.GenreId != 0;
            if (!genreExists)
            {
                genreDA.AddGenre(genre);
                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("AlreadyExisting", existingGenre);
            }
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int id)
        {
            Genre genre = genreDA.GetGenreById(id);
            bool genreExists = genre != null;
            if (!genreExists)
            {
                return View("NotFound");
            }
            return View(genre);
        }

        // POST: Genres/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Genre genre)
        {
            genreDA.EditGenre(genre);
            return RedirectToAction("index");
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int id)
        {
            Genre existingGenre = genreDA.GetGenreById(id);
            bool genreExists = existingGenre.GenreId != 0;
            if (!genreExists)
            {
                return View("NotFound");
            }
            return View(existingGenre);
        }

        // POST: Genres/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Genre genre)
        {
            Genre existingGenre = genreDA.GetGenreById(id);
            bool genreExists = existingGenre.GenreId != 0;
            if (genreExists)
            {
                genreDA.DeleteGenre(existingGenre);
                return RedirectToAction("index");
            }

            return View();
        }

        public ActionResult AlreadyExisting(Genre genre)
        {
            return View("AlreadyExisting");
        }

        protected override void Dispose(bool disposing)
        {
            genreDA.Dispose();
            base.Dispose(disposing);
        }
    }
}
