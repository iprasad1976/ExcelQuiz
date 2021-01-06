using System;
using Microsoft.EntityFrameworkCore;

namespace ExamQuizAPI.Models.DB
{
    [Keyless]
    public class SpNextPrevQuestion
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public int QuestionTypeId { get; set; }
        public int MarkValue { get; set; }
    }
}
