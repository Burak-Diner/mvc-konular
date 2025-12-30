using Microsoft.AspNetCore.Mvc;
using Web1Hafta13.Web.Models;

namespace Web1Hafta13.Web.Controllers
{
    public class Kisi : Controller
    {
        public ILog log { get; set; }
        public Kisi(ILog log)
        {
            this.log = log;
        }
        public IActionResult Index()
        {
            log.LogYaz();
            return View();
        }
    }
}
