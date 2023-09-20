# <span style="color: white">EF CRUD MySQL MVC app</span>
- Dotnet new mvc --no-https -o Xxx
### <span style="color: yellow">Objective</span>
- Build an MVC project that is capable of connecting to a database.
- Create models that will represent tables in a database.
### <span style="color: yellow">Steps</span>
## <span style="color: white">Initital Setup and Models</span>

#### <span style="color: white">console commands for dependencies</span>
    dotnet add package Pomelo.EntityFrameworkCore.MySql
    dotnet add package Microsoft.EntityFrameworkCore.Design
#### <span style="color: white">Build the models</span>
Models: Dish.cs

    #pragma warning disable CS8618 //ready...
    using System.ComponentModel.DataAnnotations;

    namespace ChefsAndDishes.Models; //Is the namsepace correct?

    public class Dish                     //Is modelName correct?
    {

        [Key]                           //PK
        public int DishId { get; set; } //PK

        [Required]
        [MinLength(2)]
        public string DishName { get; set; }
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Must have calories")]
        public int Calories { get; set; }
        [Required]
        [Range(1, 5)]
        public string Tastiness { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public int ChefId {get;set;}
        //hook
        public Chef? Cook {get;set;}
    }
Models: Chef.cs

    #pragma warning disable CS8618 //ready
    using System.ComponentModel.DataAnnotations;

    namespace ChefsAndDishes.Models; //Is the namsepace correct?

    public class Chef                       //Is modelName correct?
    {

        [Key]                           //PK
        public int ChefId { get; set; } //PK

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }
        
        [Required (ErrorMessage = "must enter age")]
        [AgeCheck (ErrorMessage = "must be over 18")]
        public DateTime Age { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public List<Dish> AllDishes {get;set;} = new List<Dish>();
    }

    public class AgeCheck : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime Age && Age < DateTime.Now)
            {
                int YearsOld = DateTime.Now.Year - Age.Year; //comparing year only, not month and days
                return YearsOld >= 18;
            }
            return false; // if not valid age or future person
        }
    }
#### <span style="color: white">Build in Models folder- Context.cs</span>
##### <span style="color: white">MyContext will tell MySQL what to forward engineer </span>
<span style="color: white">Models: MyContext.cs</span>

    #pragma warning disable CS8618
    using Microsoft.EntityFrameworkCore;
    namespace ChefsAndDishes.Models;
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) {} //REMEMBER WILL NOT CHANGE
        public DbSet<Chef> Chefs {get;set;}                         //Users Table; will use _context.Users for DQL
        public DbSet<Dish> Dishes {get;set;}                        //Users Table; will use _context.Users for DQL
    }

#### <span style="color: white">Establish Credentials to login to MySQL</span>
#### <span style="color: white">Edit appsettings.json</span>
##### <span style="color: white">appsettings.json will connect via a defaultConnection listed in code...  </span>
    {
    "Logging": {
        "LogLevel": {
        "Default": "Information",
        "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*",
    "ConnectionStrings":
    {
        "DefaultConnection": "Server=localhost;port=3306;userid=root;password=rootroot;database=ChefsDb;" 
    }
    }

#### <span style="color: white">Connect to MySql</span>
#### <span style="color: white">Edit Program.cs</span>
#### <span style="color: white">Use the Connection String created in mysettings.json @ </span>

    using Microsoft.EntityFrameworkCore;
    using WeddingPLanner.Models; // In order to access MyContext.cs within Models
    var builder = WebApplication.CreateBuilder(args);
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); //get DefaultConnection we made in appsettings.json

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<MyContext>(options =>                                 //
    {
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); //
    });

    var app = builder.Build();


    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.Run();

    //We can now contact MySQL using the connection String.

#### <span style="color: white">Create a Migrate Instance</span>
##### <span style="color: white">Within Console:</span>
    dotnet ef migrations add FirstMigration -v
#### <span style="color: white">Migrate the project over to MySQL</span>
##### <span style="color: white">Console should print the tables</span>
    dotnet ef database update -v
##### <span style="color: white">Upon Success, DB exists within Workbench</span>
#### <span style="color: white">Add MyContext and _context into XxxController.cs</span>

##### <span style="color: white">ChefController.cs</span>
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using ChefsAndDishes.Models;
    using Microsoft.EntityFrameworkCore;

    namespace ChefsAndDishes.Controllers;

    public class ChefController : Controller
    {
        private MyContext _context;
        private readonly ILogger<ChefController> _logger;

        public ChefController(ILogger<ChefController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = _context.Chefs.Include(c => c.AllDishes).ToList(); //JOIN
            return View(AllChefs);
        }

        [HttpGet("chef/new")]
        public IActionResult AddChef()
        {
            return View();
        }

        [HttpPost("chefs/create")]
        public IActionResult CreateChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                _context.Add(newChef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View ("AddChef");
            // return View ("AddChef",newChef);
            
        }
    }
##### <span style="color: white">DishController.cs</span>
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using ChefsAndDishes.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc.Rendering;

    namespace ChefsAndDishes.Controllers;

    public class DishController : Controller
    {
        private MyContext _context;
        private readonly ILogger<DishController> _logger;

        public DishController(ILogger<DishController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("dish/view")]                       //REMEMBER
        public IActionResult ViewDish()
        {
            List<Dish> AllDishes = _context.Dishes.Include(d => d.Cook).ToList(); //JOIN
            return View(AllDishes);
        }
        [HttpGet("dish/new")]
        public IActionResult AddDish()
        {
            List<Chef> Cooks = _context.Chefs.ToList();
            ViewBag.ChefList = new SelectList(Cooks, "ChefId", "FirstName");
            return View();
        }
        [HttpPost("dish/create")]
        public IActionResult CreateDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("ViewDish");
            }
            return View("AddDish");
            // return View ("AddDish",newDish);

        }
    }

## <span style="color: white">CRUD'ing Data for our DB</span>
### Create the forms to handle the data for the models within:
#### Views->TableNameSingular->ViewFile Containing the form

Index.cshtml

    @model List<Chef>
    @using Microsoft.EntityFrameworkCore; 
    @await Html.PartialAsync("_navBar")

    <h1>Chef Crew:</h1>
    <hr>
    <table>
        <thead>
            <tr>
            <td>Name</td>
            <td>Age</td>
            <td># of Dishes</td>
            </tr>
        </thead>
        <tbody>
            @foreach (Chef cook in Model)
            {
                <tr>
                    <td>@cook.FirstName @cook.LastName</td>
                    <td>@{
                            int age = DateTime.Today.Year - cook.Age.Year;
                            @age
                        }
                    </td>
                    <td>@cook.AllDishes.Count</td>
                </tr>
            }----Still Need Css
        </tbody>
    </table>
    ### <span style="color: white">Read</span>
    #### <span style="color: white">Read stuff</span>
    ### <span style="color: white">Update</span>
    #### <span style="color: white">Update stuff</span>
    ### <span style="color: white">Delete</span>
    #### <span style="color: white">Delete Stuff</span>
### <span style="color: white">Create</span>
#### <span style="color: white">create stuff</span>
    //C view
    [HttpGet("dish/new")]
    public IActionResult AddDish()
    {
        List<Chef> Cooks = _context.Chefs.ToList();
        ViewBag.ChefList = new SelectList(Cooks, "ChefId", "FirstName");
        return View();
    }

    //C action
    [HttpPost("dish/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("ViewDish");
        }
        return View("AddDish");
        // return View ("AddDish",newDish);

    }
### <span style="color: white">Read</span>
#### <span style="color: white">read stuff</span>
    [HttpGet("dish/view")]
    public IActionResult ViewDish()
    {
        List<Dish> AllDishes = _context.Dishes.Include(d => d.Cook).ToList(); //JOIN
        return View(AllDishes);
    }
### <span style="color: white">Update</span>
#### <span style="color: white">update stuff</span>
    // crUd Action
    [HttpPost("Dish/{dishId}/update")]
    public IActionResult Update(int dishId, Dish editedDish)
    {
        Dish? ToBeUpdated = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if (!ModelState.IsValid || ToBeUpdated == null)
        {
            return View("Edit", ToBeUpdated);
        }

        ToBeUpdated.Chef = editedDish.Chef;
        ToBeUpdated.Name = editedDish.Name;
        ToBeUpdated.Calories = editedDish.Calories;
        ToBeUpdated.Tastiness = editedDish.Tastiness;
        ToBeUpdated.Description = editedDish.Description;
        ToBeUpdated.UpdatedAt = DateTime.Now;
        _context.SaveChanges();

        return RedirectToAction("Details", new { id = dishId });
    }

    [HttpGet("dish/{dishId}/edit")]
    public IActionResult Edit(int dishId)
    {
        Dish? ToBeEdited = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        return View(ToBeEdited);
    }

### <span style="color: white">Delete</span>
#### <span style="color: white">delete stuff</span>
    //cruD View
    [HttpPost("Dishes/{id}/delete")]
    public IActionResult Delete(int id)
    {
        Dish? ToBeDeleted = _context.Dishes.SingleOrDefault(d => d.DishId == id);

        Console.WriteLine(ToBeDeleted);
        _context.Dishes.Remove(ToBeDeleted);
        _context.SaveChanges();


        return RedirectToAction("Index");
    }




































</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>
</br>

#### <span style="color: yellow">Notes</span>
Within the cs files- documentation formatting:
- // TODO asdasd
- // ! asdasd
- // ? asdasd
- // * asdasd

dotnet restore will restore this app to functioning (post project folder move)