using Microsoft.AspNetCore.Mvc;     // Pulling in MVC Package in order to do MVC;

namespace MVC.Controllers;          // namespace ProjectNameHere.NameOfControllerFolderHere;


public class FirstController : Controller //The main scope of the the file
{
    //Root Listener
    [HttpGet("")]                               //listening for: root route ///

    public string Index()                       //New Index object printing:
    {
        return "Hello from FirstController.";   //Your print goes here
    }

    //Secret Listener
    [HttpGet("secret_tunnel")]                  //listening for: secret_tunnel route

    public string Secret()                      //New Index object printing:
    {
        return "Get outa ma secret tunnel.";        //Your print goes here
    }

    //params Listener
    [HttpGet("params/{id}/{name}")]             // if (userInput.id=string) {id defaults => 0}
    public string Params(int id, string name)
    {
        return $"{name}'s ID: {id}";
    }

    //View Listener
    [HttpGet("view")]
    public ViewResult FirstView()
    {
        return View("FirstView");
    }
}