using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class CandidateAnswer
    {
        public int Id { get; set; }
        public int QuestionAnswerId { get; set; }
        public QuestionAnswer QuestionAnswer { get; set; }
        public bool IsCorrect { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
