using System;
using Microsoft.EntityFrameworkCore;

namespace ExamQuizAPI.Models.DB
{
    [Keyless]
    public class SpListExam
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
    }
}
