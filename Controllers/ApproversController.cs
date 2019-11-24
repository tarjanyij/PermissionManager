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
    public class ApproversController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApproversController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Approvers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Approvers.ToListAsync());
        }

        // GET: Approvers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approver = await _context.Approvers
                .FirstOrDefaultAsync(m => m.ApproverID == id);
            if (approver == null)
            {
                return NotFound();
            }

            return View(approver);
        }

        // GET: Approvers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Approvers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApproverID,ApproverName,ApproverEmail")] Approver approver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(approver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(approver);
        }

        // GET: Approvers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approver = await _context.Approvers.FindAsync(id);
            if (approver == null)
            {
                return NotFound();
            }
            return View(approver);
        }

        // POST: Approvers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApproverID,ApproverName,ApproverEmail")] Approver approver)
        {
            if (id != approver.ApproverID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(approver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApproverExists(approver.ApproverID))
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
            return View(approver);
        }

        // GET: Approvers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approver = await _context.Approvers
                .FirstOrDefaultAsync(m => m.ApproverID == id);
            if (approver == null)
            {
                return NotFound();
            }

            return View(approver);
        }

        // POST: Approvers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var approver = await _context.Approvers.FindAsync(id);
            _context.Approvers.Remove(approver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApproverExists(int id)
        {
            return _context.Approvers.Any(e => e.ApproverID == id);
        }
    }
}
