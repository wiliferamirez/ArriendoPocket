using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArriendoPocket.Data;
using ArriendoPocket.Models;

namespace ArriendoPocket.Controllers
{
    public class PropiedadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropiedadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Propiedades
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Propiedades.Include(p => p.Propietario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Propiedades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propiedad = await _context.Propiedades
                .Include(p => p.Propietario)
                .FirstOrDefaultAsync(m => m.PropiedadID == id);
            if (propiedad == null)
            {
                return NotFound();
            }

            return View(propiedad);
        }

        // GET: Propiedades/Create
        public IActionResult Create()
        {
            ViewData["ArrendatarioID"] = new SelectList(_context.Arrendatarios, "Id", "Id");
            return View();
        }

        // POST: Propiedades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropiedadID,ArrendatarioID,NombreInquilino,AliasPropiedad,DireccionPropiedad,NumeroHabitaciones,CanonArrendatario,Disponible,MesesGarantia,NumeroPisos,AreaConstruccion,CiudadUbicacion,FechaConstruccion,FechaCreacion")] Propiedad propiedad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propiedad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArrendatarioID"] = new SelectList(_context.Arrendatarios, "Id", "Id", propiedad.ArrendatarioID);
            return View(propiedad);
        }

        // GET: Propiedades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propiedad = await _context.Propiedades.FindAsync(id);
            if (propiedad == null)
            {
                return NotFound();
            }
            ViewData["ArrendatarioID"] = new SelectList(_context.Arrendatarios, "Id", "Id", propiedad.ArrendatarioID);
            return View(propiedad);
        }

        // POST: Propiedades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PropiedadID,ArrendatarioID,NombreInquilino,AliasPropiedad,DireccionPropiedad,NumeroHabitaciones,CanonArrendatario,Disponible,MesesGarantia,NumeroPisos,AreaConstruccion,CiudadUbicacion,FechaConstruccion,FechaCreacion")] Propiedad propiedad)
        {
            if (id != propiedad.PropiedadID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propiedad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropiedadExists(propiedad.PropiedadID))
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
            ViewData["ArrendatarioID"] = new SelectList(_context.Arrendatarios, "Id", "Id", propiedad.ArrendatarioID);
            return View(propiedad);
        }

        // GET: Propiedades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propiedad = await _context.Propiedades
                .Include(p => p.Propietario)
                .FirstOrDefaultAsync(m => m.PropiedadID == id);
            if (propiedad == null)
            {
                return NotFound();
            }

            return View(propiedad);
        }

        // POST: Propiedades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propiedad = await _context.Propiedades.FindAsync(id);
            if (propiedad != null)
            {
                _context.Propiedades.Remove(propiedad);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropiedadExists(int id)
        {
            return _context.Propiedades.Any(e => e.PropiedadID == id);
        }
    }
}
