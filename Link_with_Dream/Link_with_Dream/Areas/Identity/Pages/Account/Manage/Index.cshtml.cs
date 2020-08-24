using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Link_with_Dream.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Link_with_Dream.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "Profession")]
            public string Profession { get; set; }

            [Display(Name = "Personal Objective")]
            public string PersonalObjective { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Date Of Birth")]
            public DateTime DateOfBirth { get; set; }

            [Display(Name = "Address")]
            public string Address { get; set; }

            [Display(Name = "Gender")]
            public string Gender { get; set; }

            [Display(Name = "Nationality")]
            public string Nationality { get; set; }

            [Display(Name = "Religion")]
            public string Religion { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Profession = user.Profession,
                PersonalObjective = user.PersonalObjective,
                DateOfBirth = user.DateOfBirth,
                Address=user.Address,
                Gender = user.Gender,
                Nationality = user.Nationality,
                Religion = user.Religion
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

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.FirstName != user.FirstName)
            {
                user.FirstName = Input.FirstName;
                await _userManager.UpdateAsync(user);
            }
            if (Input.LastName != user.LastName)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
            }
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }
            if (Input.Profession != user.Profession)
            {
                user.Profession = Input.Profession;
                await _userManager.UpdateAsync(user);
            }

            if (Input.PersonalObjective != user.PersonalObjective)
            {
                user.PersonalObjective = Input.PersonalObjective;
                await _userManager.UpdateAsync(user);
            }
            if (Input.DateOfBirth != user.DateOfBirth)
            {
                user.DateOfBirth = Input.DateOfBirth;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Gender != user.Gender)
            {
                user.Gender = Input.Gender;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Address != user.Address)
            {
                user.Address = Input.Address;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Nationality != user.Nationality)
            {
                user.Nationality = Input.Nationality;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Religion != user.Religion)
            {
                user.Religion = Input.Religion;
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
