//ln 18
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyWithModel.Models;
namespace DojoSurveyWithModel.Controllers;

public class HomeController : Controller
{
    static User NewUser; //1. make this so we can pass it in the form via action="process"

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    // Start getting and postin here
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(User user) //2. pass the user here
    {
        NewUser = user; //3. populate new user with user here
        return RedirectToAction("Result");
    }

    [HttpGet("result")]
    public IActionResult Result()
    {
        return View(NewUser); //4. Return the NewUser ; 
                                //Now our result is going to recieve a view model...
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
