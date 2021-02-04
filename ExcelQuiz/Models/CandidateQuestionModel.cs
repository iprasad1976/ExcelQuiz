using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcelQuiz.Models
{
    public class CandidateQuestionModel
    {
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public List<CandidateQuestionOption> QuestionOptions { get; set; }
        public int SlNo { get; set; }

        public int MarkValue { get; set; }

        public int QuestionTypeId { get; set; }

        public int TotalQuestion { get; set; }
    }

    public class CandidateQuestionParamModel
    {
        public int ExamId { get; set; }
        public int SeqNo { get; set; }
    }

    public class CandidateQuestionOption
    {
        public int SlNo { get; set; }
        public int QuestionOptionsId { get; set; }
        public string Option { get; set; }
        public string IsSelected { get; set; }
    }
}