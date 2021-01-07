using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamQuizAPI.Models
{
    public class ExamModel
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public int TotalMarks { get; set; }
        public int PassingPercentage { get; set; }
        public string Instructions { get; set; }
        public int Duration { get; set; }
    }
}
