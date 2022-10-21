using Base.Modules.Companies.Api;
using Base.Modules.ErrorsLogger.DAL;
using Base.Modules.Users.Api;
using Base.Shared;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCompaniesModule();
builder.Services.AddUsersModule();
builder.Services.AddErrorsLogggerModule();


builder.Services.AddSharedFramework(builder.Configuration);
var app = builder.Build();
app.UseSharedFramework();


app.UseCompaniesModule();
app.UseUsersModule();
app.UseErrorsLogggerModule();


app.MapControllers();
app.Run();


