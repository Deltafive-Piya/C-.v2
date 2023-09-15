# <span style= "color: white;">Portfolio</span>

- Construct an ASP.NET Core project with an MVC structure.

- Build multiple routes in a Controller that return strings.

### <span style= "color: white;">objectives</span>

- Build an Index (front) route and render "This is my Index!"

- Build a Projects route and render "These are my projects!"

- Build a Contact route and render "This is my Contact!"



### <span style= "color: white;">steps</span>

#### <span style= "color: white;">project create:</span>

    cd dotnetWeb (directory for all dotnetWeb projects)
    dotnet new web --no-https -o PortfolioI
    cd PortfolioI
    code .

#### <span style= "color: white;">Program.cs edit:</span>

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllersWithViews();
    var app = builder.Build();

    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );

    app.Run();

#### <span style= "color: white;">Controllers:</span>

- create a Controller folder and make new controller 

    "HelloController":

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
