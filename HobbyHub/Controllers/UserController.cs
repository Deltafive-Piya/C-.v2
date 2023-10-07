#pragma warning disable CS8600
#pragma warning disable CS8629
#pragma warning disable IDE0052
#pragma warning disable IDE0044

//Todo- Are we keeping System.Diagnostics for the _logger we are not using?
// using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HobbyHub.Models;
using Microsoft.EntityFrameworkCore;
namespace HobbyHub.Controllers;

public class UserController : Controller
{
    private MyContext _context;
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    // Home-2 Partials
    [HttpGet("")]
    public IActionResult Index()
    {
        // List<User> AllUsers = _context.Users.Include(g => g.iUAs).ToList(); //JOIN
        return View();
    }

    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if (ModelState.IsValid)
        {
            PasswordHasher<User> Model = new();
            newUser.Password = Model.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);       //move on, action "Success"
            HttpContext.Session.SetString("FName", newUser.FName);       //move on, action "Success"
            return RedirectToAction("Dashboard", "Hobby");
        }
        else

            return View("Index");
        // return View ("AddUser",newUser);

    }

    [HttpPost("users/login")]
    public IActionResult Login(Login loginUser)
    {
        if (ModelState.IsValid)
        {
            User? userInDb = _context.Users.SingleOrDefault(u => u.UName == loginUser.LogUName);                   //find the user based on UName
            if (userInDb == null)
            {
                ModelState.AddModelError("LogUName", "Invalid UName/Password");
                Console.WriteLine("LogUName console");
                return View("Index");
                // return RedirectToAction("Dashboard","Hobby");
            }
            PasswordHasher<Login> hasher = new();
            var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.LogPassword);         //Created a variable that will store the result of pass comparison
            if (result == 0)                                                                                     //If validation fails
            {
                Console.WriteLine("LogPassword console");
                ModelState.AddModelError("LogPassword", "Invalid UName/Password");                                   //Handle a failed validation
                return View("Index");
                // return RedirectToAction("Dashboard","Hobby");
            }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);       //move on, action "Success"
            HttpContext.Session.SetString("FName", userInDb.FName);       //move on, action "Success"
            Console.WriteLine("Dashboardmove console");
            return RedirectToAction("Dashboard", "Hobby");

        }
        return View("Index");
    }

    

    [HttpPost("users/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpGet("users/profile")]
    public IActionResult AccountInfo()
    {
        int personLoggedIn = (int)HttpContext.Session.GetInt32("UserId"); //ln 68
        User loggedeInUserAttributes = _context.Users.Include(u=>u.IsUAs).Include(u=>u.Hobbies).FirstOrDefault(u=>u.UserId == personLoggedIn); //LINQ DQL
        return View(loggedeInUserAttributes);
    }

    [HttpPost("users/adduser")]
public IActionResult AddUser(int id)
{
    if (HttpContext.Session.GetInt32("UserId") is int userId)
    {
        HobbyHasUsers iUA = _context.HobbyHasUsers.FirstOrDefault(r => r.HobbyId == id && r.UserId == userId);
        if (iUA == null)
        {
            HobbyHasUsers isiUAd = new()
            {
                UserId = userId,
                HobbyId = id
            };
            _context.Add(isiUAd);
        }
        else
        {
            _context.Remove(iUA);
        }
        _context.SaveChanges();
        return RedirectToAction("Dashboard", "Hobby");
    }
    return RedirectToAction("Index", "User"); // If user not loggedIn; Handle.
}
}