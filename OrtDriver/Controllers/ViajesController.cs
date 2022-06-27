using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrtDriver.Context;
using OrtDriver.Models;

namespace OrtDriver.Controllers
{
    public class ViajesController : Controller
    {
        private readonly OrtDriverDBContext _context;

        public ViajesController(OrtDriverDBContext context)
        {
            _context = context;
        }

        // GET: Viajes
        public async Task<IActionResult> Index()
        {
            var ortDriverDBContext = _context.Viajes.Include(v => v.Conductor);
            return View(await ortDriverDBContext.ToListAsync());
        }

        // GET: Viajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viajes
                .Include(v => v.Conductor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viaje == null)
            {
                return NotFound();
            }

            return View(viaje);
        }

        // GET: Viajes/Create
        public IActionResult Create()
        {
            ViewData["ConductorId"] = new SelectList(_context.Conductores, "ConductorId", "ConductorName");
            return View();
        }

        // POST: Viajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConductorId,Origen,Destino,FechaInscripto")] Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConductorId"] = new SelectList(_context.Conductores, "ConductorId", "ConductorName", viaje.ConductorId);
            return View(viaje);
        }

        // GET: Viajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viajes.FindAsync(id);
            if (viaje == null)
            {
                return NotFound();
            }
            ViewData["ConductorId"] = new SelectList(_context.Conductores, "ConductorId", "ConductorName", viaje.ConductorId);
            return View(viaje);
        }

        // POST: Viajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConductorId,Origen,Destino,FechaInscripto")] Viaje viaje)
        {
            if (id != viaje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViajeExists(viaje.Id))
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
            ViewData["ConductorId"] = new SelectList(_context.Conductores, "ConductorId", "ConductorName", viaje.ConductorId);
            return View(viaje);
        }

        // GET: Viajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viajes
                .Include(v => v.Conductor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viaje == null)
            {
                return NotFound();
            }

            return View(viaje);
        }

        // POST: Viajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viaje = await _context.Viajes.FindAsync(id);
            _context.Viajes.Remove(viaje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViajeExists(int id)
        {
            return _context.Viajes.Any(e => e.Id == id);
        }
    }
}
