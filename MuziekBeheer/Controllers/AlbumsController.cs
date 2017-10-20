using DataLayerFramework;
using DataModelsFramework;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

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
            var getAlbumByIdQuery = from a in songsDb.Albums.Include("SongAlbums.Song")
                        where a.AlbumId == id
                        select a;
            Album album = getAlbumByIdQuery.ToList<Album>()[0];
            album.SongAlbums = album.SongAlbums.OrderBy(a => a.AlbumSequenceNumber).ToList();
            if (album == null)
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

            var getAlbumByNameQuery = from a in songsDb.Albums
                                    where a.AlbumName.ToLower().Trim() == album.AlbumName.ToLower().Trim()
                                    select a;
            
            if (getAlbumByNameQuery.Count() == 0)
            {
                songsDb.Albums.Add(album);
                songsDb.SaveChanges();
                return RedirectToAction("index"); 
            }
            else
            {
                List<Album> existingAlbums = getAlbumByNameQuery.ToList();
                return RedirectToAction("AlreadyExisting", existingAlbums[0]);
            }
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
            Album album = songsDb.Albums.Find(id);
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
            Album album = songsDb.Albums.Find(id);
            bool albumExists = album != null;
            if (!albumExists)
            {
                return View("NotFound");
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            Album album = songsDb.Albums.Find(id);

            bool albumExists = album != null;
            if (albumExists)
            {
                songsDb.Albums.Remove(album);
                songsDb.SaveChanges();
                return RedirectToAction("index");
            }

            return View();
        }

        public ActionResult AlreadyExisting(Album album)
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
            songsDb.Dispose();
            base.Dispose(disposing);
        }
    }
}
