using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public AdminController(ILogger<AdminController> logger, ExamDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("AdminLogin")]
        public SpGetToken AdminLogin(string userId, string password)
        {
            var result = _context.GetAdminToken(userId, password).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpGetToken();

        }

        [HttpGet("AddCadidateLogins")]
        public SpAddCadidateLogins AddCadidateLogins(string requestedPersonEmail, int noOfRequestedUserId, int noOfAttempt, string examIds, DateTime validFrom, DateTime validTo, string adminUserId)
        {
            var result = _context.AddCadidateLogins(requestedPersonEmail,noOfRequestedUserId,noOfAttempt,examIds,validFrom,validTo,adminUserId).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpAddCadidateLogins();

        }

        [HttpGet("DownloadCadidateLoginIds")]
        public SpDownloadCadidateLoginIds DownloadCadidateLoginIds(int requestedPersonEmail)
        {
            var result = _context.DownloadCadidateLoginIds(requestedPersonEmail).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpDownloadCadidateLoginIds();

        }

        [HttpGet("SearchRequests")]
        public SpSearchRequests SearchRequests(string search)
        {
            var result = _context.SearchRequests(search).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpSearchRequests();

        }

        [HttpGet("GetListRequestsByRequestedEmail")]
        public SpGetListRequestsByRequestedEmail GetListRequestsByRequestedEmail(string requestedPersonEmail)
        {
            var result = _context.GetListRequestsByRequestedEmail(requestedPersonEmail).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpGetListRequestsByRequestedEmail();

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
        public SpSearchExams SearchExams(string search)
        {
            var result = _context.SearchExams(search).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpSearchExams();

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
        public SpGetQuestionOptions GetQuestionOptions(int questionId)
        {
            var result = _context.GetQuestionOptions(questionId).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpGetQuestionOptions();

        }

        [HttpGet("SearchQuestions")]
        public SpSearchQuestions SearchQuestions(string search)
        {
            var result = _context.SearchQuestions(search).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpSearchQuestions();

        }

        [HttpGet("DeleteRequestedLogin")]
        public SpUpdateCommand DeleteRequestedLogin(string candidateLoginRequestId, string adminUserId)
        {
            var result = _context.DeleteRequestedLogin(candidateLoginRequestId,adminUserId).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpUpdateCommand();

        }

        [HttpGet("AddEditExam")]
        public SpUpdateCommand AddEditExam(int examId, string examName, int totalMarks, int passingPercentage, string instructions, int duration, string adminUserId)
        {
            var result = _context.AddEditExam(examId, examName, totalMarks, passingPercentage, instructions, duration, adminUserId).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpUpdateCommand();

        }

        [HttpGet("DeleteExam")]
        public SpUpdateCommand DeleteExam(int examId, string totalMarksadminUserId)
        {
            var result = _context.DeleteExam(examId, totalMarksadminUserId).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpUpdateCommand();

        }

        [HttpGet("AddEditQuestion")]
        public SpUpdateCommand AddEditQuestion(int questionId, int questionTypeId, string question, int noofOption, int markValue, int complexityLevelId, string examIds, string options, string adminUserId)
        {
            var result = _context.AddEditQuestion(questionId, questionTypeId, question, noofOption, markValue, complexityLevelId, examIds, options, adminUserId).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpUpdateCommand();

        }

        [HttpGet("DeleteQuestion")]
        public SpUpdateCommand DeleteQuestion(int questionId, string adminUserId)
        {
            var result = _context.DeleteQuestion(questionId, adminUserId).Result;
            if (result != null)
                return result.FirstOrDefault();
            else
                return new SpUpdateCommand();

        }

        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

        }
    }
