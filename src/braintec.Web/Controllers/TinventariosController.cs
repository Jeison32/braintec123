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
    public class TinventariosController : Controller
    {
        private readonly braintecDbContext _context;

        public TinventariosController(braintecDbContext context)
        {
            _context = context;
        }

        // GET: Tinventarios
        public async Task<IActionResult> Index()
        {
            var braintecDbContext = _context.Tinventario.Include(t => t.IdcategoriaNavigation).Include(t => t.IdproveedorNavigation);
            return View(await braintecDbContext.ToListAsync());
        }

        // GET: Tinventarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinventario = await _context.Tinventario
                .Include(t => t.IdcategoriaNavigation)
                .Include(t => t.IdproveedorNavigation)
                .FirstOrDefaultAsync(m => m.Refrepuesto == id);
            if (tinventario == null)
            {
                return NotFound();
            }

            return View(tinventario);
        }

        // GET: Tinventarios/Create
        public IActionResult Create()
        {
            ViewData["Idcategoria"] = new SelectList(_context.Tcategoria, "Idcategoria", "Idcategoria");
            ViewData["Idproveedor"] = new SelectList(_context.Tproveedor, "Idproveedor", "Idproveedor");
            return View();
        }

        // POST: Tinventarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Refrepuesto,Nombrerepuesto,Marcarepuesto,Cantidadexistente,Tarifarepuesto,Idcategoria,Idproveedor")] Tinventario tinventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tinventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcategoria"] = new SelectList(_context.Tcategoria, "Idcategoria", "Idcategoria", tinventario.Idcategoria);
            ViewData["Idproveedor"] = new SelectList(_context.Tproveedor, "Idproveedor", "Idproveedor", tinventario.Idproveedor);
            return View(tinventario);
        }

        // GET: Tinventarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinventario = await _context.Tinventario.FindAsync(id);
            if (tinventario == null)
            {
                return NotFound();
            }
            ViewData["Idcategoria"] = new SelectList(_context.Tcategoria, "Idcategoria", "Idcategoria", tinventario.Idcategoria);
            ViewData["Idproveedor"] = new SelectList(_context.Tproveedor, "Idproveedor", "Idproveedor", tinventario.Idproveedor);
            return View(tinventario);
        }

        // POST: Tinventarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Refrepuesto,Nombrerepuesto,Marcarepuesto,Cantidadexistente,Tarifarepuesto,Idcategoria,Idproveedor")] Tinventario tinventario)
        {
            if (id != tinventario.Refrepuesto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tinventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinventarioExists(tinventario.Refrepuesto))
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
            ViewData["Idcategoria"] = new SelectList(_context.Tcategoria, "Idcategoria", "Idcategoria", tinventario.Idcategoria);
            ViewData["Idproveedor"] = new SelectList(_context.Tproveedor, "Idproveedor", "Idproveedor", tinventario.Idproveedor);
            return View(tinventario);
        }

        // GET: Tinventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinventario = await _context.Tinventario
                .Include(t => t.IdcategoriaNavigation)
                .Include(t => t.IdproveedorNavigation)
                .FirstOrDefaultAsync(m => m.Refrepuesto == id);
            if (tinventario == null)
            {
                return NotFound();
            }

            return View(tinventario);
        }

        // POST: Tinventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tinventario = await _context.Tinventario.FindAsync(id);
            _context.Tinventario.Remove(tinventario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TinventarioExists(int id)
        {
            return _context.Tinventario.Any(e => e.Refrepuesto == id);
        }
    }
}
