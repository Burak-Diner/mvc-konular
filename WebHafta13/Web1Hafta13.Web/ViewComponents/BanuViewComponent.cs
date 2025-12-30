using Microsoft.AspNetCore.Mvc;
using Web1Hafta13.Web.Models;

namespace Web1Hafta13.Web.ViewComponents
{
    public class BanuViewComponent : ViewComponent
    {
        ILog log;
        public BanuViewComponent(ILog log)
        {
            this.log = log;
        }
        public IViewComponentResult Invoke()
        {
            log.LogYaz();
            return View();
        }
    }
}
