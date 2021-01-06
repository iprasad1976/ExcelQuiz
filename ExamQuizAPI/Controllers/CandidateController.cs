using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamQuizAPI.Models.DB;
using ExcelQuiz.Data;
using ExcelQuiz.Repository.Dal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExamQuizAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ILogger<CandidateController> _logger;
        private readonly ExamDBContext _context;
        public CandidateController(ILogger<CandidateController> logger, ExamDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("CandidateLogin")]
        public SpGetToken CandidateLogin(string userId, string password)
        {
            var result = _context.GetCandidateToken(userId, password).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpGetToken();

        }

        [HttpGet("GetListExam")]
        public SpListExam GetListExam(string userId)
        {
            var result = _context.GetListExam(userId).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpListExam();

        }

        [HttpGet("GetCandidateExamInfo")]
        public SpCandidateExamInfo GetCandidateExamInfo(int examId, string userId)
        {
            var result = _context.GetCandidateExamInfo(examId,userId).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpCandidateExamInfo();

        }

        [HttpGet("GetNextPrevQuestion")]
        public SpNextPrevQuestion GetNextPrevQuestion(int examId, string userId, string token, int seqNo)
        {
            var result = _context.GetNextPrevQuestion(examId, userId, token, seqNo).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpNextPrevQuestion();

        }

        [HttpGet("GetQuestionOptions")]
        public SpQuestionOptions GetQuestionOptions(int examId, string userId, string token, int seqNo)
        {
            var result = _context.GetQuestionOptions(examId, userId, token, seqNo).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpQuestionOptions();

        }

        [HttpGet("CalculateMarks")]
        public SpCalculateMarks CalculateMarks(int examId, string userId, string token)
        {
            var result = _context.CalculateMarks(examId, userId, token).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpCalculateMarks();

        }

        [HttpGet("SubmitAnswers")]
        public SpUpdateCommand SubmitAnswers(int examId, string userId, string token, int seqNo, string selectedOptionIds)
        {
            var result = _context.SubmitAnswers(examId, userId, token, seqNo,selectedOptionIds).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpUpdateCommand();

        }

        [HttpGet("CandidateExamStart")]
        public SpUpdateCommand CandidateExamStart(int examId, string userId, string token, string candidateName, string candidateEmailId, string candidatePhone)
        {
            var result = _context.CandidateExamStart(examId, userId, token, candidateName, candidateEmailId, candidatePhone).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpUpdateCommand();

        }
    }
}
