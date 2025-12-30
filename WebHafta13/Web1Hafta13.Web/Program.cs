using Web1Hafta13.Web.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ILog, ConsoleLog>();



var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
