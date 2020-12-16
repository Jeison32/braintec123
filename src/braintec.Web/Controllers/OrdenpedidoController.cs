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
    public class OrdenpedidoController : Controller
    {
        private readonly braintecDbContext _context;

        public OrdenpedidoController(braintecDbContext context)
        {
            _context = context;
        }

        // GET: Ordenpedido
        public async Task<IActionResult> Index()
        {
            var braintecDbContext = _context.Ordenpedido.Include(o => o.IdestordenpedNavigation).Include(o => o.NumdocumentoNavigation).Include(o => o.RefrepuestoNavigation);
            return View(await braintecDbContext.ToListAsync());
        }

        // GET: Ordenpedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenpedido = await _context.Ordenpedido
                .Include(o => o.IdestordenpedNavigation)
                .Include(o => o.NumdocumentoNavigation)
                .Include(o => o.RefrepuestoNavigation)
                .FirstOrDefaultAsync(m => m.Idopedido == id);
            if (ordenpedido == null)
            {
                return NotFound();
            }

            return View(ordenpedido);
        }

        // GET: Ordenpedido/Create
        public IActionResult Create()
        {
            ViewData["Idestordenped"] = new SelectList(_context.Estadoordenped, "Idestordenped", "Idestordenped");
            ViewData["Numdocumento"] = new SelectList(_context.Tusuario, "Numdocumento", "Numdocumento");
            ViewData["Refrepuesto"] = new SelectList(_context.Tinventario, "Refrepuesto", "Refrepuesto");
            return View();
        }

        // POST: Ordenpedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idopedido,Fpedido,Numdocumento,Refrepuesto,Idestordenped")] Ordenpedido ordenpedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenpedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idestordenped"] = new SelectList(_context.Estadoordenped, "Idestordenped", "Idestordenped", ordenpedido.Idestordenped);
            ViewData["Numdocumento"] = new SelectList(_context.Tusuario, "Numdocumento", "Numdocumento", ordenpedido.Numdocumento);
            ViewData["Refrepuesto"] = new SelectList(_context.Tinventario, "Refrepuesto", "Refrepuesto", ordenpedido.Refrepuesto);
            return View(ordenpedido);
        }

        // GET: Ordenpedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenpedido = await _context.Ordenpedido.FindAsync(id);
            if (ordenpedido == null)
            {
                return NotFound();
            }
            ViewData["Idestordenped"] = new SelectList(_context.Estadoordenped, "Idestordenped", "Idestordenped", ordenpedido.Idestordenped);
            ViewData["Numdocumento"] = new SelectList(_context.Tusuario, "Numdocumento", "Numdocumento", ordenpedido.Numdocumento);
            ViewData["Refrepuesto"] = new SelectList(_context.Tinventario, "Refrepuesto", "Refrepuesto", ordenpedido.Refrepuesto);
            return View(ordenpedido);
        }

        // POST: Ordenpedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idopedido,Fpedido,Numdocumento,Refrepuesto,Idestordenped")] Ordenpedido ordenpedido)
        {
            if (id != ordenpedido.Idopedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenpedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenpedidoExists(ordenpedido.Idopedido))
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
            ViewData["Idestordenped"] = new SelectList(_context.Estadoordenped, "Idestordenped", "Idestordenped", ordenpedido.Idestordenped);
            ViewData["Numdocumento"] = new SelectList(_context.Tusuario, "Numdocumento", "Numdocumento", ordenpedido.Numdocumento);
            ViewData["Refrepuesto"] = new SelectList(_context.Tinventario, "Refrepuesto", "Refrepuesto", ordenpedido.Refrepuesto);
            return View(ordenpedido);
        }

        // GET: Ordenpedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenpedido = await _context.Ordenpedido
                .Include(o => o.IdestordenpedNavigation)
                .Include(o => o.NumdocumentoNavigation)
                .Include(o => o.RefrepuestoNavigation)
                .FirstOrDefaultAsync(m => m.Idopedido == id);
            if (ordenpedido == null)
            {
                return NotFound();
            }

            return View(ordenpedido);
        }

        // POST: Ordenpedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenpedido = await _context.Ordenpedido.FindAsync(id);
            _context.Ordenpedido.Remove(ordenpedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenpedidoExists(int id)
        {
            return _context.Ordenpedido.Any(e => e.Idopedido == id);
        }
    }
}
