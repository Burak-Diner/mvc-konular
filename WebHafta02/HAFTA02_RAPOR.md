# Hafta 02 - Ders Özeti

## Yapılanlar
- MVC mimarisine giriş yapılarak denetleyici (Controller), model ve görünüm (View) katmanları oluşturuldu.
- `HomeController` ile temel veri aktarımı ve sayfa yönlendirme, `UrunController` ile model tabanlı listeleme senaryosu gösterildi.
- Uygulamanın yönlendirme şablonu özelleştirilerek varsayılan rota yapısı üzerinde duruldu.

## Öne Çıkan Kodlar
- `WebHafta02/WebHafta02/WebHafta02.Web/Program.cs` içerisinde özel rota tanımı yapıldı:
  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services.AddControllersWithViews();

  var app = builder.Build();
  //app.MapDefaultControllerRoute();
  app.MapControllerRoute("ana-route" ,"{action=Index}/{controller=Home}/{id?}");

  app.Run();
  ```
- `Controllers/HomeController.cs` dosyasında görünümle paylaşılan basit bir hesaplama sonucu ve ikinci sayfa aksiyonu yer alıyor:
  ```csharp
  public class HomeController : Controller
  {
      public IActionResult Index()
      {
          int a = 5;
          int b = 15;
          int sonuc = a * b;
          return View(sonuc);
      }

      public IActionResult BanuYm()
      {
          return View();
      }
  }
  ```
- `Controllers/UrunController.cs` ve `Models/Urun.cs` ile tip güvenli bir ürün listesi oluşturuldu ve `Views/Urun/Listele.cshtml` üzerinden tabloya basıldı:
  ```csharp
  public IActionResult Listele()
  {
      List<Urun> urunListe = new List<Urun>()
      {
          new Urun(1,"Kalem", 100.0),
          new Urun(2, "29' Monitör", 25000.0),
          new Urun(3, "2 tb m2 ssd", 7000.0)
      };
      return View(urunListe);
  }
  ```
  ```cshtml
  @model List<WebHafta02.Web.Models.Urun>
  <table>
      @foreach (var urun in Model)
      {
          <tr>
              <td>@urun.UrunId</td>
              <td>@urun.UrunAdi</td>
              <td>@urun.UrunFiyati</td>
          </tr>
      }
  </table>
  ```
- `Views/Home/Index.cshtml` dosyasında modelden gelen sonuç ve diğer sayfalara bağlantılar gösterildi; Razor sözdizimi ile model kullanımı pekiştirildi.
