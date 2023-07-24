using CasgemApiConsume.Dtos.IlanlarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CasgemApiConsume.Controllers
{
    public class IlanlarController : Controller
    {
        readonly IHttpClientFactory _httpClientFactory;

        public IlanlarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> ListIlan()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44332/api/UserIlan");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultIlanlarDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
