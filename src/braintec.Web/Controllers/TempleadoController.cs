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
    public class TempleadoController : Controller
    {
        private readonly braintecDbContext _context;

        public TempleadoController(braintecDbContext context)
        {
            _context = context;
        }

        // GET: Templeado
        public async Task<IActionResult> Index()
        {
            var braintecDbContext = _context.Templeado.Include(t => t.IdestadouNavigation).Include(t => t.IdrolesNavigation).Include(t => t.NumdocumentoNavigation);
            return View(await braintecDbContext.ToListAsync());
        }

        // GET: Templeado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var templeado = await _context.Templeado
                .Include(t => t.IdestadouNavigation)
                .Include(t => t.IdrolesNavigation)
                .Include(t => t.NumdocumentoNavigation)
                .FirstOrDefaultAsync(m => m.Idempleado == id);
            if (templeado == null)
            {
                return NotFound();
            }

            return View(templeado);
        }

        // GET: Templeado/Create
        public IActionResult Create()
        {
            ViewData["Idestadou"] = new SelectList(_context.Estadousuarioemp, "Idestadou", "Idestadou");
            ViewData["Idroles"] = new SelectList(_context.Troles, "Idroles", "Idroles");
            ViewData["Numdocumento"] = new SelectList(_context.Tusuario, "Numdocumento", "Numdocumento");
            return View();
        }

        // POST: Templeado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idempleado,Cargoempleado,Usuarioempleado,Contrasenaempleado,Fcreacion,Fultimoacceso,Numdocumento,Idroles,Idestadou")] Templeado templeado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(templeado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idestadou"] = new SelectList(_context.Estadousuarioemp, "Idestadou", "Idestadou", templeado.Idestadou);
            ViewData["Idroles"] = new SelectList(_context.Troles, "Idroles", "Idroles", templeado.Idroles);
            ViewData["Numdocumento"] = new SelectList(_context.Tusuario, "Numdocumento", "Numdocumento", templeado.Numdocumento);
            return View(templeado);
        }

        // GET: Templeado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var templeado = await _context.Templeado.FindAsync(id);
            if (templeado == null)
            {
                return NotFound();
            }
            ViewData["Idestadou"] = new SelectList(_context.Estadousuarioemp, "Idestadou", "Idestadou", templeado.Idestadou);
            ViewData["Idroles"] = new SelectList(_context.Troles, "Idroles", "Idroles", templeado.Idroles);
            ViewData["Numdocumento"] = new SelectList(_context.Tusuario, "Numdocumento", "Numdocumento", templeado.Numdocumento);
            return View(templeado);
        }

        // POST: Templeado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idempleado,Cargoempleado,Usuarioempleado,Contrasenaempleado,Fcreacion,Fultimoacceso,Numdocumento,Idroles,Idestadou")] Templeado templeado)
        {
            if (id != templeado.Idempleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(templeado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TempleadoExists(templeado.Idempleado))
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
            ViewData["Idestadou"] = new SelectList(_context.Estadousuarioemp, "Idestadou", "Idestadou", templeado.Idestadou);
            ViewData["Idroles"] = new SelectList(_context.Troles, "Idroles", "Idroles", templeado.Idroles);
            ViewData["Numdocumento"] = new SelectList(_context.Tusuario, "Numdocumento", "Numdocumento", templeado.Numdocumento);
            return View(templeado);
        }

        // GET: Templeado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var templeado = await _context.Templeado
                .Include(t => t.IdestadouNavigation)
                .Include(t => t.IdrolesNavigation)
                .Include(t => t.NumdocumentoNavigation)
                .FirstOrDefaultAsync(m => m.Idempleado == id);
            if (templeado == null)
            {
                return NotFound();
            }

            return View(templeado);
        }

        // POST: Templeado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var templeado = await _context.Templeado.FindAsync(id);
            _context.Templeado.Remove(templeado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TempleadoExists(int id)
        {
            return _context.Templeado.Any(e => e.Idempleado == id);
        }
    }
}
