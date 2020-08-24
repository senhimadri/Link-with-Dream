using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Link_with_Dream.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Mail;
using System.Net;

namespace Link_with_Dream.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public ForgotPasswordModel(UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user != null || (await _userManager.IsEmailConfirmedAsync(user)))
                {
                    var code = await _userManager.GeneratePasswordResetTokenAsync(user);

                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var email = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(user.Email));
                    var callbackUrl = Url.Page(
                        "/Account/ResetPassword",
                        pageHandler: null,
                        values: new { area = "Identity", code=code, email = email },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(
                        Input.Email,
                        "Reset Password",
                        $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    // Sending email using SMTP

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("linkwithdream2020@gmail.com", "Link with Dream");
                        mail.To.Add(user.Email);
                        mail.Subject = "Password Recovery";
                        mail.Body = "<h2>Link with Dream</h2> <p>Dear "+user.FirstName+",</p> <p> Click this Bellow link to recover your password. After clicking this you will find a page to recover your account</p> <a href=" + callbackUrl + ">Click Here</a>";
                        mail.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.UseDefaultCredentials = true;
                            smtp.Credentials = new NetworkCredential("linkwithdream2020@gmail.com", "Jiko@mia@1330");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }
                    return RedirectToPage("./ForgotPasswordConfirmation");            
                }
               
                else
                {
                    // Don't reveal that the user does not exist or is not confirmed.
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }
                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
            }

            return Page();
        }
    }
}
