using Microsoft.AspNetCore.Mvc;
using AlbumApp.Entities;
using System.Linq;
using AlbumApp.Models;

namespace AlbumApp.Controllers
{
    public class AlbumController : Controller
    {
        private readonly AlbumsDbContext _context;

        public AlbumController(AlbumsDbContext context)
        {
            _context = context;
        }

        public IActionResult Items()
        {
            var albums = _context.Albums.OrderByDescending(a => a.Rating).ToList();
            return View(albums);
        }

        public IActionResult Details(int id)
        {
            var album = _context.Albums.Find(id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                _context.SaveChanges();
                TempData["Message"] = "Album created successfully!";
                return RedirectToAction(nameof(Items));
            }
            return View(album);
        }

        public IActionResult Edit(int id)
        {
            var album = _context.Albums.Find(id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Album album)
        {
            if (id != album.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(album);
                _context.SaveChanges();
                TempData["Message"] = "Album updated successfully!";
                return RedirectToAction(nameof(Items));
            }
            return View(album);
        }
    }
}