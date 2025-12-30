var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.MapControllerRoute("main", "{controller=AnaSayfa}/{action=Index}/{id?}");
//app.MapGet("/", () => "Hello World!");

app.Run();



//Server=MUH13NOLUDERSLI;Database=ETicaretDb;Trusted_Connection=True;TrustServerCertificate=True;


//Scaffold-DbContext "connectionstring" -OutputDir ModelKlasörüYolu -ContextDir DbContextYolu

// add-migration ilkMigration
//update-database