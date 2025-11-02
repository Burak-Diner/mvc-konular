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

## Benzer Örnek: Alternatif Rota ve ViewModel Kullanımı
- MVC rotaları farklı varsayılan controller/action ikilileriyle genişletilebilir. Aşağıdaki örnekte `KategoriController` için özel bir rota tanımlanıyor ve kategori listesi tip güvenli bir görünümle sunuluyor.
  ```csharp
  // Program.cs
  app.MapControllerRoute(
      name: "kategori",
      pattern: "kategoriler/{action=Liste}",
      defaults: new { controller = "Kategori" });
  ```
  ```csharp
  public class KategoriController : Controller
  {
      public IActionResult Liste()
      {
          var kategoriler = new List<KategoriViewModel>
          {
              new(1, "Elektronik", 12),
              new(2, "Kitap", 34),
              new(3, "Ev Yaşam", 9)
          };
          return View(kategoriler);
      }
  }

  public record KategoriViewModel(int Id, string Ad, int UrunAdedi);
  ```
  ```cshtml
  @model IEnumerable<KategoriViewModel>
  <h2>Kategori Listesi</h2>
  <ul>
      @foreach (var kategori in Model)
      {
          <li>@kategori.Ad (@kategori.UrunAdedi ürün)</li>
      }
  </ul>
  ```
- Rota kalıbı `/kategoriler` isteğini doğrudan `KategoriController.Liste` aksiyonuna düşürür. View tarafında `record` tipinden gelen model kullanılarak Razor ile kolayca liste oluşturulur. Böylece MVC katmanları arasındaki veri akışı ve rota özelleştirmesi pekiştirilmiş olur.
