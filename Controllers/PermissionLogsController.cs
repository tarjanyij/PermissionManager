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
    public class PermissionLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PermissionLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PermissionLogs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PermissionLog.Include(p => p.Permission);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PermissionLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissionLog = await _context.PermissionLog
                .Include(p => p.Permission)
                .FirstOrDefaultAsync(m => m.PermissionLogID == id);
            if (permissionLog == null)
            {
                return NotFound();
            }

            return View(permissionLog);
        }

        // GET: PermissionLogs/Create
        public IActionResult Create()
        {
            ViewData["PermissionID"] = new SelectList(_context.Permissions, "PermissionID", "PermissionID");
            return View();
        }

        // POST: PermissionLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PermissionLogID,PermissionID,LogDate,ModifiKey,ModifyValue")] PermissionLog permissionLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permissionLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PermissionID"] = new SelectList(_context.Permissions, "PermissionID", "PermissionID", permissionLog.PermissionID);
            return View(permissionLog);
        }

        // GET: PermissionLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissionLog = await _context.PermissionLog.FindAsync(id);
            if (permissionLog == null)
            {
                return NotFound();
            }
            ViewData["PermissionID"] = new SelectList(_context.Permissions, "PermissionID", "PermissionID", permissionLog.PermissionID);
            return View(permissionLog);
        }

        // POST: PermissionLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PermissionLogID,PermissionID,LogDate,ModifiKey,ModifyValue")] PermissionLog permissionLog)
        {
            if (id != permissionLog.PermissionLogID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permissionLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermissionLogExists(permissionLog.PermissionLogID))
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
            ViewData["PermissionID"] = new SelectList(_context.Permissions, "PermissionID", "PermissionID", permissionLog.PermissionID);
            return View(permissionLog);
        }

        // GET: PermissionLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissionLog = await _context.PermissionLog
                .Include(p => p.Permission)
                .FirstOrDefaultAsync(m => m.PermissionLogID == id);
            if (permissionLog == null)
            {
                return NotFound();
            }

            return View(permissionLog);
        }

        // POST: PermissionLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permissionLog = await _context.PermissionLog.FindAsync(id);
            _context.PermissionLog.Remove(permissionLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermissionLogExists(int id)
        {
            return _context.PermissionLog.Any(e => e.PermissionLogID == id);
        }
    }
}
