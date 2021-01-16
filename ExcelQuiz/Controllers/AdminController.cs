using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

    }
}