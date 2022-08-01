using Base.Modules.Companies.Api;
using Base.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCompaniesModule();
builder.Services.AddSharedFramework(builder.Configuration);



var app = builder.Build();

app.UseSharedFramework();
app.UseCompaniesModule();


//app.MapGet("/", () => "Hello World!");


app.MapControllers();
app.Run();


