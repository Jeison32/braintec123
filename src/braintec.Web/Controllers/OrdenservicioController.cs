using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using braintec.Infrastructure.Data;

namespace braintec.Web.Controllers
{
    public class OrdenservicioController : Controller
    {
        private readonly braintecDbContext _context;

        public OrdenservicioController(braintecDbContext context)
        {
            _context = context;
        }

        // GET: Ordenservicio
        public async Task<IActionResult> Index()
        {
            var braintecDbContext = _context.Ordenservicio.Include(o => o.IdestordenservNavigation).Include(o => o.IdprioridadNavigation).Include(o => o.IdservicioNavigation).Include(o => o.NumdocumentoNavigation).Include(o => o.PlacavehiculoNavigation);
            return View(await braintecDbContext.ToListAsync());
        }

        // GET: Ordenservicio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenservicio = await _context.Ordenservicio
                .Include(o => o.IdestordenservNavigation)
                .Include(o => o.IdprioridadNavigation)
                .Include(o => o.IdservicioNavigation)
                .Include(o => o.NumdocumentoNavigation)
                .Include(o => o.PlacavehiculoNavigation)
                .FirstOrDefaultAsync(m => m.Idcasoservicio == id);
            if (ordenservicio == null)
            {
                return NotFound();
            }

            return View(ordenservicio);
        }

        // GET: Ordenservicio/Create
        public IActionResult Create()
        {
            ViewData["Idestordenserv"] = new SelectList(_context.Estadoordenserv, "Idestordenserv", "Idestordenserv");
            ViewData["Idprioridad"] = new SelectList(_context.Tprioridad, "Idprioridad", "Idprioridad");
            ViewData["Idservicio"] = new SelectList(_context.Tservicio, "Idservicio", "Idservicio");
            ViewData["Numdocumento"] = new SelectList(_context.Tusuario, "Numdocumento", "Numdocumento");
            ViewData["Placavehiculo"] = new SelectList(_context.Tvehiculo, "Placavehiculo", "Placavehiculo");
            return View();
        }

        // POST: Ordenservicio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcasoservicio,Resumenservicio,Numdocumento,Placavehiculo,Idservicio,Idestordenserv,Idprioridad")] Ordenservicio ordenservicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenservicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idestordenserv"] = new SelectList(_context.Estadoordenserv, "Idestordenserv", "Idestordenserv", ordenservicio.Idestordenserv);
            ViewData["Idprioridad"] = new SelectList(_context.Tprioridad, "Idprioridad", "Idprioridad", ordenservicio.Idprioridad);
            ViewData["Idservicio"] = new SelectList(_context.Tservicio, "Idservicio", "Idservicio", ordenservicio.Idservicio);
            ViewData["Numdocumento"] = new SelectList(_context.Tusuario, "Numdocumento", "Numdocumento", ordenservicio.Numdocumento);
            ViewData["Placavehiculo"] = new SelectList(_context.Tvehiculo, "Placavehiculo", "Placavehiculo", ordenservicio.Placavehiculo);
            return View(ordenservicio);
        }

        // GET: Ordenservicio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenservicio = await _context.Ordenservicio.FindAsync(id);
            if (ordenservicio == null)
            {
                return NotFound();
            }
            ViewData["Idestordenserv"] = new SelectList(_context.Estadoordenserv, "Idestordenserv", "Idestordenserv", ordenservicio.Idestordenserv);
            ViewData["Idprioridad"] = new SelectList(_context.Tprioridad, "Idprioridad", "Idprioridad", ordenservicio.Idprioridad);
            ViewData["Idservicio"] = new SelectList(_context.Tservicio, "Idservicio", "Idservicio", ordenservicio.Idservicio);
            ViewData["Numdocumento"] = new SelectList(_context.Tusuario, "Numdocumento", "Numdocumento", ordenservicio.Numdocumento);
            ViewData["Placavehiculo"] = new SelectList(_context.Tvehiculo, "Placavehiculo", "Placavehiculo", ordenservicio.Placavehiculo);
            return View(ordenservicio);
        }

        // POST: Ordenservicio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcasoservicio,Resumenservicio,Numdocumento,Placavehiculo,Idservicio,Idestordenserv,Idprioridad")] Ordenservicio ordenservicio)
        {
            if (id != ordenservicio.Idcasoservicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenservicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenservicioExists(ordenservicio.Idcasoservicio))
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
            ViewData["Idestordenserv"] = new SelectList(_context.Estadoordenserv, "Idestordenserv", "Idestordenserv", ordenservicio.Idestordenserv);
            ViewData["Idprioridad"] = new SelectList(_context.Tprioridad, "Idprioridad", "Idprioridad", ordenservicio.Idprioridad);
            ViewData["Idservicio"] = new SelectList(_context.Tservicio, "Idservicio", "Idservicio", ordenservicio.Idservicio);
            ViewData["Numdocumento"] = new SelectList(_context.Tusuario, "Numdocumento", "Numdocumento", ordenservicio.Numdocumento);
            ViewData["Placavehiculo"] = new SelectList(_context.Tvehiculo, "Placavehiculo", "Placavehiculo", ordenservicio.Placavehiculo);
            return View(ordenservicio);
        }

        // GET: Ordenservicio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenservicio = await _context.Ordenservicio
                .Include(o => o.IdestordenservNavigation)
                .Include(o => o.IdprioridadNavigation)
                .Include(o => o.IdservicioNavigation)
                .Include(o => o.NumdocumentoNavigation)
                .Include(o => o.PlacavehiculoNavigation)
                .FirstOrDefaultAsync(m => m.Idcasoservicio == id);
            if (ordenservicio == null)
            {
                return NotFound();
            }

            return View(ordenservicio);
        }

        // POST: Ordenservicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenservicio = await _context.Ordenservicio.FindAsync(id);
            _context.Ordenservicio.Remove(ordenservicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenservicioExists(int id)
        {
            return _context.Ordenservicio.Any(e => e.Idcasoservicio == id);
        }
    }
}
