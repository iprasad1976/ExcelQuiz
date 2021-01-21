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

        public ActionResult CandidateDelete(int candidateLoginRequestId)
        {
            List<CandidateRequestModel> result = new List<CandidateRequestModel>();
            try
            {
                if (candidateLoginRequestId > 0)
                {
                    result = WebApiProxy.WebAPIGetCall<List<CandidateRequestModel>>($"Admin/DeleteRequestedLogin?candidateLoginRequestId={candidateLoginRequestId}").Result;
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            //return View("candidateList");
            return RedirectToAction("CandidateList", new { search = string.Empty });
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
                var result = WebApiProxy.WebAPIPostCall<CandidateLoginModel, CandidateRequestModel>("Admin/AddCadidateLogins", candidateLoginModel);

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
        [HttpPost]
        public ActionResult Quiz(ExamModel examModel)
        {

            bool isSuccessful = false;
            try
            {
                var result = WebApiProxy.WebAPIPostCall<ExamModel, UpdateCommandModel>("Admin/AddEditExam", examModel);
                isSuccessful = result.Result.Status.Equals("Success") ? true : false;
            }
            catch (Exception)
            {
                return Json(isSuccessful);
            }
            return Json(isSuccessful);
        }

        public ActionResult QuizEdit(ExamModel exam)
        {
            return View(exam);
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


        public ActionResult DeleteQuiz(int examId)
        {
            List<ExamModel> result = new List<ExamModel>();
            try
            {
                if (examId > 0)
                {
                    result = WebApiProxy.WebAPIGetCall<List<ExamModel>>($"Admin/DeleteExam?examId={examId}").Result;
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }


            return RedirectToAction("QuizList", new { search = string.Empty });
        }

        public ActionResult Question()
        {
            //var a = WebApiProxy.WebAPIGetCall<ExamModel>("Admin/GetExam?examId=1");
            return View();
        }
        private List<ExamModel> GetQuizList()
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

            return result;
        }

        public ActionResult QuestionList(int? examid, string search)
        {
            QuestionViewModel questionView = new QuestionViewModel();
            questionView.ExamModels = GetQuizList();

            List<ExamModel> exams = new List<ExamModel>();
            try
            {
                if (search == null) search = string.Empty;

                if (!examid.HasValue) examid = 0;
                if (examid.Value == 0 && questionView.ExamModels.Count > 0) examid = questionView.ExamModels[0].ExamId;

                questionView.SelectedExam = examid.Value;
                questionView.SearchText = search;
                questionView.QuestionModels = WebApiProxy.WebAPIGetCall<List<QuestionModel>>($"Admin/SearchQuestions?examid={examid}&search={search}").Result;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View(questionView);
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