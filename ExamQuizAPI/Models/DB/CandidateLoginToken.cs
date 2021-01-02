using System;
using System.Collections.Generic;

#nullable disable

namespace ExamQuizAPI.Models.DB
{
    public partial class CandidateLoginToken
    {
        public int CandidateLoginTokenId { get; set; }
        public int CandidateLoginId { get; set; }
        public string Token { get; set; }
        public DateTime LoginStartTime { get; set; }
        public DateTime LoginEndTime { get; set; }
    }
}
