using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TollPlaza_PrabhDeep.Data;
using TollPlaza_PrabhDeep.Models;

namespace TollPlaza_PrabhDeep.Controllers
{
    [Authorize]
    public class TollPricesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TollPricesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TollPrices
        public async Task<IActionResult> Index()
        {
            return View(await _context.TollPrices.ToListAsync());
        }

        // GET: TollPrices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollPrice = await _context.TollPrices
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tollPrice == null)
            {
                return NotFound();
            }

            return View(tollPrice);
        }

        // GET: TollPrices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TollPrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Charges")] TollPrice tollPrice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tollPrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tollPrice);
        }

        // GET: TollPrices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollPrice = await _context.TollPrices.FindAsync(id);
            if (tollPrice == null)
            {
                return NotFound();
            }
            return View(tollPrice);
        }

        // POST: TollPrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Charges")] TollPrice tollPrice)
        {
            if (id != tollPrice.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tollPrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TollPriceExists(tollPrice.ID))
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
            return View(tollPrice);
        }

        // GET: TollPrices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollPrice = await _context.TollPrices
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tollPrice == null)
            {
                return NotFound();
            }

            return View(tollPrice);
        }

        // POST: TollPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tollPrice = await _context.TollPrices.FindAsync(id);
            _context.TollPrices.Remove(tollPrice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TollPriceExists(int id)
        {
            return _context.TollPrices.Any(e => e.ID == id);
        }
    }
}
