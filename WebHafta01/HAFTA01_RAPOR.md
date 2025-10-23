# Hafta 01 - Ders Özeti

## Yapılanlar
- İlk MVC dersinde proje iskeleti oluşturuldu ve uygulama `Program.cs` üzerinden Minimal API yaklaşımıyla ayağa kaldırıldı.
- MVC servisleri eklendi ancak henüz denetleyici ve görünüm katmanı kullanılmadı; amaç .NET 8 web uygulamasının temel yaşam döngüsünü görmekti.

## Öne Çıkan Kodlar
- `WebHafta01/WebHafta01/WebHafta01.Web/Program.cs` dosyasında uygulama başlatılıyor ve kök adrese basit bir yanıt döndürülüyor:
  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services.AddControllersWithViews();

  var app = builder.Build();
  app.MapGet("/", () => "Hello World!");
  app.Run();
  ```
- Bu haftanın sonunda tarayıcıdan `/` adresine gidildiğinde "Hello World!" mesajı görülerek projenin çalıştığı doğrulandı.
