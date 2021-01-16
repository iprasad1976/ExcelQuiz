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

        public ActionResult Login()
        {
            return View();
        }
    }
}