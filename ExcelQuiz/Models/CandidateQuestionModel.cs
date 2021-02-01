using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcelQuiz.Models
{
    public class CandidateQuestionModel
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public List<QuestionOption> QuestionOptions { get; set; }
        public int SlNo { get; set; }
    }

    public class SubmitAnswerModel
    {
        public int ExamId { get; set; }
        public int SlNo { get; set; }
        public string SelectedOptionId { get; set; }
    }
}