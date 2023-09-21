// using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
// using Microsoft.EntityFrameworkCore;
namespace WeddingPlanner.Controllers;

public class GuestController : Controller
{
    private MyContext _context;
    private readonly ILogger<GuestController> _logger;

    public GuestController(ILogger<GuestController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    // Home-2 Partials
    [HttpGet("")]
    public IActionResult Index()
    {
        // List<Guest> AllGuests = _context.Guests.Include(g => g.Rsvps).ToList(); //JOIN
        return View();
    }




    [HttpPost("guests/create")]
    public IActionResult CreateGuest(Guest newGuest)
    {
        if(ModelState.IsValid)
        {
            PasswordHasher<Guest> Model = new();
            newGuest.Password = Model.HashPassword(newGuest, newGuest.Password);
            _context.Add(newGuest);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("GuestId", newGuest.GuestId);       //move on, action "Success"
            HttpContext.Session.SetString("FirstName", newGuest.FirstName);       //move on, action "Success"
            return RedirectToAction("Dashboard","Wedding");
        }else

        return View ("Index");
        // return View ("AddGuest",newGuest);
        
    }




    [HttpPost("guests/login")]
    public IActionResult Login(Login loginGuest)
    {
        if(ModelState.IsValid)
        {
            Guest? userInDb = _context.Guests.SingleOrDefault(u => u.Email == loginGuest.LogEmail);                   //find the user based on Email
            if(userInDb == null)
            {
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                Console.WriteLine("LogEmail console");
                // return View("Index");
                return RedirectToAction("Dashboard","Wedding");
            }
            PasswordHasher<Login> hasher = new PasswordHasher<Login>();
            var result = hasher.VerifyHashedPassword(loginGuest, userInDb.Password,loginGuest.LogPassword);         //Created a variable that will store the result of pass comparison
            if(result == 0)                                                                                     //If validation fails
            {
                Console.WriteLine("LogPassword console");
                ModelState.AddModelError("LogPassword", "Invalid Email/Password");                                   //Handle a failed validation
                // return View("Index");
                return RedirectToAction("Dashboard","Wedding");
            } 
            HttpContext.Session.SetInt32("GuestId", userInDb.GuestId);       //move on, action "Success"
            HttpContext.Session.SetString("FirstName", userInDb.FirstName);       //move on, action "Success"
                Console.WriteLine("Dashboardmove console");
            return RedirectToAction("Dashboard","Wedding");
        
        }
        return RedirectToAction("Index");


        
    }
    [HttpPost("guests/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

}