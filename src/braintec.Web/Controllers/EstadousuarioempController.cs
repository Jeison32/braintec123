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
    public class EstadousuarioempController : Controller
    {
        private readonly braintecDbContext _context;

        public EstadousuarioempController(braintecDbContext context)
        {
            _context = context;
        }

        // GET: Estadousuarioemp
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estadousuarioemp.ToListAsync());
        }

        // GET: Estadousuarioemp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadousuarioemp = await _context.Estadousuarioemp
                .FirstOrDefaultAsync(m => m.Idestadou == id);
            if (estadousuarioemp == null)
            {
                return NotFound();
            }

            return View(estadousuarioemp);
        }

        // GET: Estadousuarioemp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estadousuarioemp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idestadou,Estadousuario")] Estadousuarioemp estadousuarioemp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadousuarioemp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadousuarioemp);
        }

        // GET: Estadousuarioemp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadousuarioemp = await _context.Estadousuarioemp.FindAsync(id);
            if (estadousuarioemp == null)
            {
                return NotFound();
            }
            return View(estadousuarioemp);
        }

        // POST: Estadousuarioemp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idestadou,Estadousuario")] Estadousuarioemp estadousuarioemp)
        {
            if (id != estadousuarioemp.Idestadou)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadousuarioemp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadousuarioempExists(estadousuarioemp.Idestadou))
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
            return View(estadousuarioemp);
        }

        // GET: Estadousuarioemp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadousuarioemp = await _context.Estadousuarioemp
                .FirstOrDefaultAsync(m => m.Idestadou == id);
            if (estadousuarioemp == null)
            {
                return NotFound();
            }

            return View(estadousuarioemp);
        }

        // POST: Estadousuarioemp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadousuarioemp = await _context.Estadousuarioemp.FindAsync(id);
            _context.Estadousuarioemp.Remove(estadousuarioemp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadousuarioempExists(int id)
        {
            return _context.Estadousuarioemp.Any(e => e.Idestadou == id);
        }
    }
}
