using Microsoft.AspNetCore.Mvc;
using Ornek.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ornek.Web.Controllers
{
    public class HaftalarController : Controller
    {
        private static readonly List<UrunViewModel> _urunler = new()
        {
            new UrunViewModel { UrunId = 1, UrunAdi = "29' Monitör", Aciklama = "Geniş ekran", UrunFiyat = 49999.99 },
            new UrunViewModel { UrunId = 2, UrunAdi = "16 GB RAM", Aciklama = "DDR5", UrunFiyat = 24999.99 },
            new UrunViewModel { UrunId = 3, UrunAdi = "Kablosuz Klavye", Aciklama = "Aydınlatmalı", UrunFiyat = 8999.99 }
        };

        public IActionResult Index()
        {
            var ozetler = new List<HaftaOzetModel>
            {
                new(1,
                    "ASP.NET Core'a giriş",
                    "Program.cs dosyası ve temel routing akışı",
                    new [] { "WebApplication builder", "MapGet ile ilk endpoint" },
                    Url.Action(nameof(Hafta1)) ?? string.Empty),
                new(2,
                    "Controller & View etkileşimi",
                    "Controller'dan View'e model gönderimi",
                    new [] { "ViewResult kullanımı", "Listelerle model oluşturma" },
                    Url.Action(nameof(Hafta2)) ?? string.Empty),
                new(3,
                    "Action result türleri",
                    "View, Partial, Json, Content ve EmptyResult örnekleri",
                    new [] { "İhtiyaca göre IActionResult seçimi" },
                    Url.Action(nameof(Hafta3)) ?? string.Empty),
                new(4,
                    "Veri paylaşım mekanizmaları",
                    "ViewBag, ViewData ve TempData ile kullanıcı bilgisi taşıma",
                    new [] { "Dinamik ViewBag", "Sözlük tabanlı ViewData", "Yönlendirmede TempData" },
                    Url.Action(nameof(Hafta4)) ?? string.Empty),
                new(5,
                    "Formlar ve HTML helper",
                    "Özel HTML helper ile form oluşturma",
                    new [] { "Uzantı metoduyla helper", "Model binding ile form post" },
                    Url.Action(nameof(Hafta5)) ?? string.Empty),
                new(6,
                    "CRUD akışı",
                    "Bellekte ürün yönetimi",
                    new [] { "Listeleme", "Ekleme", "Güncelleme", "Silme" },
                    Url.Action(nameof(Hafta6Liste)) ?? string.Empty),
                new(7,
                    "HTTP istek verileri",
                    "Query string ve header bilgilerini inceleme",
                    new [] { "Request.Query", "Request.Headers" },
                    Url.Action(nameof(Hafta7)) ?? string.Empty)
            };

            return View(ozetler.OrderBy(o => o.HaftaNo).ToList());
        }

        public IActionResult Hafta1()
        {
            return View();
        }

        public IActionResult Hafta2()
        {
            const int sayi1 = 5;
            const int sayi2 = 15;
            ViewBag.Sayi1 = sayi1;
            ViewBag.Sayi2 = sayi2;
            return View(sayi1 * sayi2);
        }

        public IActionResult Hafta3()
        {
            return View();
        }

        public IActionResult Hafta3Sonuc(int id)
        {
            switch (id)
            {
                case 1:
                    ViewBag.SonucTuru = "ViewResult";
                    return View("Hafta3Sonuc", "Tam ViewResult örneği");
                case 2:
                    return PartialView("_Hafta3Partial", "PartialViewResult örneği");
                case 3:
                    return Json(new { mesaj = "JsonResult örneği", tarih = DateTime.UtcNow });
                case 4:
                    return Content("ContentResult örneği");
                case 5:
                    return new EmptyResult();
                default:
                    TempData["Hafta3Uyari"] = "Geçersiz seçim yaptınız.";
                    return RedirectToAction(nameof(Hafta3));
            }
        }

        public IActionResult Hafta4()
        {
            var model = new KullaniciViewModel
            {
                KullaniciId = 1,
                Ad = "BANÜ Yazılım",
                Eposta = "yazilim@bandirma.edu.tr",
                Sifre = "123456"
            };

            ViewBag.Bilgi = "ViewBag ile taşınan başlık";
            ViewData["Aciklama"] = "ViewData ile gelen açıklama";
            TempData["Bildirim"] = "TempData yönlendirmeler arasında da yaşar";

            return View(model);
        }

        public IActionResult Hafta5()
        {
            return View(new UrunViewModel());
        }

        [HttpPost]
        public IActionResult Hafta5(UrunViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.Mesaj = $"{model.UrunAdi} ürünü başarıyla alındı.";
            return View(model);
        }

        public IActionResult Hafta6Liste()
        {
            return View(_urunler.OrderBy(u => u.UrunId));
        }

        public IActionResult Hafta6Ekle()
        {
            return View(new UrunViewModel());
        }

        [HttpPost]
        public IActionResult Hafta6Ekle(UrunViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.UrunId = _urunler.Any() ? _urunler.Max(u => u.UrunId) + 1 : 1;
            _urunler.Add(model);
            TempData["Hafta6Mesaj"] = $"{model.UrunAdi} listesine eklendi.";
            return RedirectToAction(nameof(Hafta6Liste));
        }

        public IActionResult Hafta6Duzenle(int id)
        {
            var urun = _urunler.FirstOrDefault(u => u.UrunId == id);
            if (urun is null)
            {
                return NotFound();
            }

            return View(new UrunViewModel
            {
                UrunId = urun.UrunId,
                UrunAdi = urun.UrunAdi,
                Aciklama = urun.Aciklama,
                UrunFiyat = urun.UrunFiyat
            });
        }

        [HttpPost]
        public IActionResult Hafta6Duzenle(UrunViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var urun = _urunler.FirstOrDefault(u => u.UrunId == model.UrunId);
            if (urun is null)
            {
                return NotFound();
            }

            urun.UrunAdi = model.UrunAdi;
            urun.Aciklama = model.Aciklama;
            urun.UrunFiyat = model.UrunFiyat;

            TempData["Hafta6Mesaj"] = $"{model.UrunAdi} güncellendi.";
            return RedirectToAction(nameof(Hafta6Liste));
        }

        public IActionResult Hafta6Sil(int id)
        {
            var urun = _urunler.FirstOrDefault(u => u.UrunId == id);
            if (urun is not null)
            {
                _urunler.Remove(urun);
                TempData["Hafta6Mesaj"] = $"{urun.UrunAdi} silindi.";
            }

            return RedirectToAction(nameof(Hafta6Liste));
        }

        public IActionResult Hafta7()
        {
            var model = new RequestInfoModel
            {
                Path = Request.Path,
                Query = Request.Query.ToDictionary(k => k.Key, v => (string?)v.Value),
                Headers = Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString())
            };

            return View(model);
        }

        public IActionResult Hata()
        {
            return View();
        }
    }
}
