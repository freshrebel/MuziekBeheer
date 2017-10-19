using DataLayerFramework;
using DataModelsFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuziekBeheer.Controllers
{
    public class ArtistsController : Controller
    {

        SongsDb songsDb = new SongsDb();

        // GET: Artist
        public ActionResult Index()
        {
            var artists = songsDb.Artists;
            return View(artists);
        }

        // GET: Artist/Details/5
        public ActionResult Details(int id)
        {
            var getArtistByIdQuery = from a in songsDb.Artists.Include("SongArtists.Song")
                                    where a.ArtistId == id
                                    select a;
            Artist artist = getArtistByIdQuery.ToList<Artist>()[0];
            if (artist == null)
            {
                return View("NotFound");
            }
            return View(artist);
        }

        // GET: Artist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artist/Create
        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            var getArtistByNameQuery = from a in songsDb.Artists
                                       where a.ArtistName == artist.ArtistName
                                       select a;
            
            if (getArtistByNameQuery.Count() == 0)
            {
                songsDb.Artists.Add(artist);
                songsDb.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                return View("AlreadyExisting");
            }
        }

        // GET: Artist/Edit/5
        public ActionResult Edit(int id)
        {
            Artist artist = songsDb.Artists.Find(id);
            bool artistFound = artist != null;
            if (artistFound)
            {
                return View(artist);
            }
            return View("ArtistNotFound");
        }

        // POST: Artist/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Artist artist = songsDb.Artists.Find(id);

            if (TryUpdateModel(artist))
            {
                songsDb.SaveChanges();
                return RedirectToAction("index");
            }

            return View();
        }

        // GET: Artist/Delete/5
        public ActionResult Delete(int id)
        {
            Artist artist = songsDb.Artists.Find(id);
            return View(artist);
        }

        // POST: Artist/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            Artist artist = songsDb.Artists.Find(id);
            bool artistFound = artist.ArtistId != 0;

            if (artistFound)
            {
                songsDb.Artists.Remove(artist);
                songsDb.SaveChanges();
                return RedirectToAction("index");
            }

            return View();
        }
    }
}
