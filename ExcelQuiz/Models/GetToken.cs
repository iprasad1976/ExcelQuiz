using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcelQuiz.Models
{
    public class GetToken
    {
        public string Token { get; set; }
        public DateTime? LoginStart { get; set; }
        public DateTime? LoginEnd { get; set; }
    }
}