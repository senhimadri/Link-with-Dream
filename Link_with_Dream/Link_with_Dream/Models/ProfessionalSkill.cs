using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class ProfessionalSkill
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public bool IsPublic { get; set; }
    }
}
