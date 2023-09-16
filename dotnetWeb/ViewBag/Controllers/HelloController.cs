using Microsoft.AspNetCore.Mvc;
namespace ViewBag.Controllers;  /* Edit this namespace*/

public class HelloController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        ViewBag.Name = "Piya";
        return View();
    }

}