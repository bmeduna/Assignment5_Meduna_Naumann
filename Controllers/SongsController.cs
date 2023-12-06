using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment5_Meduna_Naumann.Data;
using Assignment5_Meduna_Naumann.Models;

namespace Assignment5_Meduna_Naumann.Controllers
{
    public class SongsController : Controller
    {
        private readonly Assignment5_Meduna_NaumannContext _context;

        public SongsController(Assignment5_Meduna_NaumannContext context)
        {
            _context = context;
        }


        // GET: Browse
        public async Task<IActionResult> Browse(string view_genre, string view_artist)
        {
            if (_context.Song == null) { return Problem("_context.Song == null"); }
            //Default Values START
            IQueryable<string> genreQuery = from song in _context.Song
                                            orderby song.genre
                                            select song.genre;

            IQueryable<string> artistQuery = from song in _context.Song
                                             orderby song.artist
                                             select song.artist;

            var songs = from song in _context.Song
                        select song;
            //Default Values END
            //Filter if not null
            if (!string.IsNullOrEmpty(view_genre) && !string.Equals(view_genre, "ALL"))
            {
                songs = songs.Where(s => s.genre == view_genre);
                artistQuery = from song in _context.Song
                              where song.genre == view_genre
                              orderby song.artist
                              select song.artist;
            }
            if (!string.IsNullOrEmpty(view_artist) && !string.Equals(view_artist, "ALL"))
            {
                songs = songs.Where(s => s.artist == view_artist);
            }
            var viewModel = new SongViewModel
            {
                artists = new SelectList(await artistQuery.Distinct().ToListAsync()),
                genres  = new SelectList(await genreQuery.Distinct().ToListAsync()),
                songs   = await songs.ToListAsync()
            };
            return View(viewModel);
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
              return _context.Song != null ? 
                          View(await _context.Song.ToListAsync()) :
                          Problem("Entity set 'Assignment5_Meduna_NaumannContext.Song'  is null.");
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,title,release_date,genre,artist,price")] Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,title,release_date,genre,artist,price")] Song song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Song == null)
            {
                return Problem("Entity set 'Assignment5_Meduna_NaumannContext.Song'  is null.");
            }
            var song = await _context.Song.FindAsync(id);
            if (song != null)
            {
                _context.Song.Remove(song);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id)
        {
          return (_context.Song?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
