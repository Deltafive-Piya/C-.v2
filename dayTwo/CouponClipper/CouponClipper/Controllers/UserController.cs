// using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CouponClipper.Models;
using Microsoft.EntityFrameworkCore;
namespace CouponClipper.Controllers;

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
            HttpContext.Session.SetString("UserName", newUser.UserName);       //move on, action "Success"
            return RedirectToAction("Dashboard", "Coupon");
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
            User? userInDb = _context.Users.SingleOrDefault(u => u.Email == loginUser.LogEmail);                   //find the user based on Email
            if (userInDb == null)
            {
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                Console.WriteLine("LogEmail console");
                return View("Index");
                // return RedirectToAction("Dashboard","Coupon");
            }
            PasswordHasher<Login> hasher = new();
            var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.LogPassword);         //Created a variable that will store the result of pass comparison
            if (result == 0)                                                                                     //If validation fails
            {
                Console.WriteLine("LogPassword console");
                ModelState.AddModelError("LogPassword", "Invalid Email/Password");                                   //Handle a failed validation
                return View("Index");
                // return RedirectToAction("Dashboard","Coupon");
            }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);       //move on, action "Success"
            HttpContext.Session.SetString("UserName", userInDb.UserName);       //move on, action "Success"
            Console.WriteLine("Dashboardmove console");
            return RedirectToAction("Dashboard", "Coupon");

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
        User loggedeInUserAttributes = _context.Users.Include(u=>u.IsUAs).Include(u=>u.Coupons).FirstOrDefault(u=>u.UserId == personLoggedIn); //LINQ DQL
        return View(loggedeInUserAttributes);
    }

}