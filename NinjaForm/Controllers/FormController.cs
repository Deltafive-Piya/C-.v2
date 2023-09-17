using Microsoft.AspNetCore.Mvc;
namespace Form.Controllers;

public class FormController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet("Form")]
    public IActionResult Form()
    {
        var formData = new FormData(); // Create an instance of the model (for creating new records)
        return View(formData); // Pass the model to the Form.cshtml view
    }

    [HttpPost("Process")] // Updated the route
    public IActionResult Process(FormData formData)
    {
        return View("Results", formData);
    }
}