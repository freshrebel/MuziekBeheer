using DataLayerFramework;
using DataModelsFramework;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace MuziekBeheer.Controllers
{
    public class AlbumsController : Controller
    {

        AlbumDA albumDA = new AlbumDA();

        // GET: Albums
        public ActionResult Index()
        {
            List<Album> albums = albumDA.GetAllAlbums();

            return View(albums);
        }

        // GET: Albums/Details/5
        public ActionResult Details(int id)
        {
            Album album = albumDA.GetAlbumById(id);
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
            Album albumByName = albumDA.GetAlbumByName(album.AlbumName);
            bool albumFound = albumByName.AlbumId != 0;

            if (!albumFound)
            {
                albumDA.AddAlbum(album);
                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("AlreadyExisting", albumByName);
            }
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {
            Album album = albumDA.GetAlbumById(id);
            bool albumFound = album.AlbumId != 0;
            if (!albumFound)
            {
                return View("NotFound");
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Album Album)
        {
            Album album = albumDA.GetAlbumById(id);
            albumDA.EditAlbum(album);
            return RedirectToAction("Index");
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int id)
        {
            Album album = albumDA.GetAlbumById(id);
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

            Album album = albumDA.GetAlbumById(id);

            bool albumExists = album != null;
            if (albumExists)
            {
                albumDA.DeleteAlbum(album);
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

        // how to transfer this one?
        //ToDo Delete property songsDb
        protected override void Dispose(bool disposing)
        {
            albumDA.Dispose();
            base.Dispose(disposing);
        }
    }
}
