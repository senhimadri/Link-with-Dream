using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Link_with_Dream.Models
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public string Option { get; set; }

        public int QuestionSerial { get; set; }

        public bool IsCorrest { get; set; }
        public int ExamQuestionId { get; set; }
        public ExamQuestion ExamQuestion { get; set; }
    }
}
