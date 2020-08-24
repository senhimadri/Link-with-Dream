using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Link_with_Dream.Models;
using Link_with_Dream.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Link_with_Dream.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(string messege)
        {
            string usser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var groups = await _context.GroupPeople.Where(e => e.UserId == usser).ToListAsync();
            List<int> Groupaa = new List<int>();
            foreach (var item in groups)
            {
                Groupaa.Add(item.GroupId);
            }

            var Companies = await _context.CompanyPeople.Where(e => e.UserId == usser).ToListAsync();
            List<int> Companieaa = new List<int>();
            foreach (var item in Companies)
            {
                Companieaa.Add(item.CompanyId);
            }

            var friends = await _context.Friendship.Where(e => e.SenderId == User.FindFirstValue(ClaimTypes.NameIdentifier) || e.ReceiverId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToListAsync();
            List<string> friendsaa = new List<string>();
            foreach (var item in friends)
            {
                if (item.ReceiverId == User.FindFirstValue(ClaimTypes.NameIdentifier))
                {
                    friendsaa.Add(item.SenderId);
                }
                else if (item.SenderId == User.FindFirstValue(ClaimTypes.NameIdentifier))
                {
                    friendsaa.Add(item.ReceiverId);
                }
            }

            var contenposts = await _context.ContentPost.Include(e => e.User).Include(e => e.Group).Include(e => e.Company).Include(e => e.CGPoster)
                .Where(c => Groupaa.Contains(c.GroupId) || Companieaa.Contains(c.CompanyId)|| friendsaa.Contains(c.UserId) || c.UserId== usser).OrderByDescending(e => e.Id).ToListAsync();

            ViewBag.Content = contenposts;
            var UserInfo = await _userManager.GetUserAsync(User);
            ViewBag.UserInfo = UserInfo;
            ViewBag.Messege = messege;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        public async Task <IActionResult> Network(int type,string searchtext="")
        {
            if (String.IsNullOrEmpty(searchtext))
            {
                return View();
            }
            else
            {
                ViewBag.Type = type;
                if (type==1)
                {
                    var People = await _context.Users.Where(e => e.FirstName.ToLower().Contains(searchtext.ToLower()) || e.LastName.ToLower().Contains(searchtext.ToLower()) || e.Email==searchtext || e.PhoneNumber==searchtext || e.Profession.ToLower().Contains(searchtext.ToLower())).ToListAsync();
                    ViewBag.People = People;
                }
                if (type==2)
                {
                    var Group = await _context.Group.Where(e => e.Name.ToLower().Contains(searchtext.ToLower()) || e.MenbersType.ToLower().Contains(searchtext.ToLower())).ToListAsync();
                    ViewBag.Group = Group;
                }
                if (type==3)
                {
                    var Company = await _context.Company.Where(e => e.Name.ToLower().Contains(searchtext.ToLower()) || e.Address.ToLower().Contains(searchtext.ToLower())||e.Email==searchtext || e.Phone==searchtext).ToListAsync();
                    ViewBag.Company = Company;
                }
            }
            return View();
        }

        public async Task<IActionResult> SearchJob (string searchtext="")
        {
            if (!String.IsNullOrEmpty(searchtext))
            {
                var jobs = await _context.ContentPost.Include(e => e.Company).Include(e => e.CGPoster).Where(e => e.PostType == 2 && (e.JobType.Contains(searchtext) || e.Area.Contains(searchtext) || e.Company.Name.Contains(searchtext)) && e.DeadLine > DateTime.Now).ToListAsync();
                ViewBag.Content = jobs;
                ViewBag.aa = true;
            }
            else
            {
                ViewBag.aa = false;
            }
            return View();
        }
    }
}
