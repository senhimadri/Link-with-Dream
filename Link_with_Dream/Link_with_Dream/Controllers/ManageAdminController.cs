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
    public class ManageAdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ManageAdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Manage admin / See the admin list 
        public async Task<IActionResult> Index( int id)
        {
            var CompanyInfo = await _context.Company.Where(e => e.Id == id).FirstOrDefaultAsync();
            ViewBag.CompanyInfo = CompanyInfo;
            var applicationDbContext = _context.CompanyPeople.Include(c => c.Company).Include(c => c.User).Where(e=>e.CompanyId==id && e.Status==1);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ManageAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyPeople = await _context.CompanyPeople
                .Include(c => c.Company)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyPeople == null)
            {
                return NotFound();
            }

            return View(companyPeople);
        }

        // Search User for set them as an Admin
        public async Task<IActionResult> CompanyAddAdmin(int id, string Messege, string searchtext="")
        {
            ViewBag.company = await _context.Company.Where(e => e.Id == id).FirstOrDefaultAsync();

            var companyadmin = await _context.CompanyPeople.Where(e => e.CompanyId == id && (e.Status == 1 || e.Status==0 || e.Status==4)).ToListAsync();
            List<string> selectedCollection = new List<string>();

            foreach (var item in companyadmin)
            {
                selectedCollection.Add(item.UserId);
            }
            if (String.IsNullOrEmpty(searchtext))
            {
                var UserInfo =await _context.Users.Where(e=>!selectedCollection.Contains(e.Id)).ToListAsync();
                   
                ViewBag.UserInf = UserInfo;
            }
            else
            {
                var UserInfo = await _context.Users.Where(e=> (!selectedCollection.Contains(e.Id) && (e.FirstName.Contains(searchtext)|| e.LastName.Contains(searchtext)|| e.Email.Contains(searchtext)|| e.PhoneNumber.Contains(searchtext)|| e.Profession.Contains(searchtext)))).ToListAsync();
                ViewBag.UserInf = UserInfo;
            }
            ViewBag.Messege = Messege;
            return View();
        }

        // POST: ManageAdmin/Create
       // Sent request to someone for being an admin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompanySetAdmin(string userId, int companyId)
        {
            if (ModelState.IsValid)
            {
                CompanyPeople companyPeople = new CompanyPeople()
                { 
                UserId= userId,
                CompanyId= companyId,
                Status=4
                };
                _context.Add(companyPeople);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(CompanyAddAdmin));
                return RedirectToAction("CompanyAddAdmin",new { id=companyId, Messege ="Admin Request is Sent"});
            }
            return View();
        }
        // People will see the request that sent to him to be the admin
        public async Task<IActionResult> CompanyAdminRequest()
        {
            var CompanyAdminRequest = await _context.CompanyPeople.Include(e => e.Company).Where(e => e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier) && e.Status==4).ToListAsync();
            return View(CompanyAdminRequest);
        }
        public async Task<IActionResult> YourCreatedCompany()
        {
            var CompanyAdminRequest = await _context.CompanyPeople.Include(e => e.Company).Where(e => e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier) && e.Status == 0).ToListAsync();
            return View(CompanyAdminRequest);
        }
        public async Task<IActionResult> CompanyYouasAdmin()
        {
            var CompanyAdminRequest = await _context.CompanyPeople.Include(e => e.Company).Where(e => e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier) && e.Status == 1).ToListAsync();
            return View(CompanyAdminRequest);
        }

        public async Task<IActionResult> CompanyYouasFollower()
        {
            var CompanyAdminRequest = await _context.CompanyPeople.Include(e => e.Company).Where(e => e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier) && e.Status == 2).ToListAsync();
            return View(CompanyAdminRequest);
        }
        //Accept company admin request by people
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptAdminRequest(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CompanyPeople companyPeople = new CompanyPeople()
                    {
                        Id = id,
                        Status = 1
                    };

                    _context.Attach(companyPeople);
                    _context.Entry(companyPeople).Property("Status").IsModified = true;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyPeopleExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(CompanyAdminRequest));
            }

            return View();
        }
        //Reject company admin request by people

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectAdminRequest(int id, string ret, int company)
        {
            var companyPeople = await _context.CompanyPeople.FindAsync(id);
            _context.CompanyPeople.Remove(companyPeople);
            await _context.SaveChangesAsync();
            return RedirectToAction(ret,new { id= company });       
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LeaveasAdmin(int id)
        {

            var companyPeople = await _context.CompanyPeople.Where(e=>e.CompanyId==id && e.UserId== User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefaultAsync();
            _context.CompanyPeople.Remove(companyPeople);
            await _context.SaveChangesAsync();
            return RedirectToAction("CompanyAbout","CompanyProfile" ,new { id=id});
        }



        // Main admin will be able to show the people whom he sent the request 
        public async Task<IActionResult> CompanysentAdminRequest( int id)
        {
            var CompanyInfo = await _context.Company.Where(e => e.Id == id).FirstOrDefaultAsync();
            ViewBag.CompanyInfo = CompanyInfo;
            var CompanyAdminsentRequest = await _context.CompanyPeople.Include(e => e.User).Where(e => e.CompanyId== id && e.Status == 4).ToListAsync();
            return View(CompanyAdminsentRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FollowaCompany(int companyId)
        {
            if (ModelState.IsValid) 
            {
                CompanyPeople companyPeople = new CompanyPeople()
                {
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CompanyId = companyId,
                    Status = 2
                };
                _context.Add(companyPeople);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(CompanyAddAdmin));
                return RedirectToAction("CompanyAbout", "CompanyProfile", new { id = companyId});
            }
            return View();
        }















        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyPeople = await _context.CompanyPeople.FindAsync(id);
            if (companyPeople == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", companyPeople.CompanyId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", companyPeople.UserId);
            return View(companyPeople);
        }

        // POST: ManageAdmin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,CompanyId,Status")] CompanyPeople companyPeople)
        {
            if (id != companyPeople.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyPeople);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyPeopleExists(companyPeople.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", companyPeople.CompanyId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", companyPeople.UserId);
            return View(companyPeople);
        }

        // GET: ManageAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyPeople = await _context.CompanyPeople
                .Include(c => c.Company)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyPeople == null)
            {
                return NotFound();
            }

            return View(companyPeople);
        }

        // POST: ManageAdmin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyPeople = await _context.CompanyPeople.FindAsync(id);
            _context.CompanyPeople.Remove(companyPeople);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyPeopleExists(int id )
        {
            return _context.CompanyPeople.Any(e => e.Id == id);
        }
    }
}
