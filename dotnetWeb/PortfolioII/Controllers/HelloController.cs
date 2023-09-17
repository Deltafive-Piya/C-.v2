using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers
{
    public class HomeController : Controller
    {
        // Display the form
        [HttpGet]
        [Route("")]
        public ViewResult Index()
        {
            return View();
        }

        // Handle the form submission
        [HttpPost]
        [Route("process")]
        public IActionResult Process(string name, string email, string comment)
        {
            // Process the form data here (e.g., save to a database, perform calculations, etc.)
            // Store form data in ViewBag
            ViewBag.Name = name;
            ViewBag.Email = email;
            ViewBag.Comment = string.IsNullOrWhiteSpace(comment) ? "No comment" : comment;

            // Redirect to the results page
            return RedirectToAction("Results");
        }

        // Display the results
        [HttpGet]
        [Route("results")]
        public IActionResult Results()
        {
            return View();
        }
    }
}