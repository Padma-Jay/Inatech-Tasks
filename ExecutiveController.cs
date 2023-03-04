using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WingTruck.Data;
using WingTruck.Models;

namespace WingTruck.Controllers
{
    public class ExecutiveController : Controller
    {
        private readonly WingTruckContext _context;

        public ExecutiveController(WingTruckContext context)
        {
            _context = context;
        }

        // GET: Executive
        public async Task<IActionResult> Index()
        {
            var wingTruckContext = _context.Executive.Include(e => e.Order);
            return View(await wingTruckContext.ToListAsync());
        }

        // GET: Executive/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Executive == null)
            {
                return NotFound();
            }

            var executive = await _context.Executive
                .Include(e => e.Order)
                .FirstOrDefaultAsync(m => m.ExecutiveId == id);
            if (executive == null)
            {
                return NotFound();
            }

            return View(executive);
        }

        // GET: Executive/Create
        public IActionResult Create()
        {
            ViewData["OrderTypeId"] = new SelectList(_context.Order, "OrderTypeId", "OrderTypeId");
            return View();
        }

        public IActionResult Service()
        {
            return View();
        }

        // POST: Executive/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExecutiveId,ExecutiveName,OrderTypeId,PhnNo")] Executive executive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(executive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderTypeId"] = new SelectList(_context.Order, "OrderTypeId", "OrderTypeId", executive.OrderTypeId);
            return View(executive);
        }

        // GET: Executive/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Executive == null)
            {
                return NotFound();
            }

            var executive = await _context.Executive.FindAsync(id);
            if (executive == null)
            {
                return NotFound();
            }
            ViewData["OrderTypeId"] = new SelectList(_context.Order, "OrderTypeId", "OrderTypeId", executive.OrderTypeId);
            return View(executive);
        }

        // POST: Executive/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExecutiveId,ExecutiveName,OrderTypeId,PhnNo")] Executive executive)
        {
            if (id != executive.ExecutiveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(executive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExecutiveExists(executive.ExecutiveId))
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
            ViewData["OrderTypeId"] = new SelectList(_context.Order, "OrderTypeId", "OrderTypeId", executive.OrderTypeId);
            return View(executive);
        }

        // GET: Executive/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Executive == null)
            {
                return NotFound();
            }

            var executive = await _context.Executive
                .Include(e => e.Order)
                .FirstOrDefaultAsync(m => m.ExecutiveId == id);
            if (executive == null)
            {
                return NotFound();
            }

            return View(executive);
        }

        // POST: Executive/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Executive == null)
            {
                return Problem("Entity set 'WingTruckContext.Executive'  is null.");
            }
            var executive = await _context.Executive.FindAsync(id);
            if (executive != null)
            {
                _context.Executive.Remove(executive);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExecutiveExists(int id)
        {
          return _context.Executive.Any(e => e.ExecutiveId == id);
        }
    }
}
