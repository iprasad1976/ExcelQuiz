using System;
using Microsoft.EntityFrameworkCore;

namespace ExamQuizAPI.Models.DB
{
    [Keyless]
    public class SpCandidateExamInfo
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public string Instructions { get; set; }
        public int TotalNoofAttempts { get; set; }
        public int NoofAttempted { get; set; }
    }
}
