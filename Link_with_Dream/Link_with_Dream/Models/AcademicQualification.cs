using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class AcademicQualification
    {
        public int Id { get; set; }
        [Display(Name = "Exam Name")]
        public string ExamName { get; set; }
        public string Subject { get; set; }
        public string Institute { get; set; }
        public string Board { get; set; }

        [Display(Name = "Passing Year")]
        public int PassingYear { get; set; }
        public string Result { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public bool IsPublic { get; set; }
    }
}
