﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeMoney.DBases;
using Microsoft.Data.SqlClient;
using MeMoney.Pages;

namespace MeMoney.Controler
{
    public class OffersController : Controller
    {
        private readonly MyDbContext _context;

        public OffersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Offers
        public async Task<IActionResult> Index()
        {
              return _context.Offer != null ? 
                          View(await _context.Offer.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Offer'  is null.");
        }

        // GET: Offers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Offer == null)
            {
                return NotFound();
            }

            var offer = await _context.Offer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // GET: Offers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyIdCompany1,BasicSalary,AdditionalSalary,ValidFrom,ValidUntil,Condition,AdditionalCondition,IfPaid,MaximalSalary1")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(offer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Debugging: print out the validation errors
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(p => p.ErrorMessage)).ToList();
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
            }
            return View(offer);
        }

        // GET: Offers/Edit/5
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Offer == null)
            {
                return NotFound();
            }

            var offer = await _context.Offer.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }
            return View(offer);
        }
        

        // POST: Offers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyIdCompany1,BasicSalary,AdditionalSalary,ValidFrom,ValidUntil,Condition,AdditionalCondition,IfPaid,MaximalSalary1")] Offer offer)
        {
            if (id != offer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferExists(offer.Id))
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
            else
            {
                // Debugging: print out the validation errors
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(p => p.ErrorMessage)).ToList();
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
            }
            return View(offer);
        }

        // GET: Offers/Delete?id=5
        public async Task<IActionResult> Delete(int id)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=MyDb;Trusted_Connection=True;";
            string queryString = $"DELETE FROM Offer WHERE id={id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
            return View();
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Offer == null)
            {
                return Problem("Entity set 'MyDbContext.Offer'  is null.");
            }
            var offer = await _context.Offer.FindAsync(id);
            if (offer != null)
            {
                _context.Offer.Remove(offer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfferExists(int id)
        {
          return (_context.Offer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
