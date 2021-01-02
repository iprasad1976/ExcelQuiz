using System;
using System.Collections.Generic;

#nullable disable

namespace ExamQuizAPI.Models.DB
{
    public partial class ExamCandidateAttemptQuestion
    {
        public int ExamCandidateAttemptQuestionsId { get; set; }
        public int ExamCandidateAttemptId { get; set; }
        public int SeqNo { get; set; }
        public int QuestionId { get; set; }
        public string IsAnswerCorrect { get; set; }
        public int? GainScore { get; set; }
        public DateTime? AttemptTime { get; set; }
    }
}
