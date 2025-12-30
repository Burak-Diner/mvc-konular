# Hafta 09 - Ders Özeti

## Yapılanlar
- FluentValidation kütüphanesi projeye eklendi ve `KullaniciValidator` ile model alanları için detaylı kurallar oluşturuldu.
- Doğrulama kuralları otomatik olarak pipeline'a eklendi (`AddValidatorsFromAssemblyContaining`), böylece `ModelState.IsValid` kontrolü ile server-side doğrulama tetiklendi.
- `Views/Kullanici/Ekle.cshtml` formunda tag helper'lar ve `asp-validation-for`/`asp-validation-summary` ile client-side doğrulama mesajları gösterildi; jQuery unobtrusive scriptleri statik dosya olarak yüklendi.

## Öne Çıkan Kodlar
- Program başlatılırken validator taraması ve client-side adaptör kaydı yapılıyor:  
  ```csharp
  builder.Services.AddValidatorsFromAssemblyContaining<KullaniciValidator>();
  builder.Services.AddFluentValidationClientsideAdapters();
  builder.Services.AddControllersWithViews();
  ```
- `KullaniciValidator` sınıfı tüm alanlar için boş bırakmama, uzunluk ve email formatı kontrolleri yapıyor:  
  ```csharp
  RuleFor(a => a.KullaniciAdi)
      .NotNull().NotEmpty().MinimumLength(5).MaximumLength(15);
  RuleFor(a => a.KullaniciSoyadi)
      .NotNull().NotEmpty().MinimumLength(5).MaximumLength(15);
  RuleFor(a => a.KullaniciEmail)
      .NotNull().NotEmpty().EmailAddress()
      .MinimumLength(5).MaximumLength(15);
  ```
- Form gönderimi sonrasında `ModelState.IsValid` ile kurallar kontrol ediliyor ve kullanıcıya geri bildirim veriliyor:  
  ```csharp
  [HttpPost]
  public IActionResult Ekle(Kullanici model)
  {
      ViewBag.Message = ModelState.IsValid
          ? "Kullanici eklendi."
          : "Kullanici eklenirken hata oluştu.";
      return View(model);
  }
  ```
- Razor formu tag helper'lar ile modellendi; validation özetleri ve alan bazlı mesajlar aynı anda çiziliyor:  
  ```cshtml
  <div asp-validation-summary="All"></div>
  <form asp-action="Ekle" asp-controller="Kullanici" method="post">
      <input asp-for="@Model.KullaniciAdi" />
      <span asp-validation-for="@Model.KullaniciAdi"></span>
      <!-- diğer alanlar -->
  </form>
  ```

## Benzer Örnek: Çoklu Model Doğrulama ve Şarta Bağlı Kurallar
- Parola onayı veya yaş sınırı gibi ek kuralları göstermek için yeni bir validator yazılabilir:  
  ```csharp
  public class KayitValidator : AbstractValidator<KayitModel>
  {
      public KayitValidator()
      {
          RuleFor(k => k.Parola)
              .NotEmpty()
              .MinimumLength(8)
              .Matches("[A-Z]").WithMessage("En az bir büyük harf olmalı");

          RuleFor(k => k.ParolaTekrar)
              .Equal(k => k.Parola).WithMessage("Parolalar eşleşmiyor");

          RuleFor(k => k.DogumTarihi)
              .Must(dt => dt <= DateTime.Today.AddYears(-18))
              .WithMessage("18 yaşından küçükler kayıt olamaz.");
      }
  }
  ```
- Controller tarafında `KayitModel` kullanıldığında mevcut FluentValidation entegrasyonu otomatik devreye girer; böylece Hafta 09'daki doğrulama akışı ek iş yapmadan farklı modeller için de genişletilmiş olur.
