using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsAndDishes.Controllers;

public class ChefController : Controller
{
    private MyContext _context;
    private readonly ILogger<ChefController> _logger;

    public ChefController(ILogger<ChefController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        List<Chef> AllChefs = _context.Chefs.Include(c => c.AllDishes).ToList(); //JOIN
        return View(AllChefs);
    }

    [HttpGet("chef/new")]
    public IActionResult AddChef()
    {
        return View();
    }

    [HttpPost("chefs/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View ("AddChef");
        // return View ("AddChef",newChef);
        
    }
}