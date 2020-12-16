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
    public class TvehiculoController : Controller
    {
        private readonly braintecDbContext _context;

        public TvehiculoController(braintecDbContext context)
        {
            _context = context;
        }

        // GET: Tvehiculo
        public async Task<IActionResult> Index()
        {
            var braintecDbContext = _context.Tvehiculo.Include(t => t.NumdocumentoNavigation);
            return View(await braintecDbContext.ToListAsync());
        }

        // GET: Tvehiculo/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvehiculo = await _context.Tvehiculo
                .Include(t => t.NumdocumentoNavigation)
                .FirstOrDefaultAsync(m => m.Placavehiculo == id);
            if (tvehiculo == null)
            {
                return NotFound();
            }

            return View(tvehiculo);
        }

        // GET: Tvehiculo/Create
        public IActionResult Create()
        {
            ViewData["Numdocumento"] = new SelectList(_context.Tusuario, "Numdocumento", "Numdocumento");
            return View();
        }

        // POST: Tvehiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Placavehiculo,Marcavehiculo,Modelovehiculo,Cilindrajevehiculo,Kilometrajevehiculo,Trasmisionvehiculo,Aniovehiculo,Numdocumento")] Tvehiculo tvehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tvehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Numdocumento"] = new SelectList(_context.Tusuario, "Numdocumento", "Numdocumento", tvehiculo.Numdocumento);
            return View(tvehiculo);
        }

        // GET: Tvehiculo/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvehiculo = await _context.Tvehiculo.FindAsync(id);
            if (tvehiculo == null)
            {
                return NotFound();
            }
            ViewData["Numdocumento"] = new SelectList(_context.Tusuario, "Numdocumento", "Numdocumento", tvehiculo.Numdocumento);
            return View(tvehiculo);
        }

        // POST: Tvehiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Placavehiculo,Marcavehiculo,Modelovehiculo,Cilindrajevehiculo,Kilometrajevehiculo,Trasmisionvehiculo,Aniovehiculo,Numdocumento")] Tvehiculo tvehiculo)
        {
            if (id != tvehiculo.Placavehiculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvehiculoExists(tvehiculo.Placavehiculo))
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
            ViewData["Numdocumento"] = new SelectList(_context.Tusuario, "Numdocumento", "Numdocumento", tvehiculo.Numdocumento);
            return View(tvehiculo);
        }

        // GET: Tvehiculo/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvehiculo = await _context.Tvehiculo
                .Include(t => t.NumdocumentoNavigation)
                .FirstOrDefaultAsync(m => m.Placavehiculo == id);
            if (tvehiculo == null)
            {
                return NotFound();
            }

            return View(tvehiculo);
        }

        // POST: Tvehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tvehiculo = await _context.Tvehiculo.FindAsync(id);
            _context.Tvehiculo.Remove(tvehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvehiculoExists(string id)
        {
            return _context.Tvehiculo.Any(e => e.Placavehiculo == id);
        }
    }
}
