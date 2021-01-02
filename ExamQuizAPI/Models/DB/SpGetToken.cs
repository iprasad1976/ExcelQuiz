using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamQuizAPI.Models.DB
{
    [Keyless]
    public class SpGetToken
    {
        public string Token { get; set; }
        public DateTime? LoginStart { get; set; }
        public DateTime? LoginEnd { get; set; }
    }
}
