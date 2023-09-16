   using Microsoft.AspNetCore.Mvc;
    namespace Countdown.Controllers;  /* Edit this namespace*/

    public class HelloController : Controller
    {
        [HttpGet ("")]
        public ViewResult Index()
        {
            return View("Index");
        }

    } 

    // Now that this file exists within your project, make the complimentary views (within the "Views" Folder)