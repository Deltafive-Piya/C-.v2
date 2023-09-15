# <span style= "color: white;">RazorFun</span>
(Working off of Portfolio I ...)

- Render a View using Razor in a simple web application.
- Apply C# logic to render data on our View.
- Bonus: Apply conditional logic to affect how data renders.

### <span style= "color: white;">objectives</span>
- Create a web application that renders a cshtml page.
- Add a List of strings to Index.cshtml using Razor.
- Loop through the values in the List and print each one out in a p tag.
- Bonus: If the string in the array begins with the letter "c", style the p element with red text.



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
                return "This is my Index";
            }

        }
