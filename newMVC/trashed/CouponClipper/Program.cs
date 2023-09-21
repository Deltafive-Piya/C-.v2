using Microsoft.EntityFrameworkCore;
using CouponClipper.Models; // In order to access MyContext.cs within Models
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); //get DefaultConnection we made in appsettings.json

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
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
app.UseSession();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

//We can now contact MySQL using the connection String.