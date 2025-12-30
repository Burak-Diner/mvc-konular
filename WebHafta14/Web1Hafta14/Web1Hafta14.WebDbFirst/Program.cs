using Web1Hafta14.WebDbFirst.DbContext;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<FinalSirketDbContext, FinalSirketDbContext>();
var app = builder.Build();
app.MapDefaultControllerRoute();
//app.MapGet("/", () => "Hello World!");

app.Run();
