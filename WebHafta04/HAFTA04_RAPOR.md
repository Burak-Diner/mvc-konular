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
