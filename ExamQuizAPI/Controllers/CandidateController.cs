using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamQuizAPI.Models;
using ExamQuizAPI.Models.DB;
using ExcelQuiz.Data;
using ExcelQuiz.Repository.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExamQuizAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ILogger<CandidateController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor = null;
        private readonly ExamDBContext _context;
        private string _userId = string.Empty;
        private string _token = string.Empty;
        public CandidateController(ILogger<CandidateController> logger, ExamDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;

            _httpContextAccessor = httpContextAccessor;
            if (_httpContextAccessor.HttpContext.Request.Headers.ContainsKey("UserId"))
                _userId = _httpContextAccessor.HttpContext.Request.Headers["UserId"].ToString();
            if (_httpContextAccessor.HttpContext.Request.Headers.ContainsKey("Token"))
                _token = _httpContextAccessor.HttpContext.Request.Headers["Token"].ToString();
        }

        [HttpPost("CandidateLogin")]
        public SpGetToken CandidateLogin(LoginModel loginModel)
        {
            var result = _context.GetCandidateToken(loginModel.UserId, loginModel.Password).Result;
            return result.FirstOrDefault();
        }

        [HttpGet("GetListExam")]
        public List<SpListExam> GetListExam(string userId)
        {
            var result = _context.GetListExam(userId).Result;
            return result;
        }

        [HttpGet("GetCandidateExamInfo")]
        public SpCandidateExamInfo GetCandidateExamInfo(int examId)
        {
            var result = _context.GetCandidateExamInfo(examId, _userId).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpCandidateExamInfo();

        }

        [HttpPost("GetNextPrevQuestion")]
        public SpNextPrevQuestion GetNextPrevQuestion(NextPrevQuestionModel nextPrevQuestionModel)
        {
            var result = _context.GetNextPrevQuestion(nextPrevQuestionModel.ExamId, _userId, _token, nextPrevQuestionModel.SeqNo).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpNextPrevQuestion();

        }

        [HttpPost("GetQuestionOptions")]
        public List<SpQuestionOptions> GetQuestionOptions(NextPrevQuestionModel nextPrevQuestionModel)
        {
            var result = _context.GetQuestionOptions(nextPrevQuestionModel.ExamId, _userId, _token, nextPrevQuestionModel.SeqNo).Result;
            return result; ;
        }

        [HttpGet("CalculateMarks")]
        public SpCalculateMarks CalculateMarks(int examId)
        {
            var result = _context.CalculateMarks(examId, _userId, _token).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpCalculateMarks();

        }

        [HttpPost("SubmitAnswers")]
        public SpUpdateCommand SubmitAnswers(SubmitAnswerModel submitAnswerModel)
        {
            string selectedOptionIds = string.Join(',', submitAnswerModel.SelectedOptionIds);

            var result = _context.SubmitAnswers(submitAnswerModel.ExamId, _userId, _token, submitAnswerModel.SeqNo, selectedOptionIds).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpUpdateCommand();

        }

        [HttpPost("CandidateExamStart")]
        public SpUpdateCommand CandidateExamStart(ExamStartModel examStartModel)
        {
            var result = _context.CandidateExamStart(examStartModel.ExamId, _userId, _token, examStartModel.CandidateName, examStartModel.CandidateEmailId, examStartModel.CandidatePhone).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpUpdateCommand();

        }
    }
}
