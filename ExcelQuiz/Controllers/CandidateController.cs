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
            string userId = TempData.ContainsKey("userId") ? TempData["userId"].ToString() : string.Empty;
            
            ViewBag.QuizList = GetQuizList(userId).Select(x => new SelectListItem
            {
                Text = x.ExamName.ToString(),
                Value = x.ExamId.ToString()
            });

            TempData["RightMenuContent"] = userId;
            TempData.Keep();
            return View();
        }

        private List<ExamModel> GetQuizList(string userId)
        {
          
            List<ExamModel> result = new List<ExamModel>();
            try
            {
                result = WebApiProxy.WebAPIGetCall<List<ExamModel>>($"Candidate/GetListExam", userId).Result;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return result;
        }

        public ActionResult GetExam(int examId)
        {
            TempData.Keep();
            ExamModel result = null;
            try
            {
                result = WebApiProxy.WebAPIGetCall<ExamModel>($"Admin/GetExam?examId={examId}").Result;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return Json(result);

          
        }

        [HttpPost]
        public ActionResult StartExam(ExamStartModel examStartModel)
        {
            string userId = TempData.ContainsKey("userId") ? TempData["userId"].ToString() : string.Empty;
            string token = TempData.ContainsKey("token") ? TempData["token"].ToString() : string.Empty;

            UpdateCommandModel result = null;
            try
            {
                result = WebApiProxy.WebAPIPostCall<ExamStartModel, UpdateCommandModel>($"Candidate/ExamStart", examStartModel, userId, token).Result;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            
            TempData.Keep();

            if (result != null && !string.IsNullOrEmpty(result.Status) && result.Status.ToUpper() == "SUCCESS")
                return Json(true);
            else
                return Json(false);
        }
        public ActionResult Question()
        {
            TempData.Keep();
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

        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            bool isValid = false;
            try
            {
                var a = WebApiProxy.WebAPIPostCall<LoginModel, TokenModel>("Candidate/CandidateLogin", loginModel);

                if(!string.IsNullOrEmpty(a.Result.Token) && (a.Result.LoginStart<=DateTime.Now && a.Result.LoginEnd>=DateTime.Now))
                {
                    isValid = true;
                    TempData["userId"] = loginModel.UserId;
                    TempData["token"] = a.Result.Token;
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