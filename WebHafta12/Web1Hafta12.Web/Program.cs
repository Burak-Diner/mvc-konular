using Web1Hafta12.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

//app.UseStaticFiles();
//app.UseAuthorization();
//app.UseAuthentication();

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("1.Middleware baþladý.");
//    await next();
//    Console.WriteLine("1. middleware bitti.");
//});

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("2.Middleware baþladý.");
//    await next();
//    Console.WriteLine("2. middleware bitti.");
//});

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("3.Middleware baþladý.");
//    await next();
//    Console.WriteLine("3. middleware bitti.");
//});

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("4.Middleware baþladý.");
//    await next();
//    Console.WriteLine("4. middleware bitti.");
//});

app.MapControllerRoute("main", "{controller=Home}/{action=Index}/{id?}");


app.UseBanu();

app.Run(async (context) =>
{
    Console.WriteLine("Run çalýþtý.");
});



app.Run();
