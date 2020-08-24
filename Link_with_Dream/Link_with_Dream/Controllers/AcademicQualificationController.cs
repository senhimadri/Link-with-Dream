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
    public class AcademicQualificationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AcademicQualificationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: AcademicQualification
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AcademicQualification.Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AcademicQualification/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicQualification = await _context.AcademicQualification
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academicQualification == null)
            {
                return NotFound();
            }

            return View(academicQualification);
        }

        // GET: AcademicQualification/Create
        public IActionResult Create()
        {
            ViewBag.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExamName,Subject,Institute,Board,PassingYear,Result,UserId,IsPublic")] AcademicQualification academicQualification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicQualification);
                await _context.SaveChangesAsync();
                return RedirectToAction("AcademicQualification", "UserProfile", new { Messege = "New Academic Qualification is Added " });

            }
            else
            {
                return RedirectToAction("AcademicQualification", "UserProfile", new { Messege = "There is a problem" });
            }
        }

        // GET: AcademicQualification/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicQualification = await _context.AcademicQualification.FindAsync(id);
            if (academicQualification == null)
            {
                return NotFound();
            }
            ViewBag.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(academicQualification);
        }

        // POST: AcademicQualification/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExamName,Subject,Institute,Board,PassingYear,Result,UserId,IsPublic")] AcademicQualification academicQualification)
        {
            if (id != academicQualification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicQualification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicQualificationExists(academicQualification.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("AcademicQualification", "UserProfile", new { Messege = "Academic Qualification is Updated" });
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", academicQualification.UserId);
            return View(academicQualification);
        }

        // GET: AcademicQualification/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicQualification = await _context.AcademicQualification
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academicQualification == null)
            {
                return NotFound();
            }

            return View(academicQualification);
        }

        // POST: AcademicQualification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicQualification = await _context.AcademicQualification.FindAsync(id);
            _context.AcademicQualification.Remove(academicQualification);
            await _context.SaveChangesAsync();
            return RedirectToAction("AcademicQualification", "UserProfile", new { Messege = "Academic Qualification is Deleted" });
        }

        private bool AcademicQualificationExists(int id)
        {
            return _context.AcademicQualification.Any(e => e.Id == id);
        }
    }
}
