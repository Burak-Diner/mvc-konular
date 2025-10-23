using Microsoft.AspNetCore.Mvc;

namespace WebHafta02.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int a = 5;
            int b = 15;
            int sonuc = a * b;
            return View(sonuc);
        }

        public IActionResult BanuYm()
        {
            return View();
        }
    }
}
