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
            {
                TempData["TotalQuestion"] = result.UpdatedId;
                TempData["SelectedExamId"] = examStartModel.ExamId;
                return Json(true);
            }
            else
                return Json(false);
        }

        [HttpPost]
        public ActionResult SubmitAnswers(SubmitAnswerModel submitAnswerModel)
        {
            string userId = TempData.ContainsKey("userId") ? TempData["userId"].ToString() : string.Empty;
            string token = TempData.ContainsKey("token") ? TempData["token"].ToString() : string.Empty;
            TempData.Keep();

            UpdateCommandModel result = null;
            try
            {
                result = WebApiProxy.WebAPIPostCall<SubmitAnswerModel, UpdateCommandModel>($"Candidate/SubmitAnswers", submitAnswerModel, userId, token).Result;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            if (result != null && !string.IsNullOrEmpty(result.Status) && result.Status.ToUpper() == "SUCCESS")
            {
                return Json(true);
            }
            else
                return Json(false);
        }

        [HttpGet]
        public ActionResult Question(int slNo)
        {
            TempData.Keep();
            int examId = TempData.ContainsKey("SelectedExamId") ? Convert.ToInt32(TempData["SelectedExamId"]) : 0;
            int totalQuestion = TempData.ContainsKey("TotalQuestion") ? Convert.ToInt32(TempData["TotalQuestion"]) : 0;
            string userId = TempData.ContainsKey("userId") ? TempData["userId"].ToString() : string.Empty;
            string token = TempData.ContainsKey("token") ? TempData["token"].ToString() : string.Empty;

            CandidateQuestionParamModel param = new CandidateQuestionParamModel();
            CandidateQuestionModel result = new CandidateQuestionModel();
            try
            {
                param.ExamId = examId;
                param.SeqNo = slNo;
                result = WebApiProxy.WebAPIPostCall<CandidateQuestionParamModel, CandidateQuestionModel>($"Candidate/GetNextPrevQuestion", param, userId, token).Result;

                result.QuestionOptions = WebApiProxy.WebAPIPostCall<CandidateQuestionParamModel, List<CandidateQuestionOption>>($"Candidate/GetQuestionOptions", param, userId, token).Result;
                result.ExamId = examId;
                result.TotalQuestion = totalQuestion;
                result.SlNo = slNo;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            if (result == null)
            {
                result = new CandidateQuestionModel();
                result.QuestionOptions = new List<CandidateQuestionOption>();
            }

            return View(result);
        }

        public ActionResult Score()
        {
            string userId = TempData.ContainsKey("userId") ? TempData["userId"].ToString() : string.Empty;
            string token = TempData.ContainsKey("token") ? TempData["token"].ToString() : string.Empty;
            int examId = TempData.ContainsKey("SelectedExamId") ? Convert.ToInt32(TempData["SelectedExamId"]) : 0;

            TempData.Keep();

            ScoreModel result = null;
            try
            {
                result = WebApiProxy.WebAPIGetCall<ScoreModel>($"Candidate/CalculateMarks?examId={examId}", userId, token).Result;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            if (result == null) result = new ScoreModel();
            return View(result);
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