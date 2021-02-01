using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcelQuiz.Models
{
    public class QuestionModel
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string QuestionType  { get; set; }
        public int NoOfOption { get; set; }
        public int MarkValue { get; set; }
        public string ComplexityLevel { get; set; }
    }

    public class QuestionViewModel
    {
        public List<QuestionModel> QuestionModels { get; set; }
        public List<ExamModel> ExamModels { get; set; }
        public int SelectedExam { get; set; }

        public string SearchText { get; set; }
    }

    public class QuestionAddModel
    {
        public int QuestionId { get; set; }
        public int QuestionTypeId { get; set; }
        public string Question { get; set; }
        public int NoOfOption { get; set; }
        public int ComplexityLevelId { get; set; }
        public string ExamIds { get; set; }
        public string Options { get; set; }        
    }
    
}