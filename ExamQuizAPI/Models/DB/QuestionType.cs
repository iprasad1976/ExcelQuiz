using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

#nullable disable

namespace ExamQuizAPI.Models.DB
{
    [Keyless]
    public partial class QuestionType
    {
        public int QuestionTypeId { get; set; }
        public string QuestionTypeDesc { get; set; }
    }
}
