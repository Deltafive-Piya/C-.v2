using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyWithValidations.Models; // Assuming you have the appropriate namespace

namespace DojoSurveyWithValidations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/")]
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpPost("process")]
        public IActionResult Process(User newUser)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Display", newUser);
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("Display")]
        public IActionResult Display(User newUser)
        {
            return View(newUser);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}