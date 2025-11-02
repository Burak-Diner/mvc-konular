using Microsoft.AspNetCore.Mvc;

namespace WebHafta03.Web.Controllers
{
/*     [NonController] */
    public class AnaSayfaController : Controller
    {
        public IActionResult Index()
        {
            int sonuc = Topla(2, 3);
            return View(sonuc);
        }

   /*      [NonAction] */
        public int Topla(int s1, int s2)
        {
            return s1 + s2;
        }
    }
}
