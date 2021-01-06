using System;
using Microsoft.EntityFrameworkCore;

namespace ExamQuizAPI.Models.DB
{
    [Keyless]
    public class SpDownloadCadidateLoginIds
    {
        public string RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public int TotalNoofAttempts { get; set; }
        public string ExamName { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }        
    }
}
