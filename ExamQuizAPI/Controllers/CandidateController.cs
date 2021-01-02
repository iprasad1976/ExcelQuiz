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


    }
}
