using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalKendaran.Models;

namespace RentalKendaran.Controllers
{
    public class KondisisController : Controller
    {
        private readonly RentKendaraanContext _context;

        public KondisisController(RentKendaraanContext context)
        {
            _context = context;
        }

        // GET: Kondisis
        public async Task<IActionResult> Index()
        {
            var rentKendaraanContext = _context.Kondisis.Include(k => k.IdKondisiNavigation);
            return View(await rentKendaraanContext.ToListAsync());
        }

        // GET: Kondisis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kondisi = await _context.Kondisis
                .Include(k => k.IdKondisiNavigation)
                .FirstOrDefaultAsync(m => m.IdKondisi == id);
            if (kondisi == null)
            {
                return NotFound();
            }

            return View(kondisi);
        }

        // GET: Kondisis/Create
        public IActionResult Create()
        {
            ViewData["IdKondisi"] = new SelectList(_context.Pengembaliaans, "IdPengembalian", "IdPengembalian");
            return View();
        }

        // POST: Kondisis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKondisi,NamaKondisi")] Kondisi kondisi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kondisi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKondisi"] = new SelectList(_context.Pengembaliaans, "IdPengembalian", "IdPengembalian", kondisi.IdKondisi);
            return View(kondisi);
        }

        // GET: Kondisis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kondisi = await _context.Kondisis.FindAsync(id);
            if (kondisi == null)
            {
                return NotFound();
            }
            ViewData["IdKondisi"] = new SelectList(_context.Pengembaliaans, "IdPengembalian", "IdPengembalian", kondisi.IdKondisi);
            return View(kondisi);
        }

        // POST: Kondisis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKondisi,NamaKondisi")] Kondisi kondisi)
        {
            if (id != kondisi.IdKondisi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kondisi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KondisiExists(kondisi.IdKondisi))
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
            ViewData["IdKondisi"] = new SelectList(_context.Pengembaliaans, "IdPengembalian", "IdPengembalian", kondisi.IdKondisi);
            return View(kondisi);
        }

        // GET: Kondisis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kondisi = await _context.Kondisis
                .Include(k => k.IdKondisiNavigation)
                .FirstOrDefaultAsync(m => m.IdKondisi == id);
            if (kondisi == null)
            {
                return NotFound();
            }

            return View(kondisi);
        }

        // POST: Kondisis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kondisi = await _context.Kondisis.FindAsync(id);
            _context.Kondisis.Remove(kondisi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KondisiExists(int id)
        {
            return _context.Kondisis.Any(e => e.IdKondisi == id);
        }
    }
}
