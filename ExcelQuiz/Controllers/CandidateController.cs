using ExcelQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExcelQuiz.Controllers
{
    public class CandidateController : Controller
    {
        // GET: Candidate
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Question()
        {
            return View();
        }

        public ActionResult Score()
        {
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
                var a = WebApiProxy.WebAPIPostCall<LoginModel, TokenModel>("Candidate/CandidateLogin", loginModel);

                if((a.Result.LoginStart<=DateTime.Now)&&(a.Result.LoginEnd>=DateTime.Now)&&(!a.Result.Token.Equals(string.Empty)))
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