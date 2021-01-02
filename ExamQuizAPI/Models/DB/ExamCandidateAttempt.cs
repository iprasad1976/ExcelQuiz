using System;
using System.Collections.Generic;

#nullable disable

namespace ExamQuizAPI.Models.DB
{
    public partial class ExamCandidateAttempt
    {
        public int ExamCandidateAttemptId { get; set; }
        public string Token { get; set; }
        public int ExamId { get; set; }
        public int CandidateLoginId { get; set; }
        public string CandidateName { get; set; }
        public string CandidateEmailId { get; set; }
        public string CandidatePhone { get; set; }
        public DateTime? AttemptDate { get; set; }
        public bool? CompleteAttempt { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? TotalScore { get; set; }
        public int? GainScore { get; set; }
        public int? PercentageScore { get; set; }
    }
}
