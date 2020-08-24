using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public string NotificationText { get; set; }
        public DateTime NotifyTime { get; set; }

        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }

        public string ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }

        public bool IsSeen { get; set; }
    }
}
