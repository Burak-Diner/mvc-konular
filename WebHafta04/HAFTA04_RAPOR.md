# Hafta 04 - Ders Özeti

## Yapılanlar
- MVC'de veri taşıma yaklaşımları karşılaştırıldı: doğrudan model gönderimi, `ViewBag`, `ViewData` ve `TempData`.
- `KullaniciController` üzerinden farklı kaynaklardan gelen verileri aynı görünümde nasıl kullanabileceğimiz gösterildi.
- Listelerin JSON'a serileştirilip `TempData` aracılığıyla taşınması ve Razor tarafında tekrar nesne listesine dönüştürülmesi uygulandı.

## Öne Çıkan Kodlar
- `Controllers/KullaniciController.cs` dosyası veri taşıma tekniklerinin tamamını örnekliyor:
  ```csharp
  public IActionResult Listele()
  {
      List<Kullanici> liste = new List<Kullanici>()
      {
          new Kullanici(1, "BANUYM", "ym@bandirma.edu.tr","123456"),
          new Kullanici(2, "BANUMF", "mf@bandirma.edu.tr","465453245"),
          new Kullanici(3, "BANU", "info@bandirma.edu.tr","87987"),
          new Kullanici(4, "Bandırma", "bnd@bandirma.edu.tr","0425567"),
      };

      string jsonListe = JsonSerializer.Serialize(liste);

      ViewBag.KulListe = liste;
      ViewData["KulListe"] = liste;
      TempData["KulListe"] = jsonListe;

      return View(liste);
  }
  ```
- `Views/Kullanici/Listele.cshtml` Razor dosyası dört farklı kaynaktan gelen aynı veriyi tablolar halinde yan yana gösteriyor:
  ```cshtml
  @model List<Kullanici>
  <table>
      @foreach(var k in Model){ ... }
  </table>
  <table>
      @foreach (var k in ViewBag.KulListe) { ... }
  </table>
  <table>
      @foreach (var k in (List<Kullanici>)ViewData["KulListe"]) { ... }
  </table>
  <table>
      @foreach (var k in JsonSerializer.Deserialize<List<Kullanici>>((string)TempData["KulListe"])) { ... }
  </table>
  ```
- `Views/Kullanici/Index.cshtml`, `ViewBagKullanici.cshtml`, `ViewDataKullanici.cshtml` ve `TempDataKullanici.cshtml` sayfaları veri taşıma türleri arasındaki farkları tekil örneklerle pekiştirdi.
- `Models/Kullanici.cs` sınıfı ortak veri yapısını sağlayarak kod tekrarını azaltan basit bir POCO (Plain Old CLR Object) olarak kullanıldı.

## Benzer Örnek: TempData ile Bildirim Gösterme
- `TempData` kısa süreli mesajlar için idealdir. Aşağıdaki senaryoda form gönderildikten sonra kullanıcıyı bilgilendiren bir bildirim `TempData` üzerinden sonraki aksiyona taşınıyor.
  ```csharp
  public class HesapController : Controller
  {
      [HttpPost]
      public IActionResult Kaydet(HesapViewModel model)
      {
          // Kayıt işlemleri...
          TempData["BildirimMesaji"] = $"{model.Ad} hesabı başarıyla oluşturuldu.";
          TempData["BildirimTuru"] = "success";
          return RedirectToAction(nameof(Sonuc));
      }

      public IActionResult Sonuc()
      {
          ViewBag.Mesaj = TempData["BildirimMesaji"];
          ViewBag.Tur = TempData["BildirimTuru"] ?? "info";
          return View();
      }
  }

  public record HesapViewModel(string Ad, string Eposta);
  ```
  ```cshtml
  @* Views/Hesap/Sonuc.cshtml *@
  @if (ViewBag.Mesaj is not null)
  {
      <div class="alert alert-@ViewBag.Tur">
          @ViewBag.Mesaj
      </div>
  }
  else
  {
      <p>Gösterilecek bir bildirim bulunamadı.</p>
  }
  ```
- `Kaydet` aksiyonu işlemi tamamladıktan sonra `TempData` anahtarlarına mesaj ve tür bilgisini yazar. Yönlendirme sonucu tetiklenen `Sonuc` aksiyonu aynı veriyi okuyup ViewBag'e aktarır. Razor tarafında koşullu blok ile mesaj varsa gösterilir, yoksa alternatif içerik sunulur. Böylece `TempData` kullanarak tek seferlik bildirimlerin nasıl yönetileceği ve çalışma mantığı vurgulanır.
