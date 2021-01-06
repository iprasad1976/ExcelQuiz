using System;
using Microsoft.EntityFrameworkCore;

namespace ExamQuizAPI.Models.DB
{
    [Keyless]
    public class SpQuestionOptions
    {
        public int SlNo { get; set; }
        public int QuestionOptionsId { get; set; }
        public string Option { get; set; }
        public string IsSelected { get; set; }
    }
}
