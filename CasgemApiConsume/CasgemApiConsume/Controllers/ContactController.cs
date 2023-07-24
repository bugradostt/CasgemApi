using Microsoft.AspNetCore.Mvc;

namespace CasgemApiConsume.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
