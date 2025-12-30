using Microsoft.AspNetCore.Mvc;
using Web1Hafta11.Web.Models;

namespace Web1Hafta11.Web.Components
{
	public class KullaniciViewComponent : ViewComponent
	{
		public IViewComponentResult InvokeAsync()
		{
			List<Kullanici> liste = new List<Kullanici>()
			{
				new Kullanici(){ KullaniciId=1, KullaniciAdi="Banu", KullaniciSoyadi="ym", KullaniciEmail="ym@bandirma.edu.tr" }
			};
			return View(liste);
		}
	}
}
