﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExcelQuizUI.Controllers
{
    public class CandidateController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}