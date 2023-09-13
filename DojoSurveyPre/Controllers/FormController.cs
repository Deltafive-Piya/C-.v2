using Microsoft.AspNetCore.Mvc;
using DojoSurvey.Models;

namespace DojoSurvey.Controllers
{
    public class FormController : Controller
    {
        // Get Home
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Post Data
        [HttpPost]
        public IActionResult Index(DojoForm dojoForm) // Use DojoForm as the parameter type
        {
            // Lvl1 step: Render- PostRequest data//
            return View("Results", dojoForm);
        }

        // Get Data
        [HttpGet]
        public IActionResult Results(DojoForm dojoForm) // Use DojoForm as the parameter type
        {
            // Lvl2 step: Render- GetRoute data//
            return View("Results", dojoForm);
        }
    }
}