﻿using Microsoft.AspNetCore.Mvc;

using DojoSurvey.Models;
namespace DojoSurvey.Controllers
{
    public class HomeController : Controller
    {
        // Display- Initial Form
        [HttpGet]
        public IActionResult Index() { return View(); }

        // Display- Results Form
        [HttpGet]
        public IActionResult Results(DojoForm dojoForm) { return View(dojoForm); }

        // POST- Form Submission
        [HttpPost]
        public IActionResult Index(DojoForm dojoForm)
        {
            if (ModelState.IsValid)
            { return RedirectToAction("Results", dojoForm); }

            return View();
        }

    }
}