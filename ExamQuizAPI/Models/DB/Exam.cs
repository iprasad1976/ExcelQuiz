using System;
using System.Collections.Generic;

#nullable disable

namespace ExamQuizAPI.Models.DB
{
    public partial class Exam
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public int TotalMarks { get; set; }
        public int PassingPercentage { get; set; }
        public string Instructions { get; set; }
        public int Duration { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string IsActive { get; set; }
    }
}
