var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//Caution- Failure to comply may result in equiment damage or: 
// Unhandled exception. 
// System.InvalidOperationException: Unable to find the required services. 
// Please add all the required services by calling 'IServiceCollection.AddControllers' inside the call to 'ConfigureServices(...)' in the application startup code.
//    at Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.EnsureControllerServices(IEndpointRouteBuilder endpoints)
//    at Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute(IEndpointRouteBuilder endpoints, String name, String pattern, Object defaults, Object constraints, Object dataTokens)
//    at Program.<Main>$(String[] args) in C:\C#\MVC\Program.cs:line 7




var app = builder.Build();

// app.MapGet("/", () => "Hello World!"); //REMOVED- Boilerplate map

// New Map (via controller-method) below:
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run(); //'AppNameHere'.Run will always be at the bottom here
