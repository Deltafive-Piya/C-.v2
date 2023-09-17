using Microsoft.AspNetCore.Mvc;
namespace DojoForm.Controllers;

public class FormController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet("form")]
    public RedirectResult MyForm()
    {
        return View(); 
    }

    [HttpPost("Process")] // Updated the route
    public RedirectResult Process()
    {
        return Redirect("view");
    }
}