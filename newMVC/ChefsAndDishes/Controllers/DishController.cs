using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChefsAndDishes.Controllers;

public class DishController : Controller
{
    private MyContext _context;
    private readonly ILogger<DishController> _logger;

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("dish/view")]                       //REMEMBER
    public IActionResult ViewDish()
    {
        List<Dish> AllDishes = _context.Dishes.Include(d => d.Cook).ToList(); //JOIN
        return View(AllDishes);
    }
    [HttpGet("dish/new")]
    public IActionResult AddDish()
    {
        List<Chef> Cooks = _context.Chefs.ToList();
        ViewBag.ChefList = new SelectList(Cooks, "ChefId", "FirstName");
        return View();
    }
    [HttpPost("dish/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("ViewDish");
        }
        return View("AddDish");
        // return View ("AddDish",newDish);

    }
}