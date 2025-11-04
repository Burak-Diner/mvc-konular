using Microsoft.AspNetCore.Mvc;
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
    }
}
