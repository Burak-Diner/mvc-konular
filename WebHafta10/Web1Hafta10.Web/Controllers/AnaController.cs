using Microsoft.AspNetCore.Mvc;
using Web1Hafta10.Web.Models;

namespace Web1Hafta10.Web.Controllers
{
	public class AnaController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Ekle()
		{
			Urun urun = new Urun();
			return View(urun);
		}

		[HttpPost]
		public IActionResult Ekle(Urun u)
		{
			return View();
		}

		public IActionResult Hakkimizda()
		{
			return View();
		}

		public IActionResult Personel()
		{
			return View();
		}
		public IActionResult Blog()
		{
			return View();
		}

		public IActionResult Iletisim()
		{
			return View();
		}
	}
}
