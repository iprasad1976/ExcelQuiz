using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamQuizAPI.Models
{
    public class QuestionAddEditModel
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
