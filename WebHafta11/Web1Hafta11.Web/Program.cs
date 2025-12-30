var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions()
{
	RequestPath	="/wwwroot"
});

app.MapControllerRoute("yonetim", "BANU-Yonetim/{action=Index}/{id?}");
app.MapControllerRoute("main", "{controller=Home}/{action=Index}/{id?}");


app.Run();
