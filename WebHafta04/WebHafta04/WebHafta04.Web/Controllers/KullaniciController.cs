using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebHafta04.Web.Models;

namespace WebHafta04.Web.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Index()
        {
            Kullanici k = new Kullanici()
            {
                KullaniciId = 1,
                KullaniciAdi = "BANUYM",
                KullaniciEmail = "ym@bandirma.edu.tr",
                KullaniciSifre = "123456"
            };


            return View(k);
        }

        public IActionResult ViewBagKullanici()
        {
            Kullanici k = new Kullanici()
            {
                KullaniciId = 2,
                KullaniciAdi = "BANUMF",
                KullaniciEmail = "muh@bandirma.edu.tr",
                KullaniciSifre = "789456"
            };
            ViewBag.Kullanici = k;
            return View();
        }

        public IActionResult ViewDataKullanici()
        {
            Kullanici k = new Kullanici()
            {
                KullaniciId = 3,
                KullaniciAdi = "BANU",
                KullaniciEmail = "info@bandirma.edu.tr",
                KullaniciSifre = "456183"
            };

            ViewData["kul"] = k;

            return View();

        }


        public IActionResult TempDataKullanici()
        {
            Kullanici k = new Kullanici()
            {
                KullaniciId = 4,
                KullaniciAdi = "Bandırma",
                KullaniciEmail = "bnd@bandirma.edu.tr",
                KullaniciSifre = "854123"
            };

            TempData["kul"] = k;

            return View();
        }


        public IActionResult Listele()
        {
            List<Kullanici> liste = new List<Kullanici>()
            {
                new Kullanici(1, "BANUYM", "ym@bandirma.edu.tr","123456"),
                new Kullanici(2, "BANUMF", "mf@bandirma.edu.tr","465453245"),
                new Kullanici(3, "BANU", "info@bandirma.edu.tr","87987"),
                new Kullanici(4, "Bandırma", "bnd@bandirma.edu.tr","0425567"),
            };

            string jsonListe = JsonSerializer.Serialize(liste);

            ViewBag.KulListe = liste;
            ViewData["KulListe"] = liste;
            TempData["KulListe"] = jsonListe;

            return View(liste);
        }

    
    }
}
