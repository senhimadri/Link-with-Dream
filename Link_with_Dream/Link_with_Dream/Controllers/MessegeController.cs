using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class MessegeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MessegeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userinfo = await _context.Friendship.Include(e => e.Sender).Include(e => e.Receiver).Where(f => (f.ReceiverId == User.FindFirstValue(ClaimTypes.NameIdentifier) || f.SenderId == User.FindFirstValue(ClaimTypes.NameIdentifier)) && f.Status == 0).ToListAsync();
            return View(userinfo);

        }
        public async Task<IActionResult> ChatCampus( string CUserId)
        {
            var userInfo = await _userManager.FindByIdAsync(CUserId);
            ViewBag.UserInfo = userInfo;
            ViewBag.Myself = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Messege,MessegeTime,SenderId,ReceiverId,IsSeen")] ChatMessege chatMessege)
        {
            if (ModelState.IsValid)
            {
                chatMessege.SenderId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                chatMessege.MessegeTime = DateTime.Now;
                _context.Add(chatMessege);
                await _context.SaveChangesAsync();
                return RedirectToAction("ChatCampus", new { CUserId=chatMessege.ReceiverId });
            }
            return View(chatMessege);
        }

        public async Task<JsonResult> Messges(string Id)
        {
            var d = await _context.ChatMessege.Where(e => (e.ReceiverId == User.FindFirstValue(ClaimTypes.NameIdentifier) && e.SenderId == Id) || (e.SenderId == User.FindFirstValue(ClaimTypes.NameIdentifier) && e.ReceiverId == Id)).OrderByDescending(a => a.MessegeTime).ToListAsync();
            return Json(d);
        }
    }
}