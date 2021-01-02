using System;
using System.Collections.Generic;

#nullable disable

namespace ExamQuizAPI.Models.DB
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public int QuestionTypeId { get; set; }
        public string Question1 { get; set; }
        public int NoOfOption { get; set; }
        public int MarkValue { get; set; }
        public int ComplexityLevelId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string IsActive { get; set; }
    }
}
