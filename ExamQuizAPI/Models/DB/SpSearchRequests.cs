using System;
using Microsoft.EntityFrameworkCore;

namespace ExamQuizAPI.Models.DB
{
    [Keyless]
    public class SpSearchRequests
    {
        public int CandidateLoginRequestId { get; set; }
        public int RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestedPersonEmail { get; set; }
    }
}
