using System;
using Microsoft.EntityFrameworkCore;

namespace ExamQuizAPI.Models.DB
{
    [Keyless]
    public class SpSearchQuestions
    {
        public int QuestionId { get; set; }
        public string QuestionType { get; set; }
        public string Question { get; set; }
        public int NoOfOption { get; set; }
    }
}
