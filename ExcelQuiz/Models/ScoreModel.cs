using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcelQuiz.Models
{
    public class ScoreModel
    {
        public string ExamName { get; set; }
        public string RequestedPersonEmail { get; set; }
        public string CandidateName { get; set; }
        public string CandidateEmailId { get; set; }
        public string CandidatePhone { get; set; }
        public int TotalScore { get; set; }
        public int GainScore { get; set; }
        public int PercentageScore { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsPassed { get; set; }
    }
}