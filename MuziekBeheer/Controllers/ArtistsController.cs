using DataLayerFramework;
using DataModelsFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MuziekBeheer.Controllers
{
    public class ArtistsController : Controller
    {
        ArtistDA artistDA = new ArtistDA();

        // GET: Artist
        public ActionResult Index()
        {
            return View(artistDA.GetAllArtists());
        }

        // GET: Artist/Details/5
        public ActionResult Details(int id)
        {
            Artist artist = artistDA.GetArtistById(id);
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
            Artist artistByName = artistDA.GetArtistByName(artist.ArtistName);
            bool artistFound = artistByName.ArtistId != 0;

            if (!artistFound)
            {
                artistDA.AddArtist(artist);
                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("AlreadyExisting", artistByName);
            }
        }

        // GET: Artist/Edit/5
        public ActionResult Edit(int id)
        {
            Artist artist = artistDA.GetArtistById(id);
            bool artistFound = artist != null;
            if (artistFound)
            {
                return View(artist);
            }
            return View("ArtistNotFound");
        }

        // POST: Artist/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Artist artist)
        {
            artistDA.EditArtist(artist);
            return RedirectToAction("index");
        }

        // GET: Artist/Delete/5
        public ActionResult Delete(int id)
        {
            Artist artist = artistDA.GetArtistById(id);
            return View(artist);
        }

        // POST: Artist/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            Artist artist = artistDA.GetArtistById(id);
            bool artistFound = artist.ArtistId != 0;

            if (artistFound)
            {
                artistDA.DeleteArtist(artist);
                return RedirectToAction("index");
            }

            return View();
        }

        public ActionResult AlreadyExisting(Artist artist)
        {
            return View("AlreadyExisting");
        }

        [HttpPost]
        public ActionResult AlreadyExisting(int Artistid, string submit)
        {
            bool viewDetails = submit == "yes";
            if (viewDetails)
            {
                return RedirectToAction("Details", new { id = Artistid });
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            artistDA.Dispose();
            base.Dispose(disposing);
        }
    }
}
