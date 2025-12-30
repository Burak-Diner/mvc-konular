using Microsoft.AspNetCore.Mvc;
using Web1Hafta14.WebDbFirst.DbContext;
using Web1Hafta14.WebDbFirst.Models;

namespace Web1Hafta14.WebDbFirst.Controllers
{
    public class KisiController : Controller
    {
        FinalSirketDbContext _db;

        public KisiController(FinalSirketDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ekle()
        {
            TbKisi kisi = new TbKisi()
            {
                Adi = "Süleyman Gökhan",
                Soyadi = "TAŞKIN",
                DepartmanId = 1
            };

            _db.TbKisis.Add(kisi);
            _db.SaveChanges();
            return View(kisi);
        }

        [HttpPost]
        public IActionResult Ekle(TbKisi kisi)
        {
            _db.TbKisis.Add(kisi);
            _db.SaveChanges();
            return View(kisi);
        }

        public IActionResult Duzenle(int id)
        {
            TbKisi kisi = _db.TbKisis.FirstOrDefault(a => a.KisiId == id);
            kisi.Soyadi = "Taşkın";
            _db.SaveChanges();
            return View();
        }

        public IActionResult Sil(int id)
        {
            TbKisi kisi = _db.TbKisis.FirstOrDefault(a => a.KisiId == id);
            _db.TbKisis.Remove(kisi);
            _db.SaveChanges();
            return View();
        }
    }
}
