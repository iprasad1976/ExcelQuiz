using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcelQuiz.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime? LoginStart { get; set; }
        public DateTime? LoginEnd { get; set; }
    }
}