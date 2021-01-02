using System;
using System.Collections.Generic;

#nullable disable

namespace ExamQuizAPI.Models.DB
{
    public partial class ExamCandidateAttemptQuestionAnswer
    {
        public int ExamCandidateAttemptQuestionAnswersId { get; set; }
        public int ExamCandidateAttemptQuestionsId { get; set; }
        public int SlNo { get; set; }
        public int QuestionOptionsId { get; set; }
        public string IsSelected { get; set; }
    }
}
