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
    public class TrolesController : Controller
    {
        private readonly braintecDbContext _context;

        public TrolesController(braintecDbContext context)
        {
            _context = context;
        }

        // GET: Troles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Troles.ToListAsync());
        }

        // GET: Troles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var troles = await _context.Troles
                .FirstOrDefaultAsync(m => m.Idroles == id);
            if (troles == null)
            {
                return NotFound();
            }

            return View(troles);
        }

        // GET: Troles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Troles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idroles,Tiporol")] Troles troles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(troles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(troles);
        }

        // GET: Troles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var troles = await _context.Troles.FindAsync(id);
            if (troles == null)
            {
                return NotFound();
            }
            return View(troles);
        }

        // POST: Troles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idroles,Tiporol")] Troles troles)
        {
            if (id != troles.Idroles)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(troles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrolesExists(troles.Idroles))
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
            return View(troles);
        }

        // GET: Troles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var troles = await _context.Troles
                .FirstOrDefaultAsync(m => m.Idroles == id);
            if (troles == null)
            {
                return NotFound();
            }

            return View(troles);
        }

        // POST: Troles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var troles = await _context.Troles.FindAsync(id);
            _context.Troles.Remove(troles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrolesExists(int id)
        {
            return _context.Troles.Any(e => e.Idroles == id);
        }
    }
}
