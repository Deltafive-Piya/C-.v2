using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoginAndRegistration.Models;
using Microsoft.AspNetCore.Identity; //pass hashing
using Microsoft.AspNetCore.Mvc.Filters;

namespace LoginAndRegistration.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet("")]                   
    public IActionResult Index ()
    {
        return View();
    }

    [HttpPost("users/create")]                      
    public IActionResult CreateUser(User newUser)
    {
        if(ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();           // Instance of a passHasher
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);  // Hash the user pass input
            _context.Add(newUser);                                              
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Success");
        } else {
            return View("Index");
        }
    }



    [SessionCheck]
    [HttpGet("success")]
    public IActionResult Success()
    {
        User? oneUser = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
        return View(oneUser);
    }

    [HttpPost("users/login")]
    public IActionResult LoginUser(Login loginUser)
    {
        if(ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == loginUser.LogEmail);                   //find the user based on Email
            if(userInDb == null)
            {
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                return View("Index");
            }
            PasswordHasher<Login> hasher = new PasswordHasher<Login>();
            var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password,loginUser.LogPassword);         //Created a variable that will store the result of pass comparison
            if(result == 0)                                                                                     //If validation fails
            {
                ModelState.AddModelError("LogPassword", "Invalid Email/Password");                                   //Handle a failed validation
                return View("Index");
            } else {
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);       //move on, action "Success"
                return RedirectToAction("Success");
            }
        }
        return RedirectToAction("Index");
    }
    [HttpPost("users/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }


}
