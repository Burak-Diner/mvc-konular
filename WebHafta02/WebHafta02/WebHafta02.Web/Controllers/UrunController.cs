using Microsoft.AspNetCore.Mvc;
using WebHafta02.Web.Models;

namespace WebHafta02.Web.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Listele()
        {
            List<Urun> urunListe = new List<Urun>()
            {
                new Urun(1,"Kalem", 100.0),
                new Urun(2, "29' Monitör", 25000.0),
                new Urun(3, "2 tb m2 ssd", 7000.0)
            };
            return View(urunListe);
        }
    }
}
