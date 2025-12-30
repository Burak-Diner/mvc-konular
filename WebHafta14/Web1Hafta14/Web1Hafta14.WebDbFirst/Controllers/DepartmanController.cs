using Microsoft.AspNetCore.Mvc;
using Web1Hafta14.WebDbFirst.DbContext;
using Web1Hafta14.WebDbFirst.Models;

namespace Web1Hafta14.WebDbFirst.Controllers
{
    public class DepartmanController : Controller
    {
        FinalSirketDbContext _db;
        public DepartmanController(FinalSirketDbContext db)
        {
            this._db = db;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Ekle()
        {
            TbDepartman dep = new TbDepartman();
            dep.DepartmanAdi = "Bilgisayar Mühendisliği";

            _db.TbDepartmen.Add(dep);
            _db.SaveChanges();

            return View();
        }
    }
}
