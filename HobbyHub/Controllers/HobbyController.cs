#pragma warning disable CS8600
#pragma warning disable CS8629
#pragma warning disable IDE0052

using Microsoft.AspNetCore.Mvc;         //* Controller, Http(Get/), IActionResult, View, HttpContext, ModelState, RedirectToAction
using HobbyHub.Models;                  //Todo- Context/_context?
using Microsoft.EntityFrameworkCore; //* .Include
namespace HobbyHub.Controllers;

//* Hobby Class Containing methods
public class HobbyController : Controller
{
    private readonly MyContext _context;

    //? Not used: "_logger"
    //? Kept for future debugging, 
    //? Interface && Children loggers, 
    //? diagnosing in Prod Env, 
    private readonly ILogger<HobbyController> _logger;

    public HobbyController(ILogger<HobbyController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }



    //! Page 2 - /hobbies
    //* Homepage GET
    [HttpGet("hobby/dashboard")]
    public IActionResult Dashboard()
    {
        //* LINQ Lambda in SQL form- 
        //* SELECT *
        //* FROM Hobbies

        List<Hobby> AllHobbies = _context.Hobbies.ToList();
        return View(AllHobbies);
    }

    //! Page 3A - /hobbies/{id}
    //* GetOneHobbyById ACTION
    [HttpGet("hobby/view/{id}")]
    public IActionResult ViewHobby(int id)
    {
        //TODO- Explain LINQ DQL
        Hobby? hobb = _context.Hobbies.Include(user => user.AllUsers).ThenInclude(hobb => hobb.User).FirstOrDefault(h => h.HobbyId == id);
        if (hobb == null)
        {
            return RedirectToAction("Dashboard");
        }
        return View(hobb);
    }

    //! Page 3B - /hobbie/new
    //* AddOne view ACTION
    [HttpGet("hobby/new")]
    public IActionResult AddHobby()
    {
        return View();
    }

    //* AddHobby ACTION
    [HttpPost("hobby/create")]
    public IActionResult CreateHobby(Hobby newHobby)
    {
        if (HttpContext.Session.GetInt32("UserId") is int userId)
        {
            if (ModelState.IsValid)
            {
                newHobby.UserId = userId;
                // newHobby.HobbyDescription = HttpContext.Request.Form["HobbyDescription"];
                _context.Add(newHobby);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }
        return View("AddHobby", newHobby); // Return to the AddHobby view with validation errors
    }

    //! Add enthusiast
    [HttpPost("hobby/{id}/iUA")]
    public IActionResult AddUser(int id)
    {
        int userId = (int)HttpContext.Session.GetInt32("UserId");
        Hobby hobby = _context.Hobbies.Include(h => h.AllUsers).FirstOrDefault(h => h.HobbyId == id);

        if (hobby == null)
        {
            return RedirectToAction("Dashboard");
        }

        HobbyHasUsers iUA = hobby.AllUsers.FirstOrDefault(r => r.UserId == userId);

        if (iUA == null)
        {
            HobbyHasUsers isiUAd = new()
            {
                UserId = userId,
                HobbyId = id
            };
            hobby.AllUsers.Add(isiUAd);
            hobby.EnthusiastCount++; // +1 member
        }
        else
        {
            hobby.AllUsers.Remove(iUA);
            hobby.EnthusiastCount--; // -1 member
        }

        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    //? Not USED
    //* Action- DeleteOneHobbyById
    [HttpPost("hobby/{id}/destroy")]
    public IActionResult DeleteHobby(int id)
    {
        //Todo- Study this block(LINQ DQL) 
        Hobby? Hobby = _context.Hobbies.FirstOrDefault(h => h.HobbyId == id);
        if (Hobby != null)
        {
            _context.Remove(Hobby);
            _context.SaveChanges();
        }
        return RedirectToAction("Dashboard");
    }


}