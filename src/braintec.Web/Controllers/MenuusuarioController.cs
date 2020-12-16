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
    public class MenuusuarioController : Controller
    {
        private readonly braintecDbContext _context;

        public MenuusuarioController(braintecDbContext context)
        {
            _context = context;
        }

        // GET: Menuusuario
        public async Task<IActionResult> Index()
        {
            var braintecDbContext = _context.Menuusuario.Include(m => m.CodigosubmenuNavigation).Include(m => m.IdrolesNavigation);
            return View(await braintecDbContext.ToListAsync());
        }

        // GET: Menuusuario/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuusuario = await _context.Menuusuario
                .Include(m => m.CodigosubmenuNavigation)
                .Include(m => m.IdrolesNavigation)
                .FirstOrDefaultAsync(m => m.Mcodigo == id);
            if (menuusuario == null)
            {
                return NotFound();
            }

            return View(menuusuario);
        }

        // GET: Menuusuario/Create
        public IActionResult Create()
        {
            ViewData["Codigosubmenu"] = new SelectList(_context.Menuusuario, "Mcodigo", "Mcodigo");
            ViewData["Idroles"] = new SelectList(_context.Troles, "Idroles", "Idroles");
            return View();
        }

        // POST: Menuusuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mcodigo,Mnombre,Url,Tipomenu,Idroles,Codigosubmenu")] Menuusuario menuusuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuusuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Codigosubmenu"] = new SelectList(_context.Menuusuario, "Mcodigo", "Mcodigo", menuusuario.Codigosubmenu);
            ViewData["Idroles"] = new SelectList(_context.Troles, "Idroles", "Idroles", menuusuario.Idroles);
            return View(menuusuario);
        }

        // GET: Menuusuario/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuusuario = await _context.Menuusuario.FindAsync(id);
            if (menuusuario == null)
            {
                return NotFound();
            }
            ViewData["Codigosubmenu"] = new SelectList(_context.Menuusuario, "Mcodigo", "Mcodigo", menuusuario.Codigosubmenu);
            ViewData["Idroles"] = new SelectList(_context.Troles, "Idroles", "Idroles", menuusuario.Idroles);
            return View(menuusuario);
        }

        // POST: Menuusuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Mcodigo,Mnombre,Url,Tipomenu,Idroles,Codigosubmenu")] Menuusuario menuusuario)
        {
            if (id != menuusuario.Mcodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuusuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuusuarioExists(menuusuario.Mcodigo))
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
            ViewData["Codigosubmenu"] = new SelectList(_context.Menuusuario, "Mcodigo", "Mcodigo", menuusuario.Codigosubmenu);
            ViewData["Idroles"] = new SelectList(_context.Troles, "Idroles", "Idroles", menuusuario.Idroles);
            return View(menuusuario);
        }

        // GET: Menuusuario/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuusuario = await _context.Menuusuario
                .Include(m => m.CodigosubmenuNavigation)
                .Include(m => m.IdrolesNavigation)
                .FirstOrDefaultAsync(m => m.Mcodigo == id);
            if (menuusuario == null)
            {
                return NotFound();
            }

            return View(menuusuario);
        }

        // POST: Menuusuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var menuusuario = await _context.Menuusuario.FindAsync(id);
            _context.Menuusuario.Remove(menuusuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuusuarioExists(byte id)
        {
            return _context.Menuusuario.Any(e => e.Mcodigo == id);
        }
    }
}
