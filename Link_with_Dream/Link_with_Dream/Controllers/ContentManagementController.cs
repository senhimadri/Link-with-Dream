using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Link_with_Dream.Data;
using Link_with_Dream.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Link_with_Dream.Controllers
{
    [Authorize]
    public class ContentManagementController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public ContentManagementController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
        }
        public async Task<IActionResult> Index(int PostId)
        {
            var content = await _context.ContentPost.Include(e=>e.User).Include(e=>e.Group).Include(e=>e.Company).Include(e=>e.CGPoster).Where(e => e.Id == PostId).FirstOrDefaultAsync();
            if (!String.IsNullOrEmpty(content.Image))
            {
                ViewBag.Img = true;
            }
            else
            {
                ViewBag.Img = false;
            }

            var commment = await _context.ContentComents.Include(e => e.User).Where(e => e.ContentPostId == PostId).OrderByDescending(e => e.Id).ToListAsync();
            ViewBag.Coments = commment;
            ViewBag.UserInfo = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(content);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PersonalContentPost(string heading,string description, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueFileName = null;
                    if (image != null)
                    {
                        string UploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                        string FilePath = Path.Combine(UploadFolder, uniqueFileName);
                        image.CopyTo(new FileStream(FilePath, FileMode.Create));
                    }
                    ContentPost contentPost = new ContentPost()
                    {
                        Heading = heading,
                        Description= description,
                        Image = uniqueFileName,
                        PostTime = DateTime.Now,
                        UserId= User.FindFirstValue(ClaimTypes.NameIdentifier),
                        CompanyId=1,
                        GroupId=1,
                        CGPosterId= "bb652709-b818-484e-b550-c49f6942d149",
                        PostType=0
                    };
                    _context.Add(contentPost);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home", new { messege ="Your content is uploaded successfully"});

                }
                catch (Exception)
                {
                    throw;
                }
            }
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompanyContentPost(string heading, string description, IFormFile image, int companyId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueFileName = null;
                    if (image != null)
                    {
                        string UploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                        string FilePath = Path.Combine(UploadFolder, uniqueFileName);
                        image.CopyTo(new FileStream(FilePath, FileMode.Create));
                    }
                    ContentPost contentPost = new ContentPost()
                    {
                        Heading = heading,
                        Description = description,
                        Image = uniqueFileName,
                        PostTime = DateTime.Now,
                        UserId = "bb652709-b818-484e-b550-c49f6942d149",
                        CompanyId = companyId,
                        GroupId = 1,
                        CGPosterId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                        PostType = 1
                    };
                    _context.Add(contentPost);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("CompanyPost", "CompanyProfile", new {id=companyId, messege = "Your content is uploaded successfully" });

                }
                catch (Exception)
                {
                    throw;
                }
            }
            return RedirectToAction("CompanyPost", "CompanyProfile", new { id = companyId, messege = "Content in not Uploaded! There is somethinf wrong!!!" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompanyJobCircular(string heading, string description, IFormFile image, int companyId, string jobType,string area, DateTime deadLine)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueFileName = null;
                    if (image != null)
                    {
                        string UploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                        string FilePath = Path.Combine(UploadFolder, uniqueFileName);
                        image.CopyTo(new FileStream(FilePath, FileMode.Create));
                    }
                    ContentPost contentPost = new ContentPost()
                    {
                        Heading = heading,
                        Description = description,
                        Image = uniqueFileName,
                        PostTime = DateTime.Now,
                        UserId = "bb652709-b818-484e-b550-c49f6942d149",
                        CompanyId = companyId,
                        GroupId = 1,
                        CGPosterId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                        PostType = 2,
                        JobType=jobType,
                        Area = area,
                        DeadLine = deadLine
                    };
                    _context.Add(contentPost);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("CompanyPost", "CompanyProfile", new { id = companyId, messege = "Your content is uploaded successfully" });

                }
                catch (Exception)
                {
                    throw;
                }
            }
            return RedirectToAction("CompanyPost", "CompanyProfile", new { id = companyId, messege = "Content in not Uploaded! There is somethinf wrong!!!" });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Coments(int contentId, string coments)
        {
            if (ModelState.IsValid)
            {
                ContentComents contentComents = new ContentComents()
                {
                    ContentPostId = contentId,
                    Coment = coments,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    ComentTime = DateTime.Now
                };
                 _context.Add(contentComents);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index",new { PostId = contentId });
            }
            return View();
        }

    }
}