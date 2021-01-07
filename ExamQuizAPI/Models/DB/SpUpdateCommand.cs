using System;
using Microsoft.EntityFrameworkCore;

namespace ExamQuizAPI.Models.DB
{
    [Keyless]
    public class SpUpdateCommand
    {
       public int UpdatedId { get; set; }
       public string Status { get; set; }
    }
}
