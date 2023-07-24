using Microsoft.AspNetCore.Mvc;

namespace CasgemApiConsume.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
