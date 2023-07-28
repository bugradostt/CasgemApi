using CasgemApiConsume.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace CasgemApiConsume.Controllers
{
    public class LoginController : Controller
    {
        readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
		public IActionResult Index(ResultUserDto p)
		{
			return View();
		}
	}
}
