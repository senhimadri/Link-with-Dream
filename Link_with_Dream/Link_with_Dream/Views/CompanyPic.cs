﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Views
{
    public class CompanyPic
    {
        public int Id { get; set; }
        public IFormFile Photo { get; set; }
    }
}
