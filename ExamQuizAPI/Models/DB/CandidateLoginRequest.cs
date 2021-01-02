using System;
using System.Collections.Generic;

#nullable disable

namespace ExamQuizAPI.Models.DB
{
    public partial class CandidateLoginRequest
    {
        public int CandidateLoginRequestId { get; set; }
        public string RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestedPersonEmail { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string IsActive { get; set; }
    }
}
