# Hafta 05 - Ders Özeti

## Yapılanlar
- Form tabanlı veri girişine geçildi; `UrunController` üzerinden GET/POST aksiyonları ve form gönderimi incelendi.
- `UrunViewModel` ile güçlü tiplenmiş (strongly typed) Razor görünümleri oluşturuldu.
- Yerleşik HTML yardımcıları (`Html.BeginForm`, `Html.TextBox`, `Html.RadioButton`) ve özel yardımcı sınıfı (`BanuHtml`) kullanılarak tekrar eden form bileşenleri sadeleştirildi.

## Öne Çıkan Kodlar
- `Controllers/UrunController.cs` içinde listeleme ve ekleme aksiyonları tanımlandı:
  ```csharp
  public IActionResult Index()
  {
      List<UrunViewModel> liste = new List<UrunViewModel>()
      {
          new UrunViewModel(1,"kalem","kurşun kalem",50.5),
          new UrunViewModel(2,"defter","80 yaprak",100.5),
          new UrunViewModel(3,"silgi","yumuşak",30.5),
          new UrunViewModel(4,"kalemtraş","lapalı kutu",20.5),
      };
      return View(liste);
  }

  [HttpGet]
  public IActionResult Ekle()
  {
      UrunViewModel bosmodel = new UrunViewModel();
      return View(bosmodel);
  }

  [HttpPost]
  public IActionResult Ekle(int id, string adi, string aciklama)
  {
      return View();
  }
  ```
- `Views/Urun/Ekle.cshtml` dosyasında hem sade HTML formu hem de `Html.BeginForm` ile Razor formu kullanılarak farklı gönderim yöntemleri gösterildi. Aynı dosyada özel HTML yardımcısı çağrılıyor:
  ```cshtml
  @using WebHafta05.Web.Helpers
  @Html.BanuTextBox("banutext","banuym","bölüm giriniz")
  ```
- `Helpers/BanuHtml.cs` sınıfı özel bir `BanuTextBox` uzantısı tanımlayarak standart TextBox'a stil ve placeholder gibi özellikleri tek satırda eklemeyi sağladı:
  ```csharp
  public static IHtmlContent BanuTextBox(this IHtmlHelper helper, string name, string value, string placeholder)
  {
      return helper.TextBox(name, value, new
      {
          placeholder = placeholder,
          style = "background-color:green; color:white;",
          @class = "form-control"
      });
  }
  ```
- `Views/Urun/Index.cshtml` modelden gelen ürün listesini tablo halinde çizerek strongly typed Razor görünümü tekrar etti.
- `Program.cs` tarafında varsayılan rota `{controller=Ana}/{action=Index}/{id?}` olarak belirlendi ve ana sayfadan ürün listesine `Url.Action` ile yönlendirme yapıldı.

## Benzer Örnek: Strongly Typed Form ve Özel Helper
- Form senaryolarında model doğrulamasını kolaylaştırmak için `EditorFor` ve özel HTML helper birlikte kullanılabilir. Örnek senaryoda sepet talebi alınıyor ve sık kullanılan alanlar için `SepetHtml` yardımcı metodu yazılıyor.
  ```csharp
  public class SepetController : Controller
  {
      [HttpGet]
      public IActionResult Olustur() => View(new SiparisViewModel());

      [HttpPost]
      public IActionResult Olustur(SiparisViewModel model)
      {
          if (!ModelState.IsValid)
          {
              return View(model);
          }

          // Kayıt işlemleri...
          ViewBag.Mesaj = $"{model.MusteriAdi} siparişi kaydedildi.";
          return View("Tesekkur");
      }
  }

  public class SiparisViewModel
  {
      [Required]
      public string MusteriAdi { get; set; }

      [Range(1, 10)]
      public int Adet { get; set; }

      public string Notlar { get; set; }
  }

  public static class SepetHtml
  {
      public static IHtmlContent LabelVeEditorFor<TModel, TValue>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> ifade)
      {
          var label = helper.LabelFor(ifade, new { @class = "form-label" });
          var editor = helper.EditorFor(ifade, new { htmlAttributes = new { @class = "form-control" } });
          return new HtmlContentBuilder().AppendHtml(label).AppendHtml(editor);
      }
  }
  ```
  ```cshtml
  @model SiparisViewModel
  @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
  @using WebHafta05.Web.Helpers

  <form asp-action="Olustur" method="post">
      @Html.LabelVeEditorFor(m => m.MusteriAdi)
      @Html.LabelVeEditorFor(m => m.Adet)
      <label asp-for="Notlar" class="form-label"></label>
      <textarea asp-for="Notlar" class="form-control"></textarea>
      <button type="submit" class="btn btn-primary">Kaydet</button>
  </form>
  ```
- Yardımcı metot label ve editor bileşenlerini tek seferde üreterek kod tekrarını azaltır. `EditorFor` model meta verisinden yararlanıp doğrulama mesajlarını otomatik bağlar. Böylece form oluşturma mantığının yeniden kullanılabilir yapılarla nasıl zenginleştirilebileceği ortaya konur.
