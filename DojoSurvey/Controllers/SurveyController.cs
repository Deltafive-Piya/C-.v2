using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers;

public class SurveyController : Controller // Parent "Controller" relies upon AspNetCore.Mvc
{
    // Action Method- return text on BlankView
    [HttpGet("")] // root url
    public string Index()
    {
        return "Hello from SurveyController Index Page :)";
    }

    // Action Method- return text on BlankView///////////////////
    [HttpGet("two")] // "two" url                              //
    public string Two()                                        //
    {                                                          //
        return "Hello from SurveyController Page two :)";      //
    }                                                          //

    // Action Method- return text on BlankView                 //Numeric version, merge both later...
    [HttpGet("2")] // "two" url                                //
    public string NumberTwo()                                  //
    {                                                          //
        return "Hello from SurveyController Page 2 :)";        //
    }                                                          //

   // Action Method- return text on BlankView
    [HttpGet("members/{name}/{id}")] // "id + name" url
    public string Params(int id, string name)
    {
        return $"Hello from SurveyController, {name} #:{id} :)";
    }
    //note-an integer placed in the int id variable will not break the app, but resort to default value "0"

    // View Method- return view
    [HttpGet("view")]
    public ViewResult FirstView()
    {
        return View("FirstView");
    }
}