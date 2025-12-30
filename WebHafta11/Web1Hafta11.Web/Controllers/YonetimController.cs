using Microsoft.AspNetCore.Mvc;

namespace Web1Hafta11.Web.Controllers
{
	[Route("BANU-Yonetim")]
	public class YonetimController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
