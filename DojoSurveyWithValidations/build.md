
dotnet new mvc --no-https -o DojoSurveyWithValidations
cd DojoSurveyWithValidations
code .

### <span style= "color: yellow;">Objectives</span>

-   1A,B,C) Name, Location, and Favorite Language should all be required.

-   2) Name should be no less than 2 characters.

-   3) Comment isn't required, but if included, should be more than 20 characters.

-   4) If the submission is invalid, render errors.

-   5) If the submission is successful, render the results page.

-   6) Use ViewModel to display results.

### <span style= "color: yellow;">Pull files from DojoSurveyWithModels</span>

#### Model-<span style= "color: white;">User.cs</span>
#### Views-Home-<span style= "color: white;">Index.cshtml</span>
#### wwwroot-css-<span style= "color: white;">site.css</span>
#### Controllers-<span style= "color: white;">HomeController.cs</span>
#### Views-Home-<span style= "color: white;">Privacy.cshtml -> Result.cshtml</span>

### <span style= "color: yellow;">Validations</span>

<span style= "color: white;">User.cs:</span>

    #pragma warning disable CS8618              //DisableWarning- null values
    using System.ComponentModel.DataAnnotations;

    namespace DojoSurveyWithValidations;
    public class User
    {
        // OBJECTIVE 1A) Name, Location, and Favorite Language should all be required.
        [Required]
        // OBJECTIVE 2) Name should be no less than 2 characters.
        [MinLength(2)]
        public string Name {get;set;}
        // OBJECTIVE 1B) Name, Location, and Favorite Language should all be required.
        [Required]
        public string Location {get;set;}
        // OBJECTIVE 1C) Name, Location, and Favorite Language should all be required.
        [Required]
        public string Language {get;set;}
        // OBJECTIVE 3) Comment isn't required, but if included, should be more than 20 characters.
        [StringLength(20)]
        public string? Comment {get;set;} // REMEMBER- ? to allow for emptyValue
    }


### <span style= "color: yellow;">Form Restructure 1/3 (asp-for)</span>

<span style= "color: white;">Index.cshtml:</span>

    @{
        ViewData["Title"] = "Ninja Form";
    }
    @model User
    <div class="text-center">
        <h2>Piya Dojo Form</h2>
        <form action="register" method="post">
            <div>
                <label asp-for="Name"></label>
                <input asp-for="Name">
            </div>
            <div>
                <label asp-for="Location"></label>
                <input asp-for="Location">
            </div>
            <div>
                <label asp-for="Language"></label>
                <input asp-for="Language">
            </div>
            <div>
                <label asp-for="Comment"></label>
                <input asp-for="Comment">
            </div>
            <div>
                <input type="submit" value="Submit">
            </div>
        </form>
    </div>

    @* Missing our logic within the controller *@
    @* Missing our asp-for for validations *@

### <span style= "color: yellow;">Form Restructure 2/3 (asp-for & asp-validation-for)</span>

<span style= "color: white;">Index.cshtml:</span>

    @{
        ViewData["Title"] = "Ninja Form";
    }
    @model User
    <div class="text-center">
        <h2>Piya Dojo Form</h2>
        <form action="register" method="post">
            <div>
                <label asp-for="Name"></label>
                <input asp-for="Name">
                <span asp-validation-for="Name"></span>
            </div>
            <div>
                <label asp-for="Location"></label>
                <input asp-for="Location">
                <span asp-validation-for="Location"></span>
            </div>
            <div>
                <label asp-for="Language"></label>
                <input asp-for="Language">
                <span asp-validation-for="Language"></span>
            </div>
            <div>
                <label asp-for="Comment"></label>
                <input asp-for="Comment">
                <span asp-validation-for="Comment"></span>
            </div>
            <div>
                <input type="submit" value="Submit">
            </div>
        </form>
    </div>

    @* Missing our logic within the controller *@

### <span style= "color: yellow;">Form Restructure 3/3 (Controller Logic)</span>

<span style= "color: white;">HomeController.cs:</span>

    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using DojoSurveyWithValidations.Models; // Assuming you have the appropriate namespace

    namespace DojoSurveyWithValidations.Controllers
    {
        public class HomeController : Controller
        {
            private readonly ILogger<HomeController> _logger;

            public HomeController(ILogger<HomeController> logger)
            {
                _logger = logger;
            }

            [HttpGet("/")]
            public ViewResult Index()
            {
                return View("Index");
            }

            [HttpPost("process")]
            public IActionResult Process(User newUser)
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Display", newUser);
                }
                else
                {
                    return View("Index");
                }
            }

            [HttpGet("Display")]
            public IActionResult Display(User newUser)
            {
                return View(newUser);
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }

### <span style= "color: yellow;">Show Results</span>

<span style= "color: white;">Display.cshtml:</span>

    @* Removed all prior boilerplate code *@
    @model User 
    <h2>Submitted Info</h2>
    <h3>Name: @Model.Name</h3>
    <h3>Location: @Model.Location</h3>
    <h3>Language: @Model.Language</h3>
    <h3>Comment: @Model.Comment</h3>
    <a href="/" class="btn btn-danger">Go Back</a>


</br>
</br>

### <span style= "color: yellow;">notes:</span>
#### <span style= "color: white;">Validation Data Anootatations and their purpose</span>
- Required
    - Validates whether field !null
- Regular Expression
    - Validates whether submitted value conforms to a regex
- MinLength()
    - Validates that str/arr field has specified min length
- MaxLength()
    - Validates that str/arr field has specified max length
- Range()
    - Checks whether value is in range
- EmailAddress
    - Validates field is in format[email]
- Compare()
    - Validates two fields are ==
- DataType()
    - Restricts values to a specified DataType

#### <span style= "color: white;">asp-for</span>
- Hooks up to a particular Model and effeciently builds the form

#### <span style= "color: white;">asp-validation-for</span>
- Error Message Implimentors (within span tags)