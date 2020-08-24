using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class WorkingExperience
    {
        public int Id { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        [Display(Name = "Company Address")]
        public string CompanyAddress { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public bool IsPublic { get; set; }
    }
}
