using System;
using System.Collections.Generic;

#nullable disable

namespace ExamQuizAPI.Models.DB
{
    public partial class AdminLoginToken
    {
        public int AdminLoginTokenId { get; set; }
        public int AdminLoginId { get; set; }
        public string Token { get; set; }
        public DateTime LoginStartTime { get; set; }
        public DateTime LoginEndTime { get; set; }
    }
}
