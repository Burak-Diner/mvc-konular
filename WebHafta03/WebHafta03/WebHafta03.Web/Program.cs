var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


var app = builder.Build();
app.MapControllerRoute("main", "{controller=AnaSayfa}/{action=Index}/{id?}");

app.Run();
