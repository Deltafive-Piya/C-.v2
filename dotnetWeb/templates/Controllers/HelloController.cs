//template ControllerFile with Views 
// (instead of return print statements)
using Microsoft.AspNetCore.Mvc;
namespace EditThisTemplateName.Controllers;

public class HelloController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet("projects")]
    public ViewResult Projects()
    {
        return View("Projects");
    }

    [HttpGet("contact")]
    public ViewResult Contact()
    {
        return View("Contact");
    }

}