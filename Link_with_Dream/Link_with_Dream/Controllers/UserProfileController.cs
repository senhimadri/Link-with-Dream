using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Link_with_Dream.Data;
using Link_with_Dream.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Link_with_Dream.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            string CUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var personalinformation = await _userManager.GetUserAsync(User);
            var academicqualification = await _context.AcademicQualification.Where(a => a.UserId == CUserId).ToListAsync();
            var specialqualification = await _context.SpecialQualification.Where(a => a.UserId == CUserId).ToListAsync();
            var profetionalskill = await _context.ProfessionalSkill.Where(a => a.UserId == CUserId).ToListAsync();
            var workingexperience = await _context.WorkingExperience.Where(a => a.UserId == CUserId).ToListAsync();
            var project = await _context.Project.Where(a => a.UserId == CUserId).ToListAsync();
            var jobprofile = await _context.CareerInformation.Where(a => a.Id == CUserId).FirstOrDefaultAsync();

            if (academicqualification.Count != 0)
            {
                ViewBag.academicqualification = academicqualification;
                ViewBag.isacademicqualification = true;
            }
            else
            {
                ViewBag.academicqualification = null;
                ViewBag.isacademicqualification = false;
            }
            if (specialqualification.Count != 0)
            {
                ViewBag.specialqualification = specialqualification;
                ViewBag.isspecialqualification = true;
            }
            else
            {
                ViewBag.specialqualification = null;
                ViewBag.isspecialqualification = false;
            }

            if (profetionalskill.Count != 0)
            {
                ViewBag.profetionalskill = profetionalskill;
                ViewBag.isprofetionalskill = true;
            }
            else
            {
                ViewBag.profetionalskill = null;
                ViewBag.isprofetionalskill = false;
            }
            if (workingexperience.Count != 0)
            {
                ViewBag.workingexperience = workingexperience;
                ViewBag.isworkingexperience = true;
            }
            else
            {
                ViewBag.workingexperience = null;
                ViewBag.isworkingexperience = false;
            }
            if (project.Count != 0)
            {
                ViewBag.project = project;
                ViewBag.isproject = true;
            }
            else
            {
                ViewBag.project = null;
                ViewBag.isproject = false;
            }
            if (jobprofile != null)
            {
                ViewBag.jobprofile = jobprofile;
                ViewBag.isjobprofile = true;
            }
            else
            {
                ViewBag.jobprofile = null;
                ViewBag.isjobprofile = false;
            }

            return View();
        }

        public async Task<IActionResult> About(string CUserId , string Messege)
        {
            if (String.IsNullOrEmpty(CUserId))
            {
                CUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            var personalinformation = await _userManager.FindByIdAsync(CUserId);
            var academicqualification = await _context.AcademicQualification.Where(a => a.UserId == CUserId).ToListAsync();
            ViewBag.Userinfo = personalinformation;
            ViewBag.Status = status(CUserId);
            ViewBag.Messege = Messege;
            if (academicqualification.Count != 0)
            {
                ViewBag.isacademicqualification = true;
            }
            else
            {
                ViewBag.isacademicqualification = false;
            }
            return View(academicqualification);
        }

        public async Task<IActionResult> Post(string CUserId, string Messege)
        {
            if (String.IsNullOrEmpty(CUserId))
            {
                CUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            var personalinformation = await _userManager.FindByIdAsync(CUserId);
            var Posts = await _context.ContentPost.Where(a => a.UserId == CUserId).ToListAsync();
            ViewBag.Userinfo = personalinformation;
            ViewBag.Status = status(CUserId);
            ViewBag.Messege = Messege;
            var contenposts = await _context.ContentPost.Include(e => e.User)
               .Where(e=>e.UserId==CUserId && e.PostType==0).OrderByDescending(e => e.Id).ToListAsync();

            ViewBag.Content = contenposts;
            if (Posts.Count != 0)
            {
                ViewBag.haspost = true;
            }
            else
            {
                ViewBag.haspost = false;
            }
            return View(Posts);
        }

        public async Task<IActionResult> AcademicQualification(string CUserId, string Messege)
        {
            if (String.IsNullOrEmpty(CUserId))
            {
                CUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            if (CUserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                ViewBag.IsUser = true;
                var academicqualification = await _context.AcademicQualification.Where(a => a.UserId == CUserId).ToListAsync();
                var personalinformation = await _userManager.FindByIdAsync(CUserId);
                ViewBag.Status = status(CUserId);
                ViewBag.Userinfo = personalinformation;
                ViewBag.Messege = Messege;
                if (academicqualification.Count != 0)
                {
                    ViewBag.isacademicqualification = true;
                }
                else
                {
                    ViewBag.isacademicqualification = false;
                }
                return View(academicqualification);          
            }
            else
            {
                ViewBag.IsUser = false;
                var academicqualification = await _context.AcademicQualification.Where(a => a.UserId == CUserId && a.IsPublic==true).ToListAsync();
                var personalinformation = await _userManager.FindByIdAsync(CUserId);
                ViewBag.Status = status(CUserId);
                ViewBag.Userinfo = personalinformation;
                ViewBag.Messege = Messege;
                if (academicqualification.Count != 0)
                {
                    ViewBag.isacademicqualification = true;
                }
                else
                {
                    ViewBag.isacademicqualification = false;
                }
                return View(academicqualification);
            }            
        }

        public async Task<IActionResult> SpecialQualification(string CUserId, string Messege)
        {
            if (String.IsNullOrEmpty(CUserId))
            {
                CUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            if (CUserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                ViewBag.IsUser = true;
                var personalinformation = await _userManager.FindByIdAsync(CUserId);
                var specialqualification = await _context.SpecialQualification.Where(a => a.UserId == CUserId).ToListAsync();
                ViewBag.Userinfo = personalinformation;
                ViewBag.Status = status(CUserId);
                ViewBag.Messege = Messege;
                if (specialqualification.Count != 0)
                {
                    ViewBag.isspecialqualification = true;
                }
                else
                {
                    ViewBag.isspecialqualification = false;
                }
                return View(specialqualification);
            }
            else
            {
                ViewBag.IsUser = false;
                var specialqualification = await _context.SpecialQualification.Where(a => a.UserId == CUserId && a.IsPublic == true).ToListAsync();
                var personalinformation = await _userManager.FindByIdAsync(CUserId);

                ViewBag.Userinfo = personalinformation;
                ViewBag.Status = status(CUserId);
                ViewBag.Messege = Messege;
                if (specialqualification.Count != 0)
                {
                    ViewBag.isspecialqualification = true;
                }
                else
                {
                    ViewBag.isspecialqualification = false;
                }
                return View(specialqualification);
            }
        }

        public async Task<IActionResult> ProfetionalSkill(string CUserId, string Messege)
        {
            if (String.IsNullOrEmpty(CUserId))
            {
                CUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            if (CUserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                ViewBag.IsUser = true;
                var personalinformation = await _userManager.FindByIdAsync(CUserId);
                var profetionalSkill = await _context.ProfessionalSkill.Where(a => a.UserId == CUserId).ToListAsync();
                ViewBag.Userinfo = personalinformation;
                ViewBag.Messege = Messege;
                ViewBag.Status = status(CUserId);
                if (profetionalSkill.Count != 0)
                {
                    ViewBag.isprofetionalSkill = true;
                }
                else
                {
                    ViewBag.isprofetionalSkill = false;
                }
                return View(profetionalSkill);
            }
            else
            {
                ViewBag.IsUser = false;
                var profetionalSkill = await _context.ProfessionalSkill.Where(a => a.UserId == CUserId && a.IsPublic == true).ToListAsync();
                var personalinformation = await _userManager.FindByIdAsync(CUserId);

                ViewBag.Userinfo = personalinformation;
                ViewBag.Messege = Messege;
                ViewBag.Status = status(CUserId);
                if (profetionalSkill.Count != 0)
                {
                    ViewBag.isprofetionalSkill = true;
                }
                else
                {
                    ViewBag.isprofetionalSkill = false;
                }
                return View(profetionalSkill);
            }
        }

        public async Task<IActionResult> WorkingExperience(string CUserId, string Messege)
        {
            if (String.IsNullOrEmpty(CUserId))
            {
                CUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            if (CUserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            { 
                ViewBag.IsUser = true;
                var personalinformation = await _userManager.FindByIdAsync(CUserId);
                var workingExperience = await _context.WorkingExperience.Where(a => a.UserId == CUserId).ToListAsync();
                ViewBag.Userinfo = personalinformation;
                ViewBag.Messege = Messege;
                ViewBag.Status = status(CUserId);
                if (workingExperience.Count != 0)
                {
                    ViewBag.isworkingExperience = true;
                }
                else
                {
                    ViewBag.isworkingExperience = false;
                }
                return View(workingExperience);
            }
            else
            {
                ViewBag.IsUser = false;
                var workingExperience = await _context.WorkingExperience.Where(a => a.UserId == CUserId && a.IsPublic == true).ToListAsync();
                var personalinformation = await _userManager.FindByIdAsync(CUserId);
                ViewBag.Status = status(CUserId);
                ViewBag.Userinfo = personalinformation;
                ViewBag.Messege = Messege;
                if (workingExperience.Count != 0)
                {
                    ViewBag.isworkingExperience = true;
                }
                else
                {
                    ViewBag.isworkingExperience = false;
                }
                return View(workingExperience);
            }
        }

        public async Task<IActionResult> Project(string CUserId, string Messege)
        {
            if (String.IsNullOrEmpty(CUserId))
            {
                CUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            if (CUserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                ViewBag.IsUser = true;
                ViewBag.Status = status(CUserId);
                var personalinformation = await _userManager.FindByIdAsync(CUserId);
                var project = await _context.Project.Where(a => a.UserId == CUserId).ToListAsync();
                ViewBag.Userinfo = personalinformation;
                ViewBag.Messege = Messege;
                if (project.Count != 0)
                {
                    ViewBag.isproject = true;
                }
                else
                {
                    ViewBag.isproject = false;
                }
                return View(project);
            }                    
            else
            {
                ViewBag.IsUser = false;
                var project = await _context.Project.Where(a => a.UserId == CUserId && a.IsPublic == true).ToListAsync();
                var personalinformation = await _userManager.FindByIdAsync(CUserId);
                ViewBag.Status = status(CUserId);
                ViewBag.Userinfo = personalinformation;
                ViewBag.Messege = Messege;
                if (project.Count != 0)
                {
                    ViewBag.isproject = true;
                }
                else
                {
                    ViewBag.isproject = false;
                }
                return View(project);
            }
        }

        public async Task<IActionResult> CareerInformation(string CUserId, string Messege)
        {
            if (String.IsNullOrEmpty(CUserId))
            {
                CUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            if (CUserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                ViewBag.IsUser = true;
                var personalinformation = await _userManager.FindByIdAsync(CUserId);
                var jobprofile = await _context.CareerInformation.Where(a => a.Id == CUserId).FirstOrDefaultAsync();
                ViewBag.Userinfo = personalinformation;
                ViewBag.Messege = Messege;
                ViewBag.Status = status(CUserId);
                if (jobprofile != null)
                {
                    ViewBag.isjobprofile = true;
                    ViewBag.Id = jobprofile.Id;
                }
                else
                {
                    ViewBag.isjobprofile = false;
                }
                return View(jobprofile);
            }
               
            
            else
            {
                ViewBag.IsUser = false;
                var personalinformation = await _userManager.FindByIdAsync(CUserId);
                var jobprofile = await _context.CareerInformation.Where(a => a.Id == CUserId && a.IsPublic==true).FirstOrDefaultAsync();
                ViewBag.Userinfo = personalinformation;
                ViewBag.Messege = Messege;
                ViewBag.Status = status(CUserId);
                if (jobprofile != null)
                {
                    ViewBag.isjobprofile = true;
                }
                else
                {
                    ViewBag.isjobprofile = false;
                }
                return View(jobprofile);
            }
            
        }

        public int status(string UserId)
        {
            string CurrentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int st;
            var se = _context.Friendship.Where(e => e.SenderId == CurrentUser && e.ReceiverId == UserId & e.Status==1).FirstOrDefault();
            var re = _context.Friendship.Where(e => (e.SenderId == UserId && e.ReceiverId == CurrentUser & e.Status == 1)).FirstOrDefault();
            var fr = _context.Friendship.Where(e => (((e.SenderId == UserId && e.ReceiverId == CurrentUser)|| (e.SenderId == CurrentUser && e.ReceiverId == UserId)) & e.Status == 0)).FirstOrDefault();

            if (UserId== CurrentUser)
            {
                st = 0;
                //The Profile is yours
            }
            else
            {
                if (se!= null)
                {
                    st = 1;
                    //Yoy send request to this profile
                }
                else if (re!=null)
                {
                    st = 2;
                    //Profile Send Request to you
                }
                else if (fr!=null)
                {
                    st = 3;
                    //He is your Friend
                }
                else
                {
                    st = 4;
                    //He is your nothing
                }
            }
            return st;
        }
    }
}