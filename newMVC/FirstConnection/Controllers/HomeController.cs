using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstConnection.Models;

namespace FirstConnection.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;                             //added- create another variable for MyContext, then include it to the constructor below

    public HomeController(ILogger<HomeController> logger, MyContext context)   //" , MyContext context " added
    {
        _logger = logger;
        _context = context;                                 // added (research.this)- so that we can start asking for information.
    }

    public IActionResult Index()
    {
        List<Pet> AllPets = _context.Pets.ToList();         // added- Select * from Pets;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
