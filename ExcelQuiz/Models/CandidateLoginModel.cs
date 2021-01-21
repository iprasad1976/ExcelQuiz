using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcelQuiz.Models
{
    public class CandidateLoginModel
    {        
        public string RequestedPersonEmail { get; set; }
        public int NoOfRequestedUserId { get; set; }
        public int NoOfAttempt { get; set; }
        public string ExamIds { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}