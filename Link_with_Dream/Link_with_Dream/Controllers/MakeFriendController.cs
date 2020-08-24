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
    public class MakeFriendController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MakeFriendController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SearchPeople(string searchtext = "")
        {
            var fff = await _context.Friendship.Where(e => e.SenderId == User.FindFirstValue(ClaimTypes.NameIdentifier) || e.ReceiverId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToListAsync();
            List<string> aa = new List<string>();
            foreach (var item in fff)
            {
                if (item.ReceiverId == User.FindFirstValue(ClaimTypes.NameIdentifier))
                {
                    aa.Add(item.SenderId);
                }
                else if (item.SenderId == User.FindFirstValue(ClaimTypes.NameIdentifier))
                {
                    aa.Add(item.ReceiverId);
                }
            }
            if (String.IsNullOrEmpty(searchtext))
            {

                var UserInfo = await _context.Users.Where(e=>e.Id!= User.FindFirstValue(ClaimTypes.NameIdentifier) && !aa.Contains(e.Id)).ToListAsync();
                ViewBag.RCount= UserInfo.Count();
                ViewBag.UserInf = UserInfo;
            }
            else
            {
                var UserInfo = await _context.Users.Where(e => (e.FirstName.Contains(searchtext) || e.LastName.Contains(searchtext) || e.Email.Contains(searchtext) || e.PhoneNumber.Contains(searchtext) || e.Profession.Contains(searchtext)) &&(e.Id!= User.FindFirstValue(ClaimTypes.NameIdentifier)) && !aa.Contains(e.Id)).ToListAsync();
                ViewBag.UserInf = UserInfo;
                ViewBag.RCount = UserInfo.Count();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendFriendrequest(string userId)
        {
            if (ModelState.IsValid)
            {
                Friendship friendship = new Friendship()
                {
                    SenderId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    ReceiverId = userId,
                    Status = 1
                };
                _context.Add(friendship);
                await _context.SaveChangesAsync();
                return RedirectToAction("SearchPeople");
            }
            return View();
        }
        public async Task<IActionResult> FriendRequestlist()
        {
            var userinfo = await _context.Friendship.Include(e => e.Sender).Where(f => f.ReceiverId == User.FindFirstValue(ClaimTypes.NameIdentifier) && f.Status==1).ToListAsync();
            return View(userinfo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptFriendrequest(int id)
        {
            if (ModelState.IsValid)
            {
                Friendship friendship = new Friendship()
                {
                    Id = id,
                    Status = 0
                };
                _context.Attach(friendship);
                _context.Entry(friendship).Property("Status").IsModified = true;
                await _context.SaveChangesAsync();
                return RedirectToAction("FriendRequestlist");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectFriendship(int id, int ret)
        {
            var friendship = await _context.Friendship.FindAsync(id);
            _context.Friendship.Remove(friendship);
            await _context.SaveChangesAsync();
            if (ret == 1)
            {
                return RedirectToAction(nameof(Friendlist));
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Friendlist()
        {
            ViewBag.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userinfo = await _context.Friendship.Include(e => e.Sender).Include(e=>e.Receiver).Where(f => (f.ReceiverId == User.FindFirstValue(ClaimTypes.NameIdentifier)|| f.SenderId == User.FindFirstValue(ClaimTypes.NameIdentifier)) && f.Status == 0).ToListAsync();
            return View(userinfo);
        }




    }
}