using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExcelQuiz.Models;

namespace ExcelQuiz.Controllers
{
    public class AdminController : Controller
    {
        private string _baseURI = ConfigurationManager.AppSettings["baseURI"];
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Candidate()
        {
            return View();
        }

        public ActionResult Quiz()
        {
            return View();
        }

        public ActionResult Question()
        {
            var a = WebApiProxy.WebAPIGetCall<ExamModel>("Admin/GetExam?examId=1");
            return View();
        }

        public ActionResult Login()
        {
            LoginModel loginModel = new LoginModel();
            loginModel.UserId = "dbarmera";
            loginModel.Password = "12345";            
            var a = WebApiProxy.WebAPIPostCall<LoginModel,GetToken>("Admin/AdminLogin", loginModel);
            return View();
        }



    }
}