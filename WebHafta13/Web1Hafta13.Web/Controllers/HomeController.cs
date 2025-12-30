using Microsoft.AspNetCore.Mvc;
using Web1Hafta13.Web.DependencyInjection;
using Web1Hafta13.Web.Models;
using Web1Hafta13.Web.Services;

namespace Web1Hafta13.Web.Controllers
{
    public class HomeController : Controller
    {
        ILog log;
        public HomeController(ILog log)
        {

            this.log = log;

        }
        public IActionResult Index()
        {
            //MernisService srv = new MernisService();

            //KisiModel kisi = new KisiModel(srv, "12345678923");
            //kisi.KisiBilgileriniYukle();
            //return View(kisi);

            //ITopluTasima tt1 = new Metro();
            //ITopluTasima tt2 = new Otobus();
            //ITopluTasima tt3 = new Metrobus();

            //Kisi k = new Kisi(tt1);

            log.LogYaz();


            return View();
        }

        public IActionResult Detay()
        {
            log.LogYaz();
            return View();
        }
    }
}
