using Microsoft.AspNetCore.Mvc;
using WebHafta09.Web.Models;

namespace WebHafta09.Web.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ekle()
        {
            ViewBag.Message = "";
            Kullanici k = new Kullanici();
            return View(k);
        }

        [HttpPost]
        public IActionResult Ekle(Kullanici model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Kullanici eklendi.";
            }
            else
            {
                ViewBag.Message = "Kullanici eklenirken hata oluştu.";

            }
            return View(model);
        }
    }
}
