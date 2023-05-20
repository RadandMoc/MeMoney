using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeMoney.DBases;

namespace MeMoney.Controler
{
    public class MemsController : Controller
    {
        private readonly MyDbContext _context;

        public MemsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Mems
        public async Task<IActionResult> Index()
        {
              return _context.Mem != null ? 
                          View(await _context.Mem.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Mem'  is null.");
        }

        // GET: Mems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mem == null)
            {
                return NotFound();
            }

            var mem = await _context.Mem
                .FirstOrDefaultAsync(m => m.IdMem == id);
            if (mem == null)
            {
                return NotFound();
            }

            return View(mem);
        }

        // GET: Mems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMem,MemLink")] Mem mem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mem);
        }

        // GET: Mems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mem == null)
            {
                return NotFound();
            }

            var mem = await _context.Mem.FindAsync(id);
            if (mem == null)
            {
                return NotFound();
            }
            return View(mem);
        }

        // POST: Mems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMem,MemLink")] Mem mem)
        {
            if (id != mem.IdMem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemExists(mem.IdMem))
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
            return View(mem);
        }

        // GET: Mems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mem == null)
            {
                return NotFound();
            }

            var mem = await _context.Mem
                .FirstOrDefaultAsync(m => m.IdMem == id);
            if (mem == null)
            {
                return NotFound();
            }

            return View(mem);
        }

        // POST: Mems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mem == null)
            {
                return Problem("Entity set 'MyDbContext.Mem'  is null.");
            }
            var mem = await _context.Mem.FindAsync(id);
            if (mem != null)
            {
                _context.Mem.Remove(mem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemExists(int id)
        {
          return (_context.Mem?.Any(e => e.IdMem == id)).GetValueOrDefault();
        }
    }
}
