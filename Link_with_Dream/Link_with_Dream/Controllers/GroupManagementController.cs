using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_with_Dream.Data;
using Microsoft.AspNetCore.Mvc;
using Link_with_Dream.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Link_with_Dream.Controllers
{
    [Authorize]
    public class GroupManagementController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public GroupManagementController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()  
        {
            return View();
        }
        public IActionResult CreateGroup()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGroup([Bind("Id,Name,Objective,TermsCondition,MenbersType,CoverImage")] Group groupc)
        {
            if (ModelState.IsValid)
            {
                groupc.CreateTime = DateTime.Now;
                _context.Add(groupc);
                await _context.SaveChangesAsync();

                GroupPeople groupPeople = new GroupPeople()
                {
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    GroupId=groupc.Id,
                    Status = 0
                };
                _context.Add(groupPeople);
                await _context.SaveChangesAsync();
                return RedirectToAction("GroupAbout" ,new { id = groupc.Id, Messege="Your group is created" });
            }
            return View(groupc);
        }
        public async Task<IActionResult> GroupAbout(int id ,string Messege)
        {
            var groupc = await _context.Group.Where(e => e.Id == id).FirstOrDefaultAsync();
            var groupPeople = await _context.GroupPeople.Where(e => e.GroupId == id && e.Status == 2).ToListAsync();
            ViewBag.Messege = Messege;
            ViewBag.Followers = groupPeople.Count();
            ViewBag.Status = GroupStatus(id);
            return View(groupc);
        }
        public async Task<IActionResult> EditImage(int? id)
        {
            var groupinfo = await _context.Group.Where(e => e.Id == id).FirstOrDefaultAsync();

            var status = await _context.GroupPeople.Where(e => e.GroupId == id && e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefaultAsync();
            if (status != null)
            {
                ViewBag.UserStatus = status.Status;
            }
            else
            {
                ViewBag.UserStatus = 4;
            }

            ViewBag.GroupInfo = groupinfo;
            return View(groupinfo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditImage(int id, IFormFile CompanyPic)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueFileName = null;
                    if (CompanyPic != null)
                    {
                        string UploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + CompanyPic.FileName;
                        string FilePath = Path.Combine(UploadFolder, uniqueFileName);
                        CompanyPic.CopyTo(new FileStream(FilePath, FileMode.Create));
                    }
                    Group groupc = new Group()
                    {
                        Id = id,
                        CoverImage = uniqueFileName
                    };
                    _context.Attach(groupc);
                    _context.Entry(groupc).Property("CoverImage").IsModified = true;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(id))
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
        private bool GroupExists(int id)
        {
            return _context.Group.Any(e => e.Id == id);
        }
        public async Task<IActionResult> GroupEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Group.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }
            if (GroupStatus(@group.Id) == 0)
            {
                return View(@group);
            }
            else
            {
                return NotFound();
            }                             
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GroupEdit(int id, [Bind("Id,Name,Objective,TermsCondition,MenbersType,CoverImage,CreateTime")] Group @group)
        {
            if (GroupStatus(id)==0)
            {
                if (id != @group.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(@group);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!GroupExists(@group.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("GroupAbout", new { id = @group.Id , Messege ="Information is Updated"});
                }
                return View(@group);
            }
            else
            {
                return NotFound();
            }
        }

        public int GroupStatus(int Groupid)
        {
            var status = _context.GroupPeople.Where(e => e.GroupId == Groupid && e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(x => new { Status = x.Status }).FirstOrDefault();
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