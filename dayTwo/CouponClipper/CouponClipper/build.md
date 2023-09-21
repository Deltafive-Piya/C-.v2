# <span style="color:white;">CouponClipper</span>
<span style="color:orange;">If EF is a framework, why do we have to configure it so much post init?</span>
<span style="color:orange;"></span>
<span style="color:orange;"></span>
<span style="color:orange;"></span>
<span style="color:orange;"></span>
### <span style="color:red;">Considerations</span>
1) <span style="color:red;">int personLoggedIn = (int)HttpContext.Session.GetInt32("UserId");</span>
    ####  -Error-
    An unhandled exception occurred while processing the request.
    InvalidOperationException: Nullable object must have a value.
    #### -Resolve-
    There is an issue with session, attempting to access a view( CurrentSessionRequired )



## <span style="color:yellow;">Mkdir and Packages</span>
https://login.codingdojo.com/m/613/14008/104589

    dotnet new mvc --no-https -o CouponClipper
    cd CouponClipper
    dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.1
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.3 
## <span style="color:yellow;">Create Models</span>
- Tables
    - Coupon Model:
    - User Model:
    - CouponHasUsers (many-many table):
- Log/Reg
    - Login.cs:
    - MyContext.cs:
- ErrorHandling
    - ErrorViewModel.cs:

## <span style="color:yellow;">Connect to MySQL</span>
https://login.codingdojo.com/m/613/14008/105034
- Establish Credentials within appsettings.json by adding a default connection address:
    - Patch:
        - (optional) port=""
        - <span style="color:orange;">userid="localInstance"</span>
        - <span style="color:orange;">password="localInstance"</span>
        - <span style="color:orange;">database="localhostDBNameThatDoesntExist"</span>

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
                    "DefaultConnection": "Server=localhost;port=3306;userid=root;password=rootroot;database=CouponClipperDb;"
                }
                }   
## <span style="color:yellow;">Patch Program.cs</span>
https://login.codingdojo.com/m/613/14008/105212
1) using dependency- EntityFramwork.Core;
2) using dependency- (enabling access to MyContext Model) XxxProjectName.Models;
3) touch var connection from appsettings.json
4) Instruct our builder to use a DB connection Service

        using Microsoft.EntityFrameworkCore;                                                // 1 MVC
        using CouponClipper.Models;                                                         // 2 In order to access MyContext.cs within Models 
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); //3 Instantiate DefaultConnection we created in appsettings.json  (as "connectionString")

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSession();
        builder.Services.AddDbContext<MyContext>(options =>                                 //4A Instantiate Service
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); //4B Service.ConnectionString
        });

        var app = builder.Build();


        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();
        app.UseRouting();
        app.UseSession();
        app.UseAuthorization();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.Run();

## <span style="color:yellow;">Prepare a DB Instance for a migration</span>
https://login.codingdojo.com/m/613/14008/105212

    dotnet ef migrations add FirstMigration -v
-   (After Created Models, tables, connection string, and the function(connectionString) 
## <span style="color:yellow;">Forward engineer Model Tables via the migration instance</span>
    dotnet ef database update -v
-   Push all the table(info) -> MySQL
### <span style="color:red;">Considerations</span>
2) <span style="color:white;">When to re-forwardEngineer ERD:</span>
    ####  -Error-
    ERD updated, rendering any prior forward-engineered database obselete.
    #### -Resolve-
    - Delete the "Migrations" Folder
    - redo:
        - dotnet ef migrations add FirstMigration -v
        - dotnet ef database update -v
## <span style="color:yellow;">Create Controllers 1/4- Init and cRud</span>
https://login.codingdojo.com/m/613/14008/105212 @2:12
- <span style="color:white;">Controller Class
    - touch private readonly MyContext _context;
    - patch private readonly ILoggger< XxxController> _logger;
        - touch "_context = context" directly under _logger within XxxControllerILogger
    </br>
    </br>
    </br>
    - Method-Homepage
        - Http Request
        - public IActionResult Xxx() containing: 
            - (List)Linq Lambda Expression (Instance && DQL)
            - return View (NameIfNotSameAsClassName)
    </br>
    </br>
    - Method-GetOneById
        - Http Request
        - public IActionResult XxxXxx(int id) containing: 
            - Linq Lambda Expression (Instance? && DQL)
            - if (LINQ instance == null)
                - return RedirectToAction
            - return View (NameIfNotSameAsClassName)
    </br>
    </br>
    - Method-GetOneView
        - Http Request
        - public IActionResult XxxXxx() containing: 
            - Linq Lambda Expression (Instance? && DQL)
            - if (LINQ instance == null)
                - return RedirectToAction
            - return View (NameIfNotSameAsClassName)</span>

    - <span style="color:orange;"> Method </span>
        - return View();
    - <span style="color:orange;">Action </span>
        - RedirectToAction();
    - <span style="color:orange;">Get </span>
        - RedirectToAction();
        </span>
    ### <span style="color:red;">Considerations</span>
    3) <span style="color:white;">Post-Deleting DB migration folder within project:</span>
        ####  -Error-
        ERD updated, rendering any prior forward-engineered database obselete.
        #### -Resolve-
        - Delete the "Migrations" Folder
        - redo:
            - dotnet ef migrations add FirstMigration -v
            - dotnet ef database update -v
## <span style="color:yellow;">Create Controllers 2/4- Crud</span>
https://login.codingdojo.com/m/613/14008/105214 @ 00:50 

<span style="color:white;">Patch- Controller class:</span>

- <span style="color:white;">Controller Class</span>
    - <span style="color:white;">~Dependencies here~</span>
    - <span style="color:white;">~Object declarations~</span>
    - <span style="color:white;">~[HttpGet methods]~</span>
    
    </br>

    - ~ <span style="color:white;">Crud Section ~
        - [HttpPost("xxxs/xxx")]
        - if(ModelState.IsValid)
            - _context.Add(<span style="color:orange;">Obj to add to DB</span>)
            - _context.SaveChanges(<span style="color:orange;">No param</span>)
            - return RedirectToAction(">0LvlDownPage")
        - else
            - return View("XxxXxx")</span>
## <span style="color:yellow;">Create Controllers 3/4- crUd</span>

## <span style="color:yellow;">Create Controllers 4/4- cruD</span>


</br>

## <span style="color:yellow;">RESTful Routing</span>

## <span style="color:yellow;">NextStepGoesHere</span>
## <span style="color:yellow;">NextStepGoesHere</span>
## <span style="color:yellow;">NextStepGoesHere</span>
## <span style="color:yellow;">NextStepGoesHere</span>
## <span style="color:yellow;">NextStepGoesHere</span>
## <span style="color:yellow;">NextStepGoesHere</span>
- 