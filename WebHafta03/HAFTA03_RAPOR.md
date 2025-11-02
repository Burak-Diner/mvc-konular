# Hafta 03 - Ders Özeti

## Yapılanlar
- Denetleyici öznitelikleri (`[NonController]`, `[NonAction]`) ve aksiyon sonuç türleri (ViewResult, PartialViewResult, JsonResult, ContentResult, EmptyResult, ViewComponentResult) tanıtıldı.
- `AnaSayfaController` üzerinden aksiyonların nasıl sınırlandırılabileceği gösterilirken, `ResultsController` ile farklı dönüş tipleri örneklendirildi.
- `Urun` modelinden yararlanarak JSON dönüşünde tip güvenliği sağlandı.

## Öne Çıkan Kodlar
- `Controllers/AnaSayfaController.cs` dosyasında controller'ın dışarıya kapatılması ve yardımcı metodun `[NonAction]` olarak işaretlenmesi gösterildi:
  ```csharp
  [NonController]
  public class AnaSayfaController : Controller
  {
      public IActionResult Index()
      {
          int sonuc = Topla(2, 3);
          return View(sonuc);
      }

      [NonAction]
      public int Topla(int s1, int s2)
      {
          return s1 + s2;
      }
  }
  ```
- `Controllers/ResultsController.cs` içerisinde farklı Result tipleri birer aksiyon olarak sunuldu:
  ```csharp
  public JsonResult JsonResultSayfa()
  {
      Urun u = new Urun()
      {
          Id = 1,
          UrunAdi = "Monitör",
          UrunFiyati = 19999.99
      };
      return Json(u);
  }

  public IActionResult SecimliResult(int id)
  {
      switch (id)
      {
          case 1:
              return View();
          case 2:
              return PartialView();
          case 3:
              return Json("{id:5}");
          case 4:
              return Content("BANÜ YM");
          case 5:
              return new EmptyResult();
          case 6:
              return ViewComponent("");
          default:
              return View();
      }
  }
  ```
- `Views/AnaSayfa/Index.cshtml` dosyasında `Topla` metodundan gelen sonuç görüntülendi; böylece controller içi yardımcı metodun View modeline nasıl aktarıldığı pekiştirildi.
- `Program.cs` tarafında rota `{controller=AnaSayfa}/{action=Index}/{id?}` olarak ayarlanarak sonuçların test edilmesi kolaylaştırıldı.

## Benzer Örnek: Dosya ve Yönlendirme Sonuçları
- Result tipleri kullanıcıya farklı yanıtlar dönmek için güçlü araçlardır. Aşağıdaki örnek, rapor isteğini parametreye göre dosya indirme, başka aksiyona yönlendirme veya JSON cevap olarak döndürür.
  ```csharp
  public class RaporController : Controller
  {
      public IActionResult Indir(int tip)
      {
          return tip switch
          {
              1 => File(System.IO.File.ReadAllBytes("wwwroot/rapor.pdf"), "application/pdf", "aylik-rapor.pdf"),
              2 => RedirectToAction("Index", "Dashboard"),
              3 => Json(new { Durum = "Hazırlanıyor", TahminiSaniye = 25 }),
              _ => Content("Geçersiz rapor talebi", "text/plain")
          };
      }
  }
  ```
- `File` sonucu istemciye ikili veri aktarırken `RedirectToAction` tarayıcıyı yeni bir aksiyona yönlendirir. JSON ve `Content` sonuçları ise API benzeri geri dönüşler sağlar. Böylece tek aksiyon içinde senaryoya göre uygun cevap türünü seçebilmenin mantığı görülür.
