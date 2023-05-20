﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeMoney.DBases;
using MeMoney.Pages;

namespace MeMoney.Controler
{
    public class MemAuthorsController : Controller
    {
        private readonly MyDbContext _context;

        public MemAuthorsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: MemAuthors
        public async Task<IActionResult> Index()
        {
              return _context.MemAuthor != null ? 
                          View(await _context.MemAuthor.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.MemAuthor'  is null.");
        }

        // GET: MemAuthors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MemAuthor == null)
            {
                return NotFound();
            }

            var memAuthor = await _context.MemAuthor
                .FirstOrDefaultAsync(m => m.IdMemAuthor == id);
            if (memAuthor == null)
            {
                return NotFound();
            }

            return View(memAuthor);
        }

        public IActionResult Add() 
        {
            return View();

        }

        // GET: MemAuthors/Create
        public async Task<IActionResult> Add(MemAuthorModel addAuthorModel)
        {
            var memAuthor = new MemAuthor();
            memAuthor.NickName = addAuthorModel.Name;
            memAuthor.Imie = addAuthorModel.Imie;
            memAuthor.BankAccountNumber = addAuthorModel.BankAccountNumber;
            await _context.MemAuthor.AddAsync(memAuthor);    
            await _context.SaveChangesAsync();
            return RedirectToAction("Add");
        }




        // POST: MemAuthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMemAuthor,NickName,Imie,Nazwisko,BankAccountNumber")] MemAuthor memAuthor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memAuthor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //return View(memAuthor);
            return View(memAuthor);
        }

        // GET: MemAuthors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MemAuthor == null)
            {
                return NotFound();
            }

            var memAuthor = await _context.MemAuthor.FindAsync(id);
            if (memAuthor == null)
            {
                return NotFound();
            }
            return View(memAuthor);
        }

        // POST: MemAuthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMemAuthor,NickName,Imie,Nazwisko,BankAccountNumber")] MemAuthor memAuthor)
        {
            if (id != memAuthor.IdMemAuthor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memAuthor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemAuthorExists(memAuthor.IdMemAuthor))
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
            return View(memAuthor);
        }

        // GET: MemAuthors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MemAuthor == null)
            {
                return NotFound();
            }

            var memAuthor = await _context.MemAuthor
                .FirstOrDefaultAsync(m => m.IdMemAuthor == id);
            if (memAuthor == null)
            {
                return NotFound();
            }

            return View(memAuthor);
        }

        // POST: MemAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MemAuthor == null)
            {
                return Problem("Entity set 'MyDbContext.MemAuthor'  is null.");
            }
            var memAuthor = await _context.MemAuthor.FindAsync(id);
            if (memAuthor != null)
            {
                _context.MemAuthor.Remove(memAuthor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemAuthorExists(int id)
        {
          return (_context.MemAuthor?.Any(e => e.IdMemAuthor == id)).GetValueOrDefault();
        }
    }
}
