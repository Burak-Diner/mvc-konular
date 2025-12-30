using Microsoft.AspNetCore.Mvc;

namespace Web1Hafta12.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
