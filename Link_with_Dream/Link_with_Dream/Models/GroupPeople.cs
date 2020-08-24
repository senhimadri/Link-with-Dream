using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class GroupPeople
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int Status { get; set; }
    }
}
