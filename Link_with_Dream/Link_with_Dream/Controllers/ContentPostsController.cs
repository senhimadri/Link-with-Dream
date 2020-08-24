using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Link_with_Dream.Data;
using Link_with_Dream.Models;
using Microsoft.AspNetCore.Authorization;

namespace Link_with_Dream.Controllers
{
    [Authorize]
    public class ContentPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContentPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContentPosts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ContentPost.Include(c => c.CGPoster).Include(c => c.Company).Include(c => c.Group).Include(c => c.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ContentPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentPost = await _context.ContentPost
                .Include(c => c.CGPoster)
                .Include(c => c.Company)
                .Include(c => c.Group)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contentPost == null)
            {
                return NotFound();
            }

            return View(contentPost);
        }

        // GET: ContentPosts/Create
        public IActionResult Create()
        {
            ViewData["CGPosterId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id");
            ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: ContentPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Heading,Description,Image,PostTime,UserId,CompanyId,GroupId,CGPosterId,PostType,DeadLine,JobType,Area,XMStartTime,XMEndTime")] ContentPost contentPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contentPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CGPosterId"] = new SelectList(_context.Users, "Id", "Id", contentPost.CGPosterId);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", contentPost.CompanyId);
            ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Id", contentPost.GroupId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", contentPost.UserId);
            return View(contentPost);
        }

        // GET: ContentPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentPost = await _context.ContentPost.FindAsync(id);
            ViewBag.PostType = contentPost.PostType;
            if (contentPost == null)
            {
                return NotFound();
            }
            ViewData["CGPosterId"] = new SelectList(_context.Users, "Id", "Id", contentPost.CGPosterId);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", contentPost.CompanyId);
            ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Id", contentPost.GroupId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", contentPost.UserId);
            return View(contentPost);
        }

        // POST: ContentPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Heading,Description,Image,PostTime,UserId,CompanyId,GroupId,CGPosterId,PostType,DeadLine,JobType,Area,XMStartTime,XMEndTime")] ContentPost contentPost)
        {
            if (id != contentPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contentPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentPostExists(contentPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index","ContentManagement",new { PostId=contentPost.Id });
            }
            ViewData["CGPosterId"] = new SelectList(_context.Users, "Id", "Id", contentPost.CGPosterId);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", contentPost.CompanyId);
            ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Id", contentPost.GroupId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", contentPost.UserId);
            return View(contentPost);
        }

        // GET: ContentPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentPost = await _context.ContentPost
                .Include(c => c.CGPoster)
                .Include(c => c.Company)
                .Include(c => c.Group)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contentPost == null)
            {
                return NotFound();
            }

            return View(contentPost);
        }

        // POST: ContentPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contentPost = await _context.ContentPost.FindAsync(id);
            _context.ContentPost.Remove(contentPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContentPostExists(int id)
        {
            return _context.ContentPost.Any(e => e.Id == id);
        }
    }
}
