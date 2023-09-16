//template ControllerFile with Views 
// (instead of return print statements)
using Microsoft.AspNetCore.Mvc;
namespace Forms.Controllers;

public class HelloController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

[HttpPost("process")]
    public IActionResult Process(string TextField, int NumberField)
    {    
        // Do something with form input
        Console.WriteLine($"My text was: {TextField}");
        Console.WriteLine($"My number was: {NumberField}");
        // Then don't forget to return some kind of result!
    }
}