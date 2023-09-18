using Microsoft.EntityFrameworkCore;
using FirstConnection.Models;                                                               //Added


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");      //Added

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyContext>(options =>                                         //Added
{                                                                                           //
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));         //service that will connect to mysql
});                                                                                         //

var app = builder.Build();

// Configure the HTTP request pipeline.
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
