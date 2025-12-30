var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

StaticFileOptions sfo = new StaticFileOptions();
sfo.RequestPath = "/wwwroot";
app.UseStaticFiles(sfo);

app.UseStaticFiles(new StaticFileOptions()
{
	RequestPath = "/wwwroot"
});


app.MapControllerRoute("main", "{controller=Ana}/{action=Index}/{id?}");
app.Run();
