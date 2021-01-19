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


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            bool isValid = false;
            try
            {
                var a = WebApiProxy.WebAPIPostCall<LoginModel, TokenModel>("Admin/AdminLogin", loginModel);

                if ((a.Result.LoginStart <= DateTime.Now) && (a.Result.LoginEnd >= DateTime.Now) && (!a.Result.Token.Equals(string.Empty)))
                {
                    isValid = true;
                }
            }
            catch (Exception)
            {
                return Json(isValid);
            }
            return Json(isValid);
        }



    }
}