# Hafta 07 - Ders Özeti

## Yapılanlar
- HTTP isteğinden gelen farklı veri kaynakları incelendi: query string, route değerleri ve header içerikleri `Request` nesnesi üzerinden okundu.
- Model binding'in tuple yapılarıyla nasıl çalıştığı gösterildi; `[Bind(Prefix="Item1")]` ve `[Bind(Prefix="Item2")]` kullanılarak iki ayrı model tek POST aksiyonunda toplandı.
- `HaftalikOzet` modeliyle önceki haftaların konusu, kazanımları ve proje yolu tek koleksiyonda derlenerek View'e gönderildi.

## Öne Çıkan Kodlar
- Query string parametrelerini almak ve doğrudan modele bağlamak için `QueryStringAction` kullanılıyor:  
  ```csharp
  public IActionResult QueryStringAction(Ara a)
  {
      var queryStringler = Request.QueryString;
      foreach (var item in Request.Query.Keys)
      {
          var key = item;
          var value = Request.Query[key];
      }
      return View(a);
  }
  ```
- Tuple model binding ile iki farklı tip tek formdan alınabiliyor. `Bind` önekiyle tuple'ın elemanları çözümleniyor:  
  ```csharp
  public IActionResult TuppleVeri()
  {
      (Kullanici k, Urun u) tupple = (kullanici, urun);
      return View(tupple);
  }

  [HttpPost]
  public IActionResult TuppleVeri([Bind(Prefix = "Item2")] Urun u,
                                  [Bind(Prefix = "Item1")] Kullanici k)
  {
      return View();
  }
  ```
- Haftalık kazanımlar listeye çevrilip sıralanıyor ve View'e aktarılıyor:  
  ```csharp
  var ozetler = new List<HaftaOzeti>()
  {
      new HaftaOzeti(1, "ASP.NET Core'a Başlangıç", "...", new []{"WebApplication builder"}, "WebHafta01/WebHafta01/WebHafta01.Web"),
      // ...
      new HaftaOzeti(7, "HTTP İstek Verileri", "Query string, route ve header verilerini inceleme", new []{"Request üzerinden QueryString"}, "WebHafta07/WebHafta07/WebHafta07.Web")
  };

  var siraliOzetler = ozetler.OrderBy(o => o.HaftaNo).ToList();
  return View(siraliOzetler);
  ```

## Benzer Örnek: Cookie ve Query Birlikte Okuma
- Çok kaynaklı veri okumayı genişletmek için cookie ve query bilgisini aynı aksiyonda birleştirebilirsiniz:  
  ```csharp
  public IActionResult FiltreliArama([FromQuery] Ara arama)
  {
      var sonZiyaret = Request.Cookies["last-visit"];
      var userAgent = Request.Headers.UserAgent.ToString();

      ViewBag.Ziyaret = sonZiyaret;
      ViewBag.Tarayıcı = userAgent;
      return View(arama);
  }
  ```
- Bu yaklaşım, haftanın örneğinde gösterilen QueryString/Route/Header okuma modelini genişleterek kullanıcıya ait bağlamsal bilgileri (tarayıcı, son ziyaret) arama modeline eklemeyi sağlar; aynı pattern farklı veri kaynaklarını `Request` üstünden toplamak için yeniden kullanılabilir.
