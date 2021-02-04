using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcelQuiz.Models
{
    public class SubmitAnswerModel
    {
        public int ExamId { get; set; }
        public int SeqNo { get; set; }
        public string SelectedOptionIds { get; set; }
    }
}