using Hafta06.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hafta06.Web.Controllers
{
    public class AnaController : Controller
    {

        static List<UrunViewModel> _UrunListe = new List<UrunViewModel>()
        {
            new UrunViewModel(1,"29' Monitör",49999.99),
            new UrunViewModel(2,"16gb RAM",24999.99),
            new UrunViewModel(3,"i9-13900h İşlemci",69999.99),
            new UrunViewModel(4,"Kablosuz Klavye",19999.99),
            new UrunViewModel(5,"Kablosuz Mouse",9999.99)
        };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listele()
        {
            return View(_UrunListe);
        }

        public IActionResult Ekle()
        {
            UrunViewModel urun = new UrunViewModel();
            return View(urun);
        }

        [HttpPost]
        public IActionResult Ekle(UrunViewModel urun)
        {
            _UrunListe.Add(urun);
            return View(urun);
        }

        public IActionResult Duzenle(int id)
        {
            UrunViewModel? duzenlenecekUrun = _UrunListe.FirstOrDefault(urun => urun.UrunId == id);
            return View(duzenlenecekUrun);
        }

        [HttpPost]
        public IActionResult Duzenle(UrunViewModel urun)
        {
            UrunViewModel duzenlenenUrun = _UrunListe.FirstOrDefault(a => a.UrunId == urun.UrunId);
            duzenlenenUrun.UrunId = urun.UrunId;
            duzenlenenUrun.UrunAdi= urun.UrunAdi;
            duzenlenenUrun.UrunFiyat= urun.UrunFiyat;

            return View(duzenlenenUrun);
        }



        public IActionResult Sil(int id)
        {
            UrunViewModel silinecek = _UrunListe.FirstOrDefault(a=>a.UrunId ==id);
            _UrunListe.Remove(silinecek);
            return RedirectToAction("Listele"); ;
        }
    }
}
