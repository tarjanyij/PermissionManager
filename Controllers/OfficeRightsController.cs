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
    public class OfficeRightsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OfficeRightsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OfficeRights
        public async Task<IActionResult> Index()
        {
            return View(await _context.OfficeRights.ToListAsync());
        }

        // GET: OfficeRights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeRights = await _context.OfficeRights
                .FirstOrDefaultAsync(m => m.OfficeRightsID == id);
            if (officeRights == null)
            {
                return NotFound();
            }

            return View(officeRights);
        }

        // GET: OfficeRights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OfficeRights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfficeRightsID,OfficeName")] OfficeRights officeRights)
        {
            if (ModelState.IsValid)
            {
                _context.Add(officeRights);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(officeRights);
        }

        // GET: OfficeRights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeRights = await _context.OfficeRights.FindAsync(id);
            if (officeRights == null)
            {
                return NotFound();
            }
            return View(officeRights);
        }

        // POST: OfficeRights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OfficeRightsID,OfficeName")] OfficeRights officeRights)
        {
            if (id != officeRights.OfficeRightsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(officeRights);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfficeRightsExists(officeRights.OfficeRightsID))
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
            return View(officeRights);
        }

        // GET: OfficeRights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeRights = await _context.OfficeRights
                .FirstOrDefaultAsync(m => m.OfficeRightsID == id);
            if (officeRights == null)
            {
                return NotFound();
            }

            return View(officeRights);
        }

        // POST: OfficeRights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var officeRights = await _context.OfficeRights.FindAsync(id);
            _context.OfficeRights.Remove(officeRights);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfficeRightsExists(int id)
        {
            return _context.OfficeRights.Any(e => e.OfficeRightsID == id);
        }
    }
}
