using System;
using Microsoft.EntityFrameworkCore;

namespace ExamQuizAPI.Models.DB
{
    [Keyless]
    public class SpGetListRequestsByRequestedEmail
    {
        public int  CandidateLoginRequestId { get; set; }
        public string RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestedPersonEmail { get; set; }
    }
}
