using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebHafta07.Web.Models;

namespace WebHafta07.Web.Controllers
{
    
    public class AnaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult QueryStringAction(Ara a)
        {
            //if(a is null)
            //    a= new Ara();

            var queryStringler = Request.QueryString;


            foreach(var item in Request.Query.Keys)
            {
                var key = item;
                var value = Request.Query[key];
            }

            return View(a);
        }

        public IActionResult RouteValues(int id)
        {
            var routes = Request.RouteValues;

            foreach(var route in routes)
            {
                var key = route.Key;
                var value= route.Value;
            }

            return View();
        }

        public IActionResult HeaderValues()
        {
            var headers = Request.Headers;

            List<string> liste = new List<string>();
            foreach(var header in headers)
            {
                var key = header.Key;
                var value = header.Value;
            }

            return View();
        }


        public IActionResult TuppleVeri()
        {
            Kullanici kullanici = new Kullanici()
            {
                KullaniciId = 1,
                KullaniciAdi = "Banu-Yazilim",
                KullaniciMail = "yazilim@bandirma.edu.tr"
            };

            Urun urun = new Urun()
            {
                UrunId = 5,
                UrunAdi = "Ram",
                UrunFiyat = 5000.0

            };

            (Kullanici k, Urun u) tupple = (kullanici, urun);
            return View(tupple);
        }
        [HttpPost]
        public IActionResult TuppleVeri([Bind(Prefix ="Item2")]Urun u, [Bind(Prefix = "Item1")] Kullanici k)
        {
            return View();
        }

        public IActionResult HaftalikOzet()
        {
            var ozetler = new List<HaftaOzeti>()
            {
                new HaftaOzeti(
                    1,
                    "ASP.NET Core'a Başlangıç",
                    "Uygulamanın iskeletini kuran minimal Program.cs dosyası ve temel endpoint tanımı.",
                    new []
                    {
                        "WebApplication builder ile servis kaydı",
                        "Basit MapGet kullanımı"
                    },
                    "WebHafta01/WebHafta01/WebHafta01.Web"
                ),
                new HaftaOzeti(
                    2,
                    "Controller ve View ile Çalışmak",
                    "Controller üzerinden View'e model gönderme ve statik listelerle veri hazırlama.",
                    new []
                    {
                        "Controller'dan View'e ilkel tip gönderimi",
                        "Model koleksiyonları ile listeleme"
                    },
                    "WebHafta02/WebHafta02/WebHafta02.Web"
                ),
                new HaftaOzeti(
                    3,
                    "Action Result Türleri",
                    "Farklı IActionResult çeşitlerini (View, Partial, Json, Content, Empty) kullanma.",
                    new []
                    {
                        "NonAction ile yardımcı metot yazımı",
                        "İhtiyaca göre farklı sonuç tipleri döndürme"
                    },
                    "WebHafta03/WebHafta03/WebHafta03.Web"
                ),
                new HaftaOzeti(
                    4,
                    "ViewBag, ViewData ve TempData",
                    "Farklı veri aktarım mekanizmaları ile kullanıcı bilgileri yönetimi.",
                    new []
                    {
                        "ViewBag/ViewData ile geçici veri paylaşımı",
                        "TempData kullanarak yönlendirme senaryoları"
                    },
                    "WebHafta04/WebHafta04/WebHafta04.Web"
                ),
                new HaftaOzeti(
                    5,
                    "HTML Helper Geliştirme",
                    "Özel HTML helper ve form işlemleriyle kullanıcıdan veri alma.",
                    new []
                    {
                        "Uzantı metotlarla helper yazımı",
                        "Form gönderimleri için HttpGet/HttpPost aksiyonları"
                    },
                    "WebHafta05/WebHafta05/WebHafta05.Web"
                ),
                new HaftaOzeti(
                    6,
                    "CRUD İşlemleri",
                    "In-memory koleksiyon üzerinde temel ürün yönetim senaryosu.",
                    new []
                    {
                        "Listeleme, ekleme, güncelleme, silme",
                        "Model binding ile form verisi işleme"
                    },
                    "WebHafta06/WebHafta06/Hafta06.Web"
                ),
                new HaftaOzeti(
                    7,
                    "HTTP İstek Verileri",
                    "Query string, route ve header verilerini inceleme ve tuple model binding.",
                    new []
                    {
                        "Request üzerinden QueryString ve Headers okuma",
                        "Tuple binding ile çoklu model kabulü"
                    },
                    "WebHafta07/WebHafta07/WebHafta07.Web"
                )
            };

            var siraliOzetler = ozetler
                .OrderBy(o => o.HaftaNo)
                .ToList();

            return View(siraliOzetler);
        }
    }
}
