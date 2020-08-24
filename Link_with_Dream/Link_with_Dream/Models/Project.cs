using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

        [Url]
        public string Link { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public bool IsPublic { get; set; }
    }
}
