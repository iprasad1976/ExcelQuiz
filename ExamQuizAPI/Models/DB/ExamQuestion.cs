using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace ExamQuizAPI.Models.DB
{
    [Keyless]
    public partial class ExamQuestion
    {
        public int ExamQuestionId { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string IsActive { get; set; }
    }
}
