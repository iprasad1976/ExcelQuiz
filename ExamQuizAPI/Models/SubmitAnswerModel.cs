using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamQuizAPI.Models
{
    public class SubmitAnswerModel
    {
        public int ExamId { get; set; }
        public int SeqNo { get; set; }
        public List<int> SelectedOptionIds { get; set; }
    }
}
