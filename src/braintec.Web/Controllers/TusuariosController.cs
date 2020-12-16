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
    public class TusuariosController : Controller
    {
        private readonly braintecDbContext _context;

        public TusuariosController(braintecDbContext context)
        {
            _context = context;
        }

        // GET: Tusuarios
        public async Task<IActionResult> Index()
        {
            var braintecDbContext = _context.Tusuario.Include(t => t.IddocumentoNavigation);
            return View(await braintecDbContext.ToListAsync());
        }

        // GET: Tusuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tusuario = await _context.Tusuario
                .Include(t => t.IddocumentoNavigation)
                .FirstOrDefaultAsync(m => m.Numdocumento == id);
            if (tusuario == null)
            {
                return NotFound();
            }

            return View(tusuario);
        }

        // GET: Tusuarios/Create
        public IActionResult Create()
        {
            ViewData["Iddocumento"] = new SelectList(_context.Tdocumento, "Iddocumento", "Iddocumento");
            return View();
        }

        // POST: Tusuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Numdocumento,Nombre,Apellido,Telefono,Direccion,Correo,Iddocumento")] Tusuario tusuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tusuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Iddocumento"] = new SelectList(_context.Tdocumento, "Iddocumento", "Iddocumento", tusuario.Iddocumento);
            return View(tusuario);
        }

        // GET: Tusuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tusuario = await _context.Tusuario.FindAsync(id);
            if (tusuario == null)
            {
                return NotFound();
            }
            ViewData["Iddocumento"] = new SelectList(_context.Tdocumento, "Iddocumento", "Iddocumento", tusuario.Iddocumento);
            return View(tusuario);
        }

        // POST: Tusuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Numdocumento,Nombre,Apellido,Telefono,Direccion,Correo,Iddocumento")] Tusuario tusuario)
        {
            if (id != tusuario.Numdocumento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tusuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TusuarioExists(tusuario.Numdocumento))
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
            ViewData["Iddocumento"] = new SelectList(_context.Tdocumento, "Iddocumento", "Iddocumento", tusuario.Iddocumento);
            return View(tusuario);
        }

        // GET: Tusuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tusuario = await _context.Tusuario
                .Include(t => t.IddocumentoNavigation)
                .FirstOrDefaultAsync(m => m.Numdocumento == id);
            if (tusuario == null)
            {
                return NotFound();
            }

            return View(tusuario);
        }

        // POST: Tusuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tusuario = await _context.Tusuario.FindAsync(id);
            _context.Tusuario.Remove(tusuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TusuarioExists(int id)
        {
            return _context.Tusuario.Any(e => e.Numdocumento == id);
        }
    }
}
