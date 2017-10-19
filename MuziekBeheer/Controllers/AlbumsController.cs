﻿using DataLayerFramework;
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

            var getAlbumByName = from a in songsDb.Albums
                                    where a.AlbumName == album.AlbumName
                                    select a;
            
            if (getAlbumByName.Count() == 0)
            {
                songsDb.Albums.Add(album);
                songsDb.SaveChanges();
                return RedirectToAction("index"); 
            }
            else
            {
                List<Album> existingAlbums = getAlbumByName.ToList();
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

            var album = songsDb.Albums.Find(id);

            if (album != null)
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
        public ActionResult AlreadyExisting(int Albumid)
        {
            return RedirectToAction("Details", new { id = Albumid });
        }

        protected override void Dispose(bool disposing)
        {
            songsDb.Dispose();
            base.Dispose(disposing);
        }
    }
}
