using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamQuizAPI.Models
{
    public class ExamStartModel
    {
        public int ExamId { get; set; }
        public string CandidateName { get; set; }
        public string CandidateEmailId { get; set; }
        public string CandidatePhone { get; set; }
    }
}
