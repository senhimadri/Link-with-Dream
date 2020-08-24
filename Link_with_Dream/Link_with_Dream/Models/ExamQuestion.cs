using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class ExamQuestion
    {
        public int Id { get; set; }
        public string QuestionHeading { get; set; }
        public DateTime CreateDate { get; set; }

        public int ContentPostId { get; set; }
        public ContentPost ContentPost { get; set; }
    }
}
