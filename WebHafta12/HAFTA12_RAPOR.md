# Hafta 12 - Ders Özeti

## Yapılanlar
- Middleware kavramı tanıtıldı; isteğin başında ve sonunda çalışan özel `BanuMiddleware` yazıldı.
- Middleware'ı kolayca eklemek için `UseBanu` uzantı metodu oluşturuldu ve `Program.cs` pipeline'ına eklendi.
- Standart `UseStaticFiles`, `UseAuthentication` gibi middleware örnekleri üzerinde duruldu; sıralamanın önemine dikkat çekildi.

## Öne Çıkan Kodlar
- Özel middleware istek akışında mesaj yazıp sonraki delegeleri çağırıyor:  
  ```csharp
  public class BanuMiddleware
  {
      public RequestDelegate _next;
      public BanuMiddleware(RequestDelegate next) => _next = next;

      public async Task Invoke(HttpContext context)
      {
          Console.WriteLine("BANÜ Middleware başladı.");
          await _next(context);
          Console.WriteLine("BANÜ middleware bitti.");
      }
  }
  ```
- `UseBanu` uzantısı ile middleware uygulamaya ekleniyor:  
  ```csharp
  public static IApplicationBuilder UseBanu(this IApplicationBuilder builder)
      => builder.UseMiddleware<BanuMiddleware>();
  ```
- Pipeline kurulumu `Program.cs`'te yapılıyor:  
  ```csharp
  builder.Services.AddControllersWithViews();
  var app = builder.Build();
  app.MapControllerRoute("main", "{controller=Home}/{action=Index}/{id?}");
  app.UseBanu();
  ```

## Benzer Örnek: Zaman Ölçen Middleware
- İstek süresini ölçmek için hafif bir ölçüm middleware'ı eklenebilir:  
  ```csharp
  public class SureOlcerMiddleware
  {
      private readonly RequestDelegate _next;
      public SureOlcerMiddleware(RequestDelegate next) => _next = next;

      public async Task Invoke(HttpContext context)
      {
          var basla = Stopwatch.GetTimestamp();
          await _next(context);
          var sureMs = (Stopwatch.GetTimestamp() - basla) * 1000.0 / Stopwatch.Frequency;
          Console.WriteLine($"{context.Request.Path} {sureMs:F1} ms sürdü");
      }
  }
  ```
- `UseBanu` sonrası `app.UseMiddleware<SureOlcerMiddleware>();` eklenerek pipeline genişletilir; böylece Hafta 12'deki middleware zinciri gerçek performans izleme senaryosuna uyarlanmış olur.
