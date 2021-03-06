﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class ContentLike
    {
        public int Id { get; set; }
        public int LikeOrUnlike { get; set; }
        public DateTime LikeTime { get; set; }
        public int ContentPostId { get; set; }
        public ContentPost ContentPost { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
