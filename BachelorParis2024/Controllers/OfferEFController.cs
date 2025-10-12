using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BachelorParis2024.Domain.Models;
using BachelorParis2024.Repository.Context;

//CRUD créé par Entityframework pour la gestion des offres dans la BDD
//Scaffold item

namespace BachelorParis2024.Controllers
{
    public class OfferEFController : Controller
    {
        private readonly DbProjectContext _context;

        public OfferEFController(DbProjectContext context)
        {
            _context = context;
        }

        // GET: OfferEF
        public async Task<IActionResult> Index()
        {
            try
            {
                var offres = await _context.Offre.ToListAsync();
                return View(offres);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // GET: OfferEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerModel = await _context.Offre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offerModel == null)
            {
                return NotFound();
            }

            return View(offerModel);
        }

        // GET: OfferEF/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OfferEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PersonsNumber,Description,Price,Conditions,ImageUrl")] OfferModel offerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(offerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(offerModel);
        }

        // GET: OfferEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerModel = await _context.Offre.FindAsync(id);
            if (offerModel == null)
            {
                return NotFound();
            }
            return View(offerModel);
        }

        // POST: OfferEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PersonsNumber,Description,Price,Conditions,ImageUrl")] OfferModel offerModel)
        {
            if (id != offerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferModelExists(offerModel.Id))
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
            return View(offerModel);
        }

        // GET: OfferEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerModel = await _context.Offre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offerModel == null)
            {
                return NotFound();
            }

            return View(offerModel);
        }

        // POST: OfferEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var offerModel = await _context.Offre.FindAsync(id);
            if (offerModel != null)
            {
                _context.Offre.Remove(offerModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfferModelExists(int id)
        {
            return _context.Offre.Any(e => e.Id == id);
        }
    }
}
