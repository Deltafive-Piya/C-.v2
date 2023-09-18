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
        List<Dish> AllDishes = _context.Dishes.ToList(); //GET action
        return View(AllDishes);
    }

    public IActionResult Create()
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
    [HttpGet("Dish/{id}/details")]
    public IActionResult Details(int id)
    {
        var dish = _context.Dishes.Find(id);

        if (dish == null)
        {
            return NotFound(); // If !exists(ID) , 404.
        }

        return View(dish);
    }

    // crUd Action
    [HttpPost("Dish/{dishId}/update")]
    public IActionResult Update(int dishId, Dish editedDish)
    {
        Dish? ToBeUpdated = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if (!ModelState.IsValid || ToBeUpdated == null)
        {
            return View("Edit", ToBeUpdated);
        }

        ToBeUpdated.Chef = editedDish.Chef;
        ToBeUpdated.Name = editedDish.Name;
        ToBeUpdated.Calories = editedDish.Calories;
        ToBeUpdated.Tastiness = editedDish.Tastiness;
        ToBeUpdated.Description = editedDish.Description;
        ToBeUpdated.UpdatedAt = DateTime.Now;
        _context.SaveChanges();

        return RedirectToAction("Details", new { id = dishId });
    }

    [HttpGet("dish/{dishId}/edit")]
    public IActionResult Edit(int dishId)
    {
        Dish? ToBeEdited = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        return View(ToBeEdited);
    }

    //cruD View
    [HttpPost("Dishes/{id}/delete")]
    public IActionResult Delete(int id)
    {
        Dish? ToBeDeleted = _context.Dishes.SingleOrDefault(d => d.DishId == id);

        Console.WriteLine(ToBeDeleted);
        _context.Dishes.Remove(ToBeDeleted);
        _context.SaveChanges();


        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
