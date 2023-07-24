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


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string _id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44332/api/Category/{_id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ListIlann");

            }
            return View();
        }

    }
}
