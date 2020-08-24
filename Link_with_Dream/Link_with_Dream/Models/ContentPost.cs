using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class ContentPost
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime PostTime { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public string CGPosterId { get; set; }
        public ApplicationUser CGPoster { get; set; }

        // 1= NormalUserPost ,2= Group Post , 3= Company Post , 4 = Job Post Without Exam , 5 = Job Post With Exam
        public int PostType { get; set; }
        public DateTime DeadLine { get; set; }

        public  string JobType { get; set; }
        public string Area { get; set; }

        public DateTime XMStartTime { get; set; }
        public DateTime XMEndTime { get; set; }

    }
}
