using Microsoft.AspNetCore.Mvc;

namespace Casgem.ApıLayer.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
