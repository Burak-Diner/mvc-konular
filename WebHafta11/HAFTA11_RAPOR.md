# Hafta 11 - Ders Özeti

## Yapılanlar
- Attribute routing ile yönetim paneli için özel bir yol tanımlandı (`[Route("BANU-Yonetim")]`) ve `Program.cs` içinde ayrı rota kaydı oluşturuldu.
- Bootstrap'li `_Layout.cshtml` dosyasında section tabanlı iki kolonlu bir sayfa iskeleti (SolMenu + RenderBody) oluşturuldu.
- `KullaniciViewComponent` ile View Component yapısı tanıtıldı; komponent `Home/Index` sayfasında çağrılarak kullanıcı bilgisini dinamik olarak çizdi.

## Öne Çıkan Kodlar
- Yönetim rotası hem attribute hem de RouteMap ile destekleniyor:  
  ```csharp
  [Route("BANU-Yonetim")]
  public class YonetimController : Controller { ... }
  
  app.MapControllerRoute("yonetim", "BANU-Yonetim/{action=Index}/{id?}");
  ```
- Layout dosyası RenderSection ile yan menü alanı açıyor:  
  ```cshtml
  <div class="row">
      <div class="col-md-4 bg-primary">@RenderSection("SolMenu", false)</div>
      <div class="col-md-8 bg-warning">@RenderBody()</div>
  </div>
  ```
- View Component, `InvokeAsync` içinde model hazırlayıp kendi View'ini döndürüyor:  
  ```csharp
  public class KullaniciViewComponent : ViewComponent
  {
      public IViewComponentResult InvokeAsync()
      {
          List<Kullanici> liste = new() { new Kullanici { KullaniciAdi="Banu", ... } };
          return View(liste);
      }
  }
  ```
- Ana sayfada komponent çağrısı:  
  ```cshtml
  @await Component.InvokeAsync("Kullanici")
  ```

## Benzer Örnek: İstatistik View Component ve Özel Route
- Dashboard için günlük istatistikleri gösteren bir komponent yazılabilir:  
  ```csharp
  public class IstatistikViewComponent : ViewComponent
  {
      private readonly IRaporServisi _rapor;
      public IstatistikViewComponent(IRaporServisi rapor) => _rapor = rapor;

      public IViewComponentResult Invoke()
      {
          var model = _rapor.GunlukOzetGetir();
          return View(model);
      }
  }
  ```
- Yönetim alanı için farklı prefix'ler vermek Route attribute ile kolaydır:  
  ```csharp
  [Route("Yonetim/{controller=Panel}/{action=Index}/{id?}")]
  public class PanelController : Controller { }
  ```
- Bu sayede Hafta 11'deki View Component ve routing yaklaşımı, gerçek bir dashboard/istatistik senaryosuna taşınarak tekrar kullanılabilir.
