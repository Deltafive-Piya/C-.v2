using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    // Show "Input name screen"
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    // Does the work & redirects to the dashboard
    [HttpPost("Login")]
    public IActionResult Login(string? name)
    {
        if (name == null){
            return RedirectToAction("Index");
        }
        HttpContext.Session.SetString("Name", name);
        // sets default number
        HttpContext.Session.SetInt32("Number", 22);
        return RedirectToAction("Dashboard");
    }

    // Does the submission work to mod the Number in session
    [HttpPost("Submit")]
    public IActionResult Submit(string submission)
    {
        int? num = HttpContext.Session.GetInt32("Number");
        // Add the value from the Hidden Input to the value in session
        if (submission == "x2"){
            int newNum = (int)(num *2);
            HttpContext.Session.SetInt32("Number", newNum);
            
        }else if (int.TryParse(submission, out int val)){
            int newNum = (int)(num + val);
            HttpContext.Session.SetInt32("Number", newNum);

        }else {
            // Random rand = new Random();
            // int randNum = rand.Next(1,11);
            // int newNum = (int)(num + randNum);
            // HttpContext.Session.SetInt32("Number", newNum);
        }
        
        return RedirectToAction("Dashboard");
    }

    // View- Dashboard
    [HttpGet("Dashboard")]
    public IActionResult Dashboard()
    {
        // Validates that a user is in session
        string? name = HttpContext.Session.GetString("Name");
        if (name == null){
            return RedirectToAction("Index");
        }
        return View();
    }

    // Clear session; redirect to root
    [HttpPost("Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}