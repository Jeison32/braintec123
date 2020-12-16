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
    public class TproveedorController : Controller
    {
        private readonly braintecDbContext _context;

        public TproveedorController(braintecDbContext context)
        {
            _context = context;
        }

        // GET: Tproveedor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tproveedor.ToListAsync());
        }

        // GET: Tproveedor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tproveedor = await _context.Tproveedor
                .FirstOrDefaultAsync(m => m.Idproveedor == id);
            if (tproveedor == null)
            {
                return NotFound();
            }

            return View(tproveedor);
        }

        // GET: Tproveedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tproveedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idproveedor,Rsocialproveedor,Percontactoproveedor,Telefonoproveedor,Correoproveedor")] Tproveedor tproveedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tproveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tproveedor);
        }

        // GET: Tproveedor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tproveedor = await _context.Tproveedor.FindAsync(id);
            if (tproveedor == null)
            {
                return NotFound();
            }
            return View(tproveedor);
        }

        // POST: Tproveedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idproveedor,Rsocialproveedor,Percontactoproveedor,Telefonoproveedor,Correoproveedor")] Tproveedor tproveedor)
        {
            if (id != tproveedor.Idproveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tproveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TproveedorExists(tproveedor.Idproveedor))
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
            return View(tproveedor);
        }

        // GET: Tproveedor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tproveedor = await _context.Tproveedor
                .FirstOrDefaultAsync(m => m.Idproveedor == id);
            if (tproveedor == null)
            {
                return NotFound();
            }

            return View(tproveedor);
        }

        // POST: Tproveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tproveedor = await _context.Tproveedor.FindAsync(id);
            _context.Tproveedor.Remove(tproveedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TproveedorExists(int id)
        {
            return _context.Tproveedor.Any(e => e.Idproveedor == id);
        }
    }
}
