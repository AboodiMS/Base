using Base.Modules.Companies.Api;
using Base.Modules.Users.Api;
using Base.Shared;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddCompaniesModule();
builder.Services.AddUsersModule();


builder.Services.AddSharedFramework(builder.Configuration);
var app = builder.Build();
app.UseSharedFramework();


app.UseCompaniesModule();
app.UseUsersModule();



//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}/{action=Index}/{id?}");

//app.MapFallbackToFile("index.html"); 

app.MapControllers();
app.Run();


