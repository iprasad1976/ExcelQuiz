﻿using System;
using Microsoft.EntityFrameworkCore;

namespace ExamQuizAPI.Models.DB
{
    [Keyless]
    public class SpSearchRequests
    {
        public int CandidateLoginRequestId { get; set; }
        public string RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestedPersonEmail { get; set; }
        public int NoofLoginRequest { get; set; }
        public int NoofAttempt { get; set; }

        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
