using ArriendoPocket.Data;
using ArriendoPocket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArriendoPocket.Controllers
{
    public class PropiedadesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Arrendatario> _userManager;
        public PropiedadesController(ApplicationDbContext context, UserManager<Arrendatario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Propiedades
        [Authorize]
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Propiedad propiedad)
        {
            // 1. Obtener el ID del usuario autenticado
            var userId = _userManager.GetUserId(User);
            propiedad.ArrendatarioID = userId;

            // 2. Limpiar campos que no se envían desde el formulario, pero son necesarios para insertar
            ModelState.Remove(nameof(propiedad.ArrendatarioID));
            ModelState.Remove(nameof(propiedad.Propietario));

            // 3. Debug: imprimir datos recibidos
            Console.WriteLine("[DEBUG] Usuario autenticado ID: " + userId);
            Console.WriteLine("[DEBUG] Propiedad recibida:");
            Console.WriteLine("Nombre Inquilino: " + propiedad.NombreInquilino);
            Console.WriteLine("Alias Propiedad: " + propiedad.AliasPropiedad);
            Console.WriteLine("Canon: " + propiedad.CanonArrendatario);
            Console.WriteLine("ArrendatarioID (desde sesión): " + propiedad.ArrendatarioID);

            // 4. Validar modelo y guardar si es correcto
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(propiedad);
                    await _context.SaveChangesAsync();
                    Console.WriteLine("[DEBUG] Propiedad creada exitosamente.");
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[ERROR] Error al guardar propiedad: " + ex.Message);
                    ModelState.AddModelError("", "Ocurrió un error al guardar la propiedad.");
                }
            }
            else
            {
                Console.WriteLine("[ERROR] ModelState inválido:");
                foreach (var kvp in ModelState)
                {
                    foreach (var err in kvp.Value.Errors)
                    {
                        Console.WriteLine($"[ERROR] Campo: {kvp.Key}, Error: {err.ErrorMessage}");
                    }
                }
            }

            // 5. Recargar dropdown por si se vuelve a mostrar la vista
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
