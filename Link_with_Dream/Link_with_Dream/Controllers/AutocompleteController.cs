using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_with_Dream.Data;
using Link_with_Dream.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Link_with_Dream.Controllers
{
    [Route("api/autocomplete")]
    [ApiController]
    public class AutocompleteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutocompleteController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var UserIn = await _context.Users.Where(a => a.FirstName.Contains(term) || a.LastName.Contains(term)).Select(p => p.FirstName).ToListAsync();
                return Ok(UserIn);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}