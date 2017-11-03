using DataLayerFramework;
using DataModelsFramework;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Dynamic;

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
            if (album.AlbumId == 0)
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
        public ActionResult Edit(int id, Album album)
        {
            Album existingAlbum = albumDA.GetAlbumByName(album.AlbumName);
            bool albumExists = existingAlbum.AlbumId != 0;
            if (albumExists)
            {
                return RedirectToAction("AlreadyExisting", existingAlbum.AlbumId);
            }
            else
            {
                albumDA.EditAlbum(album);
                return RedirectToAction("Index");
            }            
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int id)
        {
            Album album = albumDA.GetAlbumById(id);
            bool albumExists = album.AlbumId != 0;
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

        public ActionResult AddSong(int id)
        {
            Album album = albumDA.GetAlbumById(id);
            List<Song> songsNotInAlbum = albumDA.GetSongsNotInAlbum(id);
            dynamic albumAndSongs = new ExpandoObject();
            albumAndSongs.Album = album;
            albumAndSongs.Songs = songsNotInAlbum;
            return View(albumAndSongs);
        }

        [HttpPost]
        public ActionResult AddSong(int SongId, int AlbumId)
        {
            albumDA.AddSong(SongId, AlbumId);
            return RedirectToAction("AddSong");
        }

        public ActionResult DeleteSong(int songId, int albumId)
        {
            albumDA.DeleteSong(songId, albumId);
            return RedirectToAction("Details", new { id = albumId });
        }

        protected override void Dispose(bool disposing)
        {
            albumDA.Dispose();
            base.Dispose(disposing);
        }
    }
}
