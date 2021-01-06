using System;
using Microsoft.EntityFrameworkCore;

namespace ExamQuizAPI.Models.DB
{
    [Keyless]
    public class SpUpdateCommand
    {
        public int UpdatedRows { get; set; }
    }
}
