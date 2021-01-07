using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ExamQuizAPI.Models;
//using ExamQuizAPI.Models.DB;

namespace ExamQuizAPI.Models
{
    public class LoginModel
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
