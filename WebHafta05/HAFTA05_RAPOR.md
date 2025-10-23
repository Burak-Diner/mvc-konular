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
