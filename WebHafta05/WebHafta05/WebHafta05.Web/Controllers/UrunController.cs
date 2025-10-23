using Microsoft.AspNetCore.Mvc;
using WebHafta05.Web.Models;

namespace WebHafta05.Web.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index()
        {
            List<UrunViewModel> liste = new List<UrunViewModel>()
            {
                new UrunViewModel(1,"kalem","kurşun kalem",50.5),
                new UrunViewModel(2,"defter","80 yaprak",100.5),
                new UrunViewModel(3,"silgi","yumuşak",30.5),
                new UrunViewModel(4,"kalemtraş","lapalı kutu",20.5),
            };
            return View(liste);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            UrunViewModel bosmodel = new UrunViewModel();
            return View(bosmodel);
        }

        [HttpPost]
        public IActionResult Ekle(int id, string adi, string aciklama)
        {
            return View();
        }
    }
}
