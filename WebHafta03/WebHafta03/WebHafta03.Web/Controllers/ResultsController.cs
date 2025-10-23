using Microsoft.AspNetCore.Mvc;
using WebHafta03.Web.Models;

namespace WebHafta03.Web.Controllers
{
    public class ResultsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult ViewResultSayfa()
        {
            return View();
        }

        public PartialViewResult PartialViewResultSayfa()
        {
            return PartialView();
        }

        public JsonResult JsonResultSayfa()
        {
            Urun u = new Urun()
            {
                Id = 1,
                UrunAdi = "Monitör",
                UrunFiyati = 19999.99
            };
            return Json(u);
        }

        public ContentResult ContentResultSayfa()
        {
            return Content("<h2>BANÜ YM</h2>");
        }

        public EmptyResult EmptyResultSayfa()
        {

            return new EmptyResult();
        }

        public ViewComponentResult ViewComponentSayfa()
        {

            return ViewComponent("");
        }

        public IActionResult SecimliResult(int id)
        {
            switch (id)
            {
                case 1:
                    return View();
                case 2:
                    return PartialView();
                case 3:
                    return Json("{id:5}");
                case 4:
                    return Content("BANÜ YM");
                case 5:
                    return new EmptyResult();
                case 6:
                    return ViewComponent("");
                default:
                    return View();

            }

        }
    }
}
