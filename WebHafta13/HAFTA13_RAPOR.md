# Hafta 13 - Ders Özeti

## Yapılanlar
- Bağımlılık enjeksiyonu (DI) altyapısı tanıtıldı; `Program.cs` içinde `ILog` arayüzüne karşılık `ConsoleLog` servisi `AddTransient` ile kaydedildi.
- Controller ve View Component seviyesinde constructor injection örnekleri gösterildi; `HomeController`, `Kisi` controller'ı ve `BanuViewComponent` aynı log servisini kullanıyor.
- Farklı loglayıcı implementasyonları (`ConsoleLog`, `DbLog`, `TextLog`) ile interface tabanlı geliştirme ve yaşam süresi (transient) kavramları vurgulandı.

## Öne Çıkan Kodlar
- DI kaydı `Program.cs` içinde yapılır:  
  ```csharp
  builder.Services.AddTransient<ILog, ConsoleLog>();
  ```
- Controller'lar log servisini doğrudan ctor'dan alır ve kullanır:  
  ```csharp
  public class HomeController : Controller
  {
      ILog log;
      public HomeController(ILog log) => this.log = log;

      public IActionResult Index()
      {
          log.LogYaz();
          return View();
      }
  }
  ```
- View Component de aynı servisi DI üzerinden tüketir:  
  ```csharp
  public class BanuViewComponent : ViewComponent
  {
      ILog log;
      public BanuViewComponent(ILog log) { this.log = log; }
      public IViewComponentResult Invoke()
      {
          log.LogYaz();
          return View();
      }
  }
  ```
- Alternatif log sağlayıcıları interface'i uygulayarak sistemin değişime açık olmasını sağlar:  
  ```csharp
  public class DbLog : ILog
  {
      public void LogYaz() => Console.WriteLine("Veritabanına Log yazıldı.");
  }
  ```

## Benzer Örnek: Scoped Servis ve Fabrika Kullanımı
- HTTP isteği boyunca tek örnek gereken servisler için scoped kayıt yapılabilir:  
  ```csharp
  builder.Services.AddScoped<ITopluTasima, Metrobus>();
  ```
- Farklı loglayıcıları çalışma anında seçmek için factory pattern uygulanabilir:  
  ```csharp
  builder.Services.AddTransient<Func<string, ILog>>(sp => key => key switch
  {
      "db" => sp.GetRequiredService<DbLog>(),
      "text" => sp.GetRequiredService<TextLog>(),
      _ => sp.GetRequiredService<ConsoleLog>()
  });
  ```
- Böylece Hafta 13'teki DI altyapısı, senaryoya göre servis seçimi veya yaşam süresi değişiklikleriyle genişletilebilir.
