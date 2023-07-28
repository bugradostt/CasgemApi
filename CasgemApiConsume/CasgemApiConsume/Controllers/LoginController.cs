using CasgemApiConsume.Dtos.LoginDtos;
using CasgemApiConsume.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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

  //      [HttpPost]
		//public async Task<IActionResult> Index(ResultUserDto p)
		//{
		//	var client = _httpClientFactory.CreateClient();
		//	var jsonData = JsonConvert.SerializeObject(p);
		//	StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
		//	var responseMessage = await client.PostAsync("https://localhost:44332/api/User", stringContent);
		//	if (responseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest)
		//	{
		//		return View();

		//	}
		//	else
		//	{
		//		return RedirectToAction("Index");
		//	}

		//	return View();
		//}

		[HttpPost]
		public async Task<IActionResult> Index(LoginDto p)
		{
			var client = _httpClientFactory.CreateClient();

			var jsonData = JsonConvert.SerializeObject(p);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("https://localhost:44332/api/Login", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				HttpContext.Session.SetString("UserName", p.UserName);

				
				return RedirectToAction("Index","Home");
			}
			else
			{
				return View();
			}
		}

	}
}
