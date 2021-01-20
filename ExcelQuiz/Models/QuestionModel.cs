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
}