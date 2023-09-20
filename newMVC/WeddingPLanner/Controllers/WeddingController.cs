using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WeddingPlanner.Controllers;

public class WeddingController : Controller
{
    private MyContext _context;
    private readonly ILogger<WeddingController> _logger;

    public WeddingController(ILogger<WeddingController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    [HttpGet("wedding/dashboard")]
    public IActionResult Dashboard()
    {
        List<Wedding> AllWeddings = _context.Weddings.Include(wed => wed.Organizer).Include(wed => wed.AllGuests).ToList();
        return View(AllWeddings);
    }


    [HttpGet("wedding/view/{id}")]
    public IActionResult ViewWedding(int id )
    {
        Wedding? wed = _context.Weddings.Include(p => p.Organizer)
            .Include(p => p.AllGuests)
            // This reaches into the MIDdle table to grab the nested value of User
            .ThenInclude(mid => mid.Guest)
            .FirstOrDefault(p => p.WeddingId == id);
        if(wed == null)
        {
            return RedirectToAction("Dashboard");
        }
        return View(wed);
    }

    [HttpGet("wedding/new")]
    public IActionResult AddWedding()
    {
        return View();
    }
    [HttpPost("wedding/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("ViewWedding");
        }
        return View("AddWedding");
        // return View ("AddWedding",newWedding);
    }

}