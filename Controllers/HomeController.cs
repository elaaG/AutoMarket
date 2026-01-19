using Microsoft.AspNetCore.Mvc;

namespace AutoMarket.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
