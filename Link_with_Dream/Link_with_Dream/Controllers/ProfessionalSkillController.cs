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
    public class ProfessionalSkillController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfessionalSkillController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ProfessionalSkill
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProfessionalSkill.Include(p => p.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProfessionalSkill/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalSkill = await _context.ProfessionalSkill
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professionalSkill == null)
            {
                return NotFound();
            }

            return View(professionalSkill);
        }

        // GET: ProfessionalSkill/Create
        public IActionResult Create()
        {
            ViewBag.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }

        // POST: ProfessionalSkill/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,Details,UserId,IsPublic")] ProfessionalSkill professionalSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professionalSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction("ProfetionalSkill", "UserProfile");
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", professionalSkill.UserId);
            return View(professionalSkill);
        }

        // GET: ProfessionalSkill/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalSkill = await _context.ProfessionalSkill.FindAsync(id);
            if (professionalSkill == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", professionalSkill.UserId);
            return View(professionalSkill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,Details,UserId,IsPublic")] ProfessionalSkill professionalSkill)
        {
            if (id != professionalSkill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professionalSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionalSkillExists(professionalSkill.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ProfetionalSkill", "UserProfile");
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", professionalSkill.UserId);
            return View(professionalSkill);
        }

        // GET: ProfessionalSkill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalSkill = await _context.ProfessionalSkill
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professionalSkill == null)
            {
                return NotFound();
            }

            return View(professionalSkill);
        }

        // POST: ProfessionalSkill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professionalSkill = await _context.ProfessionalSkill.FindAsync(id);
            _context.ProfessionalSkill.Remove(professionalSkill);
            await _context.SaveChangesAsync();
            return RedirectToAction("ProfetionalSkill", "UserProfile");
        }
        private bool ProfessionalSkillExists(int id)
        {
            return _context.ProfessionalSkill.Any(e => e.Id == id);
        }
    }
}
