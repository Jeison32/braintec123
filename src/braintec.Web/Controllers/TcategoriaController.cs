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
    public class TcategoriaController : Controller
    {
        private readonly braintecDbContext _context;

        public TcategoriaController(braintecDbContext context)
        {
            _context = context;
        }

        // GET: Tcategoria
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tcategoria.ToListAsync());
        }

        // GET: Tcategoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tcategoria = await _context.Tcategoria
                .FirstOrDefaultAsync(m => m.Idcategoria == id);
            if (tcategoria == null)
            {
                return NotFound();
            }

            return View(tcategoria);
        }

        // GET: Tcategoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tcategoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcategoria,Categoriarepuesto")] Tcategoria tcategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tcategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tcategoria);
        }

        // GET: Tcategoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tcategoria = await _context.Tcategoria.FindAsync(id);
            if (tcategoria == null)
            {
                return NotFound();
            }
            return View(tcategoria);
        }

        // POST: Tcategoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcategoria,Categoriarepuesto")] Tcategoria tcategoria)
        {
            if (id != tcategoria.Idcategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tcategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TcategoriaExists(tcategoria.Idcategoria))
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
            return View(tcategoria);
        }

        // GET: Tcategoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tcategoria = await _context.Tcategoria
                .FirstOrDefaultAsync(m => m.Idcategoria == id);
            if (tcategoria == null)
            {
                return NotFound();
            }

            return View(tcategoria);
        }

        // POST: Tcategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tcategoria = await _context.Tcategoria.FindAsync(id);
            _context.Tcategoria.Remove(tcategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TcategoriaExists(int id)
        {
            return _context.Tcategoria.Any(e => e.Idcategoria == id);
        }
    }
}
