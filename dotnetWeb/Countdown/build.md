# <span style= "color: white;">Countdown</span>

## <span style= "color: yellow;">objective</span>
- Display & compare dates/times.
- Render results on View.

## <span style= "color: yellow;">requirements</span>
- Visually recreate the wireframe
- Research- DateTimes(format and compare)
- Apply logic to make the page functional

## <span style= "color: yellow;">development</span>
#### <span style= "color: white;">1. Init the project- Program and Controller</span>


        dotnet new web --no-https -o Countdown
        cd Countdown
        mkdir Controllers
        cd Controllers -> touch HelloController.cs:

- Program.cs:

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

- HelloController.cs:

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

#### <span style= "color: white;">2. Add the necessary view (that contains the date functions) for the controller</span>

        <!DOCTYPE html>
        <html lang="en">
        <head>
            stuff here
        </head>
        <body>
            @{
                @* Example for function test- 2023 December 25 7hrs 0min0sec *@
                DateTime endDate = new DateTime(2023, 12, 25, 7, 00, 00);
                TimeSpan difference = endDate - DateTime.Now;
            }
            <h2>Start Time</h2>
            <h3>@DateTime.Now.ToString("MMM d, yy h:mm tt")</h3>
            <h2>End Time</h2>
            <h3>@endDate.ToString("MMM d, yy h:mm tt")</h3>
            <h2>Remaining Time</h2>
            <h3>@difference.Days day(s), @difference.Hours hour(s), @difference.Minutes minute(s)</h3>
        </body>
        </html>

#### <span style= "color: white;">3. wwwroot style.css</span>

        mkdir wwwroot
        cd wwwroot
            mkdir css
            cd css
                touch style.css
#### <span style= "color: white;">4. Assign classnames to index.cshtml tags and style</span>
- style.css:
    -   make each card div (StartTime & EndTime) within a cards div;
    -   make a remaining div for the RemainingTime
    -   new css classes ("container", "cards", "card", "remaining")

            @* Index.cshtml *@
            <!DOCTYPE html>
            <html lang="en">
            <head>
                <meta charset="UTF-8">
                <meta http-equiv="X-UA-Compatible" content="IE-edge">
                <meta name="viewport" content="width=device-width, initial-scale=1.0">
                <title>Piya- About Me Page</title>
                <link rel="stylesheet" href="~/css/style.css">
                @* <link rel="stylesheet" href="~/css/nav.css"> *@
            </head>
            <body>
                @{
                    @* Example- 2023 December 25 7hrs 0min0sec *@
                    DateTime endDate = new DateTime(2023, 12, 25, 7, 00, 00);
                    TimeSpan difference = endDate - DateTime.Now;
                }

                <div class="container">
                    <div class="cards">

                        @* Collection *@
                        <div class="card">
                            <h2>Start Time</h2>
                            <h3>@DateTime.Now.ToString("MMM d, yy h:mm tt")</h3>
                        </div>

                        @* entry *@
                        <div class="card">
                            <h2>End Time</h2>
                            <h3>@endDate.ToString("MMM d, yy h:mm tt")</h3>
                        </div>
                        
                        @* Calculated Results *@
                        <div class="remaining">
                            <h2>Remaining Time</h2>
                            <h3>@difference.Days day(s), @difference.Hours hour(s), @difference.Minutes minute(s)</h3>
                        </div>

                    </div>
                </div>

                
            </body>
            </html>

<span style= "color: white;">style.css</span>

    /* style.css */
    * {
        margin: 0;
        padding: 0;
        font-family: monospace;
    }

    .container {
        
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
        background-color: #ffffff;
        flex-direction: column;
    }

    .cards {
        display: flex;
        justify-content: space-between;
        align-items: center;
        background-color: #ffffff;
        padding: 20px;
        border-radius: 10px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
    }

    .card {
        margin: 5px 5px;
        text-align: center;
        padding: 20px;
        background-color: navajowhite;
        border-radius: 5px;
        box-shadow: 0 0 5px rgba(0, 0, 0, 0);
    }

    .remaining {
        text-align: center;
        border-radius: 2px;
        margin:10px 10px;
        background-color: rgb(0, 0, 0);
        color: rgb(255, 255, 255);
    }

    /* Style headings in cards */
    h2 {
        font-size: 18px;
        margin-bottom: 5px;
    }

    h3 {
        font-size: 16px;
        margin: 0;
    }
