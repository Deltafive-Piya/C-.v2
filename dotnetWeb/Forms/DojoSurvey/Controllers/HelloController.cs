using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers;

public class HelloController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpPost("process")]
    public IActionResult Process(FormData formData)
    {
        //REMEMBER- processing of incoming data happens here later...

        return View("Results", formData);
    }
}
