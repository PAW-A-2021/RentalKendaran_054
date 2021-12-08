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
    public class PengembaliaansController : Controller
    {
        private readonly RentKendaraanContext _context;

        public PengembaliaansController(RentKendaraanContext context)
        {
            _context = context;
        }

        // GET: Pengembaliaans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pengembaliaans.ToListAsync());
        }

        // GET: Pengembaliaans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pengembaliaan = await _context.Pengembaliaans
                .FirstOrDefaultAsync(m => m.IdPengembalian == id);
            if (pengembaliaan == null)
            {
                return NotFound();
            }

            return View(pengembaliaan);
        }

        // GET: Pengembaliaans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pengembaliaans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPengembalian,TglPengembalian,IdPeminjaman,IdKondisi,Denda")] Pengembaliaan pengembaliaan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pengembaliaan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pengembaliaan);
        }

        // GET: Pengembaliaans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pengembaliaan = await _context.Pengembaliaans.FindAsync(id);
            if (pengembaliaan == null)
            {
                return NotFound();
            }
            return View(pengembaliaan);
        }

        // POST: Pengembaliaans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPengembalian,TglPengembalian,IdPeminjaman,IdKondisi,Denda")] Pengembaliaan pengembaliaan)
        {
            if (id != pengembaliaan.IdPengembalian)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pengembaliaan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PengembaliaanExists(pengembaliaan.IdPengembalian))
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
            return View(pengembaliaan);
        }

        // GET: Pengembaliaans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pengembaliaan = await _context.Pengembaliaans
                .FirstOrDefaultAsync(m => m.IdPengembalian == id);
            if (pengembaliaan == null)
            {
                return NotFound();
            }

            return View(pengembaliaan);
        }

        // POST: Pengembaliaans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pengembaliaan = await _context.Pengembaliaans.FindAsync(id);
            _context.Pengembaliaans.Remove(pengembaliaan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PengembaliaanExists(int id)
        {
            return _context.Pengembaliaans.Any(e => e.IdPengembalian == id);
        }
    }
}
