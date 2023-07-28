using CasgemApiConsume.Dtos.IlanlarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CasgemApiConsume.Controllers
{
    public class HomeController : Controller
    {
        readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44332/api/UserIlan/ListIlan");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultIlanlarDto>>(jsonData);
                return View(values.Take(6).ToList());
            }
            return View();
        }
    }
}
