# <span style= "color: white;">RazorFun</span>
(Working off of Portfolio I ...)
https://github.com/Deltafive-Piya/C-.v2/tree/main/dotnetWeb/PortfolioI

- Render a View using Razor in a simple web application.
- Apply C# logic to render data on our View.
- Bonus: Apply conditional logic to affect how data renders.

### <span style= "color: white;">objectives</span>
- Create a web application that renders a cshtml page.
- Add a List of strings to Index.cshtml using Razor.
- Loop through the values in the List and print each one out in a p tag.
- Bonus: If the string in the array begins with the letter "c", style the p element with red text.



### <span style= "color: white;">steps</span>

#### <span style= "color: white;">Hello View create:</span>

- Create a Views folder
- Within that Views folder, create a folder named after the controller (Hello in this case)
- With Hello, touch Index.cshtml:

        <!DOCTYPE html>
        <html lang="en">
            <head>
                <meta charset="UTF-8">
                <meta http-equiv="X-UA-Compatible" content="IE-edge">
                <meta name="viewport" content="width=device-width, initial-scale=1.0">
                <title>Piya Index template</title>
            </head>
            <body>
                
            </body>
        </html>

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
