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
    public class ManageGroupPeopleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ManageGroupPeopleController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        #region GroupAdmin
        public async Task<IActionResult> GroupAdmins(int id)
        {
            if (GroupStatus(id)==0)
            {
                var GroupInfo = await _context.Group.Where(e => e.Id == id).FirstOrDefaultAsync();
                ViewBag.GroupInfo = GroupInfo;
                var applicationDbContext = _context.GroupPeople.Include(c => c.Group).Include(c => c.User).Where(e => e.GroupId == id && e.Status == 1);
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                return NotFound();
            }

        }

        public async Task<IActionResult> GroupAddAdmin(int id, string Messege, string searchtext = "" )
        {
            if (GroupStatus(id) == 0)
            {
                ViewBag.group = await _context.Group.Where(e => e.Id == id).FirstOrDefaultAsync();
                ViewBag.Messege = Messege;

                var groupadmin = await _context.GroupPeople.Where(e => e.GroupId == id && (e.Status == 0 || e.Status == 1 || e.Status == 2 || e.Status == 4 || e.Status == 5 || e.Status == 6)).ToListAsync();
                List<string> selectedCollection = new List<string>();

                foreach (var item in groupadmin)
                {
                    selectedCollection.Add(item.UserId);
                }
                if (String.IsNullOrEmpty(searchtext))
                {
                    var UserInfo = await _context.Users.Where(e => !selectedCollection.Contains(e.Id)).ToListAsync();

                    ViewBag.UserInf = UserInfo;
                }
                else
                {
                    var UserInfo = await _context.Users.Where(e => (!selectedCollection.Contains(e.Id) && (e.FirstName.Contains(searchtext) || e.LastName.Contains(searchtext) || e.Email.Contains(searchtext) || e.PhoneNumber.Contains(searchtext) || e.Profession.Contains(searchtext)))).ToListAsync();
                    ViewBag.UserInf = UserInfo;
                }

                return View();
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GroupSetAdmin(string userId, int groupid)
        {
            if (GroupStatus(groupid) == 0)
            {
                if (ModelState.IsValid)
                {
                    GroupPeople groupPeople = new GroupPeople()
                    {
                        UserId = userId,
                        GroupId = groupid,
                        Status = 4
                    };
                    _context.Add(groupPeople);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("GroupAddAdmin", new { id = groupid, Messege="Admin request is Sent" });
                }
                return View();
            }
            else
            {
                return NotFound();
            }
           
        }
        public async Task<IActionResult> GroupAdminRequest()
        {
            var GroupAdminRequest = await _context.GroupPeople.Include(e => e.Group).Where(e => e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier) && e.Status == 4).ToListAsync();
            return View(GroupAdminRequest);
        }

        public async Task<IActionResult> YourCreatedGroup()
        {
            var Groupsaaa = await _context.GroupPeople.Include(e => e.Group).Where(e => e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier) && e.Status == 0).ToListAsync();
            return View(Groupsaaa);
        }
        public async Task<IActionResult> Groupyouareasadmin()
        {
            var Groupsaaa = await _context.GroupPeople.Include(e => e.Group).Where(e => e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier) && e.Status == 1).ToListAsync();
            return View(Groupsaaa);
        }
        //Accept Group admin request by people
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptAdminRequest(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    GroupPeople groupPeople = new GroupPeople()
                    {
                        Id = id,
                        Status = 1
                    };
                    _context.Attach(groupPeople);
                    _context.Entry(groupPeople).Property("Status").IsModified = true;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupPeopleExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(GroupAdminRequest));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptAsAdmin(int GroupId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var gp = await _context.GroupPeople.Where(e => e.GroupId == GroupId && e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(x => new { GPID = x.Id}).FirstOrDefaultAsync(); 
                    GroupPeople groupPeople = new GroupPeople()
                    {
                       Id= gp.GPID,
                       Status = 1
                    };
                    //var groupp = _context.GroupPeople.Where(e => e.GroupId == id && e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
                    _context.Attach(groupPeople);
                    _context.Entry(groupPeople).Property("Status").IsModified = true;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("GroupAbout", "GroupManagement", new { id = GroupId,Messege="Congralutation!! You are an Admin now." });
            }
            return View();
        }


        //Reject Group admin request by people

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectAdminRequest(int id, int ret, int GroupId)
        {
            var groupPeople = await _context.GroupPeople.FindAsync(id);
            _context.GroupPeople.Remove(groupPeople);
            await _context.SaveChangesAsync();
            if (ret == 1)
            {
                return RedirectToAction(nameof(GroupAdminRequest));
            }
            else if (ret == 2)
            {
                //GroupsentAdminRequest
                return RedirectToAction("GroupAdmins", new { id = GroupId });
            }
            else if (ret == 3)
            {
                return RedirectToAction("GroupsentAdminRequest", new { id = GroupId });
            }
            else if (ret==4)
            {
                return RedirectToAction("GroupMembers", new { id = GroupId });
            }
            else if (ret==5)
            {
                return RedirectToAction(nameof(GroupMemberRequest));
            }
            else if (ret ==6)
            {
                return RedirectToAction("GroupsentMemberRequest", new { id = GroupId });
            }
            else
            {
                return NotFound();
            }
        }
        public async Task<IActionResult> GroupsentAdminRequest(int id)
        {
            if (GroupStatus(id) == 0)
            {
                var GroupInfo = await _context.Group.Where(e => e.Id == id).FirstOrDefaultAsync();
                ViewBag.GroupInfo = GroupInfo;
                var GroupAdminsentRequest = await _context.GroupPeople.Include(e => e.User).Where(e => e.GroupId == id && e.Status == 4).ToListAsync();
                return View(GroupAdminsentRequest);
            }
            else
            {
                return NotFound();
            }
            
        }

        private bool GroupPeopleExists(int id)
        {
            return _context.GroupPeople.Any(e => e.Id == id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LeaveasAdmin(int groupid)
        {
            if (GroupStatus(groupid) == 1)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var gp = await _context.GroupPeople.Where(e => e.GroupId == groupid && e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(x => new { gid = x.Id }).FirstOrDefaultAsync();
                        GroupPeople groupPeople = new GroupPeople()
                        {
                            Id = gp.gid,
                            Status = 2
                        };
                        //var groupp = _context.GroupPeople.Where(e => e.GroupId == id && e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
                        _context.Attach(groupPeople);
                        _context.Entry(groupPeople).Property("Status").IsModified = true;
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                    return RedirectToAction("GroupAbout", "GroupManagement", new { id = groupid,Messege="You are no longer an admin now!!" });
                }
                return View();
            }
            else
            {
                return NotFound();
            }
            
        }
        #endregion

        #region Group People
        public async Task<IActionResult> GroupMembers(int id)
        {
            if (GroupStatus(id) == 0 || GroupStatus(id) == 1)
            {
                var GroupInfo = await _context.Group.Where(e => e.Id == id).FirstOrDefaultAsync();
                ViewBag.GroupInfo = GroupInfo;
                var applicationDbContext = _context.GroupPeople.Include(c => c.Group).Include(c => c.User).Where(e => e.GroupId == id && e.Status == 2);
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> GroupAddMember(int id, string searchtext = "")
        {
            if (GroupStatus(id) == 0 || GroupStatus(id) == 1)
            {
                ViewBag.group = await _context.Group.Where(e => e.Id == id).FirstOrDefaultAsync();

                var groupadmin = await _context.GroupPeople.Where(e => e.GroupId == id && (e.Status == 0 || e.Status == 1 || e.Status == 2 || e.Status == 4 || e.Status == 5 || e.Status == 6)).ToListAsync();
                List<string> selectedCollection = new List<string>();

                foreach (var item in groupadmin)
                {
                    selectedCollection.Add(item.UserId);
                }
                if (String.IsNullOrEmpty(searchtext))
                {
                    var UserInfo = await _context.Users.Where(e => !selectedCollection.Contains(e.Id)).ToListAsync();

                    ViewBag.UserInf = UserInfo;
                }
                else
                {
                    var UserInfo = await _context.Users.Where(e => (!selectedCollection.Contains(e.Id) && (e.FirstName.Contains(searchtext) || e.LastName.Contains(searchtext) || e.Email.Contains(searchtext) || e.PhoneNumber.Contains(searchtext) || e.Profession.Contains(searchtext)))).ToListAsync();
                    ViewBag.UserInf = UserInfo;
                }

                return View();
            }
            else
            {
                return NotFound();
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GroupSetMember(string userId, int groupid)
        {
            if (GroupStatus(groupid) == 0 || GroupStatus(groupid) == 1)
            {
                if (ModelState.IsValid)
                {
                    GroupPeople groupPeople = new GroupPeople()
                    {
                        UserId = userId,
                        GroupId = groupid,
                        Status = 5
                    };
                    _context.Add(groupPeople);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("GroupAddMember", new { id = groupid });
                }
                return View();
            }
            else
            {
                return NotFound();
            }
            
        }

        public async Task<IActionResult> GroupMemberRequest()
        {
            var GroupMemberRequest = await _context.GroupPeople.Include(e => e.Group).Where(e => e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier) && e.Status == 5).ToListAsync();
            return View(GroupMemberRequest);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptMemberRequest(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    GroupPeople groupPeople = new GroupPeople()
                    {
                        Id = id,
                        Status = 2
                    };
                    _context.Attach(groupPeople);
                    _context.Entry(groupPeople).Property("Status").IsModified = true;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupPeopleExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(GroupMemberRequest));
            }
            return View();
        }

        public async Task<IActionResult> GroupsentMemberRequest(int id)
        {
            if (GroupStatus(id) == 0 || GroupStatus(id) == 1)
            {
                var GroupInfo = await _context.Group.Where(e => e.Id == id).FirstOrDefaultAsync();
                ViewBag.GroupInfo = GroupInfo;
                var GroupMembersentRequest = await _context.GroupPeople.Include(e => e.User).Where(e => e.GroupId == id && e.Status == 5).ToListAsync();
                return View(GroupMembersentRequest);
            }
            else
            {
                return NotFound();
            }
            
        }
        //Name of the group that you send request to be a member
        public async Task<IActionResult> YoursentRequestGroup()
        {
            var Groupsaaa = await _context.GroupPeople.Include(e => e.Group).Where(e => e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier) && e.Status == 6).ToListAsync();
            return View(Groupsaaa);
        }
        public async Task<IActionResult> YourConnectedGroup()
        {
            var Groupsaaa = await _context.GroupPeople.Include(e => e.Group).Where(e => e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier) && e.Status == 2).ToListAsync();
            return View(Groupsaaa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LeaveasMember(int id)
        {
            if (GroupStatus(id) == 2 || GroupStatus(id) == 6)
            {
                var groupPeople = await _context.GroupPeople.Where(e => e.GroupId == id && e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefaultAsync();
                _context.GroupPeople.Remove(groupPeople);
                await _context.SaveChangesAsync();
                return RedirectToAction("GroupAbout", "GroupManagement", new { id = id ,Messege="You are no longer a member now."});
            }
            else
            {
                return NotFound();
            }
           
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GroupaddRequest(int groupid)
        {
            if (ModelState.IsValid)
            {
                GroupPeople groupPeople = new GroupPeople()
                {
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    GroupId = groupid,
                    Status = 6
                };
                _context.Add(groupPeople);
                await _context.SaveChangesAsync();
                return RedirectToAction("GroupAbout", "GroupManagement", new { id = groupid ,Messege="Your request is sent. You will be a member after accepted by admin."});
            }
            return View();
        }

        public async Task<IActionResult> AddRequestfromMembers(int id)
        {
            if (GroupStatus(id) == 0 || GroupStatus(id) == 1)
            {
                var GroupInfo = await _context.Group.Where(e => e.Id == id).FirstOrDefaultAsync();
                ViewBag.GroupInfo = GroupInfo;
                var applicationDbContext = _context.GroupPeople.Include(c => c.Group).Include(c => c.User).Where(e => e.GroupId == id && e.Status == 6);
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptRequestfromMembers(int id,int GroupId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    GroupPeople groupPeople = new GroupPeople()
                    {
                        Id = id,
                        Status = 2
                    };
                    _context.Attach(groupPeople);
                    _context.Entry(groupPeople).Property("Status").IsModified = true;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupPeopleExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("AddRequestfromMembers", new {id= GroupId });
            }
            return View();
        }
        #endregion


        public  int GroupStatus(int Groupid)
        {
            var status =  _context.GroupPeople.Where(e => e.GroupId == Groupid && e.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(x => new { Status = x.Status }).FirstOrDefault();
            if (status==null)
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