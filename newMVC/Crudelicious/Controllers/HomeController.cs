using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Crudelicious.Models;

namespace Crudelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()                   // Crud View
    {
        return View();
    }

    // Crud Action
    [HttpPost]
    public IActionResult Create(Dish dish)
    {
        if (ModelState.IsValid)
        {
            _context.Dishes.Add(dish);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(dish); // If !isValid(model.state) , restate Index with errors with errors
    }

    // cRud View
    public IActionResult Details(int id)
    {
        var dish = _context.Dishes.Find(id);

        if (dish == null)
        {
            return NotFound(); // If !exists(ID) , 404.
        }

        return View(dish);
    }

    // crUd View
    public IActionResult Edit(int id)
    {
        var dish = _context.Dishes.Find(id);

        if (dish == null)
        {
            return NotFound(); // If!esxists(ID), 404.
        }

        return View(dish);
    }

                                                    // crUd Action
    [HttpPost]
    public IActionResult Edit(Dish dish)
    {
        if (ModelState.IsValid)
        {
            _context.Dishes.Update(dish);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(dish);
    }

                                                    //cruD View
    public IActionResult Delete(int id)
    {
        var dish = _context.Dishes.Find(id);

        if (dish == null)
        {
            return NotFound();
        }

        return View(dish);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
