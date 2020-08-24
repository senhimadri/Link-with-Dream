using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class CareerInformation
    {
        [Key]
        public string Id { get; set; }

        [Display(Name = "Carrier Objective")]
        public string CarrierObjective { get; set; }

        [Display(Name = "Looking For")]
        public string LookingFor { get; set; }

        [Display(Name = "Available For")]
        public string AvailableFor { get; set; }

        [Display(Name = "Prefered Job Catagory - 1")]
        public string PreferedJobCatagory1 { get; set; }

        [Display(Name = "Prefered Job Catagory - 2")]
        public string PreferedJobCatagory2 { get; set; }

        [Display(Name = "Prefered Job Catagory - 3")]
        public string PreferedJobCatagory3 { get; set; }

        [Display(Name = "Prefered Area - 1")]
        public string PreferdArea1 { get; set; }

        [Display(Name = "Prefered Area - 2")]
        public string PreferdArea2 { get; set; }

        public string ExpectedSalary { get; set; }
        public bool IsPublic { get; set; }
    }
}
