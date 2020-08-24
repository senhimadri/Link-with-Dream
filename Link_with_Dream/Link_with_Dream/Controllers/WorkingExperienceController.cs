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
    public class WorkingExperienceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public WorkingExperienceController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: WorkingExperience
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WorkingExperience.Include(w => w.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WorkingExperience/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingExperience = await _context.WorkingExperience
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workingExperience == null)
            {
                return NotFound();
            }

            return View(workingExperience);
        }

        // GET: WorkingExperience/Create
        public IActionResult Create()
        {
            ViewBag.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }

        // POST: WorkingExperience/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,Department,Designation,CompanyAddress,StartDate,EndDate,UserId,IsPublic")] WorkingExperience workingExperience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workingExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction("WorkingExperience", "UserProfile");
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", workingExperience.UserId);
            return View(workingExperience);
        }

        // GET: WorkingExperience/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingExperience = await _context.WorkingExperience.FindAsync(id);
            if (workingExperience == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", workingExperience.UserId);
            return View(workingExperience);
        }

        // POST: WorkingExperience/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,Department,Designation,CompanyAddress,StartDate,EndDate,UserId,IsPublic")] WorkingExperience workingExperience)
        {
            if (id != workingExperience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workingExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkingExperienceExists(workingExperience.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("WorkingExperience", "UserProfile");
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", workingExperience.UserId);
            return View(workingExperience);
        }

        // GET: WorkingExperience/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingExperience = await _context.WorkingExperience
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workingExperience == null)
            {
                return NotFound();
            }

            return View(workingExperience);
        }

        // POST: WorkingExperience/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workingExperience = await _context.WorkingExperience.FindAsync(id);
            _context.WorkingExperience.Remove(workingExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction("WorkingExperience", "UserProfile");
        }

        private bool WorkingExperienceExists(int id)
        {
            return _context.WorkingExperience.Any(e => e.Id == id);
        }
    }
}
