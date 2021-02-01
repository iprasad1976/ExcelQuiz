using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamQuizAPI.Models.DB
{
    [Keyless]
    public class SpGetQuestionExam
    {
        public int ExamId { get; set; }
        public int MarkValue { get; set; }
    }
}
