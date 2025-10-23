var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();
//app.MapDefaultControllerRoute();
app.MapControllerRoute("ana-route" ,"{action=Index}/{controller=Home}/{id?}");

app.Run();
