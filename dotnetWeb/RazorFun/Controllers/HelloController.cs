using Microsoft.AspNetCore.Mvc;
namespace RazorFun.Controllers;

public class HelloController : Controller
{
    // View Method to display Index View
    [HttpGet ("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet ("projects")]
    public string Projects()
    {
        return "This is my Piya Projects Page";
    }

    [HttpGet ("contact")]
    public string Contact()
    {
        return "This is my Piya Contact Page";
    }

}