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
    public class CareerInformationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CareerInformationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: CareerInformation
        public async Task<IActionResult> Index()
        {
            return View(await _context.CareerInformation.ToListAsync());
        }

        // GET: CareerInformation/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careerInformation = await _context.CareerInformation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (careerInformation == null)
            {
                return NotFound();
            }

            return View(careerInformation);
        }

        // GET: CareerInformation/Create
        public IActionResult Create()
        {
            ViewBag.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }

        // POST: CareerInformation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarrierObjective,LookingFor,AvailableFor,PreferedJobCatagory1,PreferedJobCatagory2,PreferedJobCatagory3,PreferdArea1,PreferdArea2,ExpectedSalary,IsPublic")] CareerInformation careerInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careerInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction("CareerInformation", "UserProfile", new { Messege = "Carrier Information is Created" });
            }
            return View(careerInformation);
        }

        // GET: CareerInformation/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careerInformation = await _context.CareerInformation.FindAsync(id);
            if (careerInformation == null)
            {
                return NotFound();
            }
            return View(careerInformation);
        }

        // POST: CareerInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,CarrierObjective,LookingFor,AvailableFor,PreferedJobCatagory1,PreferedJobCatagory2,PreferedJobCatagory3,PreferdArea1,PreferdArea2,ExpectedSalary,IsPublic")] CareerInformation careerInformation)
        {
            if (id != careerInformation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careerInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareerInformationExists(careerInformation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("CareerInformation", "UserProfile", new { Messege = "Carrier Information is Edited" });
            }
            return View(careerInformation);
        }

        // GET: CareerInformation/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careerInformation = await _context.CareerInformation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (careerInformation == null)
            {
                return NotFound();
            }

            return View(careerInformation);
        }

        // POST: CareerInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var careerInformation = await _context.CareerInformation.FindAsync(id);
            _context.CareerInformation.Remove(careerInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareerInformationExists(string id)
        {
            return _context.CareerInformation.Any(e => e.Id == id);
        }
    }
}
