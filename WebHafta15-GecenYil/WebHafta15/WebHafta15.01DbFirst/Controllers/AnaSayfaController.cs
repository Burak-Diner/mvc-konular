using Microsoft.AspNetCore.Mvc;
using WebHafta15._01DbFirst.Data;
using WebHafta15._01DbFirst.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebHafta15._01DbFirst.Controllers
{
    public class AnaSayfaController : Controller
    {
        EticaretDbContext db;
        public AnaSayfaController()
        {
            db = new EticaretDbContext();
        }
        public IActionResult Index()
        {
           
            var urunListesi = db.Uruns.Include(a=>a.Kat).ToList();
            return View(urunListesi);
        }

        public IActionResult Ekle()
        {
            
            Urun urun = new Urun();
            ViewBag.UrunKategorileri = db.Kategoris.ToList();

            return View(urun);
        }

        [HttpPost]
        public IActionResult Ekle(Urun model)
        {
            db.Uruns.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");   
        }
    }
}
