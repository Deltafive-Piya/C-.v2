using Microsoft.AspNetCore.Mvc;

namespace Survey.Controllers;

public class SurveyController: Controller
{

    [HttpGet("/")]
    public ViewResult Index()
    {
        return View("Form");
    }
    
    [HttpPost("submission")]
    public IActionResult Submission(string name, string location, string language, string comment)
    {
        ViewBag.Name = name;
        ViewBag.Location = location;
        ViewBag.Language = language;
        ViewBag.Comment = comment;
        return View("Display");
    }
}