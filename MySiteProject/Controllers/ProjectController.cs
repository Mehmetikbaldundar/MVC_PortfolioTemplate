using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySiteProject.Models.Context;
using MySiteProject.Models.Entities;

namespace MySiteProject.Controllers
{
    public class ProjectController : Controller
    {
        private readonly MySiteContext _context;

        public ProjectController(MySiteContext context)
        {
            _context = context;
        }

        // GET: Project
        public async Task<IActionResult> Index()
        {
              return View(await _context.ProjectInfos.ToListAsync());
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectInfos == null)
            {
                return NotFound();
            }

            var projectInfo = await _context.ProjectInfos
                .FirstOrDefaultAsync(m => m.ProjectID == id);
            if (projectInfo == null)
            {
                return NotFound();
            }

            return View(projectInfo);
        }

        // GET: Project/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectID,ProjectName,ProjectDescription,ProjectDate,ProjectPhoto")] ProjectInfo projectInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectInfo);
        }

        // GET: Project/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectInfos == null)
            {
                return NotFound();
            }

            var projectInfo = await _context.ProjectInfos.FindAsync(id);
            if (projectInfo == null)
            {
                return NotFound();
            }
            return View(projectInfo);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectID,ProjectName,ProjectDescription,ProjectDate,ProjectPhoto")] ProjectInfo projectInfo)
        {
            if (id != projectInfo.ProjectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectInfoExists(projectInfo.ProjectID))
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
            return View(projectInfo);
        }

        // GET: Project/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectInfos == null)
            {
                return NotFound();
            }

            var projectInfo = await _context.ProjectInfos
                .FirstOrDefaultAsync(m => m.ProjectID == id);
            if (projectInfo == null)
            {
                return NotFound();
            }

            return View(projectInfo);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectInfos == null)
            {
                return Problem("Entity set 'MySiteContext.ProjectInfos'  is null.");
            }
            var projectInfo = await _context.ProjectInfos.FindAsync(id);
            if (projectInfo != null)
            {
                _context.ProjectInfos.Remove(projectInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectInfoExists(int id)
        {
          return _context.ProjectInfos.Any(e => e.ProjectID == id);
        }
    }
}
