//? 1 using dependency- EntityFramwork.Core;
//? 2 using dependency- (enabling access to MyContext Model) XxxProjectName.Models;
//? 3 touch var connection from appsettings.json
//? 4 Instruct our builder to use a DB connection Service



using Microsoft.EntityFrameworkCore;                                                    //? 1 MVC
using HobbyHub.Models;                                                                  //? 2 In order to access MyContext.cs within Models 
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");  //? 3 Instantiate DefaultConnection we created in appsettings.json  (as "connectionString")

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddDbContext<MyContext>(options =>                                     //? 4A Instantiate Service
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));     //? 4B Service.ConnectionString
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