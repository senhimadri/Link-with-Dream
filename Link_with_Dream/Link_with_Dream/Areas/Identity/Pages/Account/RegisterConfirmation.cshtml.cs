using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Threading.Tasks;
using Link_with_Dream.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Net;

namespace Link_with_Dream.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _sender;

        public RegisterConfirmationModel(UserManager<ApplicationUser> userManager, IEmailSender sender)
        {
            _userManager = userManager;
            _sender = sender;
        }

        public string Email { get; set; }

        public bool DisplayConfirmAccountLink { get; set; }

        public string EmailConfirmationUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string email)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }

            Email = email;
            // Once you add a real email sender, you should remove this code that lets you confirm the account
            DisplayConfirmAccountLink = true;
            if (DisplayConfirmAccountLink)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                EmailConfirmationUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, code = code },
                    protocol: Request.Scheme);

                // Sending email using SMTP

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("linkwithdream2020@gmail.com", "Link with Dream");
                    mail.To.Add(Email);
                    mail.Subject = "Account Confirmation";
                    mail.Body = "<h2> Welcome to Link with Dream</h2> <p> Click this Bellow link to conferm your email. After clicking this you will be able to Login your account</p> <a href=" + EmailConfirmationUrl + ">Click Here</a>";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = new NetworkCredential("linkwithdream2020@gmail.com", "Jiko@mia@1330");
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(mail);
                    }
                }
            }

            return Page();
        }
    }
}
