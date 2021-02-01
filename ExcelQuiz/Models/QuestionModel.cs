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

        public int QuestionTypeId { get; set; }
        public int NoOfOption { get; set; }

        public List<QuestionExam> QuestionExams { get; set; }

        public List<QuestionOption> QuestionOptions { get; set; }
    }

    public class QuestionOption
    {
        public int OptionId { get; set; }
        public int SlNo { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class QuestionViewModel
    {
        public List<QuestionModel> QuestionModels { get; set; }
        public List<ExamModel> ExamModels { get; set; }
        public int SelectedExam { get; set; }

        public string SearchText { get; set; }
    }



    public class QuestionExam
    {
        public int ExamId { get; set; }
        public int MarkValue { get; set; }
    }
    public class QuestionAddModel
    {
        public int QuestionId { get; set; }
        public int QuestionTypeId { get; set; }
        public string Question { get; set; }
        public int NoOfOption { get; set; }
        public string ExamIds { get; set; }
        public string Options { get; set; }        
    }
    
}