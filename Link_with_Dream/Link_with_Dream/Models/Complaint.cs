                                                                                                                                                                                                                                         using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class Complaint
    {
        public int Id { get; set; }
        public string ComplaintText { get; set; }
        public string RefImage { get; set; }
        public DateTime ComplaintTime { get; set; }
        public string ComplentById { get; set; }
        public ApplicationUser ComplentBy { get; set; }

        public string ComplentToId { get; set; }
        public ApplicationUser ComplentTo { get; set; }
    }
}
