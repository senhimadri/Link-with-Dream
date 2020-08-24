using Link_with_Dream.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Link_with_Dream.Data
{
    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public MyUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            //identity.AddClaim(new Claim("ContactName", user.ContactName ?? "[Click to edit profile]"));

            identity.AddClaim(new Claim("FirstName", user.FirstName ?? "[Click to edit profile]"));
            identity.AddClaim(new Claim("LastName", user.LastName ?? "[Click to edit profile]"));
            identity.AddClaim(new Claim("ProfilePic", user.ProfilePic ?? "[Click to edit profile]"));
            identity.AddClaim(new Claim("PersonalObjective", user.PersonalObjective ?? "[Click to edit profile]"));
            identity.AddClaim(new Claim("DateOfBirth", user.DateOfBirth.ToString() ?? "[Click to edit profile]"));
            identity.AddClaim(new Claim("Gender", user.Gender ?? "[Click to edit profile]"));
            identity.AddClaim(new Claim("Nationality", user.Nationality ?? "[Click to edit profile]"));
            identity.AddClaim(new Claim("Religion", user.Religion ?? "[Click to edit profile]"));

            return identity;
        }
    }
}
