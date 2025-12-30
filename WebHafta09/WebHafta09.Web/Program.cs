using FluentValidation;
using FluentValidation.AspNetCore;
using WebHafta09.Web.Models.Validators;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddValidatorsFromAssemblyContaining<KullaniciValidator>(); // register validators
//builder.Services.AddFluentValidationAutoValidation(); // the same old MVC pipeline behavior
builder.Services.AddFluentValidationClientsideAdapters(); // for client side

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles(new StaticFileOptions()
{
    RequestPath = "/wwwroot",
    
});

//app.UseStaticFiles("/wwwroot");

app.MapControllerRoute("main", "{controller=Ana}/{action=Index}/{id?}");

app.Run();
