using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Objective { get; set; }
        public string CoverPic { get; set; }
        public string About { get; set; }
        public string Services { get; set; }
        public string CaseStudy { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime Instalation  { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
