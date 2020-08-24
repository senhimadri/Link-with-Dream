                       using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class CompanyPeople
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int Status { get; set; }
    }
}
