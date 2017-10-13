using DataLayerFramework;
using DataModelsFramework;
using System.Web.Mvc;

namespace MuziekBeheer.Controllers
{
    public class AlbumsController : Controller
    {

        SongsDb songsDb = new SongsDb();

        // GET: Albums
        public ActionResult Index()
        {
            var albums = songsDb.Albums;

            return View(albums);
        }

        // GET: Albums/Details/5
        public ActionResult Details(int id)
        {
            var album = songsDb.Albums.Find(id);
            if(album == null)
            {
                return View("NotFound");
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        public ActionResult Create(Album album)
        {
            // TODO: check if already exists

            songsDb.Albums.Add(album);
            songsDb.SaveChanges();
            return RedirectToAction("index");

        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {
            var album = songsDb.Albums.Find(id);
            if (album == null)
            {
                return View("NotFound");
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Album Album)
        {
            var album = songsDb.Albums.Find(id);
            if (TryUpdateModel(album))
            {
                songsDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int id)
        {
            var album = songsDb.Albums.Find(id);
            if (album == null)
            {
                return View("NotFound");
            }
            return View(album);
        }

        // POST: Albums/Delete/5
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
