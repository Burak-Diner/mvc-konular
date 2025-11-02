# Hafta 06 - Ders Özeti

## Yapılanlar
- `AnaController` içinde statik ürün listesiyle CRUD akışının temel adımları (listeleme, ekleme, düzenleme, silme) gerçekleştirildi.
- Razor formlarında `asp-for` tag helper'ları kullanılarak model binding otomatik hale getirildi; POST aksiyonlarında `UrunViewModel` nesnesi doğrudan alındı.
- `Views/Ana/Index.cshtml` sayfasında `Html.BeginForm`, `cache` tag helper'ı, `environment` koşulları, partial view çağrısı ve özel `logo` tag helper bir arada kullanılarak Razor ekosisteminin farklı bileşenleri gösterildi.
- `TagHelpers/LogoTagHelper.cs` ile parametreye göre farklı görselleri seçen özel bir tag helper geliştirildi.

## Öne Çıkan Kodlar
- `Controllers/AnaController.cs` CRUD aksiyonlarını tek çatı altında topluyor:
  ```csharp
  static List<UrunViewModel> _UrunListe = new List<UrunViewModel>()
  {
      new UrunViewModel(1,"29' Monitör",49999.99),
      new UrunViewModel(2,"16gb RAM",24999.99),
      new UrunViewModel(3,"i9-13900h İşlemci",69999.99),
      new UrunViewModel(4,"Kablosuz Klavye",19999.99),
      new UrunViewModel(5,"Kablosuz Mouse",9999.99)
  };

  public IActionResult Listele() => View(_UrunListe);

  [HttpPost]
  public IActionResult Ekle(UrunViewModel urun)
  {
      _UrunListe.Add(urun);
      return View(urun);
  }

  [HttpPost]
  public IActionResult Duzenle(UrunViewModel urun)
  {
      UrunViewModel duzenlenenUrun = _UrunListe.FirstOrDefault(a => a.UrunId == urun.UrunId);
      duzenlenenUrun.UrunAdi = urun.UrunAdi;
      duzenlenenUrun.UrunFiyat = urun.UrunFiyat;
      return View(duzenlenenUrun);
  }
  ```
- `Views/Ana/Listele.cshtml` ürünleri tablo halinde sunuyor ve düzenleme/silme bağlantıları için `asp-route-id` kullanıyor:
  ```cshtml
  @model List<Hafta06.Web.Models.UrunViewModel>
  <table width="600" border="1">
      <thead>
          <tr>
              <th colspan="4" style="text-align:right">
                  <a asp-controller="Ana" asp-action="Ekle">Yeni Ürün Ekle</a>
              </th>
          </tr>
          <tr>
              <th>Id</th>
              <th>Adı</th>
              <th>Fiyatı</th>
              <th></th>
          </tr>
      </thead>
      <tbody>
          @foreach (var item in Model)
          {
              <tr>
                  <td>@item.UrunId</td>
                  <td>@item.UrunAdi</td>
                  <td>@item.UrunFiyat</td>
                  <td>
                      <a asp-controller="Ana" asp-action="Duzenle" asp-route-id=@item.UrunId>Düzenle</a> |
                      <a asp-controller="Ana" asp-action="Sil" asp-route-id=@item.UrunId>Sil</a>
                  </td>
              </tr>
          }
      </tbody>
  </table>
  ```
- `TagHelpers/LogoTagHelper.cs` parametreye göre kaynak atayan özel helper örneği sunuyor:
  ```csharp
  public class LogoTagHelper : TagHelper
  {
      public bool Renkli { get; set; }

      public override void Process(TagHelperContext context, TagHelperOutput output)
      {
          output.TagName = "img";
          if (Renkli)
          {
              output.Attributes.Add("src", "/wwwroot/images/renklilogo.png");
              output.Attributes.Add("alt", "RenkliLogo");
          }
          else
          {
              output.Attributes.Add("src", "/wwwroot/images/siyahbeyazlogo.png");
              output.Attributes.Add("alt", "SiyahBeyazLogo");
          }
          output.Attributes.Add("class", "img-logo");
          base.Process(context, output);
      }
  }
  ```

## Benzer Örnek: Kart Tag Helper ve Partial Kullanımı
- CRUD ekranlarını zenginleştirmek için farklı partial'lar ve tag helper'lar oluşturulabilir. Örneğin ürün kartı üreten bir helper ile liste görsel olarak güçlendirilebilir.
  ```csharp
  public class KartTagHelper : TagHelper
  {
      public string Baslik { get; set; }
      public string Aciklama { get; set; }
      public decimal Fiyat { get; set; }

      public override void Process(TagHelperContext context, TagHelperOutput output)
      {
          output.TagName = "div";
          output.Attributes.Add("class", "urun-karti");
          output.Content.SetHtmlContent($"<h3>{Baslik}</h3><p>{Aciklama}</p><strong>{Fiyat:C2}</strong>");
      }
  }
  ```
  ```cshtml
  @* Views/Urun/Partials/UrunKarti.cshtml *@
  @model UrunViewModel
  <kart baslik="@Model.UrunAdi" aciklama="Güncel stok ürünü" fiyat="@Model.UrunFiyat"></kart>
  ```
  ```cshtml
  @* Liste görünümünde kullanım *@
  @foreach (var urun in Model)
  {
      @Html.Partial("~/Views/Urun/Partials/UrunKarti.cshtml", urun)
  }
  ```
- `KartTagHelper` HTML çıktı üretirken Razor partial'ı her ürün için helper'ı çağırır. Bu yapı Tag Helper ile tekrar kullanılabilir UI bileşenleri oluşturmanın mantığını gösterir; partial ise helper'a model sağlayarak çalışma şeklini tamamlar. Böylece Hafta 06'da görülen `logo` helper ve partial kullanımının farklı bir varyasyonu ortaya çıkmış olur.
