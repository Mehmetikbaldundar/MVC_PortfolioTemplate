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
    public class AboutMeController : Controller
    {
        private readonly MySiteContext _context;

        public AboutMeController(MySiteContext context)
        {
            _context = context;
        }

        // GET: AboutMe
        public async Task<IActionResult> Index()
        {
              return View(await _context.AboutMes.ToListAsync());
        }

        // GET: AboutMe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AboutMes == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.AboutMes
                .FirstOrDefaultAsync(m => m.AboutMeID == id);
            if (aboutMe == null)
            {
                return NotFound();
            }

            return View(aboutMe);
        }

        // GET: AboutMe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AboutMe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AboutMeID,Title,Description,DescriptionDate,DescriptionPhoto")] AboutMe aboutMe,IFormFile DescriptionPhoto)
        {
            if (ModelState.IsValid)
            {
                //--File adding settings--
                if (DescriptionPhoto != null)
                {
                    string imageName = DescriptionPhoto.FileName;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/assets/img/aboutme/{imageName}");
                    var stream = new FileStream(path, FileMode.OpenOrCreate);
                    aboutMe.DescriptionPhoto = imageName;
                    DescriptionPhoto.CopyTo(stream);
                }
                _context.Add(aboutMe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutMe);
        }

        // GET: AboutMe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AboutMes == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.AboutMes.FindAsync(id);
            if (aboutMe == null)
            {
                return NotFound();
            }
            return View(aboutMe);
        }

        // POST: AboutMe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AboutMeID,Title,Description,DescriptionDate,DescriptionPhoto")] AboutMe aboutMe, IFormFile DescriptionPhoto)
        {
            if (id != aboutMe.AboutMeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (DescriptionPhoto != null)
                    {
                        string imageName = DescriptionPhoto.FileName;
                        string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/assets/img/aboutme/{imageName}");
                        var stream = new FileStream(path, FileMode.OpenOrCreate);
                        aboutMe.DescriptionPhoto = imageName;
                        DescriptionPhoto.CopyTo(stream);
                    }
                    _context.Update(aboutMe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutMeExists(aboutMe.AboutMeID))
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
            return View(aboutMe);
        }

        // GET: AboutMe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AboutMes == null)
            {
                return NotFound();
            }

            var aboutMe = await _context.AboutMes
                .FirstOrDefaultAsync(m => m.AboutMeID == id);
            if (aboutMe == null)
            {
                return NotFound();
            }

            return View(aboutMe);
        }

        // POST: AboutMe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AboutMes == null)
            {
                return Problem("Entity set 'MySiteContext.AboutMes'  is null.");
            }
            var aboutMe = await _context.AboutMes.FindAsync(id);
            if (aboutMe != null)
            {
                _context.AboutMes.Remove(aboutMe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutMeExists(int id)
        {
          return _context.AboutMes.Any(e => e.AboutMeID == id);
        }
    }
}
