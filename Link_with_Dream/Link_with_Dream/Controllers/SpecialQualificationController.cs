using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Link_with_Dream.Data;
using Link_with_Dream.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Link_with_Dream.Controllers
{
    [Authorize]
    public class SpecialQualificationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SpecialQualificationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: SpecialQualification
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SpecialQualification.Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SpecialQualification/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialQualification = await _context.SpecialQualification
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialQualification == null)
            {
                return NotFound();
            }

            return View(specialQualification);
        }

        // GET: SpecialQualification/Create
        public IActionResult Create()
        {
            ViewBag.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }

        // POST: SpecialQualification/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseTitle,Topic,Institute,StartDate,EndDate,UserId,IsPublic")] SpecialQualification specialQualification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialQualification);
                await _context.SaveChangesAsync();
                return RedirectToAction("SpecialQualification", "UserProfile");
            }
            return View(specialQualification);
        }

        // GET: SpecialQualification/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialQualification = await _context.SpecialQualification.FindAsync(id);
            if (specialQualification == null)
            {
                return NotFound();
            }
            ViewBag.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(specialQualification);
        }

        // POST: SpecialQualification/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseTitle,Topic,Institute,StartDate,EndDate,UserId,IsPublic")] SpecialQualification specialQualification)
        {
            if (id != specialQualification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialQualification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialQualificationExists(specialQualification.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("SpecialQualification", "UserProfile");
            }
            return View(specialQualification);
        }

        // GET: SpecialQualification/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialQualification = await _context.SpecialQualification
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialQualification == null)
            {
                return NotFound();
            }

            return View(specialQualification);
        }

        // POST: SpecialQualification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialQualification = await _context.SpecialQualification.FindAsync(id);
            _context.SpecialQualification.Remove(specialQualification);
            await _context.SaveChangesAsync();
            return RedirectToAction("SpecialQualification", "UserProfile");
        }

        private bool SpecialQualificationExists(int id)
        {
            return _context.SpecialQualification.Any(e => e.Id == id);
        }
    }
}
