using Microsoft.AspNetCore.Mvc;
namespace PortfolioI.Controllers;

public class HelloController : Controller
{
    [HttpGet ("")]
    public string Index()
    {
        return "This is my Piya Index";
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