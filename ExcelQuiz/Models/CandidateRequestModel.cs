using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExcelQuiz.Models
{
    public class CandidateRequestModel
    {
        public int CandidateLoginRequestId { get; set; }
        public string RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestedPersonEmail { get; set; }
        public int NoofLoginRequest { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string NoofAttempt { get; set; }
    }

    public class CandidateRequestViewModel
    {
        public List<CandidateRequestModel> CandidateRequestModels { get; set; }
        public List<ExamModel> ExamModels { get; set; }
        public int SelectedExam { get; set; }
    }
}