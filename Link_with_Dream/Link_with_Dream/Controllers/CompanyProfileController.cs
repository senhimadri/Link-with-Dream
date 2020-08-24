using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Link_with_Dream.Data;
using Link_with_Dream.Models;
using Link_with_Dream.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Link_with_Dream.Controllers
{
    [Authorize]
    public class CompanyProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment hostingEnvironment;

        public CompanyProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index( )
        {
            return View();
        }
        public IActionResult CreateCompany()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCompany([Bind("Id,Name,Objective,CoverPic,About,Services,CaseStudy,Address,Phone,Email,Instalation")] Company company)
        {
            if (ModelState.IsValid)
            {
                company.CreateTime = DateTime.Now;
                _context.Add(company);
                await _context.SaveChangesAsync();
                CompanyPeople companyPeople = new CompanyPeople()
                {
                    CompanyId = company.Id,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    Status = 0
                };
                _context.Add(companyPeople);
                await _context.SaveChangesAsync();

                return RedirectToAction("CompanyAbout", new { id = company.Id });
            }
            return View(company);
        }
        public async Task<IActionResult> CompanyAbout(int id,string Messege)
        {
            var company = await _context.Company.Where(e => e.Id == id).FirstOrDefaultAsync();
            var companyPeople = await _context.CompanyPeople.Where(e => e.CompanyId == id && e.Status == 2).ToListAsync();
            var status = await _context.CompanyPeople.Where(e => e.CompanyId == id && e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefaultAsync();
            ViewBag.Followers = companyPeople.Count();
            ViewBag.Messege = Messege;
            ViewBag.Status = CompanyStatus(id);
            return View(company);
        }
        public async Task<IActionResult> CompanyPost(int id ,string messege)
        {
            var company = await _context.Company.Where(e => e.Id == id).FirstOrDefaultAsync();
            var companyPeople = await _context.CompanyPeople.Where(e => e.CompanyId == id && e.Status == 3).ToListAsync();
            var status = await _context.CompanyPeople.Where(e => e.CompanyId == id && e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefaultAsync();
            ViewBag.Followers = companyPeople.Count();
            ViewBag.Messege = messege;
            ViewBag.Status = CompanyStatus(id);
            var contenposts = await _context.ContentPost.Include(e => e.CGPoster).Where(e => e.CompanyId == id && (e.PostType == 1||e.PostType==2)).OrderByDescending(e => e.Id).ToListAsync();
            ViewBag.Useriid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Content = contenposts;
            return View(company);
        }

        public async Task<IActionResult> Carrier(int id, string messege)
        {
            var company = await _context.Company.Where(e => e.Id == id).FirstOrDefaultAsync();
            var companyPeople = await _context.CompanyPeople.Where(e => e.CompanyId == id && e.Status == 3).ToListAsync();
            var status = await _context.CompanyPeople.Where(e => e.CompanyId == id && e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefaultAsync();
            ViewBag.Followers = companyPeople.Count();
            ViewBag.Messege = messege;
            ViewBag.Status = CompanyStatus(id);
            var contenposts = await _context.ContentPost.Include(e => e.CGPoster).Where(e => e.CompanyId == id && e.PostType == 2 && e.DeadLine>DateTime.Now).OrderByDescending(e => e.Id).ToListAsync();
            ViewBag.Useriid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Content = contenposts;
            return View(company);
        }
        public async Task<IActionResult> CompanyServise(int id = 1)
        {
            var company = await _context.Company.Where(e => e.Id == id).FirstOrDefaultAsync();
            var companyPeople = await _context.CompanyPeople.Where(e => e.CompanyId == id && e.Status == 3).ToListAsync();
            var status = await _context.CompanyPeople.Where(e => e.CompanyId == id && e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefaultAsync();
            ViewBag.Followers = companyPeople.Count();
            if (status == null)
            {
                ViewBag.Status = 4;
            }
            else
            {
                ViewBag.Status = status.Status;
            }
            return View(company);
        }
        public async Task<IActionResult> CompanyCaseStudy(int id = 1)
        {
            var company = await _context.Company.Where(e => e.Id == id).FirstOrDefaultAsync();
            var companyPeople = await _context.CompanyPeople.Where(e => e.CompanyId == id && e.Status == 3).ToListAsync();
            var status = await _context.CompanyPeople.Where(e => e.CompanyId == id && e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefaultAsync();
            ViewBag.Followers = companyPeople.Count();
            if (status == null)
            {
                ViewBag.Status = 4;
            }
            else
            {
                ViewBag.Status = status.Status;
            }
            return View(company);
        }
        public async Task<IActionResult> EditInformation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInformation(int id, [Bind("Id,Name,Objective,CoverPic,About,Services,CaseStudy,Address,Phone,Email,Instalation,CreateTime")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("CompanyAbout", new {id= id, Messege = "Company Information is Updated" });
            }
            return View(company);
        }
        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.Id == id);
        }
        public async Task<IActionResult> EditOptional(int? id = 1)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOptional(int id, [Bind("Id,About,Services,CaseStudy")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Attach(company);
                    _context.Entry(company).Property("About").IsModified = true;
                    _context.Entry(company).Property("Services").IsModified = true;
                    _context.Entry(company).Property("CaseStudy").IsModified = true;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
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
            return View(company);
        }
        public async Task<IActionResult> EditImage (int? id)
        {
            var companyinfo = await _context.Company.Where(e => e.Id == id).FirstOrDefaultAsync();

            var status = await _context.CompanyPeople.Where(e => e.CompanyId == id && e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefaultAsync();
            if (status!=null)
            {
                ViewBag.UserStatus = status.Status;
            }
            else
            {
                ViewBag.UserStatus = 4;
            }
         
            ViewBag.CompanyInfo = companyinfo;
            return View(companyinfo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditImage( int id, IFormFile CompanyPic)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueFileName = null;
                    if (CompanyPic != null )
                    {
                        string UploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + CompanyPic.FileName;
                        string FilePath = Path.Combine(UploadFolder, uniqueFileName);
                        CompanyPic.CopyTo(new FileStream(FilePath, FileMode.Create));
                    }

                    Company companyup = new Company()
                    {
                        Id = id,
                        CoverPic = uniqueFileName

                    };
                    _context.Attach(companyup);
                    _context.Entry(companyup).Property("CoverPic").IsModified = true;

                    await _context.SaveChangesAsync();
                    
 
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(EditImage));
            }
            return View();
        }


        public int CompanyStatus(int Companyid)
        {
            var status = _context.CompanyPeople.Where(e => e.CompanyId == Companyid && e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(x => new { Status = x.Status }).FirstOrDefault();

            if (status == null)
            {
                return 7;
            }
            else
            {
                int st = status.Status;
                return st;
            }
        }
    }
}