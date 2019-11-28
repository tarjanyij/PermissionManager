using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PermissionManager.Data;
using PermissionManager.Models;

namespace PermissionManager.Controllers
{
    public class RightsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RightsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rights
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rights.Include(r => r.OfficeRights);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rights = await _context.Rights
                .Include(r => r.OfficeRights)
                .FirstOrDefaultAsync(m => m.RightsID == id);
            if (rights == null)
            {
                return NotFound();
            }

            return View(rights);
        }

        // GET: Rights/Create
        public IActionResult Create()
        {
            ViewData["OfficeRightsID"] = new SelectList(_context.OfficeRights, "OfficeRightsID", "OfficeRightsID");
            return View();
        }

        // POST: Rights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RightsID,RightsName,RightsValue,OfficeRightsID")] Rights rights)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rights);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OfficeRightsID"] = new SelectList(_context.OfficeRights, "OfficeRightsID", "OfficeRightsID", rights.OfficeRightsID);
            return View(rights);
        }

        // GET: Rights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rights = await _context.Rights.FindAsync(id);
            if (rights == null)
            {
                return NotFound();
            }
            ViewData["OfficeRightsID"] = new SelectList(_context.OfficeRights, "OfficeRightsID", "OfficeRightsID", rights.OfficeRightsID);
            return View(rights);
        }

        // POST: Rights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RightsID,RightsName,RightsValue,OfficeRightsID")] Rights rights)
        {
            if (id != rights.RightsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rights);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RightsExists(rights.RightsID))
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
            ViewData["OfficeRightsID"] = new SelectList(_context.OfficeRights, "OfficeRightsID", "OfficeRightsID", rights.OfficeRightsID);
            return View(rights);
        }

        // GET: Rights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rights = await _context.Rights
                .Include(r => r.OfficeRights)
                .FirstOrDefaultAsync(m => m.RightsID == id);
            if (rights == null)
            {
                return NotFound();
            }

            return View(rights);
        }

        // POST: Rights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rights = await _context.Rights.FindAsync(id);
            _context.Rights.Remove(rights);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RightsExists(int id)
        {
            return _context.Rights.Any(e => e.RightsID == id);
        }
    }
}
