using Base.Modules.Companies.Api;
using Base.Modules.Users.Api;
using Base.Shared;
using Base.Shared.Helper101;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
//using InstitutionManagement.Api;

var builder = WebApplication.CreateBuilder(args);


await Firebase.SendMessageToPhonNumberAsync("+9647506865425", "123456");


builder.Services.AddCompaniesModule();
builder.Services.AddUsersModule();
//builder.Services.AddInstitutionManagementModule();

builder.Services.AddSharedFramework(builder.Configuration);
var app = builder.Build();
app.UseSharedFramework();


app.UseCompaniesModule();
app.UseUsersModule();
//app.UseInstitutionManagementModule();


app.MapControllers();
app.Run();


