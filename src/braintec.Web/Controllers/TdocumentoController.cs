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
    public class TdocumentoController : Controller
    {
        private readonly braintecDbContext _context;

        public TdocumentoController(braintecDbContext context)
        {
            _context = context;
        }

        // GET: Tdocumento
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tdocumento.ToListAsync());
        }

        // GET: Tdocumento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tdocumento = await _context.Tdocumento
                .FirstOrDefaultAsync(m => m.Iddocumento == id);
            if (tdocumento == null)
            {
                return NotFound();
            }

            return View(tdocumento);
        }

        // GET: Tdocumento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tdocumento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iddocumento,Tipodocumento")] Tdocumento tdocumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tdocumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tdocumento);
        }

        // GET: Tdocumento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tdocumento = await _context.Tdocumento.FindAsync(id);
            if (tdocumento == null)
            {
                return NotFound();
            }
            return View(tdocumento);
        }

        // POST: Tdocumento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iddocumento,Tipodocumento")] Tdocumento tdocumento)
        {
            if (id != tdocumento.Iddocumento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tdocumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TdocumentoExists(tdocumento.Iddocumento))
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
            return View(tdocumento);
        }

        // GET: Tdocumento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tdocumento = await _context.Tdocumento
                .FirstOrDefaultAsync(m => m.Iddocumento == id);
            if (tdocumento == null)
            {
                return NotFound();
            }

            return View(tdocumento);
        }

        // POST: Tdocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tdocumento = await _context.Tdocumento.FindAsync(id);
            _context.Tdocumento.Remove(tdocumento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TdocumentoExists(int id)
        {
            return _context.Tdocumento.Any(e => e.Iddocumento == id);
        }
    }
}
