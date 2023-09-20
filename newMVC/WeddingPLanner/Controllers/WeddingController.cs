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
            newWedding.GuestId = (int) HttpContext.Session.GetInt32("GuestId");
            _context.Add(newWedding);
            _context.SaveChanges();
            // return RedirectToAction("ViewWedding", newWedding.WeddingId);
            return RedirectToAction("Dashboard");
                                                                                //Todo Change this
            // return ViewWedding(newWedding.WeddingId);
        }
        return View("AddWedding");
        // return View ("AddWedding",newWedding);
    }
    [HttpPost("wedding/{id}/rsvp")]
    public IActionResult AddGuest(int id)
    {
        int UUID = (int)HttpContext.Session.GetInt32("GuestId");
        WeddingHasGuests rsvp = _context.WeddingHasGuests.FirstOrDefault(r => r.WeddingId == id && r.GuestId == UUID);
        if (rsvp == null)
        {
            WeddingHasGuests isRsvpd = new()
            {
                GuestId = UUID,
                WeddingId = id
            }; 
            _context.Add(isRsvpd);
            
        } else {
            _context.Remove(rsvp);
        }
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [HttpPost("wedding/{id}/destroy")]
    public IActionResult DeleteWedding(int id) //goes into dashboard.cshtml
    {
        Wedding? Wedding = _context.Weddings.FirstOrDefault(w => w.WeddingId == id);
        if (Wedding != null) 
        {
            _context.Remove(Wedding);
            _context.SaveChanges();
        }
            return RedirectToAction("Dashboard");
    }
}