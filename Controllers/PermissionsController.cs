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
    public class PermissionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PermissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Permissions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Permissions.Include(p => p.PermissionPaper).Include(p => p.Person).Include(p => p.Rights);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Permissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permission = await _context.Permissions
                .Include(p => p.PermissionPaper)
                .Include(p => p.Person)
                .Include(p => p.Rights)
                .FirstOrDefaultAsync(m => m.PermissionID == id);
            if (permission == null)
            {
                return NotFound();
            }

            return View(permission);
        }

        // GET: Permissions/Create
        public IActionResult Create()
        {
            ViewData["PermissionPaperID"] = new SelectList(_context.PermissionPaper, "PermissionPaperID", "PermissionPaperID");
            ViewData["PersonID"] = new SelectList(_context.Persons, "PersonID", "PersonID");
            ViewData["RightsID"] = new SelectList(_context.Rights, "RightsID", "RightsID");
            return View();
        }

        // POST: Permissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PermissionID,PersonID,RightsID,BeginDate,EndDate,ApproverID,ResponsibleID,PermissionPaperID")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PermissionPaperID"] = new SelectList(_context.PermissionPaper, "PermissionPaperID", "PermissionPaperID", permission.PermissionPaperID);
            ViewData["PersonID"] = new SelectList(_context.Persons, "PersonID", "PersonID", permission.PersonID);
            ViewData["RightsID"] = new SelectList(_context.Rights, "RightsID", "RightsID", permission.RightsID);
            return View(permission);
        }

        // GET: Permissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permission = await _context.Permissions.FindAsync(id);
            if (permission == null)
            {
                return NotFound();
            }
            ViewData["PermissionPaperID"] = new SelectList(_context.PermissionPaper, "PermissionPaperID", "PermissionPaperID", permission.PermissionPaperID);
            ViewData["PersonID"] = new SelectList(_context.Persons, "PersonID", "PersonID", permission.PersonID);
            ViewData["RightsID"] = new SelectList(_context.Rights, "RightsID", "RightsID", permission.RightsID);
            return View(permission);
        }

        // POST: Permissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PermissionID,PersonID,RightsID,BeginDate,EndDate,ApproverID,ResponsibleID,PermissionPaperID")] Permission permission)
        {
            if (id != permission.PermissionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermissionExists(permission.PermissionID))
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
            ViewData["PermissionPaperID"] = new SelectList(_context.PermissionPaper, "PermissionPaperID", "PermissionPaperID", permission.PermissionPaperID);
            ViewData["PersonID"] = new SelectList(_context.Persons, "PersonID", "PersonID", permission.PersonID);
            ViewData["RightsID"] = new SelectList(_context.Rights, "RightsID", "RightsID", permission.RightsID);
            return View(permission);
        }

        // GET: Permissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permission = await _context.Permissions
                .Include(p => p.PermissionPaper)
                .Include(p => p.Person)
                .Include(p => p.Rights)
                .FirstOrDefaultAsync(m => m.PermissionID == id);
            if (permission == null)
            {
                return NotFound();
            }

            return View(permission);
        }

        // POST: Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permission = await _context.Permissions.FindAsync(id);
            _context.Permissions.Remove(permission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermissionExists(int id)
        {
            return _context.Permissions.Any(e => e.PermissionID == id);
        }
    }
}
