using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Objective { get; set; }
        public string TermsCondition { get; set; }
        public string MenbersType { get; set; }
        public string CoverImage { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
