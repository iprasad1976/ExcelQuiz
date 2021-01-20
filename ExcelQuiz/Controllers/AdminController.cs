using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExcelQuiz.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ExcelQuiz.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult CandidateList(string search)
        {
            List<CandidateRequestModel> result = new List<CandidateRequestModel>();
            try
            {
                if (search == null) search = string.Empty;

                result = WebApiProxy.WebAPIGetCall<List<CandidateRequestModel>>($"Admin/SearchRequests?search={search}").Result;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View(result);
        }

        public ActionResult Candidate()
        {
            ViewBag.ExamList = GetExamList().Select(x => new SelectListItem
            {
                Text = x.ExamName.ToString(),
                Value = x.ExamId.ToString()
            });
            return View();
        }

        [HttpPost]
        public ActionResult Candidate(CandidateLoginModel candidateLoginModel)
        {
            bool isSuccessful = false;
            try
            {
                candidateLoginModel.RequestDate = DateTime.Now;
                candidateLoginModel.ValidFrom = Convert.ToDateTime(candidateLoginModel.ValidFrom);
                candidateLoginModel.ValidTo = Convert.ToDateTime(candidateLoginModel.ValidTo);
                var result = WebApiProxy.WebAPIPostCall<CandidateLoginModel, CandidateLoginModel>("Admin/AddCadidateLogins", candidateLoginModel);

                if (result.Result != null)
                {
                    isSuccessful = true;
                }
            }
            catch (Exception)
            {
                return Json(isSuccessful);
            }
            return Json(isSuccessful);
        }

        private List<ExamModel> GetExamList()
        {
            List<ExamModel> result = new List<ExamModel>();
            try
            {
                result = WebApiProxy.WebAPIGetCall<List<ExamModel>>($"Admin/SearchExams?search={string.Empty}").Result;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            //return Json(result,JsonRequestBehavior.AllowGet);
            return result;
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult Quiz()
        {
            return View();
        }

        public ActionResult QuizList(string search)
        {
            List<ExamModel> result = new List<ExamModel>();
            try
            {
                if (search == null) search = string.Empty;

                result = WebApiProxy.WebAPIGetCall<List<ExamModel>>($"Admin/SearchExams?search={search}").Result;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View(result);
        }

        public ActionResult Question()
        {
            //var a = WebApiProxy.WebAPIGetCall<ExamModel>("Admin/GetExam?examId=1");
            return View();
        }

        public ActionResult QuestionList(int examid, string search)
        {
            List<ExamModel> result = new List<ExamModel>();
            try
            {
                if (search == null) search = string.Empty;

                result = WebApiProxy.WebAPIGetCall<List<ExamModel>>($"Admin/SearchQuestions?examid={examid}&search={search}").Result;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View(result);
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