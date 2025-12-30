# Hafta 10 - Ders Özeti

## Yapılanlar
- Ortak _layout yapısı kurularak Bootstrap navbar, içerik alanı ve footer düzeni tanımlandı; `_ViewStart.cshtml` ile tüm sayfaların bu yerleşimi kullanması sağlandı.
- `AnaController` altında Ekle/Hakkımızda/Personel/Blog/İletişim gibi çoklu sayfa aksiyonları oluşturuldu ve boş View'lerle yönlendirme akışı test edildi.
- Ürün ekleme formu `asp-for` tag helper'larıyla strongly typed hale getirildi ve layout içindeki gezinme linkleri ile ilişkilendirildi.

## Öne Çıkan Kodlar
- `_MainLayout.cshtml` navigasyon ve gövde alanını `@RenderBody()` ile tanımlıyor:  
  ```cshtml
  <nav class="navbar navbar-expand-lg bg-body-tertiary">
      <!-- navbar linkleri -->
  </nav>
  <div>
      @RenderBody()
  </div>
  <div class="row bg-primary">
      Footer kısmı
  </div>
  ```
- `_ViewStart.cshtml` tüm görünümlere aynı layout'u uygular:  
  ```cshtml
  @{ Layout = "~/Views/Layouts/_MainLayout.cshtml"; }
  ```
- `Views/Ana/Ekle.cshtml` formu modelin alanlarına bağlayarak girişleri kolaylaştırır:  
  ```cshtml
  @model Urun
  <form asp-controller="Ana" asp-action="Ekle" method="post">
      <input asp-for="@Model.UrunId" placeholder="Ürün id giriniz..." />
      <input asp-for="@Model.UrunAdi" placeholder="Ürün adı giriniz..." />
      <input asp-for="@Model.UrunAciklama" placeholder="Ürün açıklama giriniz..." />
      <input asp-for="@Model.UrunFiyat" placeholder="Ürün fiyatı giriniz..." />
  </form>
  ```

## Benzer Örnek: Bölümlere Ayrılmış Layout ve Section Kullanımı
- Daha esnek sayfalar için opsiyonel bir banner veya yan menü section'ı eklenebilir:  
  ```cshtml
  <!DOCTYPE html>
  <body>
      <header>@RenderSection("Banner", required: false)</header>
      <main class="container">@RenderBody()</main>
      <footer>@DateTime.Now.Year © Şirket</footer>
  </body>
  ```
- Belirli sayfalar ihtiyaca göre banner'ı doldurur:  
  ```cshtml
  @section Banner {
      <div class="alert alert-info">Kampanya haftası!</div>
  }
  ```
- Böylece Hafta 10'daki ortak layout yaklaşımı, farklı sayfalar için küçük bölüm eklemeleriyle yeniden kullanılabilir hale gelir.
