using Base.Modules.Companies.Api;
using Base.Modules.Users.Api;
using Base.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCompaniesModule();
builder.Services.AddUsersModule();

builder.Services.AddSharedFramework(builder.Configuration);
var app = builder.Build();
app.UseSharedFramework();

app.UseCompaniesModule();
app.UseUsersModule();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapFallbackToFile("index.html"); ;

app.Run();
