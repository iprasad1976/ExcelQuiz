using System;
using System.Collections.Generic;

#nullable disable

namespace ExamQuizAPI.Models.DB
{
    public partial class AdminLogin
    {
        public int AdminLoginId { get; set; }
        public string UserId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string IsActive { get; set; }
    }
}
