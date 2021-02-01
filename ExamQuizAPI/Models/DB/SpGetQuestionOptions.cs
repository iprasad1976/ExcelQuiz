using System;
using Microsoft.EntityFrameworkCore;

namespace ExamQuizAPI.Models.DB
{
    [Keyless]
    public class SpGetQuestionOptions
    {
        public int QuestionOptionsId { get; set; }
        public int SlNo { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }
    }
}
