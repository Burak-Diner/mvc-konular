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

## Benzer Örnek: Parametreli Minimal API
- Aynı yaklaşım farklı URL segmentleriyle dinamik içerik döndürmek için kullanılabilir. Aşağıdaki örnekte kullanıcının adını rota parametresi olarak alıp kişiselleştirilmiş mesaj üretildi.
  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  var app = builder.Build();

  app.MapGet("/selam/{ad}", (string ad) => $"Merhaba {ad}, MVC dünyasına hoş geldin!");
  app.MapGet("/toplam/{s1:int}/{s2:int}", (int s1, int s2) => new { Sonuc = s1 + s2 });

  app.Run();
  ```
- `MapGet` çağrıları rota kalıplarıyla eşleşen HTTP GET isteklerini yakalar. İlk rota string parametre alırken ikinci rota `int` kısıtlaması sayesinde yalnızca sayısal değerleri kabul eder ve JSON sonuç döndürür. Böylece Minimal API yaklaşımıyla hızlı prototipler geliştirilebilir, daha sonra ihtiyaç olduğunda MVC katmanları eklenebilir.
