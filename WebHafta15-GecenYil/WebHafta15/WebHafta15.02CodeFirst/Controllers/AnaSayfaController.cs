using Microsoft.AspNetCore.Mvc;
using WebHafta15._02CodeFirst.Data;
using Microsoft.EntityFrameworkCore;

namespace WebHafta15._02CodeFirst.Controllers
{
    public class AnaSayfaController : Controller
    {
        public IActionResult Index()
        {
            SirketDbContext db = new SirketDbContext();
            var liste = db.Kisis.Include(a=>a.KisiDepartmani).ToList();
            return View();
        }
    }
}
