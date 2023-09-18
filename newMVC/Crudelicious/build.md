# <span style="color: yellow">Crudelicious MVC App</span>
## <span style="color: white"> Objective</span>
- Make a EF CRUD App utilizing EF Core(EF DB) and LINQ(EF DQL)
## <span style="color: yellow">Requirements</span>
1. Create a Dishes model
2. Connect to your MySQL database
3. Complete the front page
4. Be able to add a new dish using a form
5. Able to view a single dish on a page
6. Able to edit a dish and redirect back to the view one page
7. Able to delete a dish from the database
8. Follow RESTful routing standards
## <span style="color: yellow">Init</span>
    dotnet new mvc --no-https -o Crudelicious
    cd
    code .
    dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.1
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.3
## <span style= "color: yellow;">Create our Models</span>
### <span style= "color: white;">Dish.cs</span>
    #pragma warning disable CS8618
    using System.ComponentModel.DataAnnotations;
    namespace Crudelicious.Models;                              //
    public class Dish                                           //
    {
        [Key]                           //PK Already [Required] by convention
        public int DishId {get;set;}    //PK  

        [Required]
        public string Name {get;set;}       
        [Required]                
        public string Chef {get;set;}
        [Required]
        [Range(1,5, ErrorMessage ="FistToFive- 1(inedible) - 5(sublime) please...")] 
        public int Tastiness {get;set;}
        [Required]
        [Range(1,int.MaxValue, ErrorMessage ="No calorie-free meals here...")]                       
        public int Calories {get;set;}
        [Required]
        public string Description {get;set;}                          

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
### <span style= "color: white;">MyContext.cs</span>
    #pragma warning disable CS8618
    using Microsoft.EntityFrameworkCore;
    namespace Crudelicious.Models;

    public class MyContext : DbContext{
        public MyContext(DbContextOptions options) : base(options) {}

        //Tables for our DB
        public DbSet<Dish> Dishes {get;set;}
    }
## <span style= "color: yellow;">Establish MySQL Connection (+migrate & update)</span>
### <span style= "color: white;">patch appsettings.json</span>
-Add the default connection string:

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
        "DefaultConnection": "Server=localhost;port=3306;userid=root;password=rootroot;database=Crudeliciousdb;" 
    }
    }
### <span style= "color: white;">program.cs</span>
-Head to program.cs and use the previously implimented features

    using Microsoft.EntityFrameworkCore; //Because Microsoft says so
    using Crudelicious.Models; // In order to access MyContext.cs within Models
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
## <span style= "color: white;">(console) db migrate</span>
- dotnet ef migrations add FirstMigration
## <span style= "color: white;">(console) db update</span>
- dotnet ef database update
