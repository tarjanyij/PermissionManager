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
    public class ResponsiblesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResponsiblesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Responsibles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Responsibles.ToListAsync());
        }

        // GET: Responsibles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsible = await _context.Responsibles
                .FirstOrDefaultAsync(m => m.ResponsibleID == id);
            if (responsible == null)
            {
                return NotFound();
            }

            return View(responsible);
        }

        // GET: Responsibles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Responsibles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResponsibleID,ResponsibleName,ResponsibleEmail")] Responsible responsible)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsible);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(responsible);
        }

        // GET: Responsibles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsible = await _context.Responsibles.FindAsync(id);
            if (responsible == null)
            {
                return NotFound();
            }
            return View(responsible);
        }

        // POST: Responsibles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResponsibleID,ResponsibleName,ResponsibleEmail")] Responsible responsible)
        {
            if (id != responsible.ResponsibleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsible);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsibleExists(responsible.ResponsibleID))
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
            return View(responsible);
        }

        // GET: Responsibles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsible = await _context.Responsibles
                .FirstOrDefaultAsync(m => m.ResponsibleID == id);
            if (responsible == null)
            {
                return NotFound();
            }

            return View(responsible);
        }

        // POST: Responsibles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responsible = await _context.Responsibles.FindAsync(id);
            _context.Responsibles.Remove(responsible);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsibleExists(int id)
        {
            return _context.Responsibles.Any(e => e.ResponsibleID == id);
        }
    }
}
