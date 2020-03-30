using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marquette_Mansions.Data;
using Marquette_Mansions.Models;

namespace Marquette_Mansions.Controllers
{
    public class TennantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TennantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tennants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tennants.Include(t => t.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tennants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tennant = await _context.Tennants
                .Include(t => t.IdentityUser)
                .FirstOrDefaultAsync(m => m.TennantID == id);
            if (tennant == null)
            {
                return NotFound();
            }

            return View(tennant);
        }

        // GET: Tennants/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Tennants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TennantID,IdentityUserId,Name,EmailAddress,Address,State,City,PhoneNumber")] Tennant tennant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tennant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", tennant.IdentityUserId);
            return View(tennant);
        }

        // GET: Tennants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tennant = await _context.Tennants.FindAsync(id);
            if (tennant == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", tennant.IdentityUserId);
            return View(tennant);
        }

        // POST: Tennants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TennantID,IdentityUserId,Name,EmailAddress,Address,State,City,PhoneNumber")] Tennant tennant)
        {
            if (id != tennant.TennantID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tennant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TennantExists(tennant.TennantID))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", tennant.IdentityUserId);
            return View(tennant);
        }

        // GET: Tennants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tennant = await _context.Tennants
                .Include(t => t.IdentityUser)
                .FirstOrDefaultAsync(m => m.TennantID == id);
            if (tennant == null)
            {
                return NotFound();
            }

            return View(tennant);
        }

        // POST: Tennants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tennant = await _context.Tennants.FindAsync(id);
            _context.Tennants.Remove(tennant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TennantExists(int id)
        {
            return _context.Tennants.Any(e => e.TennantID == id);
        }
    }
}
