using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public string ProfilePic { get; set; }
        public string PersonalObjective { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
    }
}
