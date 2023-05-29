using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using muitospramuitos.Data;
using muitospramuitos.Models;

namespace muitospramuitos.Controllers
{
    public class FilhosController : Controller
    {
        private readonly Context _context;

        public FilhosController(Context context)
        {
            _context = context;
        }

        // GET: Filhos
        public async Task<IActionResult> Index()
        {
              return _context.Filhos != null ? 
                          View(await _context.Filhos.ToListAsync()) :
                          Problem("Entity set 'Context.Filhos'  is null.");
        }

        // GET: Filhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Filhos == null)
            {
                return NotFound();
            }

            var filhos = await _context.Filhos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filhos == null)
            {
                return NotFound();
            }

            return View(filhos);
        }

        // GET: Filhos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filhos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Idade,Nascimento,IdPais")] Filhos filhos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filhos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filhos);
        }

        // GET: Filhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Filhos == null)
            {
                return NotFound();
            }

            var filhos = await _context.Filhos.FindAsync(id);
            if (filhos == null)
            {
                return NotFound();
            }
            return View(filhos);
        }

        // POST: Filhos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Idade,Nascimento,IdPais")] Filhos filhos)
        {
            if (id != filhos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filhos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilhosExists(filhos.Id))
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
            return View(filhos);
        }

        // GET: Filhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Filhos == null)
            {
                return NotFound();
            }

            var filhos = await _context.Filhos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filhos == null)
            {
                return NotFound();
            }

            return View(filhos);
        }

        // POST: Filhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Filhos == null)
            {
                return Problem("Entity set 'Context.Filhos'  is null.");
            }
            var filhos = await _context.Filhos.FindAsync(id);
            if (filhos != null)
            {
                _context.Filhos.Remove(filhos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilhosExists(int id)
        {
          return (_context.Filhos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
