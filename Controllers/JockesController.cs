using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using app1.Data;
using app1.Models;

namespace app1.Controllers
{
    public class JockesController : Controller
    {
        private readonly app1Context _context;

        public JockesController(app1Context context)
        {
            _context = context;
        }

        // GET: Jockes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Jocke.ToListAsync());
        }

        // GET: Jockes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jocke == null)
            {
                return NotFound();
            }

            var jocke = await _context.Jocke
                .FirstOrDefaultAsync(m => m.id == id);
            if (jocke == null)
            {
                return NotFound();
            }

            return View(jocke);
        }

        // GET: Jockes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jockes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,JokeQuestion,JokeAnswer")] Jocke jocke)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jocke);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jocke);
        }

        // GET: Jockes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jocke == null)
            {
                return NotFound();
            }

            var jocke = await _context.Jocke.FindAsync(id);
            if (jocke == null)
            {
                return NotFound();
            }
            return View(jocke);
        }

        // POST: Jockes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,JokeQuestion,JokeAnswer")] Jocke jocke)
        {
            if (id != jocke.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jocke);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JockeExists(jocke.id))
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
            return View(jocke);
        }

        // GET: Jockes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jocke == null)
            {
                return NotFound();
            }

            var jocke = await _context.Jocke
                .FirstOrDefaultAsync(m => m.id == id);
            if (jocke == null)
            {
                return NotFound();
            }

            return View(jocke);
        }

        // POST: Jockes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jocke == null)
            {
                return Problem("Entity set 'app1Context.Jocke'  is null.");
            }
            var jocke = await _context.Jocke.FindAsync(id);
            if (jocke != null)
            {
                _context.Jocke.Remove(jocke);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JockeExists(int id)
        {
          return _context.Jocke.Any(e => e.id == id);
        }
    }
}
