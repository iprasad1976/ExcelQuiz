using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamQuizAPI.Models;
using ExamQuizAPI.Models.DB;
using ExcelQuiz.Data;
using ExcelQuiz.Repository.Dal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using ExamQuizAPI.Models.DB;

namespace ExamQuizAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly ExamDBContext _context;
        private string _userId = string.Empty;
        private string _token = string.Empty;
        public AdminController(ILogger<AdminController> logger, ExamDBContext context)
        {
            _logger = logger;
            _context = context;
            if (Request.Headers.ContainsKey("UserId"))
                _userId = Request.Headers["UserId"].ToString();
            if (Request.Headers.ContainsKey("Token"))
                _userId = Request.Headers["Token"].ToString();

        }

        [HttpPost("AdminLogin")]
        public SpGetToken AdminLogin(LoginModel loginModel)
        {
            var result = _context.GetAdminToken(loginModel.UserId, loginModel.Password).Result;
            return result.FirstOrDefault();
        }

        [HttpPost("AddCadidateLogins")]
        public SpAddCadidateLogins AddCadidateLogins(CandidateLoginModel candidateLoginModel)
        {
            var result = _context.AddCadidateLogins
                (candidateLoginModel.RequestedPersonEmail,
                    candidateLoginModel.NoOfRequestedUserId,
                    candidateLoginModel.NoOfAttempt, candidateLoginModel.ExamIds,
                    candidateLoginModel.ValidFrom,
                    candidateLoginModel.ValidTo,
                    _userId).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpAddCadidateLogins();
        }

        [HttpGet("DownloadCadidateLoginIds")]
        public List<SpDownloadCadidateLoginIds> DownloadCadidateLoginIds(int requestedPersonEmail)
        {
            var result = _context.DownloadCadidateLoginIds(requestedPersonEmail).Result;
            return result;
        }

        [HttpGet("SearchRequests")]
        public List<SpSearchRequests> SearchRequests(string search)
        {
            var result = _context.SearchRequests(search).Result;
            return result;
        }

        [HttpGet("GetListRequestsByRequestedEmail")]
        public List<SpGetListRequestsByRequestedEmail> GetListRequestsByRequestedEmail(string requestedPersonEmail)
        {
            var result = _context.GetListRequestsByRequestedEmail(requestedPersonEmail).Result;
            return result;
        }

        [HttpGet("GetExam")]
        public SpGetExam GetExam(int examId)
        {
            var result = _context.GetExam(examId).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpGetExam();
        }

        [HttpGet("SearchExams")]
        public List<SpSearchExams> SearchExams(string search)
        {
            var result = _context.SearchExams(search).Result;
            return result;
        }

        [HttpGet("GetQuestion")]
        public SpGetQuestion GetQuestion(int questionId)
        {
            var result = _context.GetQuestion(questionId).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpGetQuestion();

        }

        [HttpGet("GetQuestionOptions")]
        public List<SpGetQuestionOptions> GetQuestionOptions(int questionId)
        {
            var result = _context.GetQuestionOptions(questionId).Result;
            return result;
        }

        [HttpGet("SearchQuestions")]
        public List<SpSearchQuestions> SearchQuestions(string search)
        {
            var result = _context.SearchQuestions(search).Result;
            return result;
        }

        [HttpGet("DeleteRequestedLogin")]
        public SpUpdateCommand DeleteRequestedLogin(string candidateLoginRequestId)
        {
            var result = _context.DeleteRequestedLogin(candidateLoginRequestId, _userId).Result;
            return result.FirstOrDefault();
        }

        [HttpPost("AddEditExam")]
        public SpUpdateCommand AddEditExam(ExamModel examModel)
        {
            var result = _context.AddEditExam(examModel.ExamId, examModel.ExamName,
                    examModel.TotalMarks, examModel.PassingPercentage,
                    examModel.Instructions, examModel.Duration, _userId).Result;

            return result.FirstOrDefault();
        }

        [HttpGet("DeleteExam")]
        public SpUpdateCommand DeleteExam(int examId)
        {
            var result = _context.DeleteExam(examId, _userId).Result;
            return result.FirstOrDefault();
        }

        [HttpPost("AddEditQuestion")]
        public SpUpdateCommand AddEditQuestion(int questionId, int questionTypeId, string question, int noofOption, int markValue, int complexityLevelId, string examIds, string options)
        {
            var result = _context.AddEditQuestion(questionId, questionTypeId, question, noofOption, markValue, complexityLevelId, examIds, options, _userId).Result;
            return result.FirstOrDefault();
        }

        [HttpGet("DeleteQuestion")]
        public SpUpdateCommand DeleteQuestion(int questionId)
        {
            var result = _context.DeleteQuestion(questionId, _userId).Result;
            return result.FirstOrDefault();
        }

        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

    }
}
