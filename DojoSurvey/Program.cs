// New MVC will generate alot of what we are doing here...
var builder = WebApplication.CreateBuilder(args);

//Service- Add controllers with views
builder.Services.AddControllersWithViews();

//Web App Instance
var app = builder.Build();
//Web App Instance's features:
app.UseStaticFiles();
app.UseRouting();
// app.UseAuthentication(); // OMITTED- for the next episode, of DragonBallZ...

// ..Not how we want it mapped anymore...    ////
// app.MapGet("/", () => "Hello Worldee!");    //

//this is how we want it mapped:
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// APP return; .this always @EOF
app.Run(); 