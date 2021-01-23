using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExcelQuiz.Models;
using static System.Net.Mime.MediaTypeNames;
using OfficeOpenXml;
using System.Net.Mail;
using System.Net;
using System.IO;

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
                    List<DownloadCadidateLoginIdsModel> cadidateLoginIdsEmail = new List<DownloadCadidateLoginIdsModel>();
                    cadidateLoginIdsEmail = WebApiProxy.WebAPIGetCall<List<DownloadCadidateLoginIdsModel>>($"Admin/DownloadCadidateLoginIds?requestedCandidateId={result.Result.CandidateLoginRequestId}").Result;
                    EmailExcelOnCreatingCandidateLogin(DataToExcel(cadidateLoginIdsEmail));
                }
            }
            catch (Exception)
            {
                return Json(isSuccessful);
            }
            return Json(isSuccessful);
        }

        public void CandidateListExcelDownload(int requestedCandidateId, char isDownload)
        {
            List<DownloadCadidateLoginIdsModel> downloadCadidateLoginIdsModels = new List<DownloadCadidateLoginIdsModel>();
            try
            {
                downloadCadidateLoginIdsModels = WebApiProxy.WebAPIGetCall<List<DownloadCadidateLoginIdsModel>>($"Admin/DownloadCadidateLoginIds?requestedCandidateId={requestedCandidateId}").Result;
                ExcelPackage excelPackage = new ExcelPackage();
                excelPackage = DataToExcel(downloadCadidateLoginIdsModels);
                Response.Clear();
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("content-disposition", "attachment; filename=" + "Report.xls");
                Response.BinaryWrite(excelPackage.GetAsByteArray());
                Response.End();

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
        }

        private ExcelPackage DataToExcel(List<DownloadCadidateLoginIdsModel> downloadCadidateLoginIdsModels)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelPackage = new ExcelPackage();
            ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Report");
            excelWorksheet.Cells["A1"].Value = "Request Id";
            excelWorksheet.Cells["B1"].Value = "Request Date";
            excelWorksheet.Cells["C1"].Value = "User Id";
            excelWorksheet.Cells["D1"].Value = "Password";
            excelWorksheet.Cells["E1"].Value = "Total No. of Attempts";
            excelWorksheet.Cells["F1"].Value = "Exam Name";
            excelWorksheet.Cells["G1"].Value = "Valid From";
            excelWorksheet.Cells["H1"].Value = "Valid To";
            excelWorksheet.Column(7).Style.Numberformat.Format = "dd-mm-yyyy";
            excelWorksheet.Column(8).Style.Numberformat.Format = "dd-mm-yyyy";
            int row = 2;
            foreach (var item in downloadCadidateLoginIdsModels)
            {
                excelWorksheet.Cells[string.Format("A{0}", row)].Value = item.RequestId;
                excelWorksheet.Cells[string.Format("B{0}", row)].Value = item.RequestDate;
                excelWorksheet.Cells[string.Format("C{0}", row)].Value = item.UserId;
                excelWorksheet.Cells[string.Format("D{0}", row)].Value = item.Password;
                excelWorksheet.Cells[string.Format("E{0}", row)].Value = item.TotalNoofAttempts;
                excelWorksheet.Cells[string.Format("F{0}", row)].Value = item.ExamName;
                excelWorksheet.Cells[string.Format("G{0}", row)].Value = item.ValidFrom;
                excelWorksheet.Cells[string.Format("H{0}", row)].Value = item.ValidTo;
                row++;
            }
            excelWorksheet.Cells["A:Z"].AutoFitColumns();

            return excelPackage;
        }

        private bool EmailExcelOnCreatingCandidateLogin(ExcelPackage excelPackage)
        {
            MemoryStream ms;
            ms = new MemoryStream(excelPackage.GetAsByteArray());
            //using (ExcelPackage ep = new ExcelPackage())
            //{

            //}
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;
            string emailFromAddress = "dharmeshbarmera@gmail.com"; //Sender Email Address  
            string password = "Db@9929383788"; //Sender Password  
            string emailToAddress = "dharmeshbarmera.db@gmail.com"; //Receiver Email Address  
            string subject = "Hello";
            string body = "Hello, This is Email sending test using gmail.";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.Body = "<html><head>Hi Team,</head><br><br><body>Attached is the excel sheet for new users created today.</body></html>";
                mail.Attachments.Add(new Attachment(ms, "UserRequest_" + DateTime.Now, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
            return true;
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