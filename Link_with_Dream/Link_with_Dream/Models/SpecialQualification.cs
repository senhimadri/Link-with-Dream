using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class SpecialQualification
    {
        public int Id { get; set; }

        [Display(Name = "Course Title")]
        public string CourseTitle { get; set; }
        public string Topic { get; set; }
        public string Institute { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public bool IsPublic { get; set; }
        public int ForTesting { get; set; }
    }
}
