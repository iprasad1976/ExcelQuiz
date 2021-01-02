using System;
using System.Collections.Generic;

#nullable disable

namespace ExamQuizAPI.Models.DB
{
    public partial class ExamCandidate
    {
        public int ExamCandidateId { get; set; }
        public int ExamId { get; set; }
        public int CandidateLoginId { get; set; }
        public int TotalNoofAttempts { get; set; }
        public int NoofAttempted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string IsActive { get; set; }
    }
}
