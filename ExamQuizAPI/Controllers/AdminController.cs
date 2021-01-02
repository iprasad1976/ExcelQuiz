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

        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

        }
    }
