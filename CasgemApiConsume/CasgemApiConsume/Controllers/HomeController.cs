using Microsoft.AspNetCore.Mvc;

namespace CasgemApiConsume.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
