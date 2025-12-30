using Microsoft.AspNetCore.Mvc;

namespace Web1Hafta14.WebDbFirst.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
