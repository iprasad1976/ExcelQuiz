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
    public class CommonController : ControllerBase
    {
        private readonly ILogger<CommonController> _logger;
        private readonly ExamDBContext _context;

        public CommonController(ILogger<CommonController> logger, ExamDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("GetQuiz")]
        public string GetQuiz(string examId)
        {
                return "";

        }

        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

        }
    }
