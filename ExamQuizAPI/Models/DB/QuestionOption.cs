using System;
using System.Collections.Generic;

#nullable disable

namespace ExamQuizAPI.Models.DB
{
    public partial class QuestionOption
    {
        public int QuestionOptionsId { get; set; }
        public int QuestionId { get; set; }
        public int SlNo { get; set; }
        public string Option { get; set; }
        public int IsCorrect { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string IsActive { get; set; }
    }
}
