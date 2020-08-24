using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Link_with_Dream.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Link_with_Dream.Areas.Identity.Pages.Account.Manage
{
    public partial class ProfilePictureModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ProfilePictureModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IWebHostEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.hostingEnvironment = hostingEnvironment;
        }
        [TempData]
        public string StatusMessage { get; set; }
        [TempData]
        public string ProPic { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public IFormFile ProfilePicture { get; set; }

        }
        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            ProPic = user.ProfilePic;

            Input = new InputModel
            {              
            };
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            string uniqueFileName = null;
            if (Input.ProfilePicture != null)
            {
                string UploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Input.ProfilePicture.FileName;
                string FilePath = Path.Combine(UploadFolder, uniqueFileName);
                Input.ProfilePicture.CopyTo(new FileStream(FilePath, FileMode.Create));
            }
            if (uniqueFileName != user.FirstName)
            {
                user.ProfilePic = uniqueFileName;
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
